namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn_OrderForRoutineVisit_in_Domain_Table : DbMigration
    {
        public override void Up()
        {

            AddColumn("dbo.Domain", "OrderForRoutineVisit", c => c.Int(nullable: false));

            //ADD VALUES TO COLUMN
            Sql(@"Update D SET D.[OrderForRoutineVisit] = 1 FROM [Domain] D WHERE D.DomainID = 6", false); // Fortalecimento Econ�mico
            Sql(@"Update D SET D.[OrderForRoutineVisit] = 2 FROM [Domain] D WHERE D.DomainID = 1", false); // Alimentac�o/Nutri��o
            Sql(@"Update D SET D.[OrderForRoutineVisit] = 3 FROM [Domain] D WHERE D.DomainID = 7", false); // Habita��o
            Sql(@"Update D SET D.[OrderForRoutineVisit] = 4 FROM [Domain] D WHERE D.DomainID = 2", false); // Educa��o
            Sql(@"Update D SET D.[OrderForRoutineVisit] = 5 FROM [Domain] D WHERE D.DomainID = 3", false); // Sa�de
            Sql(@"Update D SET D.[OrderForRoutineVisit] = 6 FROM [Domain] D WHERE D.DomainID = 5", false); // Apoio Psico social
            Sql(@"Update D SET D.[OrderForRoutineVisit] = 7 FROM [Domain] D WHERE D.DomainID = 4", false); // Protec��o e Apoio Legal
        }
        
        public override void Down()
        {
            DropColumn("dbo.Domain", "OrderForRoutineVisit");
        }
    }
}
