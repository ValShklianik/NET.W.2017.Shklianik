using System;
using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IRepository 
    {
        /// <summary>
        /// Adds <paramref name="account"/> to the repository.
        /// </summary>
        /// <param name="account"></param>
        /// Thrown when an exception occurred in repository or
        /// <paramref name="account"/> already exists.
        void AddAccount(DalAccount account);

        /// <summary>
        /// Returns the account with the specified <paramref name="number"/>.
        /// </summary>
        /// <param name="number">account id</param>
        /// <returns>DalAccount or null if there is no such account in the repository.</returns>
        DalAccount GetAccount(string number);

        /// <summary>
        /// Updates account information.
        /// </summary>
        /// <param name="account">account</param>
        /// Thrown when an exception occurred in repository or
        /// <paramref name="account"/> does not exists.
        void UpdateAccount(DalAccount account);

        /// <summary>
        /// Removes <param name="account"></param>.
        /// </summary>
        /// <param name="account">account</param>
        /// Thrown when an exception occurred in repository or
        /// <paramref name="account"/> does not exists.
        void RemoveAccount(DalAccount account);

        /// <summary>
        /// Returns all accounts stored in the repository.
        /// </summary>
        /// <returns>All accounts contained in the repository.</returns>
        /// Thrown when an exception occurred in repository.
        IEnumerable<DalAccount> GetAccounts(Predicate<DalAccount> predicate);
    }
}
