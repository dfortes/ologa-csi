namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_New_RoutineVisit_Description : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE sst
                SET sst.Description = 
                (CASE WHEN sst.SupportServiceOrderInDomain = 89 THEN 'Sensibiliza��o/ Mobiliza��o para  Participa��o no grupo de poupan�a (Todos)' 
                WHEN sst.SupportServiceOrderInDomain = 90 THEN 'Incentivar para a realiza��o de pequenos neg�cios (todos)'
                WHEN sst.SupportServiceOrderInDomain = 91 THEN 'Mobiliza��o e referencia para servi�os sociais (INAS) (Todos)'
                WHEN sst.SupportServiceOrderInDomain = 92 THEN 'Participa ou continua a participar  num grupo de poupan�a? Se sim coloque X para todos os membros da fam�lia (Todos)'
                WHEN sst.SupportServiceOrderInDomain = 93 THEN 'Aconselhamento sobre Preven��o de  HIV ( benefici�rios de 10 anos ou mais)'
                WHEN sst.SupportServiceOrderInDomain = 94 THEN 'Sensibiliza��o/Mobiliza��o para  refer�ncia a testagem (ATS)-(Crian�a ou Adulto)'
                WHEN sst.SupportServiceOrderInDomain = 95 THEN 'Sensibiliza��o/Mobiliza��o para iniciar o TARV (Crian�a ou Adulto)'
                WHEN sst.SupportServiceOrderInDomain = 96 THEN 'Acompanhamento para ader�ncia ao TARV (Continuidade  no tratamento e toma correcta da medica��o)(Crian�a ou Adulto)'
                WHEN sst.SupportServiceOrderInDomain = 97 THEN 'Sensibiliza��o/Mobiliza��o para cuidados HIV - Vida positiva) (Crian�a e/ou Adulto)'
                WHEN sst.SupportServiceOrderInDomain = 98 THEN 'Sensibiliza��o para participa��o em grupos de PVHS ( benefici�rios de 10 anos ou mais)'
                WHEN sst.SupportServiceOrderInDomain = 99 THEN 'Sensibiliza��o/Mobiliza��o para eliminar barreiras e facilitar acesso � testagem do HIV (Crian�a ou Adulto)'
                WHEN sst.SupportServiceOrderInDomain = 100 THEN 'Sensibiliza��o para revela��o do seroestado (Crian�a ou Adulto)'
                WHEN sst.SupportServiceOrderInDomain = 101 THEN 'Sensibiliza��o/Mobiliza��o sobre a import�ncia do cumprimento do calend�rios de vacina��o (Crian�a 0-5 anos)'
                WHEN sst.SupportServiceOrderInDomain = 102 THEN 'Mobiliza��o/ Refer�ncia  para outros servi�os de sa�de (fora de HIV) (Crian�a ou Adulto)'
                WHEN sst.SupportServiceOrderInDomain = 103 THEN 'Sensibiliza��o sobre higiene, �gua e  saneamento (Todos)'
                WHEN sst.SupportServiceOrderInDomain = 104 THEN 'Aconselhamento sobre sa�de sexual reprodutiva ( benefici�rios de 10 anos ou mais)'
                WHEN sst.SupportServiceOrderInDomain = 105 THEN 'Mobiliza��o/referencia para obten��o e uso correto de redes mosquiteiras (Crian�as e Mulheres Gravidas)'
                WHEN sst.SupportServiceOrderInDomain = 106 THEN 'Rastreados para o HIV (0-17 anos) -> Teste n�o recomendado'
                WHEN sst.SupportServiceOrderInDomain = 107 THEN 'Rastreados para o HIV (0-17 anos) -> Refer�ncia para testagem (ATS)'
                WHEN sst.SupportServiceOrderInDomain = 108 THEN 'HIV-'
                WHEN sst.SupportServiceOrderInDomain = 109 THEN 'HIV+ -> Em TARV'
                WHEN sst.SupportServiceOrderInDomain = 110 THEN 'HIV+ -> N�o TARV'
                WHEN sst.SupportServiceOrderInDomain = 111 THEN 'Conhece mas n�o revelou'
                WHEN sst.SupportServiceOrderInDomain = 112 THEN 'N�o conhece'
                WHEN sst.SupportServiceOrderInDomain = 113 THEN 'Sensibiliza��o para reabilita��o ou constru��o da casa (todos)'
                WHEN sst.SupportServiceOrderInDomain = 114 THEN 'Mobiliza��o/Sensibiliza��o da comunidade para reabilita��o ou constru��o de casa de benefici�rios (todos)'
                WHEN sst.SupportServiceOrderInDomain = 115 THEN 'Sensibiliza��o sobre  cuidados com a casa (casa fresca e ventilada) (Todos)'
                WHEN sst.SupportServiceOrderInDomain = 116 THEN 'Resultado do rastreio do MUAC: Verde '
                WHEN sst.SupportServiceOrderInDomain = 117 THEN 'Resultado do rastreio do MUAC: Amarelo'
                WHEN sst.SupportServiceOrderInDomain = 118 THEN 'Resultado do rastreio do MUAC: Vermelho'
                WHEN sst.SupportServiceOrderInDomain = 119 THEN 'Mobilizacao e referencia de casos de desnutri��o para  o Programa de Reabilita��o Nutricional (PRN) '
                WHEN sst.SupportServiceOrderInDomain = 120 THEN 'Sensibilizacao/ Acompanhamento e acampanhamento na comunidade para ader�ncia a reabilita��o nutricional (consultas e toma de suplementos)'
                WHEN sst.SupportServiceOrderInDomain = 121 THEN 'Educa��o / Aconselhamento Nutricional (amamenta��o, alimenta��o complementar/Equilibrada da fam�lia) (Todos)'
                WHEN sst.SupportServiceOrderInDomain = 122 THEN 'Demonstra��o culin�ria para fam�lia (apoio na prepara��o de alimentos)(Todos)'
                WHEN sst.SupportServiceOrderInDomain = 123 THEN 'Mobiliza��o/Demonstra��o de hortas caseiras (Todos)'
                WHEN sst.SupportServiceOrderInDomain = 124 THEN 'Mobiliza��o para Matr�cula Escolar (Crian�as)'
                WHEN sst.SupportServiceOrderInDomain = 125 THEN 'Apoio no pagamento ou isen��o de taxas escolares(Crian�as e adolescente e jovens no secund�rio de 18 a 20 anos)'
                WHEN sst.SupportServiceOrderInDomain = 126 THEN 'Reintegra��o escolar (Crian�as)'
                WHEN sst.SupportServiceOrderInDomain = 127 THEN 'Apoio/Sensibiliza��o para apoio no TPC (Crian�as)'
                WHEN sst.SupportServiceOrderInDomain = 128 THEN 'Mobiliza��o para apoio em uniforme e/ou material escolar(Crian�as)'
                WHEN sst.SupportServiceOrderInDomain = 129 THEN 'Mobiliza��o para perman�ncia na escola (Crian�as)'
                WHEN sst.SupportServiceOrderInDomain = 130 THEN 'Monitoria da educa��o (A crian�a continua a frequentar a escola)'
                WHEN sst.SupportServiceOrderInDomain = 131 THEN 'Monitoria do progresso escolar  (passagem de classe a ser preenchido no final do  ano escolar) (Crian�as)'
                WHEN sst.SupportServiceOrderInDomain = 132 THEN 'Mobiliza��o/Refer�ncia aos servi�os de registo de nascimento(Crian�a e Adulto)'
                WHEN sst.SupportServiceOrderInDomain = 133 THEN 'Registo de nascimento efectuado (comprovativo do registo)  (Crian�a ou adulto)'
                WHEN sst.SupportServiceOrderInDomain = 134 THEN 'Apoio para obten��o de Atestado de pobreza   (Crian�a ou adulto)'
                WHEN sst.SupportServiceOrderInDomain = 135 THEN 'Aconselhamento p�s-viol�ncia (todo tipo de viol�ncia)   (Crian�a ou adulto)'
                WHEN sst.SupportServiceOrderInDomain = 136 THEN 'Mobiliza��o para acesso aos servi�os sa�de p�s-viol�ncia   (Crian�a ou adulto)'
                WHEN sst.SupportServiceOrderInDomain = 137 THEN 'Mobilizar/Referir para o gabinete de atendimento de vitima de viol�ncia(pol�cia ou outra entidade)  (Crian�a ou adulto)'
                WHEN sst.SupportServiceOrderInDomain = 138 THEN 'Habita��o alternativa em casos de ambiente propicio a viol�ncia (Crian�a)'
                WHEN sst.SupportServiceOrderInDomain = 139 THEN 'Integra��o no grupo de adolescentes (clube, grupo de estudo�..)  (Adolescentes)'
                WHEN sst.SupportServiceOrderInDomain = 140 THEN 'Sensibiliza��o e aconselhamento  dos adolescentes para Preven��o HIV e viol�ncia (Adolescentes)'
                WHEN sst.SupportServiceOrderInDomain = 141 THEN 'Sensibiliza��o cuidador para preven��o de viol�ncia e riscos sexuais nas crian�as '
                WHEN sst.SupportServiceOrderInDomain = 142 THEN 'Mobiliza��o para a integra��o nos grupos de apoio (Igreja, m�e para m�e, etc)'
                WHEN sst.SupportServiceOrderInDomain = 143 THEN 'Mobiliza��o /Referencia para apoio psicossocial especializado (Crian�a ou adulto)'
                WHEN sst.SupportServiceOrderInDomain = 144 THEN 'Escutar e confortar a crian�a no caso de abandono/luto/abuso/descrimina��o (Crian�a)'
                WHEN sst.SupportServiceOrderInDomain = 145 THEN 'Monitoria dos marcos de desenvolvimento '
                WHEN sst.SupportServiceOrderInDomain = 146 THEN 'Mobiliza��o/Refer�ncia Suspeita de atraso de desenvolvimento'
                WHEN sst.SupportServiceOrderInDomain = 147 THEN 'Estimula��o da crian�a de acordo com a idade'
                WHEN sst.SupportServiceOrderInDomain = 148 THEN 'Fabrico de Brinquedos'
                WHEN sst.SupportServiceOrderInDomain = 149 THEN 'Monitoria do Plano de Ac��o da fam�lia'
                WHEN sst.SupportServiceOrderInDomain = 150 THEN 'Monitoria da Ader�ncia ao tratamento (monitorar se cada pessoa HIV+ est� a aderir ao tratamento)'
                WHEN sst.SupportServiceOrderInDomain = 151 THEN 'Atribui��o do Apoio Social de emerg�ncia'
                ELSE  sst.Description
                END)
                FROM [CSI_PROD].[dbo].[SupportServiceType] sst
                WHERE sst.Tool = 'routine-visit'");
        }
        
        public override void Down()
        {
        }
    }
}
