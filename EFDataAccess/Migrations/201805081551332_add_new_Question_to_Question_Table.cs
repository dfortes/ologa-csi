namespace EFDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_new_Question_to_Question_Table : DbMigration
    {
        public override void Up()
        {
            Sql(@"BEGIN
	                IF NOT EXISTS (SELECT * FROM Domain)
	                BEGIN
		                INSERT INTO [Domain] (Description, DomainCode, DomainColor, [Order], [OrderForRoutineVisit]) VALUES ('Alimentac�o/Nutri��o', 'AN', 'Lime', 2,2);
		                INSERT INTO [Domain] (Description, DomainCode, DomainColor, [Order], [OrderForRoutineVisit]) VALUES ('Educa��o', 'ED', 'Blue',3,4);
		                INSERT INTO [Domain] (Description, DomainCode, DomainColor, [Order], [OrderForRoutineVisit]) VALUES ('Sa�de', 'SD', 'Yellow',1,5);
		                INSERT INTO [Domain] (Description, DomainCode, DomainColor, [Order], [OrderForRoutineVisit]) VALUES ('Protec��o e Apoio Legal', 'PL', 'Cyan',4,7);
		                INSERT INTO [Domain] (Description, DomainCode, DomainColor, [Order], [OrderForRoutineVisit]) VALUES ('Apoio Psico social', 'APS', 'Gray',6,6);
		                INSERT INTO [Domain] (Description, DomainCode, DomainColor, [Order], [OrderForRoutineVisit]) VALUES ('Fortalecimento Econ�mico', 'FE', 'Red',7,1);
		                INSERT INTO [Domain] (Description, DomainCode, DomainColor, [Order], [OrderForRoutineVisit]) VALUES ('Habita��o', 'Hab', 'Green',5,3);
	                END
                END");

            Sql(@"INSERT INTO  [Question] ([Description],[Code],[Goal],[DomainID],[FileID],[ExcludeFromReport],[QuestionOrder],[QuestionVersion])
                    VALUES('1 - Cumpre com o calend�rio de vacina��o? (0-5 anos)','3A','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_1'),0,1,2),
                    ('2 - Bebe �gua tratada?','3B','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_2'),0,2,2),
                    ('3 - As �ltimas 3 vezes que a crian�a sentiu-se mal, foi atendida na unidade sanit�ria?','3C','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_3'),0,3,2),
                    ('4 - A crian�a esteve doente nas ultimas duas semanas?','3D','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_4'),0,4,2),
                    ('5 - Dorme dentro de uma rede mosquiteira tratada?','3E','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_5'),0,5,2),
                    ('6 - Tem acesso a uma latrina limpa, ou casa de banho e acesso a �gua para lavar as m�os?','3F','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_6'),0,6,2),
                    ('7 - Teve educa��o acerca do HIV nos �ltimos 2 meses? (10 - 17 anos)','3G','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_7'),0,7,2),
                    ('8 - Conhece o seu estado de HIV?','3H','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_8'),0,8,2),
                    ('9 - A crian�a est� em TARV (Se for HIV+)?','3I','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_9'),0,9,2),
                    ('10 - Teve educa��o ou acesso aos servi�os de Sa�de Sexual e Reproductiva? (10-17 anos)','3J','Goal to be set',3,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_10'),0,10,2),
                    ('11 - A crian�a come pelo menos duas refei��es por dia?','2A','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_11'),0,11,2),
                    ('12 - A crian�a variou os alimentos nos �ltimos 2 dias?','2B','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_12'),0,12,2),
                    ('13 - A crian�a est� inscrita no ensino pre-escolar, prim�rio, secund�rio ou curso professional? (3-5 ou 6-17 anos)','2C','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_13'),0,13,2),
                    ('14 - Foi � escola/escolinha todos os dias durante a semana anterior? (3-5 ou 6-17 anos)','2D','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_14'),0,14,2),
                    ('15 - A crian�a tem uniforme escolar? (6-17 anos)','2E','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_15'),0,15,2),
                    ('16 - A crian�a tem material escolar? (6-17 anos)','2F','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_16'),0,16,2),
                    ('17 - A crian�a tem acompanhamento dos pais/cuidadores na vida escolar? (3-5 ou 6-17 anos)','2G','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_17'),0,17,2),
                    ('18 - A crian�a tem um bom aproveitamento escolar? (3-5 ou 6-17 anos)','2H','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_18'),0,18,2),
                    ('19 - A crian�a faz TPC e revis�o das mat�rias? (6-17 anos)','2I','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_19'),0,19,2),
                    ('20 - A crian�a passou de classe no ano passado? (6-17 anos)','2J','Goal to be set',2,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_20'),0,20,2),
                    ('21 - A crian�a � tratada de forma igual em rela��o as outras crian�as da fam�lia?','4A','Goal to be set',4,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_21'),0,21,2),
                    ('22 - A crian�a teve educa��o sobre direitos e deveres da crian�a? (3-17 anos)','4B','Goal to be set',4,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_22'),0,22,2),
                    ('23 - A crian�a tem registo de nascimento?','4C','Goal to be set',4,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_23'),0,23,2),
                    ('24 - A crian�a foi ou � v�tima de viol�ncia (psic�loga/f�sica/sexual/neglig�ncia)?','4D','Goal to be set',4,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_24'),0,24,2),
                    ('25 - A crian�a respeita aos mais velhos (n�o desafia nem se revolta)? (5-17 anos)','5A','Goal to be set',5,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_25'),0,25,2),
                    ('26 - A crian�a participa de servi�os religiosos ou grupos de suporte caso deseje? (5-17 anos)','5B','Goal to be set',5,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_26'),0,26,2),
                    ('27 - Tem um bom amigo ou fala com um adulto acerca dos problemas? (5-17 anos)','5C','Goal to be set',5,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_27'),0,27,2),
                    ('28 - A crian�a brinca com outras crian�as?','5D','Goal to be set',5,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_28'),0,28,2),
                    ('29 - A crian�a est� envolvida em alguma actividade onde consegue expressar a sua opini�o (Fam�lia, clube escolar, CCPC, etc.)? (5-17 anos)','5E','Goal to be set',5,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_29'),0,29,2),
                    ('30 - O cuidador � capaz de dar exemplo de uma brincadeira que fez com a crian�a? (0-5 anos)','5F','Goal to be set',5,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_30'),0,30,2),
                    ('31 - Casa adequada, segura, seca e ventilada, com paredes e tecto fortes?','7A','Goal to be set',7,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_31'),0,31,2),
                    ('32 - A crian�a beneficia das actividades de gera��o de renda da fam�lia (Ex: Machamba, cria��o de animais)?','6A','Goal to be set',6,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_32'),0,32,2),
                    ('33 - O cuidador participa em algum grupo de poupan�a?','6B','Goal to be set',6,(SELECT FileID FROM  [File] WHERE [FileName] = 'new_MAC_33'),0,33,2)", false);
        }

        public override void Down()
        {
            Sql(@"DELETE FROM  [Question] WHERE QuestionVersion = 2", false);

        }
    }
}
