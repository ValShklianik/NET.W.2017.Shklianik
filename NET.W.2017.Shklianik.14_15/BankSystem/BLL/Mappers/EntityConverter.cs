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
                OwnerFirstName = account.OwnerFirstName,
                OwnerSecondName = account.OwnerSecondName,
                OwnerEmail = account.OwnerEmail,
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints
            };
        }

        public static Account FromDalAccount(DalAccount account)
        {
            Account newAccount = (Account) Activator.CreateInstance(GetBllAccountType(account.AccountType));
            newAccount.Id = account.Id;
            newAccount.AccountNumber = account.AccountNumber;
            newAccount.Balance = account.Balance;
            newAccount.BenefitPoints = account.BenefitPoints;
            newAccount.OwnerFirstName = account.OwnerFirstName;
            newAccount.OwnerSecondName = account.OwnerSecondName;
            newAccount.OwnerEmail = account.OwnerEmail;

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
