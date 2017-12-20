using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Models;
using DAL.Interface;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.EF
{
    public class AccountRepository : IAccountRepository
    {
        public void AddAccount(DalAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            using (var db = new AccountContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var accountOwner = GetOrCreateOwner(db, account);
                        var accountType = GetOrCreateType(db, account);

                        var dbAccount = new Account();
                        UpdateAccount(db, dbAccount, account, accountOwner, accountType);

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new RepositoryException("Add account error.", e);
                    }
                }
            }
        }

        public DalAccount GetAccount(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException($"{nameof(number)} is invalid.", nameof(number));
            }
            using (var db = new AccountContext())
            {
                Account account = db.Accounts.Find(number);

                return Serialize(account);
            }

        }

        public void UpdateAccount(DalAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            using (var db = new AccountContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var dbAccount = db.Accounts.Find(account.Id);
                        var accountOwner = GetOrCreateOwner(db, account);
                        var accountType = GetOrCreateType(db, account);
                        UpdateAccount(db, dbAccount, account, accountOwner, accountType);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new RepositoryException("Update account error.", e);
                    }
                }
            }
        }

        public void RemoveAccount(DalAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            using (var db = new AccountContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var dbAccount = db.Accounts.Find(account.Id);
                        if (!ReferenceEquals(dbAccount, null)) db.Accounts.Remove(dbAccount);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new RepositoryException("Update account error.", e);
                    }
                }
            }
        }

        public IEnumerable<DalAccount> GetAccounts(Predicate<DalAccount> predicate)
        {
            if (ReferenceEquals(predicate, null))
            {
                throw new ArgumentException($"{nameof(predicate)} is invalid.", nameof(predicate));
            }
            using (var db = new AccountContext())
            {
                return db.Accounts.Select(acc => Serialize(acc)).Where(a => predicate(a));
            }
        }

        private DalAccount Serialize(Account account)
        {
            return new DalAccount
            {
                AccountType = account.AccountType.Type,
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                Balance = account.CurrentSum,
                BenefitPoints = account.BonusPoints,
                OwnerFirstName = account.AccountOwner.FirstName,
                OwnerSecondName = account.AccountOwner.SecondName,
                OwnerEmail = account.AccountOwner.Email,
            };
        }

        private void UpdateAccount(AccountContext db, Account dbAccount, DalAccount account, Owner accountOwner, AccountType accountType)
        {
            dbAccount.AccountType = accountType;
            dbAccount.AccountOwner = accountOwner;
            dbAccount.CurrentSum = account.Balance;
            dbAccount.BonusPoints = account.BenefitPoints;
            dbAccount.AccountNumber = account.AccountNumber;
            db.SaveChanges();
        }

        private Owner GetOrCreateOwner(AccountContext db, DalAccount account)
        {
            Owner owner = db.Owners.Find(account.OwnerEmail, account.OwnerFirstName, account.OwnerSecondName);

            if (!ReferenceEquals(owner, null)) return owner;
            owner = new Owner
            {
                Email = account.OwnerEmail,
                FirstName = account.OwnerFirstName,
                SecondName = account.OwnerSecondName
            };
            db.Owners.Add(owner);
            db.SaveChanges();

            return owner;
        }

        private AccountType GetOrCreateType(AccountContext db, DalAccount account)
        {
            AccountType accountType = db.AccountTypes.Find(account.AccountType);

            if (!ReferenceEquals(accountType, null)) return accountType;
            accountType = new AccountType
            {
                Type = account.AccountType,
            };
            db.AccountTypes.Add(accountType);
            db.SaveChanges();

            return accountType;
        }
    }
}
