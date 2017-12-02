﻿using System;

namespace BankSystem.Logic
{
    [Serializable]
    public class GoldAccount : Account
    {
        public GoldAccount(string accountNumber, string name) : base(accountNumber, name)
        {

        }
        protected override bool IsValidBalance(decimal value) => value > -1000;

        protected override int CalculateBanefitPoints(decimal amount) => (int)Math.Round(amount * 0.03m + Balance * 0.03m);
    }

}
