using System.Data.Entity;
using DAL.EF.Models;

namespace DAL.EF
{
    internal class AccountContext : DbContext
    {
        public AccountContext() : base("Accounts")
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<OperationType> OperationTypes { get; set; }

        public DbSet<AccountOperation> AccountOperations { get; set; }
    }
}