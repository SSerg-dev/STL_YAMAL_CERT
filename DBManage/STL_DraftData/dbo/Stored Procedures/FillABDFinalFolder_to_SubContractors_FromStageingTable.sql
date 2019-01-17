

-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-12-12
-- Description:	Used in SSIS package LVI_Final_ABD_Compilation_Full
-- =============================================
CREATE PROCEDURE [dbo].[FillABDFinalFolder_to_SubContractors_FromStageingTable] 
(
	 @DraftData		nvarchar(100) = '',
	 @MainData		nvarchar(100) = ''
)
AS
BEGIN
	set nocount on;

	declare 
		 @SQL		nvarchar(max);

	DROP TABLE IF EXISTS #TMP_F_To_SC;

	CREATE TABLE #TMP_F_To_SC (folder nvarchar(300)
						  ,SubContractor nvarchar(255)
						  ,ABDFinalFolder_ID uniqueidentifier
						  ,SubContractor_ID uniqueidentifier);
    -- Create temp table with data from denormalised tables, databaser params from package, to make easyer Debugging package in DEV_
	SET @SQL = 
		 N'INSERT INTO #TMP_F_To_SC (folder, SubContractor, ABDFinalFolder_ID, SubContractor_ID)
		   SELECT DISTINCT a.Folder,a.SubContractor,f.ABDFinalFolder_ID,s.SubContractor_ID
		   FROM (SELECT folder, N''YAM'' as SubContractor 
				 FROM '+@DraftData+'.dbo.s_Final_ABD_Compilation_LOG
				 WHERE C_YAM is not null and ltrim(rtrim(C_YAM)) <> ''''
				 UNION ALL
				 SELECT folder, N''VEL'' as SubContractor 
				 FROM '+@DraftData+'.dbo.s_Final_ABD_Compilation_LOG
				 WHERE C_VEL is not null and ltrim(rtrim(C_VEL)) <> ''''
				 UNION ALL
				 SELECT folder, N''ZPGS'' as SubContractor 
				 FROM '+@DraftData+'.dbo.s_Final_ABD_Compilation_LOG
				 WHERE C_ZPGS is not null and ltrim(rtrim(C_ZPGS)) <> ''''
				 UNION ALL
				 SELECT folder, N''KXM'' as SubContractor 
				 FROM '+@DraftData+'.dbo.s_Final_ABD_Compilation_LOG
				 WHERE C_KXM is not null and ltrim(rtrim(C_KXM)) <> ''''
				 UNION ALL
				 SELECT folder, N''REGA'' as SubContractor 
				 FROM '+@DraftData+'.dbo.s_Final_ABD_Compilation_LOG
				 WHERE C_REGA is not null and ltrim(rtrim(C_REGA)) <> ''''
				 UNION ALL
				 SELECT folder, N''NOVA'' as SubContractor 
				 FROM '+@DraftData+'.dbo.s_Final_ABD_Compilation_LOG
				 WHERE C_NOVA is not null and ltrim(rtrim(C_NOVA)) <> ''''
				 UNION ALL
				 SELECT folder, N''SNEMA'' as SubContractor 
				 FROM '+@DraftData+'.dbo.s_Final_ABD_Compilation_LOG
				 WHERE C_SNEMA is not null) a
				 left join '+@MainData+'.dbo.p_ABDFinalFolder f ON a.Folder = f.ABDFinalFolder_Name
				 left join '+@MainData+'.dbo.p_SubContractor s ON a.SubContractor = s.SubContractor_Name  
				 ORDER BY folder';

	EXECUTE sp_executesql @SQL;
	--Fill 'to' table with data from temp table
	SET @SQL = 
		 N'INSERT INTO '+@MainData+'.[dbo].[p_ABDFinalFolder_to_SubContractor]
                      ([ABDFinalFolder_to_SubContractor_ID]
                      ,[Insert_DTS]
                      ,[Update_DTS]
                      ,[Row_Status]
                      ,[ABDFinalFolder_ID]
                      ,[SubContractor_ID])
           SELECT newid()
                  ,getdate()
                  ,getdate()
                  ,0
                  ,ABDFinalFolder_ID
                  ,SubContractor_ID
           FROM #TMP_F_To_SC
           WHERE ABDFinalFolder_ID is not null and SubContractor_ID is not null'

	EXECUTE sp_executesql @SQL;
	
	DROP TABLE IF EXISTS #TMP_F_To_SC;

END
