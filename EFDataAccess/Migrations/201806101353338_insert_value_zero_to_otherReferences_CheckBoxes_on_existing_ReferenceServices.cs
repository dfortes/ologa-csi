namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert_value_zero_to_otherReferences_CheckBoxes_on_existing_ReferenceServices : DbMigration
    {
        public override void Up()
        {

            //-----------------ACTIVISTA-----------------------

            //Activista/Atestado de Pobreza
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Atestado de Pobreza')
		            AND rType.ReferenceCategory IN ('Activist')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Activista/Registo de Nascimento/C�dula
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Registo de Nascimento/C�dula')
		            AND rType.ReferenceCategory IN ('Activist')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Activista/Bilhete de Identidade (B.I)
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Bilhete de Identidade (B.I)')
		            AND rType.ReferenceCategory IN ('Activist')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Activista/Integra��o Escolar
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Integra��o Escolar')
		            AND rType.ReferenceCategory IN ('Activist')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Activista/Curso de Forma��o Vocacional
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Curso de Forma��o Vocacional')
		            AND rType.ReferenceCategory IN ('Activist')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Activista/Material Escolar
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Material Escolar')
		            AND rType.ReferenceCategory IN ('Activist')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Activista/Cesta B�sica
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Cesta B�sica')
		            AND rType.ReferenceCategory IN ('Activist')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Activista/Subs�dios Sociais do INAS
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Subs�dios Sociais do INAS')
		            AND rType.ReferenceCategory IN ('Activist')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);




            //-----------------SERVI�O SOCIAL-----------------------


            //Social/Atestado de Pobreza
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Atestado de Pobreza')
		            AND rtype.ReferenceOrder = 12
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);
 

            //Social/Registo de Nascimento/C�dula
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Registo de Nascimento/C�dula')
		            AND rType.ReferenceCategory IN ('Social')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Social/Bilhete de Identidade (B.I)
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Bilhete de Identidade (B.I)')
		            AND rType.ReferenceCategory IN ('Social')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Social/Integra��o Escolar
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Integra��o Escolar')
		            AND rType.ReferenceCategory IN ('Social')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Social/Curso de Forma��o Vocacional
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Curso de Forma��o Vocacional')
		            AND rType.ReferenceCategory IN ('Social')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Social/Material Escolar
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Material Escolar')
		            AND rType.ReferenceCategory IN ('Social')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Social/Cesta B�sica
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Cesta B�sica')
		            AND rType.ReferenceCategory IN ('Social')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);


            //Social/Subs�dios Sociais do INAS
            Sql(@"INSERT INTO [Reference]
            ([Value],[ReferenceTypeID],[ReferenceServiceID],[State],[SyncState])
            SELECT 
	            0, 
	            (
		            SELECT [ReferenceTypeID]
		            FROM  [ReferenceType] rType
		            WHERE rType.ReferenceName IN ('Subs�dios Sociais do INAS')
		            AND rType.ReferenceCategory IN ('Social')
	            ),
	            rService.ReferenceServiceID, 0, 0 
            FROM  [ReferenceService] rService", false);
        }
        
        public override void Down()
        {
            //DELETE VALUES NAS OUTRAS REFER�NCIAS DO SERVI�O SOCIAL
            Sql(@"DELETE reference FROM  [ReferenceType] rType
                JOIN  [Reference] reference ON reference.ReferenceTypeID = rType.ReferenceTypeID 
                AND rType.ReferenceName IN ('Atestado de Pobreza','Registo de Nascimento/C�dula', 'Bilhete de Identidade (B.I)'
                , 'Integra��o Escolar', 'Curso de Forma��o Vocacional', 'Material Escolar', 'Cesta B�sica', 'Subs�dios Sociais do INAS') 
                AND rType.ReferenceCategory='Social' AND rType.ReferenceOrder>11", false);

            //DELETE VALUES NAS OUTRAS REFER�NCIAS DO ACTIVISTA
            Sql(@"DELETE reference FROM  [ReferenceType] rType
                JOIN  [Reference] reference ON reference.ReferenceTypeID = rType.ReferenceTypeID 
                AND rType.ReferenceName IN ('Atestado de Pobreza','Registo de Nascimento/C�dula',  'Bilhete de Identidade (B.I)', 'Integra��o Escolar',
                'Curso de Forma��o Vocacional', 'Material Escolar', 'Cesta B�sica', 'Subs�dios Sociais do INAS') 
                AND rType.ReferenceCategory='Activist' AND rType.ReferenceOrder>29", false);

        }
    }
}
