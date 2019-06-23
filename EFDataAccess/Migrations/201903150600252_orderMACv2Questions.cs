namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderMACv2Questions : DbMigration
    {
        public override void Up()
        {
            Sql(@" --
                 UPDATE [Question] SET [QuestionOrder] = 1 	where description='1 - Cumpre com o calend�rio de vacina��o? (0-5 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 2 	where description='2 - Bebe �gua tratada?'
	             UPDATE [Question] SET [QuestionOrder] = 3 	where description='3 - As �ltimas 3 vezes que a crian�a sentiu-se mal, foi atendida na unidade sanit�ria?'
	             UPDATE [Question] SET [QuestionOrder] = 4 	where description='4 - A crian�a esteve doente nas ultimas duas semanas?'
	             UPDATE [Question] SET [QuestionOrder] = 5 	where description='5 - Dorme dentro de uma rede mosquiteira tratada?'
	             UPDATE [Question] SET [QuestionOrder] = 6 	where description='6 - Tem acesso a uma latrina limpa, ou casa de banho e acesso a �gua para lavar as m�os?'
	             UPDATE [Question] SET [QuestionOrder] = 7 	where description='7 - Teve educa��o acerca do HIV nos �ltimos 2 meses? (10 - 17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 8 	where description='8 - Conhece o seu estado de HIV?'
	             UPDATE [Question] SET [QuestionOrder] = 9 	where description='9 - A crian�a est� em TARV (Se for HIV+)?'
	             UPDATE [Question] SET [QuestionOrder] = 10	where description='10 - Teve educa��o ou acesso aos servi�os de Sa�de Sexual e Reproductiva? (10-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 11	where description='11 - A crian�a come pelo menos duas refei��es por dia?'
	             UPDATE [Question] SET [QuestionOrder] = 12	where description='12 - A crian�a variou os alimentos nos �ltimos 2 dias?'
	             UPDATE [Question] SET [QuestionOrder] = 13	where description='13 - A crian�a est� inscrita no ensino pre-escolar, prim�rio, secund�rio ou curso professional? (3-5 ou 6-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 14	where description='14 - Foi � escola/escolinha todos os dias durante a semana anterior? (3-5 ou 6-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 15	where description='15 - A crian�a tem uniforme escolar? (6-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 16	where description='16 - A crian�a tem material escolar? (6-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 17	where description='17 - A crian�a tem acompanhamento dos pais/cuidadores na vida escolar? (3-5 ou 6-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 18	where description='18 - A crian�a tem um bom aproveitamento escolar? (3-5 ou 6-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 19	where description='19 - A crian�a faz TPC e revis�o das mat�rias? (6-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 20	where description='20 - A crian�a passou de classe no ano passado? (6-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 21	where description='21 - A crian�a � tratada de forma igual em rela��o as outras crian�as da fam�lia?'
	             UPDATE [Question] SET [QuestionOrder] = 22	where description='22 - A crian�a teve educa��o sobre direitos e deveres da crian�a? (3-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 23	where description='23 - A crian�a tem registo de nascimento?'
	             UPDATE [Question] SET [QuestionOrder] = 24	where description='24 - A crian�a foi ou � v�tima de viol�ncia (psic�loga/f�sica/sexual/neglig�ncia)?'
	             UPDATE [Question] SET [QuestionOrder] = 25	where description='25 - A crian�a respeita aos mais velhos (n�o desafia nem se revolta)? (5-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 26	where description='26 - A crian�a participa de servi�os religiosos ou grupos de suporte caso deseje? (5-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 27	where description='27 - Tem um bom amigo ou fala com um adulto acerca dos problemas? (5-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 28	where description='28 - A crian�a brinca com outras crian�as?'
	             UPDATE [Question] SET [QuestionOrder] = 29	where description='29 - A crian�a est� envolvida em alguma actividade onde consegue expressar a sua opini�o (Fam�lia, clube escolar, CCPC, etc.)? (5-17 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 30	where description='30 - O cuidador � capaz de dar exemplo de uma brincadeira que fez com a crian�a? (0-5 anos)'
	             UPDATE [Question] SET [QuestionOrder] = 31	where description='31 - Casa adequada, segura, seca e ventilada, com paredes e tecto fortes?'
	             UPDATE [Question] SET [QuestionOrder] = 32	where description='32 - A crian�a beneficia das actividades de gera��o de renda da fam�lia (Ex: Machamba, cria��o de animais)?'
	             UPDATE [Question] SET [QuestionOrder] = 33	where description='33 - O cuidador participa em algum grupo de poupan�a?'
              ");
        }

        public override void Down()
        {
        }
    }
}
