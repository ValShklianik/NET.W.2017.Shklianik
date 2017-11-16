using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Account
{
    [Serializable]
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
            AccountNumber = accountNumber;
            Name = name;
            Balance = 0;

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
            if (amount < 0 && amount > balance)
            {
                throw new ArgumentException(nameof(amount));
            }

            Balance -= amount;
            benefitPoints -= CalculateBanefitPoints(amount);
        }

        protected abstract bool IsValidBalance(decimal value);

        protected abstract int CalculateBanefitPoints(decimal amount);

        public override string ToString()
        {
            return $"{name}, {balance}, {benefitPoints}";
        }
    }
}
