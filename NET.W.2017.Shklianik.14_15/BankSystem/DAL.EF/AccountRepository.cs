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
                        db.Accounts.Add(dbAccount);
                        UpdateAccount(db, dbAccount, account, accountOwner, accountType);

                        var operationType = GetOrCreateOperationType(db, "Create");

                        CreateOperation(operationType, account.Balance, dbAccount, db);

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

        public DalAccountDetailed GetAccountHistory(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException($"{nameof(number)} is invalid.", nameof(number));
            }
            using (var db = new AccountContext())
            {
                Account account = db.Accounts.FirstOrDefault(acc => acc.AccountNumber == number);
                if (ReferenceEquals(account, null)) throw new RepositoryException($"Can not find account with account number {number}");

                return new DalAccountDetailed
                {
                    AccountObject = Serialize(account),
                    Operations = db.AccountOperations.Where(op => op.ChangedAccountId == account.Id).Select(op => new DalAccountOperation {
                        Id = op.Id,
                        AccountId = account.Id,
                        Operation = op.AccountOperationType.Type,
                        OperationValue = op.OperationValue,
                        OperationDate = op.OperationDate
                    }).ToList()
                };
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
                    var dbAccount = db.Accounts.FirstOrDefault(acc => acc.Active == true && acc.AccountNumber == account.AccountNumber);
                    if (ReferenceEquals(dbAccount, null)) throw new RepositoryException($"Can not find open account with account number {account.AccountNumber}");
                    try
                    {
                        var accountOwner = GetOrCreateOwner(db, account);
                        var accountType = GetOrCreateType(db, account);
                        decimal diff = account.Balance - dbAccount.CurrentSum;
                        string operation = diff > 0 ? "Deposit" : "Withdraw";
                        var operationType = GetOrCreateOperationType(db, operation);

                        CreateOperation(operationType, diff, dbAccount, db);
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

        public DalAccount GetAccount(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException($"{nameof(number)} is invalid.", nameof(number));
            }
            using (var db = new AccountContext())
            {
                Account account = db.Accounts.FirstOrDefault(acc => acc.AccountNumber == number);

                return Serialize(account);
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
                    var dbAccount = db.Accounts.FirstOrDefault(acc => acc.Active == true && acc.AccountNumber == account.AccountNumber);
                    if (ReferenceEquals(dbAccount, null)) throw new RepositoryException($"Can not find open account with account number {account.AccountNumber}");
                    try
                    {
                        dbAccount.Active = false;
                        var operationType = GetOrCreateOperationType(db, "Close");

                        CreateOperation(operationType, 0, dbAccount, db);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new RepositoryException("Remove account error.", e);
                    }
                }
            }
        }

        private AccountOperation CreateOperation(OperationType operationType, decimal value, Account account, AccountContext db)
        {
            var operation = new AccountOperation
            {
                ChangedAccount = account,
                AccountOperationType = operationType,
                OperationValue = value
            };

            db.AccountOperations.Add(operation);
            db.SaveChanges();

            return operation;
        }

        public IEnumerable<DalAccount> GetAccounts(string ownerEmail)
        {
            if (string.IsNullOrWhiteSpace(ownerEmail))
            {
                throw new ArgumentException($"{nameof(ownerEmail)} is invalid.", nameof(ownerEmail));
            }
            using (var db = new AccountContext())
            {
                return db.Accounts.Where(a => a.AccountOwner.Email == ownerEmail).AsEnumerable().Select(Serialize).ToList();
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
                OwnerEmail = account.AccountOwner.Email,
                Open = account.Active
            };
        }

        private void UpdateAccount(AccountContext db, Account dbAccount, DalAccount account, Owner accountOwner, AccountType accountType)
        {
            dbAccount.AccountType = accountType;
            dbAccount.AccountOwnerId = accountOwner.Id;
            dbAccount.CurrentSum = account.Balance;
            dbAccount.BonusPoints = account.BenefitPoints;
            dbAccount.AccountNumber = account.AccountNumber;
            db.SaveChanges();
        }

        private Owner GetOrCreateOwner(AccountContext db, DalAccount account)
        {
            Owner owner = db.Owners.FirstOrDefault(dbAccount => dbAccount.Email == account.OwnerEmail);

            if (!ReferenceEquals(owner, null)) return owner;
            owner = new Owner
            {
                Email = account.OwnerEmail
            };
            db.Owners.Add(owner);
            db.SaveChanges();

            return owner;
        }

        private AccountType GetOrCreateType(AccountContext db, DalAccount account)
        {
            AccountType accountType = db.AccountTypes.FirstOrDefault(at =>at.Type == account.AccountType);

            if (!ReferenceEquals(accountType, null)) return accountType;
            accountType = new AccountType
            {
                Type = account.AccountType,
            };
            db.AccountTypes.Add(accountType);
            db.SaveChanges();

            return accountType;
        }

        private OperationType GetOrCreateOperationType(AccountContext db, string opType)
        {
            var operationType = db.OperationTypes.FirstOrDefault(ot => ot.Type == opType);

            if (ReferenceEquals(operationType, null))
            {
                operationType = new OperationType
                {
                    Type = opType
                };
                db.OperationTypes.Add(operationType);

                db.SaveChanges();
            }

            return operationType;
        }
    }
}
