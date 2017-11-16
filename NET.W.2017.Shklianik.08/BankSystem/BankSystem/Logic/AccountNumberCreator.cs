using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Account
{
    public class AccountNumberCreator : IAccountNumberCreator
    {
        public string Create() => Guid.NewGuid().ToString();
    }
}
