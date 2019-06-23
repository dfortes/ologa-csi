﻿using EFDataAccess.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using EFDataAccess.DTO;
using System.Data;
using VPPS.CSI.Domain;
using System.Collections;
using EFDataAccess.DTO.AgreggatedDTO;
using System.Reflection;
using EFDataAccess.Services;
using EFDataAccess.DTO.SummaryReportsDTO;

namespace EFDataAccess.Services.ReportServices.Version_2019
{
    public class SummaryReports : BaseService
    {
        public SummaryReports(UnitOfWork uow) : base(uow) { }

        // Resumo de Novos Beneficiários
        public static String QueryNewBeneficiariesSummary =
        @"SELECT
	            p.ChiefPartner--<<ReplaceColumn<<--
	            As Partner,
	            ISNULL(obj_Age.btw_x_1_M, 0) As btw_x_1_M,
	            ISNULL(obj_Age.btw_1_4_M, 0) AS btw_1_4_M,
	            ISNULL(obj_Age.btw_5_9_M, 0) AS btw_5_9_M,
	            ISNULL(obj_Age.btw_10_14_M, 0) AS btw_10_14_M,
	            ISNULL(obj_Age.btw_15_17_M, 0) AS btw_15_17_M,
	            ISNULL(obj_Age.btw_18_24_M, 0) AS btw_18_24_M,
	            ISNULL(obj_Age.btw_25_x_M, 0) AS btw_25_x_M,
	            ISNULL(obj_Age.btw_x_1_F, 0) AS btw_x_1_F,
	            ISNULL(obj_Age.btw_1_4_F, 0) AS btw_1_4_F,
	            ISNULL(obj_Age.btw_5_9_F, 0) AS btw_5_9_F,
	            ISNULL(obj_Age.btw_10_14_F, 0) AS btw_10_14_F,
	            ISNULL(obj_Age.btw_15_17_F, 0) AS btw_15_17_F,
	            ISNULL(obj_Age.btw_18_24_F, 0) AS btw_18_24_F,
	            ISNULL(obj_Age.btw_25_x_F, 0) AS btw_25_x_F,
	            ISNULL(obj_Age.ovc_father, 0) As ovc_father,
	            ISNULL(obj_Age.ovc_mother, 0) As ovc_mother,
	            ISNULL(obj_Age.ovc_both, 0) As ovc_both,
	            ISNULL(obj_age.Went_To_School, 0) AS Went_To_School,
	            ISNULL(obj_age.IsPartSavingGroup, 0) AS IsPartSavingGroup,
	
	            ISNULL(hiv_obj.HIV_N_Child, 0)  AS HIV_N_Child,
	            ISNULL(hiv_obj.HIV_P_IN_TARV_Child, 0)  AS HIV_P_IN_TARV_Child,
	            ISNULL(hiv_obj.HIV_P_NOT_TARV_Child, 0)  AS HIV_P_NOT_TARV_Child,
	            ISNULL(hiv_obj.HIV_KNOWN_NREVEAL_Child, 0)  AS HIV_KNOWN_NREVEAL_Child,
	            ISNULL(hiv_obj.HIV_NOT_RECOMMENDED_Child, 0)  AS  HIV_NOT_RECOMMENDED_Child,
	            ISNULL(hiv_obj.HIV_UNKNOWN_Child, 0)  AS HIV_UNKNOWN_Child,
	            ISNULL(hiv_obj.HIV_N_Adult, 0)  AS HIV_N_Adult,
	            ISNULL(hiv_obj.HIV_P_IN_TARV_Adult, 0)  AS HIV_P_IN_TARV_Adult,
	            ISNULL(hiv_obj.HIV_P_NOT_TARV_Adult, 0)  AS HIV_P_NOT_TARV_Adult,
	            ISNULL(hiv_obj.HIV_KNOWN_NREVEAL_Adult, 0)  AS  HIV_KNOWN_NREVEAL_Adult,
	            ISNULL(hiv_obj.HIV_UNKNOWN_Adult, 0)  AS HIV_UNKNOWN_Adult,
	            ISNULL(hiv_obj.HIVTracked, 0)  AS HIVTracked,

	            ISNULL(ref_origin_obj.US, 0) As US,
	            ISNULL(ref_origin_obj.Com, 0) As Com,
	            ISNULL(ref_origin_obj.Parceiro_Clínico, 0) As Parceiro_Clínico,
	            ISNULL(ref_origin_obj.Parceiro_Populacoes_Chave, 0) As Parceiro_Populacoes_Chave,
	            ISNULL(ref_origin_obj.OCBS, 0) As OCBS,
	            ISNULL(ref_origin_obj.Others, 0) As Others
	
