namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReferenceColumnAndRowNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReferenceType", "ReferenceColumn", c => c.Int());
            AddColumn("dbo.ReferenceType", "ReferenceRow", c => c.Int());

            Sql(@"UPDATE[ReferenceType] SET[ReferenceColumn] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Maternidade p/ Parto'
                UPDATE[ReferenceType] SET[ReferenceRow] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Maternidade p/ Parto'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'CPN'
                UPDATE[ReferenceType] SET[ReferenceRow] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'CPN'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'CPN Familiar'
                UPDATE[ReferenceType] SET[ReferenceRow] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'CPN Familiar'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Consulta P�s-Parto'
                UPDATE[ReferenceType] SET[ReferenceRow] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Consulta P�s-Parto'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'CCR'
                UPDATE[ReferenceType] SET[ReferenceRow] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'CCR'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'PTV'
                UPDATE[ReferenceType] SET[ReferenceRow] = 5 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'PTV'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'ATS'
                UPDATE[ReferenceType] SET[ReferenceRow] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'ATS'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'ITS'
                UPDATE[ReferenceType] SET[ReferenceRow] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'ITS'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Pr�-TARV/IO'
                UPDATE[ReferenceType] SET[ReferenceRow] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Pr�-TARV/IO'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Testado HIV+'
                UPDATE[ReferenceType] SET[ReferenceRow] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Testado HIV+'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Abandono TARV'
                UPDATE[ReferenceType] SET[ReferenceRow] = 5 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Abandono TARV'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'PPE'
                UPDATE[ReferenceType] SET[ReferenceRow] = 6 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'PPE'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Circuncisao Masculina'
                UPDATE[ReferenceType] SET[ReferenceRow] = 7 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Circuncisao Masculina'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Suspeito de TB'
                UPDATE[ReferenceType] SET[ReferenceRow] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Suspeito de TB'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Contacto de TB'
                UPDATE[ReferenceType] SET[ReferenceRow] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Contacto de TB'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Controlo de BK'
                UPDATE[ReferenceType] SET[ReferenceRow] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Controlo de BK'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Abandono de TTB'
                UPDATE[ReferenceType] SET[ReferenceRow] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Abandono de TTB'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Reac��es do TTB'
                UPDATE[ReferenceType] SET[ReferenceRow] = 5 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Reac��es do TTB'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Suspeito de Mal�ria'
                UPDATE[ReferenceType] SET[ReferenceRow] = 6 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Suspeito de Mal�ria'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'OCB/Apoio Comunit�rio'
                UPDATE[ReferenceType] SET[ReferenceRow] = 1 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'OCB/Apoio Comunit�rio'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Educa��o'
                UPDATE[ReferenceType] SET[ReferenceRow] = 2 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Educa��o'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Ac��o Social'
                UPDATE[ReferenceType] SET[ReferenceRow] = 3 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Ac��o Social'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'GAVV'
                UPDATE[ReferenceType] SET[ReferenceRow] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'GAVV'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Apoio Psico-Social'
                UPDATE[ReferenceType] SET[ReferenceRow] = 5 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Apoio Psico-Social'
                UPDATE[ReferenceType] SET[ReferenceColumn] = 4 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Posto Policial'
                UPDATE[ReferenceType] SET[ReferenceRow] = 6 WHERE[ReferenceCategory] = 'Activist' AND[ReferenceName] = 'Posto Policial'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReferenceType", "ReferenceRow");
            DropColumn("dbo.ReferenceType", "ReferenceColumn");
        }
    }
}
