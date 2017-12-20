using System;

namespace BLL.Interface.Account
{
    [Serializable]
    public class GoldAccount : Account
    {
        public GoldAccount(string accountNumber) : base(accountNumber)
        {

        }

        protected override bool IsValidBalance(decimal value) => value > -1000;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.03m + Balance * 0.03m);
    }

}
