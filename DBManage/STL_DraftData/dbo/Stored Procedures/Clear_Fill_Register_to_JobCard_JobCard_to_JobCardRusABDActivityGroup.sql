


-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-12-19
-- Description:	Used in SSIS package LVI_WorkProgress_Full
-- Create temp table with data from denormalised tables, databaser params from package, to make easyer Debugging package in 
-- =============================================
CREATE PROCEDURE [dbo].[Clear_Fill_Register_to_JobCard_JobCard_to_JobCardRusABDActivityGroup] 
(
	 @DraftData		nvarchar(100) = '',
	 @MainData		nvarchar(100) = ''
)
AS
BEGIN
	set nocount on;

	--create and fill main data table for each WorkType directly
	declare @SQL00 nvarchar(max) = 
		 N'CREATE TABLE #TMP_RAW (FileLOG nvarchar(500) COLLATE Cyrillic_General_CI_AS, 
		                           Register_Number nvarchar(100) COLLATE Cyrillic_General_CI_AS, 
								   JobCard_Number nvarchar(100) COLLATE Cyrillic_General_CI_AS, 
								   Report_Order int)
								  ;'

	declare @sql01 nvarchar(max) = 
		 N'INSERT INTO #TMP_RAW
		   SELECT wpq.Source_File as FileLOG_Code,
				  wpq.[1_reg] as Register_Number,
	              JC.JobCard_Number as JobCard_Number,
	              1 as Report_Order
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.Module as l ON wpq.Module_ID = l.Module_ID
		   LEFT JOIN '+@MainData+'.dbo.JobCard as JC ON wpq.JobCard = JC.JobCard_Number
		   INNER JOIN '+@MainData+'.dbo.Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpq.[1_reg] is not null
		   ;'

	declare @sql02 nvarchar(max) = 
		 N'INSERT INTO #TMP_RAW
		   SELECT wpq.Source_File as FileLOG_Code,
				  wpq.[2_reg] as Register_Number,
	              JC.JobCard_Number as JobCard_Number,
	              2 as Report_Order
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.Module as l ON wpq.Module_ID = l.Module_ID
		   LEFT JOIN '+@MainData+'.dbo.JobCard as JC ON wpq.JobCard = JC.JobCard_Number
		   INNER JOIN '+@MainData+'.dbo.Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpq.[2_reg] is not null
		   ;'

	declare @sql03 nvarchar(max) = 
		 N'INSERT INTO #TMP_RAW
		   SELECT wpq.Source_File as FileLOG_Code,
				  wpq.[3_reg] as Register_Number,
	              JC.JobCard_Number as JobCard_Number,
	              3 as Report_Order
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.Module as l ON wpq.Module_ID = l.Module_ID
		   LEFT JOIN '+@MainData+'.dbo.JobCard as JC ON wpq.JobCard = JC.JobCard_Number
		   INNER JOIN '+@MainData+'.dbo.Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpq.[3_reg] is not null
		   ;'

	declare @sql04 nvarchar(max) = 
		 N'INSERT INTO #TMP_RAW
		   SELECT wpq.Source_File as FileLOG_Code,
				  wpq.[4_reg] as Register_Number,
	              JC.JobCard_Number as JobCard_Number,
	              4 as Report_Order
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.Module as l ON wpq.Module_ID = l.Module_ID
		   LEFT JOIN '+@MainData+'.dbo.JobCard as JC ON wpq.JobCard = JC.JobCard_Number
		   INNER JOIN '+@MainData+'.dbo.Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpq.[4_reg] is not null
		   ;'

	declare @sql05 nvarchar(max) = 
		 N'INSERT INTO #TMP_RAW
		   SELECT wpq.Source_File as FileLOG_Code,
				  wpq.[5_reg] as Register_Number,
	              JC.JobCard_Number as JobCard_Number,
	              5 as Report_Order
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.Module as l ON wpq.Module_ID = l.Module_ID
		   LEFT JOIN '+@MainData+'.dbo.JobCard as JC ON wpq.JobCard = JC.JobCard_Number
		   INNER JOIN '+@MainData+'.dbo.Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpq.[5_reg] is not null
		   ;'

	declare @sql06 nvarchar(max) = 
		 N'INSERT INTO #TMP_RAW
		   SELECT wpq.Source_File as FileLOG_Code,
				  wpq.[6_reg] as Register_Number,
	              JC.JobCard_Number as JobCard_Number,
	              6 as Report_Order
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.Module as l ON wpq.Module_ID = l.Module_ID
		   LEFT JOIN '+@MainData+'.dbo.JobCard as JC ON wpq.JobCard = JC.JobCard_Number
		   INNER JOIN '+@MainData+'.dbo.Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpq.[6_reg] is not null
		   ;'

	declare @sql07 nvarchar(max) = 
		 N'INSERT INTO #TMP_RAW
		   SELECT wpq.Source_File as FileLOG_Code,
				  wpq.[7_reg] as Register_Number,
	              JC.JobCard_Number as JobCard_Number,
	              7 as Report_Order
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.Module as l ON wpq.Module_ID = l.Module_ID
		   LEFT JOIN '+@MainData+'.dbo.JobCard as JC ON wpq.JobCard = JC.JobCard_Number
		   INNER JOIN '+@MainData+'.dbo.Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpq.[7_reg] is not null
		   ;'

	declare @sql08 nvarchar(max) = 
		 N'INSERT INTO #TMP_RAW
		   SELECT wpq.Source_File as FileLOG_Code,
				  wpq.[8_reg] as Register_Number,
	              JC.JobCard_Number as JobCard_Number,
	              8 as Report_Order
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.Module as l ON wpq.Module_ID = l.Module_ID
		   LEFT JOIN '+@MainData+'.dbo.JobCard as JC ON wpq.JobCard = JC.JobCard_Number
		   INNER JOIN '+@MainData+'.dbo.Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpq.[8_reg] is not null
		   ;'

	declare @sql09 nvarchar(max) = 
		 N'INSERT INTO #TMP_RAW
		   SELECT wpq.Source_File as FileLOG_Code,
				  wpq.[9_reg] as Register_Number,
	              JC.JobCard_Number as JobCard_Number,
	              9 as Report_Order
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.Module as l ON wpq.Module_ID = l.Module_ID
		   LEFT JOIN '+@MainData+'.dbo.JobCard as JC ON wpq.JobCard = JC.JobCard_Number
		   INNER JOIN '+@MainData+'.dbo.Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpq.[9_reg] is not null
		   ;'

	declare @sql10 nvarchar(max) = 
		 N'CREATE TABLE #TMP_Register_to_JobCard (FileLOG nvarchar(255) COLLATE Cyrillic_General_CI_AS, 
		                                           Register_ID uniqueidentifier, 
											       JobCard_ID uniqueidentifier, 
											       JobCardRusABDActivityGroup_ID uniqueidentifier)
												   ;'

	declare @sql11 nvarchar(max) = 
		 N'INSERT INTO #TMP_Register_to_JobCard  (FileLOG, Register_ID, JobCard_ID, JobCardRusABDActivityGroup_ID) 									
		   SELECT DISTINCT a.FileLOG, r.Register_ID, j.JobCard_ID, pwt.JobCardRusABDActivityGroup_ID
		   FROM #TMP_RAW AS a
		   JOIN '+@MainData+'.dbo.Register AS r on a.FileLOG = r.FileLOG and a.Register_Number = r.Register_Number
		   JOIN '+@MainData+'.dbo.JobCard AS j on a.JobCard_Number = j.JobCard_Number 
		   JOIN '+@MainData+'.dbo.JobCardRusABDActivityGroup pwt on a.Report_Order= pwt.Report_Order
		   ;'

	declare @sql12 nvarchar(max) = 
		 N'SELECT * 
		   INTO #TMP_Register_to_JobCard_Errors
           FROM #TMP_Register_to_JobCard;'

	-- insert errors into error table
	-- left only errors
	declare @sql13 nvarchar(max) = 
		 N'WITH CTE AS(SELECT t.FileLOG, t.JobCard_ID, t.JobCardRusABDActivityGroup_ID,
							  row_number() OVER(PARTITION BY t.FileLOG, t.JobCard_ID, t.JobCardRusABDActivityGroup_ID ORDER BY t.FileLOG) AS [rn]
		               FROM #TMP_Register_to_JobCard_Errors t
					   )
		   DELETE FROM cte WHERE [rn] = 1
		   ;'

	-- insert errors into error table
	-- left only errors
	declare @sql14 nvarchar(max) = 
		 N'INSERT INTO '+@DraftData+'.dbo.s_WPCOWQuantityErrors
				([JC]
				,[Source_File]
				,[Load_Date]
				,[Reason])
		   SELECT i.JobCard_Number
				,e.FileLOG
				,getdate()
				,32
		   FROM #TMP_Register_to_JobCard_Errors e
		   join '+@MainData+'.dbo.JobCard i on e.JobCard_ID = i.JobCard_ID
		   ;'


	-- clear errors
	declare @sql15 nvarchar(max) = 
		 N'WITH CTE AS(SELECT t.FileLOG, t.JobCard_ID, t.JobCardRusABDActivityGroup_ID,
							  row_number() OVER(PARTITION BY t.FileLOG, t.JobCard_ID, t.JobCardRusABDActivityGroup_ID ORDER BY t.FileLOG) AS [rn]
					   from #TMP_Register_to_JobCard t
					   )
		   delete from cte where [rn] > 1
		   ;'

	-- fill Final Tables
	declare @sql16 nvarchar(max) = 
	N'
		INSERT INTO '+@MainData+'.dbo.p_RegisterJobCardAction_m
			   ([RegisterJobCardAction_m_ID]
			   ,[Register_ID]
			   ,[JobCardRusABDActivityGroup_ID]
			   ,[JobCard_ID]
			   ,[Row_Status]
			   ,[Insert_DTS]
			   ,[Update_DTS]
				)
			Select 
				newid()
				,Register_ID
				,JobCardRusABDActivityGroup_ID
				,JobCard_ID
				,0
				,getdate()
				,getdate()	 
			from #TMP_Register_to_JobCard    
		;'

	declare @sql99 nvarchar(max) = ''
	--N'
	--	drop table if exists STL_SA..trm_raw2;
	--	drop table if exists STL_SA..trm_RI2;
	--	drop table if exists STL_SA..trm_RI_Err2;
	--	select * into STL_SA..trm_raw2		from #TMP_RAW									where 1=2;
	--	select * into STL_SA..trm_RI2		from #TMP_Register_to_JobCard					where 1=2;
	--	select * into STL_SA..trm_RI_Err2	from #TMP_Register_to_JobCard_Errors			where 1=2;
	--	insert into STL_SA..trm_raw2		select * from #TMP_RAW							where 1=1;
	--	insert into STL_SA..trm_RI2			select * from #TMP_Register_to_JobCard			where 1=1;
	--	insert into STL_SA..trm_RI_Err2		select * from #TMP_Register_to_JobCard_Errors	where 1=1;
	--'

	exec(@SQL00+@SQL01+@SQL02+@SQL03+@SQL04+@SQL05+@SQL06+@SQL07+@SQL08+@SQL09+@SQL10+@SQL11+@SQL12+@SQL13+@SQL14+@SQL15+@SQL16+@sql99)

END
