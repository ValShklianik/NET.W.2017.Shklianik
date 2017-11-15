using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Account
{
    public class AccountService
    {
        private IRepository repository;
        public AccountService(IRepository repository)
        {
            this.repository = repository;
        }

        public void OpenAccount(string name, AccountType accountType, IAccountNumberCreator creator)
        {
            Account account = null;
            string accountNumber = creator.Create();
            switch (accountType)
            {
                case AccountType.Base:
                    account = new BaseAccount(accountNumber, name);
                    break;

                case AccountType.Gold:
                    account = new GoldAccount(accountNumber, name);
                    break;

                case AccountType.Platinum:
                    account = new PlatinumAccount(accountNumber, name);
                    break;
            }
        }
    }
}
