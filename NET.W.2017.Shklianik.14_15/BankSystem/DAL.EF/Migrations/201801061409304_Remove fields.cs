namespace DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removefields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Owners", "FirstName");
            DropColumn("dbo.Owners", "SecondName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Owners", "SecondName", c => c.String());
            AddColumn("dbo.Owners", "FirstName", c => c.String());
        }
    }
}
