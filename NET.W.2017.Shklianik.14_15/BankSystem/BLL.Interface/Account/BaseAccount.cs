using System;

namespace BLL.Interface.Account
{
    [Serializable]
    public class BaseAccount : Account
    {

        public BaseAccount(string accountNumber, string name) : base(accountNumber, name)
        {

        }

        public BaseAccount(int id, string accountNumber, string name, decimal balance, int benefitPoints) : base(id, accountNumber, name, balance, benefitPoints)
        {

        }

        protected override bool IsValidBalance(decimal value) => value >= 0;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.01m + Balance * 0.01m);

        
    }
}
