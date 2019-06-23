namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_MaitenanceState : DbMigration
    {
        public override void Up()
        {
            //UPDATE DE CRIAN�AS EM MANUTEN��O PARA INICIAL
            Sql(@"UPDATE csh
                SET csh.[ChildStatusID] = 
                (
	                SELECT cs.[StatusID]
	                FROM  [ChildStatus] cs
	                WHERE cs.Description = 'Inicial'
                )
                FROM  [ChildStatusHistory] csh
                JOIN  [ChildStatus] cs ON csh.ChildStatusID = cs.StatusID AND cs.Description = 'Manuten��o' AND csh.childID IS NOT NULL", false);

            //UPDATE DE ADULTOS EM MANUTEN��O PARA ADULTO
            Sql(@"UPDATE csh
                SET csh.[ChildStatusID] = 
                (
	                SELECT cs.[StatusID]
	                FROM  [ChildStatus] cs
	                WHERE cs.Description = 'Adulto'
                )
                FROM  [ChildStatusHistory] csh
                JOIN  [ChildStatus] cs ON csh.ChildStatusID = cs.StatusID AND cs.Description = 'Manuten��o' AND csh.AdultID IS NOT NULL", false);

            //DELETE MANUTEN��O
            Sql(@"DELETE FROM [ChildStatus] WHERE Description = 'Manuten��o'", false);

        }
        
        public override void Down()
        {
            //INSERT MANUTEN��O
            Sql(@"INSERT INTO  [ChildStatus] (Description,state,SyncState) VALUES ('Manuten��o',0,0)", false);

        }
    }
}
