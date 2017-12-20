using System;

namespace BLL.Interface.Account
{
    [Serializable]
    public class BaseAccount : Account
    {

        public BaseAccount(string accountNumber) : base(accountNumber)
        {

        }

        protected override bool IsValidBalance(decimal value) => value >= 0;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.01m + Balance * 0.01m);

        
    }
}
