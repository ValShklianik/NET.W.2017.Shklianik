using System;

namespace BankSystem.Logic
{
    [Serializable]
    public class BaseAccount : Account
    {

        public BaseAccount(string accountNumber, string name) : base(accountNumber, name)
        {

        }
        protected override bool IsValidBalance(decimal value) => value >= 0;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.01m + Balance * 0.01m);

        
    }
}
