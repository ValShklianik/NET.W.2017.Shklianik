using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Program
    {
        public static void Main()
        {
            //	Account account = new BaseAccount();
            //	account.AccountNumber = "NN1233224";
            //	account.Name = "Nastichka";
            //	account.Deposit(120m);
            //	account.Withdraw(120m);
            //	account.Dump();
            //	
            //	Account accountSilv = new SilverAccount();
            //	accountSilv.AccountNumber = "NNNNN1233224";
            //	accountSilv.Name = "Nastichka";
            //	accountSilv.Deposit(120m);
            //	accountSilv.Withdraw(1000m);
            //	accountSilv.Dump();

            //	var guid = new Guid();

            var repo = new FakeRepository();
            AccountService service = new AccountService(repo);
            service.OpenAccount("user", AccountType.Base, new AccountNumberCreator());
            //Console.WriteLine(repo.repository);
            //Console.Read();

        }

        public abstract class Account
        {
            private string accountNumber;
            private string name;
            private decimal balance;
            private int benefitPoints;

            public string AccountNumber
            {
                get => accountNumber;
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        accountNumber = value;
                    }
                    else
                    {
                        throw new ArgumentException(nameof(accountNumber));
                    }
                }
            }

            public string Name
            {
                get => name;
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        name = value;
                    }
                    else
                    {
                        throw new ArgumentException(nameof(name));
                    }
                }
            }

            public decimal Balance
            {
                get => balance;
                private set
                {
                    if (IsValidBalance(value))
                    {
                        balance = value;
                    }
                    else
                    {
                        throw new ArgumentException(nameof(balance));
                    }
                }
            }

            public int BenefitPoints
            {
                get => benefitPoints;
            }

            protected Account(string accountNumber, string name)
            {
                this.AccountNumber = accountNumber;
                this.Name = name;
                this.Balance = 0;

            }

            public void Deposit(decimal amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentException(nameof(amount));
                }
                Balance += amount;
                benefitPoints += CalculateBanefitPoints(amount);
            }

            public void Withdraw(decimal amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentException(nameof(amount));
                }
                Balance -= amount;
                benefitPoints -= CalculateBanefitPoints(amount);
            }

            protected abstract bool IsValidBalance(decimal value);

            protected abstract int CalculateBanefitPoints(decimal amount);
        }


        public class BaseAccount : Account
        {

            public BaseAccount(string accountNumber, string name) : base(accountNumber, name)
            {

            }
            protected override bool IsValidBalance(decimal value) => value >= 0;

            protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.01m + Balance * 0.01m);
        }


        public class SilverAccount : Account
        {
            public SilverAccount(string accountNumber, string name) : base(accountNumber, name)
            {

            }
            protected override bool IsValidBalance(decimal value) => value > -1000;

            protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.03m + Balance * 0.03m);
        }

        public enum AccountType { Base, Silver }

        public interface IAccountNumberCreator
        {
            string Create();
        }

        public class AccountNumberCreator : IAccountNumberCreator
        {
            public string Create() => Guid.NewGuid().ToString();
        }

        public interface IRepository //CRUD
        {
            void Create(Account account);
        }

        public class FakeRepository : IRepository
        {
            public List<Account> repository = new List<Account>();
            public void Create(Account account)
            {
                repository.Add(account);
            }
        }

        public class AccountService
        {
            private IRepository repository;
            public AccountService(IRepository repository)
            {
                this.repository = repository;
            }

            public void OpenAccount(string name, AccountType accountType, IAccountNumberCreator creator)
            {
                //Account account = new BaseAccount("","");
                Account account = null;
                string accountNumber = creator.Create();
                switch (accountType)
                {
                    case AccountType.Base:
                        account = new BaseAccount(accountNumber, name);
                        break;

                    case AccountType.Silver:
                        account = new SilverAccount(accountNumber, name);
                        break;
                }
            }
        }
    }
}
