namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSiteGoalsTableAndFamilyKitReceivedOnTableRoutineVisit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteGoal",
                c => new
                    {
                        SiteGoalID = c.Int(nullable: false, identity: true),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        SiteGoal_guid = c.Guid(nullable: false, defaultValueSql: "newid()"),
                        Indicator = c.String(nullable: false, maxLength: 250),
                        SitePerformanceComment = c.String(nullable: false, maxLength: 250),
                        GoalDate = c.DateTime(nullable: false),
                        GoalNumber = c.Int(nullable: false),
                        SiteID = c.Int(),
                    })
                .PrimaryKey(t => t.SiteGoalID)
                .ForeignKey("dbo.Site", t => t.SiteID)
                .Index(t => t.SiteID, name: "IX_Site_SiteID");
            
            AddColumn("dbo.RoutineVisit", "FamilyKitReceived", c => c.Boolean(nullable: false));

            Sql(@"INSERT INTO[dbo].[SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('N�mero de benefici�rios servido por programas de PEPFAR para OVC e fam�lias afetadas pelo HIV/AIDS','', GETDATE(),1)",false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('N�mero de referencias de sa�de e outros servi�os sociais','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('N�mero de referencias de sa�de e outros servi�os sociais designadas por completas','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('N�mero de agregados familiares recebendo Kit Familiar','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('N�mero de crian�as dos 6 - 59 meses rastreados para malnutri��o aguda ao n�vel comunit�rio (MUAC)','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('N�mero de crian�as  6 - 59 meses com malnutri��o aguda, detetados ao n�vel  da comunidade (Muac)','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('Percentagem de OVC com seroestado reportado ao parceiro de implementa��o (<18 anos)','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('Percentagem de OVC com seroestado reportado ao parceiro de implementa��o (>18 anos)','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('HIV-','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('HIV+ em TARV','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('HIV+  N�o em  TARV','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('Seroestado conhecido n�o revelado','', GETDATE(),1)", false);
            Sql(@"INSERT INTO [SiteGoal] ([Indicator],[SitePerformanceComment],[GoalDate],[GoalNumber])
            VALUES('Desconhecido','', GETDATE(),1)", false);
        }

    public override void Down()
        {
            DropForeignKey("dbo.SiteGoal", "SiteID", "dbo.Site");
            DropIndex("dbo.SiteGoal", "IX_Site_SiteID");
            DropColumn("dbo.RoutineVisit", "FamilyKitReceived");
            DropTable("dbo.SiteGoal");
        }
    }
}
