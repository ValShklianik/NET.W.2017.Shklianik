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
            //	Account account = new BaseAccount();
            //	account.AccountNumber = "NN1233224";
            //	account.Name = "Nastichka";
            //	account.Deposit(120m);
            //	account.Withdraw(120m);
            //	account.Dump();
            //	
            //	Account accountSilv = new SilverAccount();
            //	accountSilv.AccountNumber = "NNNNN1233224";
            //	accountSilv.Name = "Nastichka";
            //	accountSilv.Deposit(120m);
            //	accountSilv.Withdraw(1000m);
            //	accountSilv.Dump();

            //	var guid = new Guid();

            var repo = new FileRepository();
            AccountService service = new AccountService(repo);
            service.OpenAccount("user", AccountType.Base, new AccountNumberCreator());
            //Console.WriteLine(repo.repository);
            //Console.Read();

        }
    }
}
