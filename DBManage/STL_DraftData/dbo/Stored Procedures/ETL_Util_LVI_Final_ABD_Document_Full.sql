
-- =============================================
-- Author:		RAlizade
-- Create date: 2018-05-10
-- Description:	Utils for package LVI_Final_ABD_Document_Full
-- SQL Utils for LVI_Final_ABD_Document_Full package
-- =============================================
CREATE PROCEDURE [dbo].[ETL_Util_LVI_Final_ABD_Document_Full] 
(
	 @DraftData		nvarchar(100) = '',
	 @MainData		nvarchar(100) = '',
	 @WayNumber		nvarchar(32) = ''
)
AS
BEGIN
	set nocount on;

	declare 
		 @SQL_Query	nvarchar(max);
 /*
	DROP TABLE IF EXISTS #TMP_WPCR;
	DROP TABLE IF EXISTS #TMP_WPCQ; 
	DROP TABLE IF EXISTS #Tmp_All_COWRegs;

	DROP TABLE IF EXISTS TMP_WPCR;
	DROP TABLE IF EXISTS TMP_WPCQ; 
	DROP TABLE IF EXISTS Tmp_All_COWRegs;
*/
    --prepare COW data R_WorkProgressCOWQuantity


	IF @WayNumber = '1' -- Update s_ABD_Mod
	BEGIN 

		SET @SQL_Query = 
		N'update '+@DraftData+'.dbo.s_ABD_Mod
		set ABDDocument_ID=ABD.ABDDocument_ID
		from '+@MainData+'.dbo.ABDDocument ABD
		join '+@DraftData+'.dbo.s_ABD_Mod SABD ON SABD.INT_Document_Sequiential_No_in_Folder = ABD.Number_in_Folder
		and SABD.Folder_Number = ABD.ABDFinalFolder_Name';

		EXECUTE sp_executesql @SQL_Query;
	END 

END -- End of the Procedure


	/*
		 N'SELECT  distinct
				   tio.TitleObject_Name 
		   	      ,m.Marka_Name 
				  ,wc.WorkClass_Name
				  ,u.Module_Name
				  ,wpc.JobCard
				  ,tio.TitleObject_ID
				  ,m.Marka_ID
				  ,wpc.Log_ID 
				  ,wc.WorkClass_ID
				  ,u.Module_ID
				  ,wpc.[1_ABD_cur_state_ID]
				  ,wpc.[1_reg]
				  ,wpc.[2_ABD_cur_state_ID]
				  ,wpc.[2_reg]
				  ,wpc.[3_ABD_cur_state_ID]
				  ,wpc.[3_reg]
				  ,wpc.[4_ABD_cur_state_ID]
				  ,wpc.[4_reg]
				  ,wpc.[5_ABD_cur_state_ID]
				  ,wpc.[5_reg]
				  ,wpc.[6_ABD_cur_state_ID]
				  ,wpc.[6_reg]
				  ,wpc.[7_ABD_cur_state_ID]
				  ,wpc.[7_reg]
				  ,wpc.[8_ABD_cur_state_ID]
				  ,wpc.[8_reg]
				  ,wpc.[9_ABD_cur_state_ID]
				  ,wpc.[9_reg]
				  ,wpc.Source_File
		   INTO TMP_WPCQ
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpc 
		   INNER JOIN '+@MainData+'.dbo.p_WorkPackage as wp ON wpc.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.p_Marka as m ON wpc.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.p_TitleObject as TiO ON wpc.TitleObject_ID = tio.TitleObject_ID
		   INNER JOIN '+@MainData+'.dbo.p_WorkClass as wc ON wpc.Swc_WorkClass_ID = wc.WorkClass_ID
		   INNER JOIN '+@MainData+'.dbo.p_Module as u ON wpc.Module_ID = u.Module_ID
		   WHERE  1=2';

		EXECUTE sp_executesql @SQL;
		*/