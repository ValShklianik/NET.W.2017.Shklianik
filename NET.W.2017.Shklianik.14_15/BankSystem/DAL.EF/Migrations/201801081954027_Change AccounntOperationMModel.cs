namespace DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAccounntOperationMModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AccountOperations", name: "OperationTypeId", newName: "AccountOperationTypeId");
            RenameColumn(table: "dbo.AccountOperations", name: "AccountId", newName: "ChangedAccountId");
            RenameIndex(table: "dbo.AccountOperations", name: "IX_AccountId", newName: "IX_ChangedAccountId");
            RenameIndex(table: "dbo.AccountOperations", name: "IX_OperationTypeId", newName: "IX_AccountOperationTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AccountOperations", name: "IX_AccountOperationTypeId", newName: "IX_OperationTypeId");
            RenameIndex(table: "dbo.AccountOperations", name: "IX_ChangedAccountId", newName: "IX_AccountId");
            RenameColumn(table: "dbo.AccountOperations", name: "ChangedAccountId", newName: "AccountId");
            RenameColumn(table: "dbo.AccountOperations", name: "AccountOperationTypeId", newName: "OperationTypeId");
        }
    }
}
