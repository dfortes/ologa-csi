namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewBeneficiaryStatus1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO  [ChildStatus] (Description,[CreatedDate], [LastUpdatedDate], [SyncDate], [SyncGuid], [CreatedUserID], [LastUpdatedUserID], state,SyncState) 
            VALUES ('Eliminado - Sem Servi�os',GETDATE(), GETDATE(), NULL, NULL, 1, 1, 0, 0)");

            Sql(@"INSERT INTO  [ChildStatus] (Description,[CreatedDate], [LastUpdatedDate], [SyncDate], [SyncGuid], [CreatedUserID], [LastUpdatedUserID], state, SyncState) 
            VALUES ('Eliminado - Transferido', GETDATE(), GETDATE(), NULL, NULL, 1, 1, 0, 0)");

            Sql(@"INSERT INTO  [ChildStatus] (Description,[CreatedDate], [LastUpdatedDate], [SyncDate], [SyncGuid], [CreatedUserID], [LastUpdatedUserID], state,SyncState) 
            VALUES ('Eliminado - Gradua��o', GETDATE(), GETDATE(), NULL, NULL, 1, 1, 0, 0)");

            Sql(@"INSERT INTO  [ChildStatus] (Description,[CreatedDate], [LastUpdatedDate], [SyncDate], [SyncGuid], [CreatedUserID], [LastUpdatedUserID], state,SyncState) 
            VALUES ('Eliminado - Desist�ncia',GETDATE(), GETDATE(), NULL, NULL, 1, 1, 0, 0)");

            Sql(@"INSERT INTO  [ChildStatus] (Description,[CreatedDate], [LastUpdatedDate], [SyncDate], [SyncGuid], [CreatedUserID], [LastUpdatedUserID], state,SyncState) 
            VALUES ('Eliminado - Perdido', GETDATE(), GETDATE(), NULL, NULL, 1, 1, 0, 0)");

            Sql(@"INSERT INTO  [ChildStatus] (Description,[CreatedDate], [LastUpdatedDate], [SyncDate], [SyncGuid], [CreatedUserID], [LastUpdatedUserID], state, SyncState) 
            VALUES ('Eliminado - �bito', GETDATE(), GETDATE(), NULL, NULL, 1, 1, 0, 0)");

            Sql(@"INSERT INTO  [ChildStatus] (Description,[CreatedDate], [LastUpdatedDate], [SyncDate], [SyncGuid], [CreatedUserID], [LastUpdatedUserID], state,SyncState) 
            VALUES ('Eliminado - Outras Sa�das', GETDATE(), GETDATE(), NULL, NULL, 1, 1, 0, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
