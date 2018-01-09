using System;

namespace BLL.Interface.Account
{
    public enum AccountType { Base, Gold, Platinum }

    [Serializable]
    public abstract class Account
    {
        private string accountNumber;
        private decimal balance;

        public string OwnerEmail { get; set; }
        public int BenefitPoints { get; set; }
        public int Id { get; set; }
        public bool Open { get; set; }

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

        public string Name => OwnerEmail;

        public decimal Balance
        {
            get => balance;
            set
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

        protected Account(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
            Id = -1;
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
            return $"{Name}, {balance}, {BenefitPoints}";
        }
    }
}