            FROM
            (
	            SELECT
		            ChiefPartner--<<ReplaceColumn<<--
	            FROM
	            (
		            SELECT cp.Name As ChiefPartner, p.Name As Partner
		            FROM  [Partner] p
		            inner join  [Partner] cp on (p.SuperiorId = cp.PartnerID)
		            Where p.CollaboratorRoleID = 1
	            ) p
	            group by p.ChiefPartner--<<ReplaceColumn<<--
            ) p
            LEFT JOIN
            (
	            SELECT
		            obj_age.ChiefPartner--<<ReplaceColumn<<--
	                ,
		            SUM(obj_Age.btw_x_1_M) As btw_x_1_M,
		            SUM(obj_Age.btw_1_4_M) AS btw_1_4_M,
		            SUM(obj_Age.btw_5_9_M) AS btw_5_9_M,
		            SUM(obj_Age.btw_10_14_M) AS btw_10_14_M,
		            SUM(obj_Age.btw_15_17_M) AS btw_15_17_M,
		            SUM(obj_Age.btw_18_24_M) AS btw_18_24_M,
		            SUM(obj_Age.btw_25_x_M) AS btw_25_x_M,
		            SUM(obj_Age.btw_x_1_F) AS btw_x_1_F,
		            SUM(obj_Age.btw_1_4_F) AS btw_1_4_F,
		            SUM(obj_Age.btw_5_9_F) AS btw_5_9_F,
		            SUM(obj_Age.btw_10_14_F) AS btw_10_14_F,
		            SUM(obj_Age.btw_15_17_F) AS btw_15_17_F,
		            SUM(obj_Age.btw_18_24_F) AS btw_18_24_F,
		            SUM(obj_Age.btw_25_x_F) AS btw_25_x_F,		                            
		            SUM(obj_Age.ovc_father) As ovc_father,
		            SUM(obj_Age.ovc_mother) As ovc_mother,
		            SUM(obj_Age.ovc_both) As ovc_both,
		            SUM(obj_age.Went_To_School) AS Went_To_School,
		            SUM(obj_age.IsPartSavingGroup) AS IsPartSavingGroup
	            FROM
	            (
		            SELECT
			            cp.Name As ChiefPartner,
			            p.Name As Partner,
			            count(ben.BeneficiaryID) as ID,
			            ben.FirstName As FirstName, 
			            ben.LastName As LastName, 
			            btw_x_1_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) < 12 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_1_4_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 12 AND 59 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_5_9_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 60 AND 119 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_10_14_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 120 AND 179 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_15_17_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 180 AND 215 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_18_24_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 216 AND 299 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_25_x_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) >= 300 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_x_1_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) < 12 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_1_4_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 12 AND 59 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_5_9_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 60 AND 119 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_10_14_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 120 AND 179 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_15_17_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 180 AND 215 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_18_24_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 216 AND 299 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_25_x_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) >= 300 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            ovc_father = CASE WHEN ovc.Description = 'Orfão de Pai' THEN 1 ELSE 0 END,
			            ovc_mother = CASE WHEN ovc.Description = 'Orfão de mãe' THEN 1 ELSE 0 END,
			            ovc_both = CASE WHEN ovc.Description = 'Orfão de ambos' THEN 1 ELSE 0 END,
			            Went_To_School = CASE WHEN ben.ScholarityLevel <> '' THEN 1 ELSE 0 END,
			            IsPartSavingGroup = CASE WHEN DATEDIFF(year, CAST(ben.DateOfBirth As Date), @lastDate) >=12 AND ben.IsPartSavingGroup = 1 THEN 1 ELSE 0 END
		            FROM  [Partner] p
		            inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		            inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		            inner join [Beneficiary] ben on (ben.HouseholdID = hh.HouseHoldID)
		            inner join [vw_beneficiary_details] benView on benView.ID = ben.BeneficiaryID
		            left join  [OVCType] ovc ON (ovc.OVCTypeID = ben.OVCTypeID)
		            Where p.CollaboratorRoleID = 1
		            AND benView.RegistrationDate <= @lastDate --Beneficiário registado desde o início até a data final
		            AND ben.BeneficiaryID NOT IN 
		            (
			            SELECT 
				            ben.BeneficiaryID
			            FROM Beneficiary ben
			            inner join [vw_beneficiary_details] benView on benView.ID = ben.BeneficiaryID
			            inner join Household hh on hh.HouseholdID = ben.HouseholdID
			            WHERE benView.RegistrationDate <= @initialDate
			            AND ben.HIVTracked = '1'
		            )
		            --(-- Beneficiário em que o último estado é Inicial no intervalo de datas
		            --	SELECT
		            --		benStatusObj.BeneficiaryID
		            --	FROM
		            --	(
		            --		SELECT 
		            --			row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
		            --			--Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
		            --			,[ChildStatusID]
		            --			,BeneficiaryID
		            --		FROM [ChildStatusHistory] csh
		            --		WHERE csh.[EffectiveDate] BETWEEN @initialDate AND @lastDate
		            --	)benStatusObj
		            --	JOIN ChildStatus cs ON cs.StatusID = benStatusObj.ChildStatusID 
		            --	AND cs.Description = 'Inicial' AND benStatusObj.LastStatusRow = 1 
		            --	-- Verifica se o último estado do Intervalo escolhido é Inicial
		            --)
		            AND ben.BeneficiaryID IN --Beneficiarios que tenham recebido pelo menos 1 serviço entre a data inicial e data final
		            (
			            SELECT rvs.BeneficiaryID
			            FROM  [Routine_Visit_Summary] rvs
			            WHERE rvs.RoutineVisitDate BETWEEN @initialDate AND @lastDate AND rvs.BeneficiaryHasServices = 1
		            )
		            AND ben.BeneficiaryID IN --Beneficiarios que tenham recebido pelo menos 1 serviço entre a data inicial e data final
		            (
			            SELECT rvs.BeneficiaryID
			            FROM  [Routine_Visit_Summary] rvs
			            WHERE rvs.RoutineVisitDate BETWEEN @initialDate AND @lastDate AND rvs.BeneficiaryHasServices = 1
		            )
		            AND ben.BeneficiaryID NOT IN --Beneficiário que não tenham recebido algum serviço desde o início até a data inicial do intervalo
		            (
			            SELECT rvs.BeneficiaryID
			            FROM  [Routine_Visit_Summary] rvs
			            WHERE rvs.RoutineVisitDate <= @initialDate AND rvs.BeneficiaryHasServices = 1
		            )
		            AND ben.BeneficiaryID IN --Beneficiario que teve pelo menos 1 referência entre a data inicial e data final
		            (
			            SELECT
				            ben.BeneficiaryID
			            FROM [Beneficiary] ben
			            inner join [ReferenceService] AS rs ON (rs.BeneficiaryID = ben.BeneficiaryID)
			            inner join [Reference] AS r ON r.ReferenceServiceID = rs.ReferenceServiceID  
			            AND rs.ReferenceDate BETWEEN @initialDate AND @lastDate 
			            AND r.Value <> '0' AND r.Value <> '' AND r.Value IS NOT NULL
			            inner join dbo.ReferenceType rt ON (r.ReferenceTypeID = rt.ReferenceTypeID and rt.ReferenceCategory = 'Activist')
		            )
		            AND ben.BeneficiaryID NOT IN--Beneficiário que não tenham recebido alguma referência desde o início até a data inicial do intervalo
		            (
			            SELECT
				            ben.BeneficiaryID
			            FROM [Beneficiary] ben
			            inner join [ReferenceService] AS rs ON (rs.BeneficiaryID = ben.BeneficiaryID)
			            inner join [Reference] AS r ON r.ReferenceServiceID = rs.ReferenceServiceID  
			            AND rs.ReferenceDate <= @initialDate 
			            AND r.Value <> '0' AND r.Value <> '' AND r.Value IS NOT NULL
			            inner join dbo.ReferenceType rt ON (r.ReferenceTypeID = rt.ReferenceTypeID and rt.ReferenceCategory = 'Activist')
		            )
		            group by cp.Name, p.Name, ben.BeneficiaryID, ben.FirstName, ben.LastNamE, Ben.DateOfBirth, 
			            ben.Gender, ovc.Description, ben.ScholarityLevel, ben.IsPartSavingGroup
	            )obj_age 
	            group by obj_age.ChiefPartner--<<ReplaceColumn<<--
            )
            obj_Age
            ON 
            (
	            p.ChiefPartner--<<ReplaceColumn<<--
	            =
	            obj_Age.ChiefPartner--<<ReplaceColumn<<--
            ) 
            LEFT JOIN
            (
	            SELECT
		            hiv_obj.ChiefPartner--<<ReplaceColumn<<--
	                ,
		            SUM(HIV_P_IN_TARV_Child) AS HIV_P_IN_TARV_Child,
		            SUM(HIV_P_IN_TARV_Adult) AS HIV_P_IN_TARV_Adult,
		            SUM(HIV_P_NOT_TARV_Child) AS HIV_P_NOT_TARV_Child,
		            SUM(HIV_P_NOT_TARV_Adult) AS HIV_P_NOT_TARV_Adult,
		            SUM(HIV_N_Child) AS HIV_N_Child,
		            SUM(HIV_N_Adult) AS HIV_N_Adult,
		            SUM(HIV_KNOWN_NREVEAL_Child) AS HIV_KNOWN_NREVEAL_Child,
		            SUM(HIV_KNOWN_NREVEAL_Adult) AS  HIV_KNOWN_NREVEAL_Adult,
		            SUM(HIV_NOT_RECOMMENDED_Child) AS  HIV_NOT_RECOMMENDED_Child,
		            SUM(HIV_NOT_RECOMMENDED_Adult) AS  HIV_NOT_RECOMMENDED_Adult,
		            SUM(HIV_UNKNOWN_Child) AS HIV_UNKNOWN_Child,
		            SUM(HIV_UNKNOWN_Adult) AS HIV_UNKNOWN_Adult,
		            SUM(HIVTracked) AS HIVTracked
	            FROM
	            (
		            SELECT
			            cp.Name AS ChiefPartner
			            ,p.[Name] AS Partner
			            ,hh.HouseholdName AS HouseholdName
			            ,ben.RegistrationDate AS RegistrationDate
			            ,ben.FirstName AS FirstName
			            ,ben.LastName AS LastName
			            ,ben.Gender AS Gender
			            ,ben.DateOfBirth,
			            HIV_P_IN_TARV_Child = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_P_IN_TARV_Adult = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_P_NOT_TARV_Child = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_P_NOT_TARV_Adult = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_N_Child = CASE WHEN hiv.HIV = 'N' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_N_Adult = CASE WHEN hiv.HIV = 'N' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_KNOWN_NREVEAL_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_KNOWN_NREVEAL_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_NOT_RECOMMENDED_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 2 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_NOT_RECOMMENDED_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 2 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_UNKNOWN_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_UNKNOWN_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIVTracked = CASE WHEN ben.HIVTracked = 1 THEN 1 ELSE 0 END
		            FROM [Partner] p
		            inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		            inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		            inner join [Beneficiary] ben on (ben.HouseholdID = hh.HouseHoldID)
		            inner join [vw_beneficiary_details] benView on benView.ID = ben.BeneficiaryID
		            inner join [HIVStatus] hiv ON hiv.BeneficiaryID = ben.BeneficiaryID 
		            AND hiv.HIVStatusID IN -- Último estado de HIV no intervalo de datas
		            (
			            SELECT
				            benHIVStatusObj.HIVStatusID
			            FROM
			            (
				            SELECT 
					            row_number() OVER (PARTITION BY BeneficiaryID ORDER BY InformationDate DESC) AS LastHIVStatusRow
					            --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					            ,HIVStatusID
					            ,BeneficiaryID
				            FROM [HIVStatus] hiv
				            WHERE hiv.InformationDate <= @lastDate
			            )benHIVStatusObj
			            WHERE benHIVStatusObj.LastHIVStatusRow = 1 
			            -- Verifica o último estado de HIV do Intervalo
		            )
		            Where p.CollaboratorRoleID = 1
		            AND ben.BeneficiaryID NOT IN 
		            (
			            SELECT 
				            ben.BeneficiaryID
			            FROM Beneficiary ben
			            inner join [vw_beneficiary_details] benView on benView.ID = ben.BeneficiaryID
			            inner join Household hh on hh.HouseholdID = ben.HouseholdID
			            WHERE benView.RegistrationDate <= @initialDate
			            AND ben.HIVTracked = '1'
		            )
		            --(-- Beneficiário em que o último estado é Inicial no intervalo de datas
		            --	SELECT
		            --		benStatusObj.BeneficiaryID
		            --	FROM
		            --	(
		            --		SELECT 
		            --			row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
		            --			--Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
		            --			,[ChildStatusID]
		            --			,BeneficiaryID
		            --		FROM [ChildStatusHistory] csh
		            --		WHERE csh.[EffectiveDate] BETWEEN @initialDate AND @lastDate
		            --	)benStatusObj
		            --	JOIN ChildStatus cs ON cs.StatusID = benStatusObj.ChildStatusID 
		            --	AND cs.Description = 'Inicial' AND benStatusObj.LastStatusRow = 1 
		            --	-- Verifica se o último estado do Intervalo escolhido é Inicial
		            --)
		            AND ben.BeneficiaryID IN --Beneficiarios que tenham recebido pelo menos 1 serviço entre a data inicial e data final
		            (
			            SELECT rvs.BeneficiaryID
			            FROM  [Routine_Visit_Summary] rvs
			            WHERE rvs.RoutineVisitDate BETWEEN @initialDate AND @lastDate AND rvs.BeneficiaryHasServices = 1
		            )
		            AND ben.BeneficiaryID IN --Beneficiarios que tenham recebido pelo menos 1 serviço entre a data inicial e data final
		            (
			            SELECT rvs.BeneficiaryID
			            FROM  [Routine_Visit_Summary] rvs
			            WHERE rvs.RoutineVisitDate BETWEEN @initialDate AND @lastDate AND rvs.BeneficiaryHasServices = 1
		            )
		            AND ben.BeneficiaryID NOT IN --Beneficiário que não tenham recebido algum serviço desde o início até a data inicial do intervalo
		            (
			            SELECT rvs.BeneficiaryID
			            FROM  [Routine_Visit_Summary] rvs
			            WHERE rvs.RoutineVisitDate <= @initialDate AND rvs.BeneficiaryHasServices = 1
		            )
		            AND ben.BeneficiaryID IN --Beneficiario que teve pelo menos 1 referência entre a data inicial e data final
		            (
			            SELECT
				            ben.BeneficiaryID
			            FROM [Beneficiary] ben
			            inner join [ReferenceService] AS rs ON (rs.BeneficiaryID = ben.BeneficiaryID)
			            inner join [Reference] AS r ON r.ReferenceServiceID = rs.ReferenceServiceID  
			            AND rs.ReferenceDate BETWEEN @initialDate AND @lastDate 
			            AND r.Value <> '0' AND r.Value <> '' AND r.Value IS NOT NULL
			            inner join dbo.ReferenceType rt ON (r.ReferenceTypeID = rt.ReferenceTypeID and rt.ReferenceCategory = 'Activist')
		            )
		            AND ben.BeneficiaryID NOT IN--Beneficiário que não tenham recebido alguma referência desde o início até a data inicial do intervalo
		            (
			            SELECT
				            ben.BeneficiaryID
			            FROM [Beneficiary] ben
			            inner join [ReferenceService] AS rs ON (rs.BeneficiaryID = ben.BeneficiaryID)
			            inner join [Reference] AS r ON r.ReferenceServiceID = rs.ReferenceServiceID  
			            AND rs.ReferenceDate <= @initialDate 
			            AND r.Value <> '0' AND r.Value <> '' AND r.Value IS NOT NULL
			            inner join dbo.ReferenceType rt ON (r.ReferenceTypeID = rt.ReferenceTypeID and rt.ReferenceCategory = 'Activist')
		            )
	            )hiv_obj 
	            group by hiv_obj.ChiefPartner--<<ReplaceColumn<<--
            )hiv_obj
            ON 
            (
	            p.ChiefPartner--<<ReplaceColumn<<--
	            =
	            hiv_obj.ChiefPartner--<<ReplaceColumn<<--
            )
            LEFT JOIN
            (
	            SELECT  --  Total de familias de acordo com a referencia
		            ref_origin_obj.ChiefPartner--<<ReplaceColumn<<--
		            ,
		            SUM(ref_origin_obj.US) As US,
		            SUM(ref_origin_obj.Com) As Com,
		            SUM(ref_origin_obj.Parceiro_Clínico) As Parceiro_Clínico,
		            SUM(ref_origin_obj.Parceiro_Populacoes_Chave) As Parceiro_Populacoes_Chave,
		            SUM(ref_origin_obj.OCBS) As OCBS,
		            SUM(ref_origin_obj.Others) As Others
	            FROM
	            (
		            SELECT
			            cp.Name As ChiefPartner, 
			            ChiefPartnerRole = CASE cp.CollaboratorRoleID WHEN 3 THEN 'Supervior' WHEN 2 THEN 'Activista Chefe' ELSE 'Activista' END,
			            p.Name As Partner, 
			            PartnerRole = CASE p.CollaboratorRoleID WHEN 3 THEN 'Supervior' WHEN 2 THEN 'Activista Chefe' ELSE 'Activista' END,
			            hh.HouseholdName,
			            ben.BeneficiaryID, ben.FirstName, ben.LastName,
			            US = CASE WHEN se.Description = 'Unidade Sanitária' THEN 1 ELSE 0 END,
			            Com = CASE WHEN se.Description = 'Comunidade' THEN 1 ELSE 0 END,
			            Parceiro_Clínico = CASE WHEN se.Description = 'Parceiro Clínico' THEN 1 ELSE 0 END,
			            Parceiro_Populacoes_Chave = CASE WHEN se.Description = 'Parceiros de Populacoes-Chave' THEN 1 ELSE 0 END,
			            OCBS = CASE WHEN se.Description = 'Nenhuma' THEN 1 ELSE 0 END,
			            Others = CASE WHEN se.Description = 'Outra' THEN 1 ELSE 0 END
		            FROM [Partner] p
		            inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		            inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		            inner join [SimpleEntity] se on (se.SimpleEntityID = hh.FamilyOriginRefID)
		            inner join [Beneficiary] ben on (ben.HouseholdID = hh.HouseHoldID)
		            inner join [vw_beneficiary_details] benView on benView.ID = ben.BeneficiaryID
		            Where p.CollaboratorRoleID = 1
		            AND ben.BeneficiaryID NOT IN 
		            (
			            SELECT 
				            ben.BeneficiaryID
			            FROM Beneficiary ben
			            inner join [vw_beneficiary_details] benView on benView.ID = ben.BeneficiaryID
			            inner join Household hh on hh.HouseholdID = ben.HouseholdID
			            WHERE benView.RegistrationDate <= @initialDate
			            AND ben.HIVTracked = '1'
		            )
		            --(-- Beneficiário em que o último estado é Inicial no intervalo de datas
		            --	SELECT
		            --		benStatusObj.BeneficiaryID
		            --	FROM
		            --	(
		            --		SELECT 
		            --			row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
		            --			--Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
		            --			,[ChildStatusID]
		            --			,BeneficiaryID
		            --		FROM [ChildStatusHistory] csh
		            --		WHERE csh.[EffectiveDate] BETWEEN @initialDate AND @lastDate
		            --	)benStatusObj
		            --	JOIN ChildStatus cs ON cs.StatusID = benStatusObj.ChildStatusID 
		            --	AND cs.Description = 'Inicial' AND benStatusObj.LastStatusRow = 1 
		            --	-- Verifica se o último estado do Intervalo escolhido é Inicial
		            --)
		            AND ben.BeneficiaryID IN --Beneficiarios que tenham recebido pelo menos 1 serviço entre a data inicial e data final
		            (
			            SELECT rvs.BeneficiaryID
			            FROM  [Routine_Visit_Summary] rvs
			            WHERE rvs.RoutineVisitDate BETWEEN @initialDate AND @lastDate AND rvs.BeneficiaryHasServices = 1
		            )
		            AND ben.BeneficiaryID IN --Beneficiarios que tenham recebido pelo menos 1 serviço entre a data inicial e data final
		            (
			            SELECT rvs.BeneficiaryID
			            FROM  [Routine_Visit_Summary] rvs
			            WHERE rvs.RoutineVisitDate BETWEEN @initialDate AND @lastDate AND rvs.BeneficiaryHasServices = 1
		            )
		            AND ben.BeneficiaryID NOT IN --Beneficiário que não tenham recebido algum serviço desde o início até a data inicial do intervalo
		            (
			            SELECT rvs.BeneficiaryID
			            FROM  [Routine_Visit_Summary] rvs
			            WHERE rvs.RoutineVisitDate <= @initialDate AND rvs.BeneficiaryHasServices = 1
		            )
		            AND ben.BeneficiaryID IN --Beneficiario que teve pelo menos 1 referência entre a data inicial e data final
		            (
			            SELECT
				            ben.BeneficiaryID
			            FROM [Beneficiary] ben
			            inner join [ReferenceService] AS rs ON (rs.BeneficiaryID = ben.BeneficiaryID)
			            inner join [Reference] AS r ON r.ReferenceServiceID = rs.ReferenceServiceID  
			            AND rs.ReferenceDate BETWEEN @initialDate AND @lastDate 
			            AND r.Value <> '0' AND r.Value <> '' AND r.Value IS NOT NULL
			            inner join dbo.ReferenceType rt ON (r.ReferenceTypeID = rt.ReferenceTypeID and rt.ReferenceCategory = 'Activist')
		            )
		            AND ben.BeneficiaryID NOT IN--Beneficiário que não tenham recebido alguma referência desde o início até a data inicial do intervalo
		            (
			            SELECT
				            ben.BeneficiaryID
			            FROM [Beneficiary] ben
			            inner join [ReferenceService] AS rs ON (rs.BeneficiaryID = ben.BeneficiaryID)
			            inner join [Reference] AS r ON r.ReferenceServiceID = rs.ReferenceServiceID  
			            AND rs.ReferenceDate <= @initialDate 
			            AND r.Value <> '0' AND r.Value <> '' AND r.Value IS NOT NULL
			            inner join dbo.ReferenceType rt ON (r.ReferenceTypeID = rt.ReferenceTypeID and rt.ReferenceCategory = 'Activist')
		            )
	            ) ref_origin_obj
	            group by 
		            ref_origin_obj.ChiefPartner--<<ReplaceColumn<<--
            ) ref_origin_obj 
            on 
            (
	            p.ChiefPartner--<<ReplaceColumn<<--
	            =
	            ref_origin_obj.ChiefPartner--<<ReplaceColumn<<--
            )";


        public List<NewBeneficiariesSummaryReportDTO> getNewBeneficiariesSummaryChiefPartner(DateTime initialDate, DateTime lastDate)
        {
            return getNewBeneficiariesSummary(initialDate, lastDate, "chiefpartner");
        }

        public List<NewBeneficiariesSummaryReportDTO> getNewBeneficiariesSummaryPartner(DateTime initialDate, DateTime lastDate)
        {
            return getNewBeneficiariesSummary(initialDate, lastDate, "partner");
        }



        public List<NewBeneficiariesSummaryReportDTO> getNewBeneficiariesSummary(DateTime initialDate, DateTime lastDate, string partnerType)
        {
            string QueryNewBeneficiariesSummaryForChiefPartner;
            if (partnerType.Equals("partner"))
            {
                QueryNewBeneficiariesSummary = QueryNewBeneficiariesSummary.Replace("ChiefPartner--<<ReplaceColumn<<--", "Partner");
            }
            else
            {
                QueryNewBeneficiariesSummary = QueryNewBeneficiariesSummary.Replace("ChiefPartner--<<ReplaceColumn<<--", "ChiefPartner--<<ReplaceColumn<<--"); 
            }

            return UnitOfWork.DbContext.Database.SqlQuery<NewBeneficiariesSummaryReportDTO>(QueryNewBeneficiariesSummary,
                                                            new SqlParameter("initialDate", initialDate),
                                                            new SqlParameter("lastDate", lastDate)).ToList();
        }

        // Resumo Mensal de Beneficiarios Activos
        public static String QueryMonthlyActiveBeneficiariesSummary =
        @"SELECT
	            p.ChiefPartner--<<ReplaceColumn<<--
	            As Partner,
	            ISNULL(obj_Age.btw_x_1_M, 0) As btw_x_1_M,
	            ISNULL(obj_Age.btw_1_4_M, 0) AS btw_1_4_M,
	            ISNULL(obj_Age.btw_5_9_M, 0) AS btw_5_9_M,
	            ISNULL(obj_Age.btw_10_14_M, 0) AS btw_10_14_M,
	            ISNULL(obj_Age.btw_15_17_M, 0) AS btw_15_17_M,
	            ISNULL(obj_Age.btw_18_24_M, 0) AS btw_18_24_M,
	            ISNULL(obj_Age.btw_25_x_M, 0) AS btw_25_x_M,
	            ISNULL(obj_Age.btw_x_1_F, 0) AS btw_x_1_F,
	            ISNULL(obj_Age.btw_1_4_F, 0) AS btw_1_4_F,
	            ISNULL(obj_Age.btw_5_9_F, 0) AS btw_5_9_F,
	            ISNULL(obj_Age.btw_10_14_F, 0) AS btw_10_14_F,
	            ISNULL(obj_Age.btw_15_17_F, 0) AS btw_15_17_F,
	            ISNULL(obj_Age.btw_18_24_F, 0) AS btw_18_24_F,
	            ISNULL(obj_Age.btw_25_x_F, 0) AS btw_25_x_F,

	            ISNULL(HIV_P_IN_TARV_Child, 0)  AS HIV_P_IN_TARV_Child,
	            ISNULL(HIV_P_NOT_TARV_Child, 0)  AS HIV_P_NOT_TARV_Child,
	            ISNULL(HIV_N_Child, 0)  AS HIV_N_Child,
	            ISNULL(HIV_KNOWN_NREVEAL_Child, 0)  AS HIV_KNOWN_NREVEAL_Child,
	            ISNULL(HIV_NOT_RECOMMENDED_Child, 0)  AS  HIV_NOT_RECOMMENDED_Child,
	            ISNULL(HIV_UNKNOWN_Child, 0)  AS HIV_UNKNOWN_Child,
	            ISNULL(HIV_P_IN_TARV_Adult, 0)  AS HIV_P_IN_TARV_Adult,
	            ISNULL(HIV_P_NOT_TARV_Adult, 0)  AS HIV_P_NOT_TARV_Adult,
	            ISNULL(HIV_N_Adult, 0)  AS HIV_N_Adult,
	            ISNULL(HIV_KNOWN_NREVEAL_Adult, 0)  AS  HIV_KNOWN_NREVEAL_Adult,
	            ISNULL(HIV_UNKNOWN_Adult, 0)  AS HIV_UNKNOWN_Adult,

	            ISNULL(obj_NonGratuated.DeathChild, 0) AS DeathChild, 
	            ISNULL(obj_NonGratuated.DeathAdult, 0) AS DeathAdult, 
	            ISNULL(obj_NonGratuated.LostChild, 0) AS LostChild, 
	            ISNULL(obj_NonGratuated.LostAdult, 0) AS LostAdult, 
	            ISNULL(obj_NonGratuated.GaveUpChild, 0) AS GaveUpChild, 
	            ISNULL(obj_NonGratuated.GaveUpAdult, 0) AS GaveUpAdult, 
	            ISNULL(obj_NonGratuated.TransfersPEPFARChild, 0) AS TransfersPEPFARChild, 
	            ISNULL(obj_NonGratuated.TransfersPEPFARAdult, 0) AS TransfersPEPFARAdult, 
	            ISNULL(obj_NonGratuated.TransfersNotPEPFARChild, 0) AS TransfersNotPEPFARChild, 
	            ISNULL(obj_NonGratuated.TransfersNotPEPFARAdult, 0) AS TransfersNotPEPFARAdult, 
	            ISNULL(obj_NonGratuated.BecameAdult, 0) AS BecameAdult, 
	            ISNULL(obj_NonGratuated.ChildHasServices, 0) AS ChildHasServices, 
	            ISNULL(obj_NonGratuated.AdultHasServices, 0) AS AdultHasServices
            FROM
            (
	            SELECT
		            ChiefPartner--<<ReplaceColumn<<--
	            FROM
	            (
		            SELECT cp.Name As ChiefPartner, p.Name As Partner
		            FROM  [Partner] p
		            inner join  [Partner] cp on (p.SuperiorId = cp.PartnerID)
		            Where p.CollaboratorRoleID = 1
	            ) p
	            group by p.ChiefPartner--<<ReplaceColumn<<--
            ) p
            LEFT JOIN
            (
	            SELECT
		            obj_age.ChiefPartner--<<ReplaceColumn<<--
	                ,
		            SUM(obj_Age.btw_x_1_M) As btw_x_1_M,
		            SUM(obj_Age.btw_1_4_M) AS btw_1_4_M,
		            SUM(obj_Age.btw_5_9_M) AS btw_5_9_M,
		            SUM(obj_Age.btw_10_14_M) AS btw_10_14_M,
		            SUM(obj_Age.btw_15_17_M) AS btw_15_17_M,
		            SUM(obj_Age.btw_18_24_M) AS btw_18_24_M,
		            SUM(obj_Age.btw_25_x_M) AS btw_25_x_M,
		            SUM(obj_Age.btw_x_1_F) AS btw_x_1_F,
		            SUM(obj_Age.btw_1_4_F) AS btw_1_4_F,
		            SUM(obj_Age.btw_5_9_F) AS btw_5_9_F,
		            SUM(obj_Age.btw_10_14_F) AS btw_10_14_F,
		            SUM(obj_Age.btw_15_17_F) AS btw_15_17_F,
		            SUM(obj_Age.btw_18_24_F) AS btw_18_24_F,
		            SUM(obj_Age.btw_25_x_F) AS btw_25_x_F

	            FROM
	            (
		            SELECT
			            cp.Name As ChiefPartner,
			            p.Name As Partner,
			            count(ben.BeneficiaryID) as ID,
			            ben.FirstName As FirstName, 
			            ben.LastName As LastName, 
			            btw_x_1_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) < 12 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_1_4_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 12 AND 59 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_5_9_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 60 AND 119 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_10_14_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 120 AND 179 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_15_17_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 180 AND 215 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_18_24_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 216 AND 299 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_25_x_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) >= 300 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			            btw_x_1_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) < 12 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_1_4_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 12 AND 59 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_5_9_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 60 AND 119 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_10_14_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 120 AND 179 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_15_17_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 180 AND 215 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_18_24_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 216 AND 299 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			            btw_25_x_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) >= 300 AND ben.Gender = 'F' THEN 1 ELSE 0 END
		            FROM  [Partner] p
		            inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		            inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		            inner join [Beneficiary] ben ON ben.HouseholdID = hh.HouseHoldID
		            inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID] and ben.[ServicesStatusForReportDate] between @initialDate and @lastDate
		            inner join [SimpleEntity] se ON ben.[ServicesStatusForReportID] = se.SimpleEntityID and se.Type='ben-services-status' and se.Code= '03'
		            WHERE p.CollaboratorRoleID = 1
		            group by cp.Name, p.Name, ben.BeneficiaryID, ben.FirstName, ben.LastName, Ben.DateOfBirth, ben.Gender
	            )obj_age 
	            group by obj_age.ChiefPartner--<<ReplaceColumn<<--
            )
            obj_Age
            ON 
            (
	            p.ChiefPartner--<<ReplaceColumn<<--
	            =
	            obj_Age.ChiefPartner--<<ReplaceColumn<<--
            ) 
            LEFT JOIN
            (
	            SELECT
		            obj_NonGratuated.ChiefPartner--<<ReplaceColumn<<--
	                ,
		            SUM(obj_NonGratuated.DeathChild) AS DeathChild, 
		            SUM(obj_NonGratuated.DeathAdult) AS DeathAdult, 
		            SUM(obj_NonGratuated.LostChild) AS LostChild, 
		            SUM(obj_NonGratuated.LostAdult) AS LostAdult, 
		            SUM(obj_NonGratuated.GaveUpChild) AS GaveUpChild, 
		            SUM(obj_NonGratuated.GaveUpAdult) AS GaveUpAdult, 
		            SUM(obj_NonGratuated.TransfersPEPFARChild) AS TransfersPEPFARChild, 
		            SUM(obj_NonGratuated.TransfersPEPFARAdult) AS TransfersPEPFARAdult, 
		            SUM(obj_NonGratuated.TransfersNotPEPFARChild) AS TransfersNotPEPFARChild, 
		            SUM(obj_NonGratuated.TransfersNotPEPFARAdult) AS TransfersNotPEPFARAdult, 
		            SUM(obj_NonGratuated.BecameAdult) AS BecameAdult, 
		            SUM(obj_NonGratuated.ChildHasServices) AS ChildHasServices, 
		            SUM(obj_NonGratuated.AdultHasServices) AS AdultHasServices
	            FROM
	            (
		            SELECT
			            cp.Name As ChiefPartner,
			            p.Name As Partner,
			            count(ben.BeneficiaryID) as ID,
			            ben.FirstName As FirstName, ben.LastName As LastName, cs.Description,
			            DeathChild = CASE WHEN cs.Description = 'Óbito' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            DeathAdult = CASE WHEN cs.Description = 'Óbito' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            LostChild = CASE WHEN cs.Description = 'Perdido' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            LostAdult = CASE WHEN cs.Description = 'Perdido' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            GaveUpChild = CASE WHEN cs.Description = 'Desistência' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            GaveUpAdult = CASE WHEN cs.Description = 'Desistência' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            TransfersPEPFARChild = CASE WHEN cs.Description = 'Transferido p/ programas de PEPFAR' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            TransfersPEPFARAdult = CASE WHEN cs.Description = 'Transferido p/ programas de PEPFAR' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            TransfersNotPEPFARChild = CASE WHEN cs.Description = 'Transferido p/ programas NÃO de PEPFAR)' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            TransfersNotPEPFARAdult = CASE WHEN cs.Description = 'Transferido p/ programas NÃO de PEPFAR)' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            BecameAdult = CASE WHEN DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) = 18 THEN 1 ELSE 0 END,
			            ChildHasServices = CASE WHEN DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 AND rvs.BeneficiaryHasServices <> 1 THEN 1 ELSE 0 END,
			            AdultHasServices = CASE WHEN DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 AND rvs.BeneficiaryHasServices <> 1 THEN 1 ELSE 0 END
		            FROM [Partner] p
		            inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		            inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		            inner join [Beneficiary] ben ON ben.HouseholdID = hh.HouseHoldID
		            inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID] and ben.[ServicesStatusForReportDate] between @initialDate and @lastDate
		            inner join [SimpleEntity] se ON ben.[ServicesStatusForReportID] = se.SimpleEntityID and se.Type='ben-services-status' and se.Code= '03'
		            inner join [Routine_Visit_Summary] rvs ON rvs.BeneficiaryID = ben.BeneficiaryID AND rvs.RoutineVisitDate BETWEEN @initialDate AND @lastDate
		            inner join [ChildStatusHistory] csh ON csh.BeneficiaryID = ben.BeneficiaryID 
		            AND csh.ChildStatusHistoryID IN -- Último estado no intervalo de datas
		            (
			            SELECT
				            benStatusObj.ChildStatusHistoryID
			            FROM
			            (
				            SELECT 
					            row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
					            --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					            ,ChildStatusHistoryID
					            ,BeneficiaryID
				            FROM [ChildStatusHistory] csh
				            WHERE csh.EffectiveDate <= @lastDate
			            )benStatusObj
			            WHERE benStatusObj.LastStatusRow = 1 
			            -- Verifica o último estado do Intervalo
		            )
		            inner join [ChildStatus] cs ON cs.StatusID = csh.ChildStatusID
		            WHERE p.CollaboratorRoleID = 1
		            group by cp.Name, p.Name, ben.BeneficiaryID, ben.FirstName, ben.LastName, Ben.DateOfBirth, cs.Description, rvs.BeneficiaryHasServices
	            )obj_NonGratuated
	            group by obj_NonGratuated.ChiefPartner--<<ReplaceColumn<<--
            )
            obj_NonGratuated
            ON 
            (
	            p.ChiefPartner--<<ReplaceColumn<<--
	            =
	            obj_NonGratuated.ChiefPartner--<<ReplaceColumn<<--
            ) 
            LEFT JOIN
            (
	            SELECT
		            hiv_obj.ChiefPartner--<<ReplaceColumn<<--
	                ,
		            SUM(HIV_P_IN_TARV_Child) AS HIV_P_IN_TARV_Child,
		            SUM(HIV_P_IN_TARV_Adult) AS HIV_P_IN_TARV_Adult,
		            SUM(HIV_P_NOT_TARV_Child) AS HIV_P_NOT_TARV_Child,
		            SUM(HIV_P_NOT_TARV_Adult) AS HIV_P_NOT_TARV_Adult,
		            SUM(HIV_N_Child) AS HIV_N_Child,
		            SUM(HIV_N_Adult) AS HIV_N_Adult,
		            SUM(HIV_KNOWN_NREVEAL_Child) AS HIV_KNOWN_NREVEAL_Child,
		            SUM(HIV_KNOWN_NREVEAL_Adult) AS  HIV_KNOWN_NREVEAL_Adult,
		            SUM(HIV_NOT_RECOMMENDED_Child) AS  HIV_NOT_RECOMMENDED_Child,
		            SUM(HIV_NOT_RECOMMENDED_Adult) AS  HIV_NOT_RECOMMENDED_Adult,
		            SUM(HIV_UNKNOWN_Child) AS HIV_UNKNOWN_Child,
		            SUM(HIV_UNKNOWN_Adult) AS HIV_UNKNOWN_Adult
	            FROM
	            (
		            SELECT
			            cp.Name AS ChiefPartner
			            ,p.[Name] AS Partner
			            ,hh.HouseholdName AS HouseholdName
			            ,ben.RegistrationDate AS RegistrationDate
			            ,ben.FirstName AS FirstName
			            ,ben.LastName AS LastName
			            ,ben.Gender AS Gender
			            ,ben.DateOfBirth,
			            HIV_P_IN_TARV_Child = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_P_IN_TARV_Adult = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_P_NOT_TARV_Child = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_P_NOT_TARV_Adult = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_N_Child = CASE WHEN hiv.HIV = 'N' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_N_Adult = CASE WHEN hiv.HIV = 'N' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_KNOWN_NREVEAL_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_KNOWN_NREVEAL_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_NOT_RECOMMENDED_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 2 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_NOT_RECOMMENDED_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 2 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			            HIV_UNKNOWN_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			            HIV_UNKNOWN_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END
		            FROM [Partner] p
		            inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		            inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		            inner join [Beneficiary] ben ON ben.HouseholdID = hh.HouseHoldID
		            inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID] and ben.[ServicesStatusForReportDate] between @initialDate and @lastDate
		            inner join [SimpleEntity] se ON ben.[ServicesStatusForReportID] = se.SimpleEntityID and se.Type='ben-services-status' and se.Code= '03'
		            inner join [HIVStatus] hiv ON hiv.BeneficiaryID = ben.BeneficiaryID 
		            AND hiv.HIVStatusID IN -- Último estado de HIV no intervalo de datas
		            (
			            SELECT
				            benHIVStatusObj.HIVStatusID
			            FROM
			            (
				            SELECT 
					            row_number() OVER (PARTITION BY BeneficiaryID ORDER BY InformationDate DESC) AS LastHIVStatusRow
					            --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					            ,HIVStatusID
					            ,BeneficiaryID
				            FROM [HIVStatus] hiv
				            WHERE hiv.InformationDate <= @lastDate
			            )benHIVStatusObj
			            WHERE benHIVStatusObj.LastHIVStatusRow = 1 
			            -- Verifica o último estado de HIV do Intervalo
		            )
		            WHERE p.CollaboratorRoleID = 1
	            )hiv_obj 
	            group by hiv_obj.ChiefPartner--<<ReplaceColumn<<--
            )hiv_obj
            ON 
            (
	            p.ChiefPartner--<<ReplaceColumn<<--
	            =
	            hiv_obj.ChiefPartner--<<ReplaceColumn<<--
            )";

        public List<MonthlyActiveBeneficiariesSummaryDTO> getMonthlyActiveBeneficiariesSummaryChiefPartner(DateTime initialDate, DateTime lastDate)
        {
            return getMonthlyActiveBeneficiariesSummary(initialDate, lastDate, "chiefpartner");
        }

        public List<MonthlyActiveBeneficiariesSummaryDTO> getMonthlyActiveBeneficiariesSummaryPartner(DateTime initialDate, DateTime lastDate)
        {
            return getMonthlyActiveBeneficiariesSummary(initialDate, lastDate, "partner");
        }

        public List<MonthlyActiveBeneficiariesSummaryDTO> getMonthlyActiveBeneficiariesSummary(DateTime initialDate, DateTime lastDate, string partnerType)
        {
            if (partnerType.Equals("partner"))
            {
                QueryMonthlyActiveBeneficiariesSummary = QueryMonthlyActiveBeneficiariesSummary.Replace("ChiefPartner--<<ReplaceColumn<<--", "Partner");
            }
            else
            {
                QueryMonthlyActiveBeneficiariesSummary = QueryMonthlyActiveBeneficiariesSummary.Replace("ChiefPartner--<<ReplaceColumn<<--", "ChiefPartner--<<ReplaceColumn<<--");
            }

            return UnitOfWork.DbContext.Database.SqlQuery<MonthlyActiveBeneficiariesSummaryDTO>(QueryMonthlyActiveBeneficiariesSummary,
                                                            new SqlParameter("initialDate", initialDate),
                                                            new SqlParameter("lastDate", lastDate)).ToList();
        }

        // Resumo Mensal de Graduados por Periodo
        public static String QueryMonthlyGraduatedBeneficiariesSummary =
        @"SELECT
	        p.ChiefPartner--<<ReplaceColumn<<--
	        As Partner,
	        ISNULL(obj_Age.btw_x_1_M, 0) As btw_x_1_M,
	        ISNULL(obj_Age.btw_1_4_M, 0) AS btw_1_4_M,
	        ISNULL(obj_Age.btw_5_9_M, 0) AS btw_5_9_M,
	        ISNULL(obj_Age.btw_10_14_M, 0) AS btw_10_14_M,
	        ISNULL(obj_Age.btw_15_17_M, 0) AS btw_15_17_M,
	        ISNULL(obj_Age.btw_18_24_M, 0) AS btw_18_24_M,
	        ISNULL(obj_Age.btw_25_x_M, 0) AS btw_25_x_M,
	        ISNULL(obj_Age.btw_x_1_F, 0) AS btw_x_1_F,
	        ISNULL(obj_Age.btw_1_4_F, 0) AS btw_1_4_F,
	        ISNULL(obj_Age.btw_5_9_F, 0) AS btw_5_9_F,
	        ISNULL(obj_Age.btw_10_14_F, 0) AS btw_10_14_F,
	        ISNULL(obj_Age.btw_15_17_F, 0) AS btw_15_17_F,
	        ISNULL(obj_Age.btw_18_24_F, 0) AS btw_18_24_F,
	        ISNULL(obj_Age.btw_25_x_F, 0) AS btw_25_x_F,

	        ISNULL(HIV_P_IN_TARV_Child, 0)  AS HIV_P_IN_TARV_Child,
	        ISNULL(HIV_P_NOT_TARV_Child, 0)  AS HIV_P_NOT_TARV_Child,
	        ISNULL(HIV_N_Child, 0)  AS HIV_N_Child,
	        ISNULL(HIV_KNOWN_NREVEAL_Child, 0)  AS HIV_KNOWN_NREVEAL_Child,
	        ISNULL(HIV_NOT_RECOMMENDED_Child, 0)  AS  HIV_NOT_RECOMMENDED_Child,
	        ISNULL(HIV_UNKNOWN_Child, 0)  AS HIV_UNKNOWN_Child,
	        ISNULL(HIV_P_IN_TARV_Adult, 0)  AS HIV_P_IN_TARV_Adult,
	        ISNULL(HIV_P_NOT_TARV_Adult, 0)  AS HIV_P_NOT_TARV_Adult,
	        ISNULL(HIV_N_Adult, 0)  AS HIV_N_Adult,
	        ISNULL(HIV_KNOWN_NREVEAL_Adult, 0)  AS  HIV_KNOWN_NREVEAL_Adult,
	        ISNULL(HIV_UNKNOWN_Adult, 0)  AS HIV_UNKNOWN_Adult,

	        ISNULL(obj_permanence_in_project.Permanence_btw_x_6_month, 0) AS Permanence_btw_x_6_month, 
	        ISNULL(obj_permanence_in_project.Permanence_btw_6_11_month, 0) AS Permanence_btw_6_11_month, 
	        ISNULL(obj_permanence_in_project.Permanence_btw_12_17_month, 0) AS Permanence_btw_12_17_month, 
	        ISNULL(obj_permanence_in_project.Permanence_btw_18_x_month, 0) AS Permanence_btw_18_x_month
        FROM
        (
	        SELECT
		        ChiefPartner--<<ReplaceColumn<<--
	        FROM
	        (
		        SELECT cp.Name As ChiefPartner, p.Name As Partner
		        FROM  [Partner] p
		        inner join  [Partner] cp on (p.SuperiorId = cp.PartnerID)
		        Where p.CollaboratorRoleID = 1
	        ) p
	        group by p.ChiefPartner--<<ReplaceColumn<<--
        ) p
        LEFT JOIN
        (
	        SELECT
		        obj_age.ChiefPartner--<<ReplaceColumn<<--
	            ,
		        SUM(obj_Age.btw_x_1_M) As btw_x_1_M,
		        SUM(obj_Age.btw_1_4_M) AS btw_1_4_M,
		        SUM(obj_Age.btw_5_9_M) AS btw_5_9_M,
		        SUM(obj_Age.btw_10_14_M) AS btw_10_14_M,
		        SUM(obj_Age.btw_15_17_M) AS btw_15_17_M,
		        SUM(obj_Age.btw_18_24_M) AS btw_18_24_M,
		        SUM(obj_Age.btw_25_x_M) AS btw_25_x_M,
		        SUM(obj_Age.btw_x_1_F) AS btw_x_1_F,
		        SUM(obj_Age.btw_1_4_F) AS btw_1_4_F,
		        SUM(obj_Age.btw_5_9_F) AS btw_5_9_F,
		        SUM(obj_Age.btw_10_14_F) AS btw_10_14_F,
		        SUM(obj_Age.btw_15_17_F) AS btw_15_17_F,
		        SUM(obj_Age.btw_18_24_F) AS btw_18_24_F,
		        SUM(obj_Age.btw_25_x_F) AS btw_25_x_F

	        FROM
	        (
		        SELECT
			        cp.Name As ChiefPartner,
			        p.Name As Partner,
			        count(ben.BeneficiaryID) as ID,
			        ben.FirstName As FirstName, 
			        ben.LastName As LastName, 
			        btw_x_1_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) < 12 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_1_4_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 12 AND 59 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_5_9_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 60 AND 119 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_10_14_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 120 AND 179 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_15_17_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 180 AND 215 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_18_24_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 216 AND 299 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_25_x_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) >= 300 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_x_1_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) < 12 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_1_4_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 12 AND 59 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_5_9_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 60 AND 119 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_10_14_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 120 AND 179 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_15_17_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 180 AND 215 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_18_24_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 216 AND 299 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_25_x_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) >= 300 AND ben.Gender = 'F' THEN 1 ELSE 0 END
		        FROM  [Partner] p
		        inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		        inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		        inner join [Beneficiary] ben ON ben.HouseholdID = hh.HouseHoldID
		        inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID]
		        WHERE p.CollaboratorRoleID = 1
		        AND ben.BeneficiaryID IN 
		        (-- Beneficiário em que o último estado é Graduado no intervalo de datas
			        SELECT
				        benStatusObj.BeneficiaryID
			        FROM
			        (
				        SELECT 
					        row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
					        --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					        ,[ChildStatusID]
					        ,BeneficiaryID
				        FROM [ChildStatusHistory] csh
				        WHERE csh.[EffectiveDate] BETWEEN @initialDate AND @lastDate
			        )benStatusObj
			        JOIN ChildStatus cs ON cs.StatusID = benStatusObj.ChildStatusID 
			        AND cs.Description = 'Graduação' AND benStatusObj.LastStatusRow = 1 
			        -- Verifica se o último estado do Intervalo escolhido é Graduado
		        )
		        group by cp.Name, p.Name, ben.BeneficiaryID, ben.FirstName, ben.LastName, Ben.DateOfBirth, ben.Gender
	        )obj_age 
	        group by obj_age.ChiefPartner--<<ReplaceColumn<<--
        )
        obj_Age
        ON 
        (
	        p.ChiefPartner--<<ReplaceColumn<<--
	        =
	        obj_Age.ChiefPartner--<<ReplaceColumn<<--
        )
        LEFT JOIN
        (
	        SELECT
		        hiv_obj.ChiefPartner--<<ReplaceColumn<<--
	            ,
		        SUM(HIV_P_IN_TARV_Child) AS HIV_P_IN_TARV_Child,
		        SUM(HIV_P_IN_TARV_Adult) AS HIV_P_IN_TARV_Adult,
		        SUM(HIV_P_NOT_TARV_Child) AS HIV_P_NOT_TARV_Child,
		        SUM(HIV_P_NOT_TARV_Adult) AS HIV_P_NOT_TARV_Adult,
		        SUM(HIV_N_Child) AS HIV_N_Child,
		        SUM(HIV_N_Adult) AS HIV_N_Adult,
		        SUM(HIV_KNOWN_NREVEAL_Child) AS HIV_KNOWN_NREVEAL_Child,
		        SUM(HIV_KNOWN_NREVEAL_Adult) AS  HIV_KNOWN_NREVEAL_Adult,
		        SUM(HIV_NOT_RECOMMENDED_Child) AS  HIV_NOT_RECOMMENDED_Child,
		        SUM(HIV_NOT_RECOMMENDED_Adult) AS  HIV_NOT_RECOMMENDED_Adult,
		        SUM(HIV_UNKNOWN_Child) AS HIV_UNKNOWN_Child,
		        SUM(HIV_UNKNOWN_Adult) AS HIV_UNKNOWN_Adult
	        FROM
	        (
		        SELECT
			        cp.Name AS ChiefPartner
			        ,p.[Name] AS Partner
			        ,hh.HouseholdName AS HouseholdName
			        ,ben.RegistrationDate AS RegistrationDate
			        ,ben.FirstName AS FirstName
			        ,ben.LastName AS LastName
			        ,ben.Gender AS Gender
			        ,ben.DateOfBirth,
			        HIV_P_IN_TARV_Child = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_P_IN_TARV_Adult = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_P_NOT_TARV_Child = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_P_NOT_TARV_Adult = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_N_Child = CASE WHEN hiv.HIV = 'N' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_N_Adult = CASE WHEN hiv.HIV = 'N' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_KNOWN_NREVEAL_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_KNOWN_NREVEAL_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_NOT_RECOMMENDED_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 2 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_NOT_RECOMMENDED_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 2 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_UNKNOWN_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_UNKNOWN_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END
		        FROM [Partner] p
		        inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		        inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		        inner join [Beneficiary] ben ON ben.HouseholdID = hh.HouseHoldID
		        inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID]
		        inner join [HIVStatus] hiv ON hiv.BeneficiaryID = ben.BeneficiaryID 
		        AND hiv.HIVStatusID IN -- Último estado de HIV no intervalo de datas
		        (
			        SELECT
				        benHIVStatusObj.HIVStatusID
			        FROM
			        (
				        SELECT 
					        row_number() OVER (PARTITION BY BeneficiaryID ORDER BY InformationDate DESC) AS LastHIVStatusRow
					        --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					        ,HIVStatusID
					        ,BeneficiaryID
				        FROM [HIVStatus] hiv
				        WHERE hiv.InformationDate <= @lastDate
			        )benHIVStatusObj
			        WHERE benHIVStatusObj.LastHIVStatusRow = 1 
			        -- Verifica o último estado de HIV do Intervalo
		        )
		        WHERE p.CollaboratorRoleID = 1
		        AND ben.BeneficiaryID IN 
		        (-- Beneficiário em que o último estado é Graduado no intervalo de datas
			        SELECT
				        benStatusObj.BeneficiaryID
			        FROM
			        (
				        SELECT 
					        row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
					        --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					        ,[ChildStatusID]
					        ,BeneficiaryID
				        FROM [ChildStatusHistory] csh
				        WHERE csh.[EffectiveDate] BETWEEN @initialDate AND @lastDate
			        )benStatusObj
			        JOIN ChildStatus cs ON cs.StatusID = benStatusObj.ChildStatusID 
			        AND cs.Description = 'Graduação' AND benStatusObj.LastStatusRow = 1 
			        -- Verifica se o último estado do Intervalo escolhido é Graduado
		        )
	        )hiv_obj 
	        group by hiv_obj.ChiefPartner--<<ReplaceColumn<<--
        )hiv_obj
        ON 
        (
	        p.ChiefPartner--<<ReplaceColumn<<--
	        =
	        hiv_obj.ChiefPartner--<<ReplaceColumn<<--
        ) 
        LEFT JOIN
        (
	        SELECT
		        obj_permanence_in_project.ChiefPartner--<<ReplaceColumn<<--
	            ,
		        SUM(obj_permanence_in_project.Permanence_btw_x_6_month) AS Permanence_btw_x_6_month, 
		        SUM(obj_permanence_in_project.Permanence_btw_6_11_month) AS Permanence_btw_6_11_month, 
		        SUM(obj_permanence_in_project.Permanence_btw_12_17_month) AS Permanence_btw_12_17_month, 
		        SUM(obj_permanence_in_project.Permanence_btw_18_x_month) AS Permanence_btw_18_x_month
	        FROM
	        (
		        SELECT
			        cp.Name As ChiefPartner,
			        p.Name As Partner,
			        Permanence_btw_x_6_month = CASE WHEN DATEDIFF(month, CAST(benView.RegistrationDate As Date), csh.EffectiveDate) < 6 THEN 1 ELSE 0 END,
			        Permanence_btw_6_11_month  = CASE WHEN DATEDIFF(month, CAST(benView.RegistrationDate As Date), csh.EffectiveDate) BETWEEN 6 AND 11 THEN 1 ELSE 0 END,
			        Permanence_btw_12_17_month  = CASE WHEN DATEDIFF(month, CAST(benView.RegistrationDate As Date), csh.EffectiveDate) BETWEEN 12 AND 17 THEN 1 ELSE 0 END,
			        Permanence_btw_18_x_month  = CASE WHEN DATEDIFF(month, CAST(benView.RegistrationDate As Date), csh.EffectiveDate) > 18 THEN 1 ELSE 0 END
		        FROM [Partner] p
		        inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		        inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		        inner join [Beneficiary] ben ON ben.HouseholdID = hh.HouseHoldID
		        inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID]
		        inner join [ChildStatusHistory] csh ON csh.BeneficiaryID = ben.BeneficiaryID 
		        AND csh.[ChildStatusHistoryID] IN 
		        (-- Estado do Beneficiário no intervalo de datas
			        SELECT
				        benStatusObj.[ChildStatusHistoryID]
			        FROM
			        (
				        SELECT 
					        row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
					        --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					        ,[ChildStatusHistoryID]
					        ,[ChildStatusID]
					        ,BeneficiaryID
				        FROM [ChildStatusHistory] csh
				        WHERE csh.[EffectiveDate] BETWEEN @initialDate AND @lastDate
			        )benStatusObj
			        JOIN ChildStatus cs ON cs.StatusID = benStatusObj.ChildStatusID 
			        AND cs.Description = 'Graduação' AND benStatusObj.LastStatusRow = 1 
			        -- Verifica se o último estado do Intervalo escolhido é Graduado
		        )
	        )obj_permanence_in_project
	        group by obj_permanence_in_project.ChiefPartner--<<ReplaceColumn<<--
        )
        obj_permanence_in_project
        ON 
        (
	        p.ChiefPartner--<<ReplaceColumn<<--
	        =
	        obj_permanence_in_project.ChiefPartner--<<ReplaceColumn<<--
        )";

        public List<MonthlyGraduatedBeneficiariesSummaryDTO> getMonthlyGraduatedBeneficiariesSummaryChiefPartner(DateTime initialDate, DateTime lastDate)
        {
            return getMonthlyGraduatedBeneficiariesSummary(initialDate, lastDate, "chiefpartner");
        }

        public List<MonthlyGraduatedBeneficiariesSummaryDTO> getMonthlyGraduatedBeneficiariesSummaryPartner(DateTime initialDate, DateTime lastDate)
        {
            return getMonthlyGraduatedBeneficiariesSummary(initialDate, lastDate, "partner");
        }

        public List<MonthlyGraduatedBeneficiariesSummaryDTO> getMonthlyGraduatedBeneficiariesSummary(DateTime initialDate, DateTime lastDate, string partnerType)
        {
            if (partnerType.Equals("partner"))
            {
                QueryMonthlyGraduatedBeneficiariesSummary = QueryMonthlyGraduatedBeneficiariesSummary.Replace("ChiefPartner--<<ReplaceColumn<<--", "Partner");
            }
            else
            {
                QueryMonthlyGraduatedBeneficiariesSummary = QueryMonthlyGraduatedBeneficiariesSummary.Replace("ChiefPartner--<<ReplaceColumn<<--", "ChiefPartner--<<ReplaceColumn<<--");
            }

            return UnitOfWork.DbContext.Database.SqlQuery<MonthlyGraduatedBeneficiariesSummaryDTO>(QueryMonthlyGraduatedBeneficiariesSummary,
                                                            new SqlParameter("initialDate", initialDate),
                                                            new SqlParameter("lastDate", lastDate)).ToList();
        }

        // Resumo Mensal de Graduados Cumulativo
        public static String QueryCumulativeGraduatedBeneficiariesSummary =
        @"SELECT
	        p.ChiefPartner--<<ReplaceColumn<<--
	        As Partner,
	        ISNULL(obj_Age.btw_x_1_M, 0) As btw_x_1_M,
	        ISNULL(obj_Age.btw_1_4_M, 0) AS btw_1_4_M,
	        ISNULL(obj_Age.btw_5_9_M, 0) AS btw_5_9_M,
	        ISNULL(obj_Age.btw_10_14_M, 0) AS btw_10_14_M,
	        ISNULL(obj_Age.btw_15_17_M, 0) AS btw_15_17_M,
	        ISNULL(obj_Age.btw_18_24_M, 0) AS btw_18_24_M,
	        ISNULL(obj_Age.btw_25_x_M, 0) AS btw_25_x_M,
	        ISNULL(obj_Age.btw_x_1_F, 0) AS btw_x_1_F,
	        ISNULL(obj_Age.btw_1_4_F, 0) AS btw_1_4_F,
	        ISNULL(obj_Age.btw_5_9_F, 0) AS btw_5_9_F,
	        ISNULL(obj_Age.btw_10_14_F, 0) AS btw_10_14_F,
	        ISNULL(obj_Age.btw_15_17_F, 0) AS btw_15_17_F,
	        ISNULL(obj_Age.btw_18_24_F, 0) AS btw_18_24_F,
	        ISNULL(obj_Age.btw_25_x_F, 0) AS btw_25_x_F,

	        ISNULL(HIV_P_IN_TARV_Child, 0)  AS HIV_P_IN_TARV_Child,
	        ISNULL(HIV_P_NOT_TARV_Child, 0)  AS HIV_P_NOT_TARV_Child,
	        ISNULL(HIV_N_Child, 0)  AS HIV_N_Child,
	        ISNULL(HIV_KNOWN_NREVEAL_Child, 0)  AS HIV_KNOWN_NREVEAL_Child,
	        ISNULL(HIV_NOT_RECOMMENDED_Child, 0)  AS  HIV_NOT_RECOMMENDED_Child,
	        ISNULL(HIV_UNKNOWN_Child, 0)  AS HIV_UNKNOWN_Child,
	        ISNULL(HIV_P_IN_TARV_Adult, 0)  AS HIV_P_IN_TARV_Adult,
	        ISNULL(HIV_P_NOT_TARV_Adult, 0)  AS HIV_P_NOT_TARV_Adult,
	        ISNULL(HIV_N_Adult, 0)  AS HIV_N_Adult,
	        ISNULL(HIV_KNOWN_NREVEAL_Adult, 0)  AS  HIV_KNOWN_NREVEAL_Adult,
	        ISNULL(HIV_UNKNOWN_Adult, 0)  AS HIV_UNKNOWN_Adult,

	        ISNULL(obj_permanence_in_project.Permanence_btw_x_6_month, 0) AS Permanence_btw_x_6_month, 
	        ISNULL(obj_permanence_in_project.Permanence_btw_6_11_month, 0) AS Permanence_btw_6_11_month, 
	        ISNULL(obj_permanence_in_project.Permanence_btw_12_17_month, 0) AS Permanence_btw_12_17_month, 
	        ISNULL(obj_permanence_in_project.Permanence_btw_18_x_month, 0) AS Permanence_btw_18_x_month
        FROM
        (
	        SELECT
		        ChiefPartner--<<ReplaceColumn<<--
	        FROM
	        (
		        SELECT cp.Name As ChiefPartner, p.Name As Partner
		        FROM  [Partner] p
		        inner join  [Partner] cp on (p.SuperiorId = cp.PartnerID)
		        Where p.CollaboratorRoleID = 1
	        ) p
	        group by p.ChiefPartner--<<ReplaceColumn<<--
        ) p
        LEFT JOIN
        (
	        SELECT
		        obj_age.ChiefPartner--<<ReplaceColumn<<--
	            ,
		        SUM(obj_Age.btw_x_1_M) As btw_x_1_M,
		        SUM(obj_Age.btw_1_4_M) AS btw_1_4_M,
		        SUM(obj_Age.btw_5_9_M) AS btw_5_9_M,
		        SUM(obj_Age.btw_10_14_M) AS btw_10_14_M,
		        SUM(obj_Age.btw_15_17_M) AS btw_15_17_M,
		        SUM(obj_Age.btw_18_24_M) AS btw_18_24_M,
		        SUM(obj_Age.btw_25_x_M) AS btw_25_x_M,
		        SUM(obj_Age.btw_x_1_F) AS btw_x_1_F,
		        SUM(obj_Age.btw_1_4_F) AS btw_1_4_F,
		        SUM(obj_Age.btw_5_9_F) AS btw_5_9_F,
		        SUM(obj_Age.btw_10_14_F) AS btw_10_14_F,
		        SUM(obj_Age.btw_15_17_F) AS btw_15_17_F,
		        SUM(obj_Age.btw_18_24_F) AS btw_18_24_F,
		        SUM(obj_Age.btw_25_x_F) AS btw_25_x_F

	        FROM
	        (
		        SELECT
			        cp.Name As ChiefPartner,
			        p.Name As Partner,
			        count(ben.BeneficiaryID) as ID,
			        ben.FirstName As FirstName, 
			        ben.LastName As LastName, 
			        btw_x_1_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) < 12 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_1_4_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 12 AND 59 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_5_9_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 60 AND 119 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_10_14_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 120 AND 179 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_15_17_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 180 AND 215 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_18_24_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 216 AND 299 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_25_x_M = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) >= 300 AND ben.Gender = 'M' THEN 1 ELSE 0 END,
			        btw_x_1_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) < 12 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_1_4_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 12 AND 59 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_5_9_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 60 AND 119 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_10_14_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 120 AND 179 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_15_17_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 180 AND 215 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_18_24_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) BETWEEN 216 AND 299 AND ben.Gender = 'F' THEN 1 ELSE 0 END,
			        btw_25_x_F = CASE WHEN DATEDIFF(month, CAST(ben.DateOfBirth As Date), @lastDate) >= 300 AND ben.Gender = 'F' THEN 1 ELSE 0 END
		        FROM  [Partner] p
		        inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		        inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		        inner join [Beneficiary] ben ON ben.HouseholdID = hh.HouseHoldID
		        inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID]
		        WHERE p.CollaboratorRoleID = 1
		        AND ben.BeneficiaryID IN 
		        (-- Beneficiário em que o último estado é Graduado no intervalo de datas
			        SELECT
				        benStatusObj.BeneficiaryID
			        FROM
			        (
				        SELECT 
					        row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
					        --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					        ,[ChildStatusID]
					        ,BeneficiaryID
				        FROM [ChildStatusHistory] csh
				        WHERE csh.[EffectiveDate] BETWEEN @FiscalYearinitialDate AND @lastDate
			        )benStatusObj
			        JOIN ChildStatus cs ON cs.StatusID = benStatusObj.ChildStatusID 
			        AND cs.Description = 'Graduação' AND benStatusObj.LastStatusRow = 1 
			        -- Verifica se o último estado do Intervalo escolhido é Graduado
		        )
		        group by cp.Name, p.Name, ben.BeneficiaryID, ben.FirstName, ben.LastName, Ben.DateOfBirth, ben.Gender
	        )obj_age 
	        group by obj_age.ChiefPartner--<<ReplaceColumn<<--
        )
        obj_Age
        ON 
        (
	        p.ChiefPartner--<<ReplaceColumn<<--
	        =
	        obj_Age.ChiefPartner--<<ReplaceColumn<<--
        )
        LEFT JOIN
        (
	        SELECT
		        hiv_obj.ChiefPartner--<<ReplaceColumn<<--
	            ,
		        SUM(HIV_P_IN_TARV_Child) AS HIV_P_IN_TARV_Child,
		        SUM(HIV_P_IN_TARV_Adult) AS HIV_P_IN_TARV_Adult,
		        SUM(HIV_P_NOT_TARV_Child) AS HIV_P_NOT_TARV_Child,
		        SUM(HIV_P_NOT_TARV_Adult) AS HIV_P_NOT_TARV_Adult,
		        SUM(HIV_N_Child) AS HIV_N_Child,
		        SUM(HIV_N_Adult) AS HIV_N_Adult,
		        SUM(HIV_KNOWN_NREVEAL_Child) AS HIV_KNOWN_NREVEAL_Child,
		        SUM(HIV_KNOWN_NREVEAL_Adult) AS  HIV_KNOWN_NREVEAL_Adult,
		        SUM(HIV_NOT_RECOMMENDED_Child) AS  HIV_NOT_RECOMMENDED_Child,
		        SUM(HIV_NOT_RECOMMENDED_Adult) AS  HIV_NOT_RECOMMENDED_Adult,
		        SUM(HIV_UNKNOWN_Child) AS HIV_UNKNOWN_Child,
		        SUM(HIV_UNKNOWN_Adult) AS HIV_UNKNOWN_Adult
	        FROM
	        (
		        SELECT
			        cp.Name AS ChiefPartner
			        ,p.[Name] AS Partner
			        ,hh.HouseholdName AS HouseholdName
			        ,ben.RegistrationDate AS RegistrationDate
			        ,ben.FirstName AS FirstName
			        ,ben.LastName AS LastName
			        ,ben.Gender AS Gender
			        ,ben.DateOfBirth,
			        HIV_P_IN_TARV_Child = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_P_IN_TARV_Adult = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_P_NOT_TARV_Child = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_P_NOT_TARV_Adult = CASE WHEN hiv.HIV = 'P' AND hiv.HIVInTreatment = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_N_Child = CASE WHEN hiv.HIV = 'N' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_N_Adult = CASE WHEN hiv.HIV = 'N' AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_KNOWN_NREVEAL_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_KNOWN_NREVEAL_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 0 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_NOT_RECOMMENDED_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 2 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_NOT_RECOMMENDED_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 2 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END,
			        HIV_UNKNOWN_Child = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) < 18 THEN 1 ELSE 0 END,
			        HIV_UNKNOWN_Adult = CASE WHEN hiv.HIV = 'U' AND hiv.HIVUndisclosedReason = 1 AND DATEDIFF(year,CAST(Ben.DateOfBirth AS Date), @lastDate) >= 18 THEN 1 ELSE 0 END
		        FROM [Partner] p
		        inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		        inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		        inner join [Beneficiary] ben ON ben.HouseholdID = hh.HouseHoldID
		        inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID]
		        inner join [HIVStatus] hiv ON hiv.BeneficiaryID = ben.BeneficiaryID 
		        AND hiv.HIVStatusID IN -- Último estado de HIV no intervalo de datas
		        (
			        SELECT
				        benHIVStatusObj.HIVStatusID
			        FROM
			        (
				        SELECT 
					        row_number() OVER (PARTITION BY BeneficiaryID ORDER BY InformationDate DESC) AS LastHIVStatusRow
					        --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					        ,HIVStatusID
					        ,BeneficiaryID
				        FROM [HIVStatus] hiv
				        WHERE hiv.InformationDate <= @lastDate
			        )benHIVStatusObj
			        WHERE benHIVStatusObj.LastHIVStatusRow = 1 
			        -- Verifica o último estado de HIV do Intervalo
		        )
		        WHERE p.CollaboratorRoleID = 1
		        AND ben.BeneficiaryID IN 
		        (-- Beneficiário em que o último estado é Graduado no intervalo de datas
			        SELECT
				        benStatusObj.BeneficiaryID
			        FROM
			        (
				        SELECT 
					        row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
					        --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					        ,[ChildStatusID]
					        ,BeneficiaryID
				        FROM [ChildStatusHistory] csh
				        WHERE csh.[EffectiveDate] BETWEEN @FiscalYearinitialDate AND @lastDate
			        )benStatusObj
			        JOIN ChildStatus cs ON cs.StatusID = benStatusObj.ChildStatusID 
			        AND cs.Description = 'Graduação' AND benStatusObj.LastStatusRow = 1 
			        -- Verifica se o último estado do Intervalo escolhido é Graduado
		        )
	        )hiv_obj 
	        group by hiv_obj.ChiefPartner--<<ReplaceColumn<<--
        )hiv_obj
        ON 
        (
	        p.ChiefPartner--<<ReplaceColumn<<--
	        =
	        hiv_obj.ChiefPartner--<<ReplaceColumn<<--
        ) 
        LEFT JOIN
        (
	        SELECT
		        obj_permanence_in_project.ChiefPartner--<<ReplaceColumn<<--
	            ,
		        SUM(obj_permanence_in_project.Permanence_btw_x_6_month) AS Permanence_btw_x_6_month, 
		        SUM(obj_permanence_in_project.Permanence_btw_6_11_month) AS Permanence_btw_6_11_month, 
		        SUM(obj_permanence_in_project.Permanence_btw_12_17_month) AS Permanence_btw_12_17_month, 
		        SUM(obj_permanence_in_project.Permanence_btw_18_x_month) AS Permanence_btw_18_x_month
	        FROM
	        (
		        SELECT
			        cp.Name As ChiefPartner,
			        p.Name As Partner,
			        Permanence_btw_x_6_month = CASE WHEN DATEDIFF(month, CAST(benView.RegistrationDate As Date), csh.EffectiveDate) < 6 THEN 1 ELSE 0 END,
			        Permanence_btw_6_11_month  = CASE WHEN DATEDIFF(month, CAST(benView.RegistrationDate As Date), csh.EffectiveDate) BETWEEN 6 AND 11 THEN 1 ELSE 0 END,
			        Permanence_btw_12_17_month  = CASE WHEN DATEDIFF(month, CAST(benView.RegistrationDate As Date), csh.EffectiveDate) BETWEEN 12 AND 17 THEN 1 ELSE 0 END,
			        Permanence_btw_18_x_month  = CASE WHEN DATEDIFF(month, CAST(benView.RegistrationDate As Date), csh.EffectiveDate) > 18 THEN 1 ELSE 0 END
		        FROM [Partner] p
		        inner join [Partner] cp on (p.SuperiorId = cp.PartnerID) 
		        inner join [HouseHold] hh on (p.PartnerID = hh.PartnerID)
		        inner join [Beneficiary] ben ON ben.HouseholdID = hh.HouseHoldID
		        inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID]
		        inner join [ChildStatusHistory] csh ON csh.BeneficiaryID = ben.BeneficiaryID 
		        AND csh.[ChildStatusHistoryID] IN 
		        (-- Estado do Beneficiário no intervalo de datas
			        SELECT
				        benStatusObj.[ChildStatusHistoryID]
			        FROM
			        (
				        SELECT 
					        row_number() OVER (PARTITION BY BeneficiaryID ORDER BY EffectiveDate DESC) AS LastStatusRow
					        --Obter o número da linha de acordo com BeneficiaryID, e ordenado pela Data de Efectividade de forma DESCENDENTE(Último ao Primeiro)
					        ,[ChildStatusHistoryID]
					        ,[ChildStatusID]
					        ,BeneficiaryID
				        FROM [ChildStatusHistory] csh
				        WHERE csh.[EffectiveDate] BETWEEN @FiscalYearinitialDate AND @lastDate
			        )benStatusObj
			        JOIN ChildStatus cs ON cs.StatusID = benStatusObj.ChildStatusID 
			        AND cs.Description = 'Graduação' AND benStatusObj.LastStatusRow = 1 
			        -- Verifica se o último estado do Intervalo escolhido é Graduado
		        )
	        )obj_permanence_in_project
	        group by obj_permanence_in_project.ChiefPartner--<<ReplaceColumn<<--
        )
        obj_permanence_in_project
        ON 
        (
	        p.ChiefPartner--<<ReplaceColumn<<--
	        =
	        obj_permanence_in_project.ChiefPartner--<<ReplaceColumn<<--
        )";

        public List<MonthlyGraduatedBeneficiariesSummaryDTO> getCumulativeGraduatedBeneficiariesSummaryChiefPartner(DateTime FiscalYearinitialDate, DateTime initialDate, DateTime lastDate)
        {
            return getCumulativeGraduatedBeneficiariesSummary(FiscalYearinitialDate, initialDate, lastDate, "chiefpartner");
        }

        public List<MonthlyGraduatedBeneficiariesSummaryDTO> getCumulativeGraduatedBeneficiariesSummaryPartner(DateTime FiscalYearinitialDate, DateTime initialDate, DateTime lastDate)
        {
            return getCumulativeGraduatedBeneficiariesSummary(FiscalYearinitialDate, initialDate, lastDate, "partner");
        }

        public List<MonthlyGraduatedBeneficiariesSummaryDTO> getCumulativeGraduatedBeneficiariesSummary(DateTime FiscalYearinitialDate, DateTime initialDate, DateTime lastDate, string partnerType)
        {
            if (partnerType.Equals("partner"))
            {
                QueryCumulativeGraduatedBeneficiariesSummary = QueryCumulativeGraduatedBeneficiariesSummary.Replace("ChiefPartner--<<ReplaceColumn<<--", "Partner");
            }
            else
            {
                QueryCumulativeGraduatedBeneficiariesSummary = QueryCumulativeGraduatedBeneficiariesSummary;
            }

            return UnitOfWork.DbContext.Database.SqlQuery<MonthlyGraduatedBeneficiariesSummaryDTO>(QueryCumulativeGraduatedBeneficiariesSummary,
                                                            new SqlParameter("FiscalYearinitialDate", FiscalYearinitialDate),
                                                            new SqlParameter("initialDate", initialDate),
                                                            new SqlParameter("lastDate", lastDate)).ToList();
        }

        // Resumo Mensal de Visitas Realizadas
        public static String QueryRoutineVisitMonthlySummary =
        @"SELECT  
	        DomainOrder,
	        Domain,
	        Question,
	        SUM(btw_x_1_M) AS btw_x_1_M,
	        SUM(btw_1_4_M) AS btw_1_4_M,
	        SUM(btw_5_9_M) AS btw_5_9_M,
	        SUM(btw_10_14_M) AS btw_10_14_M,
	        SUM(btw_15_17_M) AS btw_15_17_M,
	        SUM(btw_18_24_M) AS btw_18_24_M,
	        SUM(btw_25_x_M) AS btw_25_x_M,
	        SUM(btw_x_1_F) AS btw_x_1_F,
	        SUM(btw_1_4_F) AS btw_1_4_F,
	        SUM(btw_5_9_F) AS btw_5_9_F,
	        SUM(btw_10_14_F) AS btw_10_14_F,
	        SUM(btw_15_17_F) AS btw_15_17_F,
	        SUM(btw_18_24_F) AS btw_18_24_F,
	        SUM(btw_25_x_F) AS btw_25_x_F,
	        SupportServiceOrderInDomain
        FROM
	        (SELECT 
	        sst.TypeDescription AS Domain,
	        sst.Description AS Question,
	        sst.SupportServiceOrderInDomain,
	        sst.DomainOrder,
	        btw_x_1_M = CASE WHEN ben.Gender = 'M' and DATEDIFF(MONTH, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) < 12 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_1_4_M = CASE WHEN ben.Gender = 'M' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) BETWEEN 1 AND 4 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_5_9_M = CASE WHEN ben.Gender = 'M' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate)  BETWEEN 5 AND 9 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_10_14_M = CASE WHEN ben.Gender = 'M' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) BETWEEN 10 AND 14 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_15_17_M = CASE WHEN ben.Gender = 'M' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) BETWEEN 15 AND 17 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_18_24_M = CASE WHEN ben.Gender = 'M' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) BETWEEN 18 AND 24 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_25_x_M = CASE WHEN ben.Gender = 'M' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) > 24 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_x_1_F = CASE WHEN ben.Gender = 'F' and DATEDIFF(MONTH, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) < 12 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_1_4_F = CASE WHEN ben.Gender = 'F' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) BETWEEN 1 AND 4 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_5_9_F = CASE WHEN ben.Gender = 'F' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate)  BETWEEN 5 AND 9 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_10_14_F = CASE WHEN ben.Gender = 'F' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) BETWEEN 10 AND 14 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_15_17_F = CASE WHEN ben.Gender = 'F' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) BETWEEN 15 AND 17 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_18_24_F = CASE WHEN ben.Gender = 'F' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) BETWEEN 18 AND 24 AND rvs.Checked = '1' THEN 1 ELSE 0 END,
	        btw_25_x_F = CASE WHEN ben.Gender = 'F' and DATEDIFF(YEAR, CAST(ben.DateOfBirth AS Date), rv.RoutineVisitDate) > 24 AND rvs.Checked = '1' THEN 1 ELSE 0 END
	        from HouseHold hh
	        inner join Beneficiary ben on ben.HouseholdID = hh.HouseHoldID
	        inner join [vw_beneficiary_details] benView ON benView.ID = ben.[BeneficiaryID]
	        inner join RoutineVisitMember rvm on rvm.BeneficiaryID = ben.BeneficiaryID 
	        inner join RoutineVisit rv on rv.RoutineVisitID = rvm.RoutineVisitID
	        AND rv.RoutineVisitDate BETWEEN @initialDate and @lastDate and rv.Version = 'v2'
	        inner join RoutineVisitSupport rvs on rvs.RoutineVisitMemberID = rvm.RoutineVisitMemberID AND rvs.Checked = '1'
	        inner join SupportServiceType sst on sst.SupportServiceTypeID = rvs.SupportID AND sst.Tool='routine-visit'
	        ) q
        GROUP BY DomainOrder, Domain, Question, SupportServiceOrderInDomain
        ORDER BY DomainOrder, SupportServiceOrderInDomain";

        public List<RoutineVisitMonthlyDTO> getRoutineVisitMonthlySummary(DateTime initialDate, DateTime lastDate)
        {
            return UnitOfWork.DbContext.Database.SqlQuery<RoutineVisitMonthlyDTO>(QueryRoutineVisitMonthlySummary,
                                                            new SqlParameter("initialDate", initialDate),
                                                            new SqlParameter("lastDate", lastDate)).ToList();
        }


        public Dictionary<string, List<string>> FindReportDataByCodeAndInitialDateAndLastDate(string QueryCode, DateTime initialDate, DateTime lastDate)
        {
            // Group and Sum this informtation
            List<ReportData> reportData = UnitOfWork.Repository<ReportData>().GetAll().Where(x => x.QueryCode.Equals(QueryCode) && 
                initialDate <= x.InitialPositionDate && lastDate >= x.FinalPositionDate).ToList();

            List<string> outList;
            Dictionary<string, List<string>> groupedData = new Dictionary<string, List<string>>();

            foreach (var DataRow in reportData)
            {
                if (groupedData.TryGetValue(DataRow.Field1, out outList))
                { groupedData[DataRow.Field1] = groupedData[DataRow.Field1].ToList().Concat(ConvertReportDataToStringList(DataRow, 2)).ToList(); }
                else
                { groupedData.Add(DataRow.Field1, ConvertReportDataToStringList(DataRow, 1)); }
            }

            return groupedData;
        }

        public List<string> ConvertReportDataToStringList(ReportData DataRow, int startFrom)
        {
            List<string> DataRowList = new List<string>();

            for (int i = startFrom; true; i++)
            {
                PropertyInfo prop = DataRow.GetType().GetProperty("Field" + i, BindingFlags.Public | BindingFlags.Instance);
                if (null == prop) { break; }
                else {
                    var value = prop.GetValue(DataRow, null);
                    DataRowList.Add(value == null ? string.Empty : (string) prop.GetValue(DataRow, null));
                }
            }

            return DataRowList;
        }

        public List<UniqueEntity> findAllReportDataUniqueEntities() => UnitOfWork.DbContext.Database.SqlQuery<UniqueEntity>("Select SyncGuid, ReportDataID As ID from ReportData").ToList();

        public ReportData findByID(int ID) => UnitOfWork.Repository<ReportData>().GetById(ID);

        public void SaveOrUpdate(ReportData reportData)
        {
            if (reportData.ReportDataID == 0)
            { UnitOfWork.Repository<ReportData>().Add(reportData); }
            else
            { UnitOfWork.Repository<ReportData>().Update(reportData); }
        }

        public int ImportData(string fullPath)
        {
            _logger.Information("IMPORTACAO DE DADOS DOS RELATÓRIOS...");

            UnitOfWork.DbContext.Configuration.AutoDetectChangesEnabled = false;

            string lastGuidToImport = null;
            int ReportDataCount = 0;
            FileImporter imp = new FileImporter();
            DataTable dt2 = imp.ImportFromCSV(fullPath);

            UsersDB = ConvertListToHashtableUsers(findAllUsersUniqueEntities());
            Hashtable ReportDataDB = ConvertListToHashtable(findAllReportDataUniqueEntities());
            // ClearMEReportTableBeforeImport(dt2);

            try
            {
                foreach (DataRow row in dt2.Rows)
                {
                    Guid ReportData_guid = new Guid(row["ReportData_guid"].ToString());
                    lastGuidToImport = ReportData_guid.ToString();

                    int ReportDataID = ParseStringToIntSafe(ReportDataDB[ReportData_guid]);
                    ReportData ReportData = (ReportDataID > 0) ? findByID(ReportDataID) : new ReportData();
                    ReportData.ExecutionNumber = int.Parse(row["ExecutionNumber"].ToString());
                    ReportData.QueryCode = row["QueryCode"].ToString();
                    ReportData.SiteName = row["SiteName"].ToString();
                    ReportData.Province = row["Province"].ToString();
                    ReportData.District = row["District"].ToString();
                    ReportData.Field1 = row["Field1"].ToString().Equals("") ? "0" : row["Field1"].ToString();
                    ReportData.Field2 = row["Field2"].ToString().Equals("") ? "0" : row["Field2"].ToString();
                    ReportData.Field3 = row["Field3"].ToString().Equals("") ? "0" : row["Field3"].ToString();
                    ReportData.Field4 = row["Field4"].ToString().Equals("") ? "0" : row["Field4"].ToString();
                    ReportData.Field5 = row["Field5"].ToString().Equals("") ? "0" : row["Field5"].ToString();
                    ReportData.Field6 = row["Field6"].ToString().Equals("") ? "0" : row["Field6"].ToString();
                    ReportData.Field7 = row["Field7"].ToString().Equals("") ? "0" : row["Field7"].ToString();
                    ReportData.Field8 = row["Field8"].ToString().Equals("") ? "0" : row["Field8"].ToString();
                    ReportData.Field9 = row["Field9"].ToString().Equals("") ? "0" : row["Field9"].ToString();
                    ReportData.Field10 = row["Field10"].ToString().Equals("") ? "0" : row["Field10"].ToString();
                    ReportData.Field11 = row["Field11"].ToString().Equals("") ? "0" : row["Field11"].ToString();
                    ReportData.Field12 = row["Field12"].ToString().Equals("") ? "0" : row["Field12"].ToString();
                    ReportData.Field13 = row["Field13"].ToString().Equals("") ? "0" : row["Field13"].ToString();
                    ReportData.Field14 = row["Field14"].ToString().Equals("") ? "0" : row["Field14"].ToString();
                    ReportData.Field15 = row["Field15"].ToString().Equals("") ? "0" : row["Field15"].ToString();
                    ReportData.Field16 = row["Field16"].ToString().Equals("") ? "0" : row["Field16"].ToString();
                    ReportData.Field17 = row["Field17"].ToString().Equals("") ? "0" : row["Field17"].ToString();
                    ReportData.Field18 = row["Field18"].ToString().Equals("") ? "0" : row["Field18"].ToString();
                    ReportData.Field19 = row["Field19"].ToString().Equals("") ? "0" : row["Field19"].ToString();
                    ReportData.Field20 = row["Field20"].ToString().Equals("") ? "0" : row["Field20"].ToString();
                    ReportData.Field21 = row["Field21"].ToString().Equals("") ? "0" : row["Field21"].ToString();
                    ReportData.Field22 = row["Field22"].ToString().Equals("") ? "0" : row["Field22"].ToString();
                    ReportData.Field23 = row["Field23"].ToString().Equals("") ? "0" : row["Field23"].ToString();
                    ReportData.Field24 = row["Field24"].ToString().Equals("") ? "0" : row["Field24"].ToString();
                    ReportData.Field25 = row["Field25"].ToString().Equals("") ? "0" : row["Field25"].ToString();
                    ReportData.Field26 = row["Field26"].ToString().Equals("") ? "0" : row["Field26"].ToString();
                    ReportData.Field27 = row["Field27"].ToString().Equals("") ? "0" : row["Field27"].ToString();
                    ReportData.Field28 = row["Field28"].ToString().Equals("") ? "0" : row["Field28"].ToString();
                    ReportData.Field29 = row["Field29"].ToString().Equals("") ? "0" : row["Field29"].ToString();
                    ReportData.Field30 = row["Field30"].ToString().Equals("") ? "0" : row["Field30"].ToString();
                    ReportData.Field31 = row["Field31"].ToString().Equals("") ? "0" : row["Field31"].ToString();
                    ReportData.Field32 = row["Field32"].ToString().Equals("") ? "0" : row["Field32"].ToString();
                    ReportData.Field33 = row["Field33"].ToString().Equals("") ? "0" : row["Field33"].ToString();
                    ReportData.Field34 = row["Field34"].ToString().Equals("") ? "0" : row["Field34"].ToString();
                    ReportData.Field35 = row["Field35"].ToString().Equals("") ? "0" : row["Field35"].ToString();
                    ReportData.InitialPositionDate = (row["InitialPositionDate"].ToString()).Length == 0 ? (DateTime?)null : DateTime.Parse(row["InitialPositionDate"].ToString());
                    ReportData.FinalPositionDate = (row["FinalPositionDate"].ToString()).Length == 0 ? (DateTime?)null : DateTime.Parse(row["FinalPositionDate"].ToString());
                    SetCreationDataFields(ReportData, row, ReportData_guid);
                    SetUpdatedDataFields(ReportData, row);
                    SaveOrUpdate(ReportData);
                    ReportDataCount++;
                }

                UnitOfWork.Commit();
                Rename(fullPath, fullPath + IMPORTED);
                return ReportDataCount;
            }
            catch (Exception e)
            {
                _logger.Information("Erro ao importar o Guid : " + lastGuidToImport);
                _logger.Error(e, "Erro ao importar Dados dos Relatórios", null);
                throw e;
            }
            finally
            {
                UnitOfWork.Dispose();
            }
        }

        private void ClearMEReportTableBeforeImport(DataTable dt2)
        {
            DataRow FileFirstRow = dt2.Rows[0];
            string SiteName = FileFirstRow["SiteName"].ToString();
            DateTime initialDate = DateTime.Parse(FileFirstRow["InitialPositionDate"].ToString());
            DateTime lastDate = DateTime.Parse(FileFirstRow["FinalPositionDate"].ToString());
            List<string> QueryCodes = new List<string>
            { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13"};
            QueryCodes.ForEach(queryCode =>
            {
                List<ReportData> existingRecords = UnitOfWork.DbContext.ReportData.Where(data =>
                data.InitialPositionDate == initialDate &&
                data.FinalPositionDate == lastDate &&
                data.QueryCode == queryCode && data.SiteName == SiteName)
                .ToList();

                if (existingRecords.Count() > 0)
                {
                    existingRecords.ForEach(record => UnitOfWork.DbContext.ReportData.Remove(record));
                    UnitOfWork.DbContext.SaveChanges();
                }
            });
        }
    }
}
