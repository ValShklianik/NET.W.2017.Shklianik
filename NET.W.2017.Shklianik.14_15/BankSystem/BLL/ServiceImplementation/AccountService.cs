using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Account;
using BLL.Interface.AccountIdCreatorService;
using BLL.Interface.AccountService;
using DAL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
 
        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public string OpenAccount(string name, AccountType accountType, IAccountNumberCreator creator)
        {
            Account account;
            string accountNumber = creator.Create();

            switch (accountType)
            {
                case AccountType.Base:
                    account = new BaseAccount(accountNumber);
                    break;

                case AccountType.Gold:
                    account = new GoldAccount(accountNumber);
                    break;

                case AccountType.Platinum:
                    account = new PlatinumAccount(accountNumber);
                    break;
                default:
                    account = new BaseAccount(accountNumber);
                    break;
            }

            repository.AddAccount(EntityConverter.ToDalAccount(account));

            return accountNumber;
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            Account account = GetAccountFromRepository(accountNumber);
            account.Deposit(amount);
            repository.UpdateAccount(EntityConverter.ToDalAccount(account));
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            Account account = GetAccountFromRepository(accountNumber);
            account.Withdraw(amount);
            repository.UpdateAccount(EntityConverter.ToDalAccount(account));
        }

        public void DeleteAccount(string accountNumber)
        {
            Account account = GetAccountFromRepository(accountNumber);
            repository.RemoveAccount(EntityConverter.ToDalAccount(account));
        }

        public Account GetAccountInfo(string accountNumber) => GetAccountFromRepository(accountNumber);

        private Account GetAccountFromRepository(string accountNumber)
        {
            Account account = EntityConverter.FromDalAccount(repository.GetAccount(accountNumber));
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            return account;
        }

        public IEnumerable<Account> GetAccounts(Predicate<Account> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            bool DalPredicte(DalAccount dalAccount) => predicate(EntityConverter.FromDalAccount(dalAccount));
            return repository.GetAccounts(DalPredicte).Select(EntityConverter.FromDalAccount);
        }
    }
}
