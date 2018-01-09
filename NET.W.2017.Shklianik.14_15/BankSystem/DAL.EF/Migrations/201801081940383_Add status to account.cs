namespace DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addstatustoaccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Active", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Active");
        }
    }
}
