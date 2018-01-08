using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using BLL.Interface.Account;
using BLL.Interface.AccountIdCreatorService;
using BLL.Interface.AccountService;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using Moq;

namespace BLL.Tests
{
    [TestFixture]
    public class BllLayerTest
    {

        private Mock<IAccountRepository> mockRepository;
        private List<DalAccount> accounts;
        private IAccountService service;
        private Mock<IAccountNumberCreator> mockNumberGuid;
        private int AccCount;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<IAccountRepository>();
            accounts = new List<DalAccount>();
            mockRepository.Setup(rep => rep.AddAccount(It.IsAny<DalAccount>())).Callback<DalAccount>(account => accounts.Add(account));

            service = new AccountService(mockRepository.Object);
            AccCount = 0;
            mockNumberGuid = new Mock<IAccountNumberCreator>();
            mockNumberGuid.Setup(num => num.Create()).Returns(() => $"account{AccCount++}");
            service.OpenAccount("1", AccountType.Platinum, mockNumberGuid.Object);
            service.OpenAccount("2", AccountType.Gold, mockNumberGuid.Object);
            service.OpenAccount("3", AccountType.Base, mockNumberGuid.Object);
        }

        [TestCase("1", AccountType.Platinum, ExpectedResult = typeof(PlatinumAccount))]
        [TestCase("2", AccountType.Gold, ExpectedResult = typeof(GoldAccount))]
        [TestCase("3", AccountType.Base, ExpectedResult = typeof(BaseAccount))]
        public Type OpenAccountTest(string email, AccountType accountType)
        {
            service.OpenAccount(email, accountType, new AccountNumberCreator());

            return typeof(BaseAccount);
        }

        /*[TestCase("account0", 4, ExpectedResult = 4)]
        [TestCase("account1", 4, ExpectedResult = 4)]
        [TestCase("account2", 5, ExpectedResult = 5)]
        public decimal Deposit(string accountNumber, decimal amount)
        {
            service.Deposit(accountNumber, amount);
            return service.GetAccountInfo(accountNumber).Balance;
        }*/
    }
}
