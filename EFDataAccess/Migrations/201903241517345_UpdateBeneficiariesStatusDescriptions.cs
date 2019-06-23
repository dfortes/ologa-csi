namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBeneficiariesStatusDescriptions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChildStatus", "Description", c => c.String(nullable: false, maxLength: 50, unicode: false));

            Sql(@"UPDATE cs
                SET cs.Description = 'Transferido p/ programas N�O de PEPFAR)'
                FROM [ChildStatus] cs
                WHERE cs.Description = 'Transfer�ncia'");

            Sql(@"INSERT INTO [ChildStatus] (Description, CreatedDate, LastUpdatedDate, CreatedUserID, LastUpdatedUserID, state, SyncState) 
                VALUES ('Transferido p/ programas de PEPFAR', GETDATE(), GETDATE(), 1, 1, 0,0)", false);
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChildStatus", "Description", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
    }
}
