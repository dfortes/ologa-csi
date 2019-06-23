namespace EFDataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    
    public partial class Restructurate_SupportServiceType_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupportServiceType", "SupportServiceOrderInDomainTypeCode", c => c.String());

            // Set SupportServiceOrderInDomain Column to NULL To Reorder In Correct Way
            Sql(@"UPDATE sst SET sst.SupportServiceOrderInDomain = NULL FROM SupportServiceType sst");

            int rowNumber = 0;
            int totalRows = 0;

            // ORDER NUMBERS IN DOMAIN LIST
            List<int> SupportServiceOrderInDomainByNumbers = new List<int>(new int[]
            {
	            1, 2, 3, 4, //Fort. econ�mico
	            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, //Sa�de
	            1, 2, 3, 4, 5, 6, 7, //Seroestado
	            1, 2, 3, //Habita��o
	            1, 2, 3, 4, 5, //MUAC (6-59 meses)
	            1, 2, 3, //Alim. e Nutri��o
	            1, 2, 3, 4, 5, 6, 7, 8, //Educa��o
	            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, //Protec. e Apoio legal
	            1, 2, 3, //Apoio Psico-Social
	            1, 2, 3, 4, //DPI (0-5 anos)
	            1, 2, 3, //Outros
            });

            // Set the ORDER NUMBERS IN DOMAIN from the List in Correct Way
            rowNumber = 1;
            totalRows = SupportServiceOrderInDomainByNumbers.Count;
            foreach (int orderInDomainByNumber in SupportServiceOrderInDomainByNumbers)
            {
	            if (rowNumber <= totalRows)
	            {
		            Sql(@"UPDATE sst SET sst.SupportServiceOrderInDomain = '" + orderInDomainByNumber + "' " +
		            @"FROM SupportServiceType sst 
		            INNER JOIN
		            (
			            SELECT sst.SupportServiceTypeID,
			            row_number() OVER(ORDER BY SupportServiceTypeID, DomainOrder ASC) as rowNumber
			            FROM SupportServiceType sst
			            WHERE sst.Tool = 'routine-visit'
		            ) sst2
		            ON sst.SupportServiceTypeID = sst2.SupportServiceTypeID AND sst2.rowNumber = " + rowNumber + "");
	            }
	            rowNumber++;
            }

            // DESCRIPTIONS LIST
            List<string> SupportServiceTypesDescriptions = new List<string>(new string[]
            {
	            "Sensibiliza��o/ Mobiliza��o para  Participa��o no grupo de poupan�a (Todos)",
	            "Incentivar para a realiza��o de pequenos neg�cios (todos)",
	            "Mobiliza��o e referencia para servi�os sociais (INAS) (Todos)",
	            "Participa ou continua a participar  num grupo de poupan�a? Se sim coloque X para todos os membros da fam�lia (Todos)",
	            "Aconselhamento sobre Preven��o de  HIV ( benefici�rios de 10 anos ou mais)",
	            "Sensibiliza��o/Mobiliza��o para  refer�ncia a testagem (ATS)-(Crian�a ou Adulto)",
	            "Sensibiliza��o/Mobiliza��o para iniciar o TARV (Crian�a ou Adulto)",
	            "Acompanhamento para ader�ncia ao TARV (Continuidade  no tratamento e toma correcta da medica��o)(Crian�a ou Adulto)",
	            "Sensibiliza��o/Mobiliza��o para cuidados HIV - Vida positiva) (Crian�a e/ou Adulto)",
	            "Sensibiliza��o para participa��o em grupos de PVHS ( benefici�rios de 10 anos ou mais)",
	            "Sensibiliza��o/Mobiliza��o para eliminar barreiras e facilitar acesso � testagem do HIV (Crian�a ou Adulto)",
	            "Sensibiliza��o para revela��o do seroestado (Crian�a ou Adulto)",
	            "Sensibiliza��o/Mobiliza��o sobre a import�ncia do cumprimento do calend�rios de vacina��o (Crian�a 0-5 anos)",
	            "Mobiliza��o/ Refer�ncia  para outros servi�os de sa�de (fora de HIV) (Crian�a ou Adulto)",
	            "Sensibiliza��o sobre higiene, �gua e  saneamento (Todos)",
	            "Aconselhamento sobre sa�de sexual reprodutiva ( benefici�rios de 10 anos ou mais)",
	            "Mobiliza��o/referencia para obten��o e uso correto de redes mosquiteiras (Crian�as e Mulheres Gravidas)",
	            "Rastreados para o HIV (0-17 anos) -> Teste n�o recomendado",
	            "Rastreados para o HIV (0-17 anos) -> Refer�ncia para testagem (ATS)",
	            "HIV-",
	            "HIV+ -> Em TARV",
	            "HIV+ -> N�o TARV",
	            "Conhece mas n�o revelou",
	            "N�o conhece",
	            "Sensibiliza��o para reabilita��o ou constru��o da casa (todos)",
	            "Mobiliza��o/Sensibiliza��o da comunidade para reabilita��o ou constru��o de casa de benefici�rios (todos)",
	            "Sensibiliza��o sobre  cuidados com a casa (casa fresca e ventilada) (Todos)",
	            "Resultado do rastreio do MUAC: Verde ",
	            "Resultado do rastreio do MUAC: Amarelo",
	            "Resultado do rastreio do MUAC: Vermelho",
	            "Mobilizacao e referencia de casos de desnutri��o para  o Programa de Reabilita��o Nutricional (PRN) ",
	            "Sensibilizacao/ Acompanhamento e acampanhamento na comunidade para ader�ncia a reabilita��o nutricional (consultas e toma de suplementos)",
	            "Educa��o / Aconselhamento Nutricional (amamenta��o, alimenta��o complementar/Equilibrada da fam�lia) (Todos)",
	            "Demonstra��o culin�ria para fam�lia (apoio na prepara��o de alimentos)(Todos)",
	            "Mobiliza��o/Demonstra��o de hortas caseiras (Todos)",
	            "Mobiliza��o para Matr�cula Escolar (Crian�as)",
	            "Apoio no pagamento ou isen��o de taxas escolares(Crian�as e adolescente e jovens no secund�rio de 18 a 20 anos)",
	            "Reintegra��o escolar (Crian�as)",
	            "Apoio/Sensibiliza��o para apoio no TPC (Crian�as)",
	            "Mobiliza��o para apoio em uniforme e/ou material escolar(Crian�as)",
	            "Mobiliza��o para perman�ncia na escola (Crian�as)",
	            "Monitoria da educa��o (A crian�a continua a frequentar a escola)",
	            "Monitoria do progresso escolar  (passagem de classe a ser preenchido no final do  ano escolar) (Crian�as)",
	            "Mobiliza��o/Refer�ncia aos servi�os de registo de nascimento(Crian�a e Adulto)",
	            "Registo de nascimento efectuado (comprovativo do registo)  (Crian�a ou adulto)",
	            "Apoio para obten��o de Atestado de pobreza   (Crian�a ou adulto)",
	            "Aconselhamento p�s-viol�ncia (todo tipo de viol�ncia)   (Crian�a ou adulto)",
	            "Mobiliza��o para acesso aos servi�os sa�de p�s-viol�ncia   (Crian�a ou adulto)",
	            "Mobilizar/Referir para o gabinete de atendimento de vitima de viol�ncia(pol�cia ou outra entidade)  (Crian�a ou adulto)",
	            "Habita��o alternativa em casos de ambiente propicio a viol�ncia (Crian�a)",
	            "Integra��o no grupo de adolescentes (clube, grupo de estudo�..)  (Adolescentes)",
	            "Sensibiliza��o e aconselhamento  dos adolescentes para Preven��o HIV e viol�ncia (Adolescentes)",
	            "Sensibiliza��o cuidador para preven��o de viol�ncia e riscos sexuais nas crian�as ",
	            "Mobiliza��o para a integra��o nos grupos de apoio (Igreja, m�e para m�e, etc)",
	            "Mobiliza��o /Referencia para apoio psicossocial especializado (Crian�a ou adulto)",
	            "Escutar e confortar a crian�a no caso de abandono/luto/abuso/descrimina��o (Crian�a)",
	            "Monitoria dos marcos de desenvolvimento ",
	            "Mobiliza��o/Refer�ncia Suspeita de atraso de desenvolvimento",
	            "Estimula��o da crian�a de acordo com a idade",
	            "Fabrico de Brinquedos",
	            "Monitoria do Plano de Ac��o da fam�lia",
	            "Monitoria da Ader�ncia ao tratamento (monitorar se cada pessoa HIV+ est� a aderir ao tratamento)",
	            "Atribui��o do Apoio Social de emerg�ncia",
            });

            // Set the DESCRIPTIONS from the List in Correct Way
            rowNumber = 1;
            totalRows = SupportServiceTypesDescriptions.Count;
            foreach (string description in SupportServiceTypesDescriptions)
            {
	            if (rowNumber <= totalRows)
	            {
		            Sql(@"UPDATE sst SET sst.Description = '" + description + "' " +
		            @"FROM SupportServiceType sst 
		            INNER JOIN
		            (
			            SELECT sst.SupportServiceTypeID,
			            row_number() OVER(ORDER BY SupportServiceTypeID, DomainOrder ASC) as rowNumber
			            FROM SupportServiceType sst
			            WHERE sst.Tool = 'routine-visit'
		            ) sst2
		            ON sst.SupportServiceTypeID = sst2.SupportServiceTypeID AND sst2.rowNumber = " + rowNumber + "");
	            }
	            rowNumber++;

            }

            // ORDER TYPE CODES IN DOMAIN LIST
            List<string> SupportServiceOrderInDomainByTypeCodes = new List<string>(new string[]
            {
	            "FE01", "FE02", "FE03", "FE04",
	            "SD01", "SD02", "SD03", "SD04", "SD05", "SD06", "SD07", "SD08", "SD09", "SD10", "SD11", "SD12", "SD13",
	            "HIV01", "HIV02", "HIV03", "HIV04", "HIV05", "HIV06", "HIV07",
	            "HAB01", "HAB02", "HAB03",
	            "MUAC01", "MUAC02", "MUAC03", "MUAC04", "MUAC05",
	            "AN01", "AN02", "AN03",
	            "ED01", "ED02", "ED03", "ED04", "ED05", "ED06", "ED07", "ED08",
	            "PAL01", "PAL02", "PAL03", "PAL04", "PAL05", "PAL06", "PAL07", "PAL08", "PAL09", "PAL10",
	            "APS01", "APS02", "APS03",
	            "DPI01", "DPI02", "DPI03", "DPI04",
	            "OTR01", "OTR02", "OTR03",
            });

            // Set the ORDER TYPE CODES IN DOMAIN from the List in Correct Way
            rowNumber = 1;
            totalRows = SupportServiceOrderInDomainByTypeCodes.Count;
            foreach (string orderInDomainByTypeCode in SupportServiceOrderInDomainByTypeCodes)
            {
	            if (rowNumber <= totalRows)
	            {
		            Sql(@"UPDATE sst SET sst.SupportServiceOrderInDomainTypeCode = '" + orderInDomainByTypeCode + "' " +
		            @"FROM SupportServiceType sst 
		            INNER JOIN
		            (
			            SELECT sst.SupportServiceTypeID,
			            row_number() OVER(ORDER BY SupportServiceTypeID, DomainOrder ASC) as rowNumber
			            FROM SupportServiceType sst
			            WHERE sst.Tool = 'routine-visit'
		            ) sst2
		            ON sst.SupportServiceTypeID = sst2.SupportServiceTypeID AND sst2.rowNumber = " + rowNumber + "");
	            }
	            rowNumber++;
            }
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupportServiceType", "SupportServiceOrderInDomainTypeCode");
        }
    }
}
