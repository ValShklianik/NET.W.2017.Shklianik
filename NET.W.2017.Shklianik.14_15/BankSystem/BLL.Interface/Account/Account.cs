using System;

namespace BLL.Interface.Account
{
    public enum AccountType { Base, Gold, Platinum }

    [Serializable]
    public abstract class Account
    {
        private string accountNumber;
        private string name;
        private decimal balance;

        public int BenefitPoints { get; private set; }
        public int Id { get; }

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

        protected Account(string accountNumber, string name)
        {
            AccountNumber = accountNumber;
            Name = name;
            Balance = 0;
            Id = -1;
        }

        protected Account(int id, string accountNumber, string name, decimal balance, int benefitPoints)
        {
            AccountNumber = accountNumber;
            Id = id;
            Name = name;
            Balance = balance;
            BenefitPoints = benefitPoints;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }
            Balance += amount;
            BenefitPoints += CalculateBanefitPoints(amount);
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0 && amount > balance)
            {
                throw new ArgumentException(nameof(amount));
            }

            Balance -= amount;
            BenefitPoints -= CalculateBanefitPoints(amount);
        }

        protected abstract bool IsValidBalance(decimal value);

        protected abstract int CalculateBanefitPoints(decimal amount);

        public override string ToString()
        {
            return $"{name}, {balance}, {BenefitPoints}";
        }
    }
}