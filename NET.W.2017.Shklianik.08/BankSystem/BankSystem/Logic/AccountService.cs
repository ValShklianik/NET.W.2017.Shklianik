using System;
using System.Collections.Generic;

namespace BankSystem.Logic
{
    public class AccountService
    {
        private readonly IRepository repository;
        private readonly List<Account> accounts;
        private static AccountService instance;
        
        public enum AccountType { Base, Gold, Platinum }

        private AccountService()
        {
            repository = new FileRepository(@"repository.bin");
            accounts = (List<Account>)repository.Read();

        }

        public static AccountService GetService()
        {
            return instance ?? (instance = new AccountService());
        }

        public string OpenAccount(string name, AccountType accountType, IAccountNumberCreator creator)
        {
            Account account = null;
            string accountNumber = creator.Create();
            Account accountInList = accounts?.Find(a => a.AccountNumber == accountNumber);

            while (accountInList != null)
            {
                accountNumber = creator.Create();
                accountInList = accounts?.Find(a => a.AccountNumber == accountNumber);
            }
            switch (accountType)
            {
                case AccountType.Base:
                    account = new BaseAccount(accountNumber, name);
                    break;

                case AccountType.Gold:
                    account = new GoldAccount(accountNumber, name);
                    break;

                case AccountType.Platinum:
                    account = new PlatinumAccount(accountNumber, name);
                    break;
            }

            if (accounts == null) return accountNumber;
            accounts.Add(account);
            repository.Save(accounts);

            return accountNumber;
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            Account account = accounts?.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentNullException("account with this id is no exist");
            }
            account.Deposit(amount);
            repository.Save(accounts);


        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            Account account = accounts?.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentNullException("account with this id is no exist");
            }
            account.Withdraw(amount);
            repository.Save(accounts);
        }

        public void DeleteAccount(string accountNumber)
        {
            Account account = accounts?.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentNullException("account with this id is no exist");
            }
            accounts.Remove(account);
            repository.Save(accounts);
        }

        public Account GetAccountInfo(string accountNumber)
        {
            Account account = accounts?.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentNullException("account with this id is no exist");
            }
            return accounts?.Find(a => a.AccountNumber == accountNumber);
        }
    }
}
