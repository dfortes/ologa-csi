namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewReferenceServices : DbMigration
    {
        public override void Up()
        {
            //Insert New References to Activist and Health
            Sql(@"SET IDENTITY_INSERT [ReferenceType]  ON
                  INSERT INTO  [ReferenceType] ([ReferenceTypeID],[ReferenceName],[ReferenceCategory],[ReferenceOrder],[FieldType],[OriginReferenceID])
                  VALUES(84,'SAAJ', 'Activist',38,'CheckBox',NULL),
                      (85,'Desnutri��o', 'Activist',39,'CheckBox',NULL),
                      (86,'Atraso no Desenvolvimento', 'Activist',40,'CheckBox',NULL),
                      (87,'SAAJ', 'Health',28,'CheckBox',NULL),
                      (88,'Desnutri��o', 'Health',29,'CheckBox',NULL),
                      (89,'Atraso no Desenvolvimento', 'Health',30,'CheckBox',NULL)
                  SET IDENTITY_INSERT [ReferenceType]  OFF", false);

            //Set value 0 to old Reference Services without SAAJ For Activist
            Sql(@"INSERT INTO [Reference]
                ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
                SELECT 
	                0, 
	                (
		                SELECT [ReferenceTypeID]
		                FROM  [ReferenceType] rType
		                WHERE rType.ReferenceName IN ('SAAJ')
		                AND rType.ReferenceCategory IN ('Activist')
	                ),
	                rService.ReferenceServiceID, 0, 0 
                FROM  [ReferenceService] rService", false);

            //Set value 0 to old Reference Services without Desnutri��o For Activist
            Sql(@"INSERT INTO [Reference]
                ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
                SELECT 
	                0, 
	                (
		                SELECT [ReferenceTypeID]
		                FROM  [ReferenceType] rType
		                WHERE rType.ReferenceName IN ('Desnutri��o')
		                AND rType.ReferenceCategory IN ('Activist')
	                ),
	                rService.ReferenceServiceID, 0, 0 
                FROM  [ReferenceService] rService", false);

            ///Set value 0 to old Reference Services without Atraso no Desenvolvimento For Activist
            Sql(@"INSERT INTO [Reference]
                ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
                SELECT 
	                0, 
	                (
		                SELECT [ReferenceTypeID]
		                FROM  [ReferenceType] rType
		                WHERE rType.ReferenceName IN ('Atraso no Desenvolvimento')
		                AND rType.ReferenceCategory IN ('Activist')
	                ),
	                rService.ReferenceServiceID, 0, 0 
                FROM  [ReferenceService] rService", false);



            //Set value 0 to old Reference Services without SAAJ For Health
            Sql(@"INSERT INTO [Reference]
                ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
                SELECT 
	                0, 
	                (
		                SELECT [ReferenceTypeID]
		                FROM  [ReferenceType] rType
		                WHERE rType.ReferenceName IN ('SAAJ')
		                AND rType.ReferenceCategory IN ('Health')
	                ),
	                rService.ReferenceServiceID, 0, 0 
                FROM  [ReferenceService] rService", false);

            //Set value 0 to old Reference Services without Desnutri��o For Health
            Sql(@"INSERT INTO [Reference]
                ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
                SELECT 
	                0, 
	                (
		                SELECT [ReferenceTypeID]
		                FROM  [ReferenceType] rType
		                WHERE rType.ReferenceName IN ('Desnutri��o')
		                AND rType.ReferenceCategory IN ('Health')
	                ),
	                rService.ReferenceServiceID, 0, 0 
                FROM  [ReferenceService] rService", false);

            ///Set value 0 to old Reference Services without Atraso no Desenvolvimento For Health
            Sql(@"INSERT INTO [Reference]
                ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
                SELECT 
	                0, 
	                (
		                SELECT [ReferenceTypeID]
		                FROM  [ReferenceType] rType
		                WHERE rType.ReferenceName IN ('Atraso no Desenvolvimento')
		                AND rType.ReferenceCategory IN ('Health')
	                ),
	                rService.ReferenceServiceID, 0, 0 
                FROM  [ReferenceService] rService", false);
        }
        
        public override void Down()
        {
        }
    }
}
