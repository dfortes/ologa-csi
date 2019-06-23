namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeDescriptionAndPopulateSupportServiceType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupportServiceType", "TypeDescription", c => c.String());

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o/ Mobiliza��o para Participa��o no grupo de poupan�a (Todos)', 'FE', 'Fort. econ�mico', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Incentivar para a realiza��o de pequenos neg�cios (todos)', 'FE', 'Fort. econ�mico', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o e referencia para servi�os sociais (INAS)', 'FE', 'Fort. econ�mico', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Participa ou continua a participar num grupo de poupan�a? Se sim coloque X para todos os membros da fam�lia', 'FE', 'Fort. econ�mico', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Aconselhamento sobre Preven��o de HIV ( benefici�rios de 10 anos ou mais)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o/Mobiliza��o para refer�ncia a testagem (ATS)-(Crian�a ou Adulto)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o/Mobiliza��o para iniciar o TARV (Crian�a ou Adulto)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Acompanhamento para ader�ncia ao TARV (Continuidade no tratamento e toma correcta da medica��o)(Crian�a ou Adulto)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o/Mobiliza��o para cuidados HIV - Vida positiva) (Crian�a e/ou Adulto)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o para participa��o em grupos de PVHS ( benefici�rios de 10 anos ou mais)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o/Mobiliza��o para eliminar barreiras e facilitar acesso � testagem do HIV (Crian�a ou Adulto)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o para revela��o do seroestado (Crian�a ou Adulto)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o/Mobiliza��o sobre a import�ncia do cumprimento do calend�rios de vacina��o (Crian�a 0-5 anos)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o/ Refer�ncia  para outros servi�os de sa�de (fora de HIV) (Crian�a ou Adulto)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o sobre higiene, �gua e  saneamento (Todos)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Aconselhamento sobre sa�de sexual reprodutiva ( benefici�rios de 10 anos ou mais)', 'SD', 'Sa�de', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o/referencia para obten��o e uso correto de redes mosquiteiras (Crian�as e Mulheres Gravidas)', 'SD', 'Sa�de', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Rastreados para o HIV (0-17 anos) -> Teste n�o recomendado', 'HIV', 'Seroestado', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Rastreados para o HIV (0-17 anos) -> Refer�ncia para testagem (ATS)', 'HIV', 'Seroestado', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('HIV-', 'HIV', 'Seroestado', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('HIV+ -> Em TARV', 'HIV', 'Seroestado', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('HIV+ -> N�o TARV', 'HIV', 'Seroestado', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Conhece mas n�o revelou', 'HIV', 'Seroestado', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('N�o conhece', 'HIV', 'Seroestado', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o para reabilita��o ou constru��o da casa (todos)', 'HAB', 'Habita��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o/Sensibiliza��o da comunidade para reabilita��o ou constru��o de casa de benefici�rios (todos)', 'HAB', 'Habita��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o sobre  cuidados com a casa (casa fresca e ventilada) (Todos)', 'HAB', 'Habita��o', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Resultado do rastreio do MUAC: Verde', 'MUAC', 'MUAC (6-69 meses)', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Resultado do rastreio do MUAC: Amarelo', 'MUAC', 'MUAC (6-69 meses)', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Resultado do rastreio do MUAC: Vermelho ', 'MUAC', 'MUAC (6-69 meses)', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobilizacao e referencia de casos de desnutri��o para  o Programa de Reabilita��o Nutricional (PRN)', 'MUAC', 'MUAC (6-69 meses)', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibilizacao/ Acompanhamento e acampanhamento na comunidade para ader�ncia a reabilita��o nutricional (consultas e toma de suplementos)', 'MUAC', 'MUAC (6-69 meses)', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Educa��o / Aconselhamento Nutricional (amamenta��o, alimenta��o complementar/Equilibrada da fam�lia) (Todos)', 'AN', 'Alim. e Nutri��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Demonstra��o culin�ria para fam�lia (apoio na prepara��o de alimentos)(Todos)', 'AN', 'Alim. e Nutri��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o/Demonstra��o de hortas caseiras (Todos)', 'AN', 'Alim. e Nutri��o', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o para Matr�cula Escolar (Crian�as)', 'ED', 'Educa��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Apoio no pagamento ou isen��o de taxas escolares(Crian�as e adolescente e jovens no secund�rio de 18 a 21 anos)', 'ED', 'Educa��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Reintegra��o escolar (Crian�as)', 'ED', 'Educa��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Apoio/Sensibiliza��o para apoio no TPC (Crian�as)', 'ED', 'Educa��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o para apoio em uniforme e/ou material escolar(Crian�as)', 'ED', 'Educa��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o para perman�ncia na escola (Crian�as)', 'ED', 'Educa��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Monitoria da educa��o (A crian�a continua a frequentar a escola)', 'ED', 'Educa��o', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Monitoria do progresso escolar  (passagem de classe a ser preenchido no final do  ano escolar) (Crian�as)', 'ED', 'Educa��o', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o/Refer�ncia aos servi�os de registo de nascimento(Crian�a e Adulto)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Registo de nascimento efectuado (comprovativo do registo)  (Crian�a ou adulto)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Apoio para obten��o de Atestado de pobreza   (Crian�a ou adulto)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Aconselhamento p�s-viol�ncia (todo tipo de viol�ncia)   (Crian�a ou adulto)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o para acesso aos servi�os sa�de p�s-viol�ncia   (Crian�a ou adulto)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobilizar/Referir para o gabinete de atendimento de vitima de viol�ncia(pol�cia ou outra entidade)  (Crian�a ou adulto)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Habita��o alternativa em casos de ambiente propicio a viol�ncia  ou de viol�ncia Crian�a)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Integra��o no grupo de adolescentes (clube, grupo de estudo�..)  (Adolescentes)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o e aconselhamento  dos adolescentes para Preven��o HIV e viol�ncia (Adolescentes)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Sensibiliza��o cuidador para preven��o de viol�ncia e riscos sexuais nas crian�as (Todos)', 'PAL', 'Protec. e Apoio legal', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o para a integra��o nos grupos de apoio (Igreja, m�e para m�e, etc) (Todos)', 'APS', 'Apoio Psico-Social', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o /Referencia para apoio psicossocial especializado (Crian�a ou adulto)', 'APS', 'Apoio Psico-Social', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Escutar e confortar a crian�a no caso de abandono/luto/abuso/descrimina��o (Crian�a)', 'APS', 'Apoio Psico-Social', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Monitoria dos marcos de desenvolvimento', 'DPI', 'DPI (0-5 anos)', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Mobiliza��o/Refer�ncia Suspeita de atraso de desenvolvimento', 'DPI', 'DPI (0-5 anos)', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Estimula��o da crian�a de acordo com a idade', 'DPI', 'DPI (0-5 anos)', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Fabrico de Brinquedos', 'DPI', 'DPI (0-5 anos)', 'routine-visit')");

            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Monitoria do Plano de Ac��o da fam�lia', 'OTR', 'Outros', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Monitoria da Ader�ncia ao tratamento (monitorar se cada pessoa HIV+ est� a aderir ao tratamento)', 'OTR', 'Outros', 'routine-visit')");
            Sql(@"INSERT INTO SupportServiceType ([Description], TypeCode, TypeDescription, Tool)
                VALUES ('Atribui��o do Apoio Social de emerg�ncia', 'OTR', 'Outros', 'routine-visit')");
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupportServiceType", "TypeDescription");
        }
    }
}
