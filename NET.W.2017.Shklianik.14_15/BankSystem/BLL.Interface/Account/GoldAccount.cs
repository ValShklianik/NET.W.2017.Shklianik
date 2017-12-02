using System;

namespace BLL.Interface.Account
{
    [Serializable]
    public class GoldAccount : Account
    {
        public GoldAccount(string accountNumber, string name) : base(accountNumber, name)
        {

        }

        public GoldAccount(int id, string accountNumber, string name, decimal balance, int benefitPoints) : base(id, accountNumber, name, balance, benefitPoints)
        {

        }

        protected override bool IsValidBalance(decimal value) => value > -1000;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.03m + Balance * 0.03m);
    }

}
