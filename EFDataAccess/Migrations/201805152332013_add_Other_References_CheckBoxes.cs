namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Other_References_CheckBoxes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO  [ReferenceType] ([ReferenceName],[ReferenceCategory]
                ,[ReferenceOrder],[FieldType],[OriginReferenceID])
                VALUES('Atestado de Pobreza', 'Social',12,'CheckBox',NULL),
                ('Registo de Nascimento/C�dula', 'Social',13,'CheckBox',NULL),
                ('Bilhete de Identidade (B.I)', 'Social',14,'CheckBox',NULL),
                ('Integra��o Escolar', 'Social',15,'CheckBox',NULL),
                ('Curso de Forma��o Vocacional', 'Social',16,'CheckBox',NULL),
                ('Material Escolar', 'Social',17,'CheckBox',NULL),
                ('Cesta B�sica', 'Social',18,'CheckBox',NULL),
                ('Subs�dios Sociais do INAS', 'Social',19,'CheckBox',NULL)", false);
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM  [ReferenceType] WHERE ReferenceName in 
                ('Atestado de Pobreza','Registo de Nascimento/C�dula',  'Bilhete de Identidade (B.I)', 'Integra��o Escolar',
                'Curso de Forma��o Vocacional', 'Material Escolar', 'Cesta B�sica', 'Subs�dios Sociais do INAS') 
                AND ReferenceCategory='Social' AND ReferenceOrder>11", false);
        }
    }
}
