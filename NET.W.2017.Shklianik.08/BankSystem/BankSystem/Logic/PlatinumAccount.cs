using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Account
{
    public class PlatinumAccount : Account
    {
        public PlatinumAccount(string accountNumber, string name) : base(accountNumber, name)
        {

        }
        protected override bool IsValidBalance(decimal value) => value > -5000;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.06m + Balance * 0.06m);
    }
}
