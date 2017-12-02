using System;

namespace BankSystem.Logic
{
    public class AccountNumberCreator : IAccountNumberCreator
    {
        public string Create() => Guid.NewGuid().ToString();
    }
}
