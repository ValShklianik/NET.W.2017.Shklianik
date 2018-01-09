﻿using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{

    public class FakeRepository : IAccountRepository
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

        public IEnumerable<DalAccount> GetAccounts(string ownerEmail)
        {
            return repository.Where(a => a.OwnerEmail == ownerEmail);
        }

        public DalAccountDetailed GetAccountHistory(string number)
        {
            throw new NotImplementedException();
        }
    }
}