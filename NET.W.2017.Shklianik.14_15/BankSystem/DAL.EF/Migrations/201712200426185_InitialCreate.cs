namespace DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(nullable: false),
                        CurrentSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BonusPoints = c.Int(nullable: false),
                        AccountOwnerId = c.Int(nullable: false),
                        AccountTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.AccountOwnerId, cascadeDelete: true)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypeId, cascadeDelete: true)
                .Index(t => t.AccountOwnerId)
                .Index(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "AccountTypeId", "dbo.AccountTypes");
            DropForeignKey("dbo.Accounts", "AccountOwnerId", "dbo.Owners");
            DropIndex("dbo.Accounts", new[] { "AccountTypeId" });
            DropIndex("dbo.Accounts", new[] { "AccountOwnerId" });
            DropTable("dbo.AccountTypes");
            DropTable("dbo.Owners");
            DropTable("dbo.Accounts");
        }
    }
}
