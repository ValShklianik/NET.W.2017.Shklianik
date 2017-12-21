using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.AccountIdCreatorService;
using BLL.Interface.Account;

namespace BLL.Interface.AccountService
{
    public interface IAccountService
    {
        string OpenAccount(string firstName, string lastName, string email, AccountType accountType, IAccountNumberCreator creator);

        void Deposit(string accountNumber, decimal amount);

        void Withdraw(string accountNumber, decimal amount);

        void DeleteAccount(string accountNumber);

        IEnumerable<Account.Account> GetAccounts(string ownerEmail);

        Account.Account GetAccountInfo(string accountNumber);
    }
}
