using System;
using System.Linq;
using BLL.Interface;
using BLL.Interface.Account;
using BLL.Interface.AccountIdCreatorService;
using BLL.Interface.AccountService;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            var service = resolver.Get<IAccountService>();
            var creator = resolver.Get<IAccountNumberCreator>();

            service.OpenAccount("1", AccountType.Base, creator);
            service.OpenAccount("2", AccountType.Base, creator);
            service.OpenAccount("3", AccountType.Gold, creator);
            service.OpenAccount("4", AccountType.Platinum, creator);

            var creditNumbers = service.GetAccounts("1").Select(acc => acc.AccountNumber).ToArray();

            foreach (var t in creditNumbers)
            {
                service.Deposit(t, 100);
            }

            foreach (var item in service.GetAccounts("2"))
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.Withdraw(t, 10);
            }

            foreach (var item in service.GetAccounts("3"))
            {
                Console.WriteLine(item);
            }
        }
    }
}