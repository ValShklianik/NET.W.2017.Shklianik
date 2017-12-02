﻿using System;

namespace BLL.Interface.Account
{
    [Serializable]
    public class PlatinumAccount : Account
    {
        public PlatinumAccount(string accountNumber, string name) : base(accountNumber, name)
        {

        }

        public PlatinumAccount(int id, string accountNumber, string name, decimal balance, int benefitPoints) : base(id, accountNumber, name, balance, benefitPoints)
        {

        }

        protected override bool IsValidBalance(decimal value) => value > -5000;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.06m + Balance * 0.06m);
    }
}
