namespace DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountOperation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        OperationTypeId = c.Int(nullable: false),
                        OperationValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperationDate = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationTypes", t => t.OperationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.OperationTypeId);
            
            CreateTable(
                "dbo.OperationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountOperations", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.AccountOperations", "OperationTypeId", "dbo.OperationTypes");
            DropIndex("dbo.AccountOperations", new[] { "OperationTypeId" });
            DropIndex("dbo.AccountOperations", new[] { "AccountId" });
            DropTable("dbo.OperationTypes");
            DropTable("dbo.AccountOperations");
        }
    }
}
