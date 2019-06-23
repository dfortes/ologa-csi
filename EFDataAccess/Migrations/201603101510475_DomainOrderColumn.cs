namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomainOrderColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Domain", "Order", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Domain", "Order");
        }
    }
}
