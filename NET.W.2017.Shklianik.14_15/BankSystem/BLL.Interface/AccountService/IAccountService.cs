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
        string OpenAccount(string email, AccountType accountType, IAccountNumberCreator creator);

        void Deposit(string accountNumber, decimal amount);

        void Withdraw(string accountNumber, decimal amount);

        void CloseAccount(string accountNumber);

        IEnumerable<Account.Account> GetAccounts(string ownerEmail);

        DetailedAccount GetAccountInfo(string accountNumber);
    }
}
