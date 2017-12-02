using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{

    public class FakeRepository : IRepository
    {
        private readonly List<DalAccount> repository;

        public FakeRepository()
        {
            repository = new List<DalAccount>();
        }

        public void AddAccount(DalAccount account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            repository.Add(account);
        }

        public DalAccount GetAccount(string number)
        {
            if (number == null) throw new ArgumentNullException(nameof(number));
            return repository.Find(account => number == account.AccountNumber);
        }

        public void UpdateAccount(DalAccount account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            DalAccount updetedAcc = GetAccount(account.AccountNumber);
            repository.Remove(updetedAcc);
            repository.Add(account);
        }

        public void RemoveAccount(DalAccount account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            repository.Remove(account);
        }

        public IEnumerable<DalAccount> GetAccounts(Predicate<DalAccount> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return repository.FindAll(predicate);
        }
    }
}