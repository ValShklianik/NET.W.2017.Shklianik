using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Account
{
    public class AccountService
    {
        private IRepository repository;
        private List<Account> accounts;
        public enum AccountType { Base, Gold, Platinum }

        public AccountService(IRepository repository)
        {
            this.repository = repository;
            accounts = (List<Account>)repository.Read();
        }

        public void OpenAccount(string name, AccountType accountType, IAccountNumberCreator creator)
        {
            Account account = null;
            string accountNumber = creator.Create();
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

            accounts.Add(account);
            repository.Save(accounts);
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            Account account = accounts?.Find(a => a.AccountNumber == accountNumber);
            account.Deposit(amount);
            repository.Save(accounts);


        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            Account account = accounts?.Find(a => a.AccountNumber == accountNumber);
            account.Withdraw(amount);
            repository.Save(accounts);
        }

        public void DeleteAccount(string accountNumber)
        {
            Account account = accounts?.Find(a => a.AccountNumber == accountNumber);
            accounts.Remove(account);
            repository.Save(accounts);
        }

        public class AccountNumberCreator : IAccountNumberCreator
        {
            public string Create() => Guid.NewGuid().ToString();
        }
    }
}
