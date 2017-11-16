using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Account;

namespace BankSystem.ConsoleUI
{
    class Program
    {
        public static void Main()
        {

            AccountService service = AccountService.GetService();
          

            string idAccount = service.OpenAccount("Princess Lera", AccountService.AccountType.Base, new AccountNumberCreator());
            string idAccountGold = service.OpenAccount("Princess Gold Lera", AccountService.AccountType.Gold, new AccountNumberCreator());
            string idAccountPlatinum = service.OpenAccount("Princess Platinum Lera", AccountService.AccountType.Platinum, new AccountNumberCreator());

            service.Deposit(idAccount, 1m);
            service.Deposit(idAccountGold, 5m);
            service.Withdraw(idAccountGold, 0.5m);
            service.Deposit(idAccountPlatinum, 5m);

            Console.WriteLine(service.GetAccountInfo(idAccount).ToString());
            Console.WriteLine(service.GetAccountInfo(idAccountGold).ToString());
            Console.WriteLine(service.GetAccountInfo(idAccountPlatinum).ToString());
            Console.Read();

        }
    }
}
