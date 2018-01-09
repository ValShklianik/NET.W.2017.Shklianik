using System;
using BLL.Interface.Account;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public class EntityConverter
    {
        public static DalAccount ToDalAccount(Account account)
        {
            return new DalAccount
            {
                Id = account.Id,
                AccountType = account.GetType().ToString(),
                AccountNumber = account.AccountNumber,
                OwnerEmail = account.OwnerEmail,
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints,
                Open = account.Open
            };
        }

        public static Account FromDalAccount(DalAccount account)
        {
            Account newAccount = (Account) Activator.CreateInstance(GetBllAccountType(account.AccountType), account.AccountNumber);
            newAccount.Id = account.Id;
            newAccount.Balance = account.Balance;
            newAccount.BenefitPoints = account.BenefitPoints;
            newAccount.OwnerEmail = account.OwnerEmail;
            newAccount.Open = account.Open;

            return newAccount;
        }

        private static Type GetBllAccountType(string type)
        {
            if (type.Contains("Gold"))
            {
                return typeof(GoldAccount);
            }

            if (type.Contains("Platinum"))
            {
                return typeof(PlatinumAccount);
            }

            return typeof(BaseAccount);
        }
    }
}
