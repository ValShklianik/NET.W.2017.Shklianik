using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Account
{
    public interface IRepository 
    {
        /// <summary>
        /// Returns all accounts.
        /// </summary>
        /// <returns>Books contained in the storage.</returns>
        IEnumerable<Account> Read();

        /// <summary>
        /// Saves changes.
        /// </summary>
        /// <param name="accounts">Accounts to save</param>
        void Save(IEnumerable<Account> accounts);
    }
}
