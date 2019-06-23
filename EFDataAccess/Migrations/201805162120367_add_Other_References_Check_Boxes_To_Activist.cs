namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Other_References_Check_Boxes_To_Activist : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO  [ReferenceType] ([ReferenceName],[ReferenceCategory]
                ,[ReferenceOrder],[FieldType],[OriginReferenceID])
                VALUES('Atestado de Pobreza', 'Activist',30,'CheckBox',NULL),
                ('Registo de Nascimento/C�dula', 'Activist',31,'CheckBox',NULL),
                ('Bilhete de Identidade (B.I)', 'Activist',32,'CheckBox',NULL),
                ('Integra��o Escolar', 'Activist',33,'CheckBox',NULL),
                ('Curso de Forma��o Vocacional', 'Activist',34,'CheckBox',NULL),
                ('Material Escolar', 'Activist',35,'CheckBox',NULL),
                ('Cesta B�sica', 'Activist',36,'CheckBox',NULL),
                ('Subs�dios Sociais do INAS', 'Activist',37,'CheckBox',NULL)", false);
        }

        public override void Down()
        {

            Sql(@"DELETE FROM  [ReferenceType] WHERE ReferenceName in 
                ('Atestado de Pobreza','Registo de Nascimento/C�dula',  'Bilhete de Identidade (B.I)', 'Integra��o Escolar',
                'Curso de Forma��o Vocacional', 'Material Escolar', 'Cesta B�sica', 'Subs�dios Sociais do INAS') 
                AND ReferenceCategory='Activist' AND ReferenceOrder>29", false);
        }
    }
}
