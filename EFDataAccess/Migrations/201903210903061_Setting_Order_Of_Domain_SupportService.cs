namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setting_Order_Of_Domain_SupportService : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE SupportServiceType SET DomainOrder = CASE 
		            WHEN TypeDescription = 'Fort. econ�mico' THEN 1
		            WHEN TypeDescription = 'Sa�de' THEN 2
		            WHEN TypeDescription = 'Seroestado' THEN 3
		            WHEN TypeDescription = 'Habita��o' THEN 4
		            WHEN TypeDescription = 'MUAC (6-69 meses)' THEN 5
		            WHEN TypeDescription = 'Alim. e Nutri��o' THEN 6
		            WHEN TypeDescription = 'Educa��o' THEN 7
		            WHEN TypeDescription = 'Protec. e Apoio legal' THEN 8
		            WHEN TypeDescription = 'Apoio Psico-Social' THEN 9
		            WHEN TypeDescription = 'DPI (0-5 anos)' THEN 9
		            ELSE 99
	            END");
            Sql(@"UPDATE SupportServiceType SET SupportServiceOrderInDomain = SupportServiceTypeID;");
        }
        
        public override void Down()
        {
            Sql(@"UPDATE SupportServiceType SET SupportServiceOrderInDomain = NULL, DomainOrder = NULL");
        }
    }
}
