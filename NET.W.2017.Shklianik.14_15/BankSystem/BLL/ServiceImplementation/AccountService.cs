using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Account;
using BLL.Interface.AccountIdCreatorService;
using BLL.Interface.AccountService;
using DAL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using BLL.Interface;
using System.Net.Mail;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
        private readonly IEmailService mailService;

        public AccountService(IAccountRepository repository, IEmailService mailService)
        {
            this.repository = repository;
            this.mailService = mailService;
        }

        public string OpenAccount(string email, AccountType accountType, IAccountNumberCreator creator)
        {
            Account account;
            string accountNumber = creator.Create();

            switch (accountType)
            {
                case AccountType.Base:
                    account = new BaseAccount(accountNumber);
                    break;

                case AccountType.Gold:
                    account = new GoldAccount(accountNumber);
                    break;

                case AccountType.Platinum:
                    account = new PlatinumAccount(accountNumber);
                    break;
                default:
                    account = new BaseAccount(accountNumber);
                    break;
            }
            account.OwnerEmail = email;
            repository.AddAccount(EntityConverter.ToDalAccount(account));
            var mail = new MailMessage()
            {
                Subject = "Add account",
                Body = $"New account was added. Account number: {accountNumber}",
                IsBodyHtml = true
            };
            mail.To.Add(email);
            mailService.SendMail(mail);

            return accountNumber;
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            Account account = GetAccountFromRepository(accountNumber);
            account.Deposit(amount);
            repository.UpdateAccount(EntityConverter.ToDalAccount(account));

            var mail = new MailMessage()
            {
                Subject = "Deposit account",
                Body = $"Deposit accaunt {accountNumber}. Balance: {account.Balance}",
                IsBodyHtml = true
            };
            mail.To.Add(account.OwnerEmail);
            mailService.SendMail(mail);
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            Account account = GetAccountFromRepository(accountNumber);
            account.Withdraw(amount);
            repository.UpdateAccount(EntityConverter.ToDalAccount(account));

            var mail = new MailMessage()
            {
                Subject = "Withdraw account",
                Body = $"Withdraw accaunt {accountNumber}. Balance: {account.Balance}",
                IsBodyHtml = true
            };
            mail.To.Add(account.OwnerEmail);
            mailService.SendMail(mail);
        }

        public void CloseAccount(string accountNumber)
        {
            Account account = GetAccountFromRepository(accountNumber);
            repository.RemoveAccount(EntityConverter.ToDalAccount(account));

            var mail = new MailMessage()
            {
                Subject = "Close account",
                Body = $"Closing account operation. Account number: {accountNumber}",
                IsBodyHtml = true
            };
            mail.To.Add(account.OwnerEmail);
            mailService.SendMail(mail);
        }

        public DetailedAccount GetAccountInfo(string accountNumber) {
            DalAccountDetailed dalAccountDetailed = repository.GetAccountHistory(accountNumber);

            return new DetailedAccount
            {
                AccountObject = EntityConverter.FromDalAccount(dalAccountDetailed.AccountObject),
                Operations = dalAccountDetailed.Operations.Select(op => new AccountOperation
                {
                    Id = op.Id,
                    AccountId = dalAccountDetailed.AccountObject.Id,
                    Operation = op.Operation,
                    OperationDate = op.OperationDate,
                    OperationValue = op.OperationValue
                })
            };
        }

        private Account GetAccountFromRepository(string accountNumber)
        {
            Account account = EntityConverter.FromDalAccount(repository.GetAccount(accountNumber));
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            return account;
        }

        public IEnumerable<Account> GetAccounts(string ownerEmail)
        {
            if (string.IsNullOrWhiteSpace(ownerEmail)) throw new ArgumentNullException(nameof(ownerEmail));
            return repository.GetAccounts(ownerEmail).Select(EntityConverter.FromDalAccount);
        }
    }
}
