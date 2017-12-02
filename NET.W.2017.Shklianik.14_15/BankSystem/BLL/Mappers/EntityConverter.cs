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
                AccountType = account.GetType(),
                AccountNumber = account.AccountNumber,
                Name = account.Name,
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints
            };
        }

        public static Account FromDalAccount(DalAccount account)
        {
            return (Account) Activator.CreateInstance(
                account.AccountType,
                account.Id,
                account.AccountNumber,
                account.Name,
                account.Balance,
                account.BenefitPoints);
        }
    }
}
