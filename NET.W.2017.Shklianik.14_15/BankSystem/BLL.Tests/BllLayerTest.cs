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

        private Mock<IRepository> mockRepository;
        private List<DalAccount> accounts;
        private IAccountService service;
        private Mock<IAccountNumberCreator> mockNumberGuid;
        private int AccCount;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<IRepository>();
            accounts = new List<DalAccount>();
            mockRepository.Setup(rep => rep.AddAccount(It.IsAny<DalAccount>())).Callback<DalAccount>(account => accounts.Add(account));

            service = new AccountService(mockRepository.Object);
            AccCount = 0;
            mockNumberGuid = new Mock<IAccountNumberCreator>();
            mockNumberGuid.Setup(num => num.Create()).Returns(() => $"account{AccCount++}");
            service.OpenAccount("First", AccountType.Platinum, mockNumberGuid.Object);
            service.OpenAccount("Second", AccountType.Gold, mockNumberGuid.Object);
            service.OpenAccount("Third", AccountType.Base, mockNumberGuid.Object);
        }

        [TestCase("First Accounnt", AccountType.Platinum, ExpectedResult = typeof(PlatinumAccount))]
        [TestCase("Second Accounnt", AccountType.Gold, ExpectedResult = typeof(GoldAccount))]
        [TestCase("Third Accounnt", AccountType.Base, ExpectedResult = typeof(BaseAccount))]
        public Type OpenAccountTest(string name, AccountType accountType)
        {
            string accontNummber = service.OpenAccount(name, accountType, new AccountNumberCreator());

            var accoount = accounts.Find(a => a.AccountNumber == accontNummber && a.Name == name);
            return accoount.AccountType;
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
