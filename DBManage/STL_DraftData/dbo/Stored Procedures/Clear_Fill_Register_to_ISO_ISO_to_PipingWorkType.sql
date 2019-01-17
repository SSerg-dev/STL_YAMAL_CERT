


-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-12-18
-- Description:	Used in SSIS package LVI_WorkProgress_Full
-- Create temp table with data from denormalised tables, databaser params from package, to make easyer Debugging package in 
-- =============================================
CREATE PROCEDURE [dbo].[Clear_Fill_Register_to_ISO_ISO_to_PipingWorkType] 
(
	 @DraftData		nvarchar(100) = '',
	 @MainData		nvarchar(100) = ''
)
AS
BEGIN
	set nocount on;




	--create and fill main data table for each WorkType directly
	declare @SQL4 nvarchar(max) = 
	N'	
		CREATE TABLE #TMP_RAW (FileLOG nvarchar(500) COLLATE Cyrillic_General_CI_AS, 
		Register_Number nvarchar(500) COLLATE Cyrillic_General_CI_AS, 
		ISO_Number nvarchar(100) COLLATE Cyrillic_General_CI_AS, 
		PipingWorktype nvarchar(100) COLLATE Cyrillic_General_CI_AS);
	'

	declare @SQL5 nvarchar(max) = 
	N'	
		INSERT INTO #TMP_RAW
		SELECT wpq.[Source_File] as FileLOG_Code, wpq.Shop_Weld_RegNum as Register_Number, ISO.ISO_Number, N''Shop weld'' as PipingWorktype
		FROM '+@MainData+'.dbo.WorkProgressPipingQuantity AS wpq 
		INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		
		INNER JOIN '+@MainData+'.dbo.Line as l ON wpq.Line_ID = l.Line_ID 
		LEFT JOIN '+@MainData+'.dbo.ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_Marka as LtoM ON l.Line_ID = LtoM.Line_ID 
		INNER JOIN '+@MainData+'.dbo.Marka as m ON LtoM.Marka_ID = m.Marka_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_TitleObject as LtoTO ON l.Line_ID = LtoTO.Line_ID 
		INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON LtoTO.TitleObject_ID = tio.TitleObject_ID
		WHERE wpq.Shop_Weld_RegNum is not null and Shop_Weld_AD_cur_State != N''Аннулирован / Cancelled'';
	'


	declare @SQL6 nvarchar(max) = 
	N'	
	
		INSERT INTO #TMP_RAW
		SELECT wpq.[Source_File] as FileLOG_Code, wpq.Field_Weld_RegNum as Register_Number, ISO.ISO_Number,	N''Field weld'' as PipingWorktype
		FROM '+@MainData+'.dbo.WorkProgressPipingQuantity AS wpq 
		INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 		
		INNER JOIN '+@MainData+'.dbo.Line as l ON wpq.Line_ID = l.Line_ID 
		LEFT JOIN '+@MainData+'.dbo.ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_Marka as LtoM ON l.Line_ID = LtoM.Line_ID 
		INNER JOIN '+@MainData+'.dbo.Marka as m ON LtoM.Marka_ID = m.Marka_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_TitleObject as LtoTO ON l.Line_ID = LtoTO.Line_ID 
		INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON LtoTO.TitleObject_ID = tio.TitleObject_ID
		WHERE wpq.Field_Weld_RegNum is not null and Field_Weld_AD_cur_State != N''Аннулирован / Cancelled'';
	'


	declare @SQL7 nvarchar(max) = 
	N'	
			INSERT INTO #TMP_RAW
			SELECT wpq.[Source_File] as FileLOG_Code, wpq.AKZ_Shop_RegNum as Register_Number, ISO.ISO_Number, N''Coating shop'' as PipingWorktype
			FROM '+@MainData+'.dbo.WorkProgressPipingQuantity AS wpq 
			INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 			
			INNER JOIN '+@MainData+'.dbo.Line as l ON wpq.Line_ID = l.Line_ID 
			LEFT JOIN '+@MainData+'.dbo.ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
			INNER JOIN '+@MainData+'.dbo.Line_to_Marka as LtoM ON l.Line_ID = LtoM.Line_ID 
			INNER JOIN '+@MainData+'.dbo.Marka as m ON LtoM.Marka_ID = m.Marka_ID 
			INNER JOIN '+@MainData+'.dbo.Line_to_TitleObject as LtoTO ON l.Line_ID = LtoTO.Line_ID 
			INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON LtoTO.TitleObject_ID = tio.TitleObject_ID
			WHERE wpq.AKZ_Shop_RegNum is not null and AKZ_Shop_AD_cur_State != N''Аннулирован / Cancelled'';
	'


	declare @SQL8 nvarchar(max) = 
	N'	
		INSERT INTO #TMP_RAW
		SELECT wpq.[Source_File] as FileLOG_Code, wpq.AKZ_Weld_RegNum as Register_Number, ISO.ISO_Number, N''Coating weld'' as PipingWorktype
		FROM '+@MainData+'.dbo.WorkProgressPipingQuantity AS wpq 
		INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 		
		INNER JOIN '+@MainData+'.dbo.Line as l ON wpq.Line_ID = l.Line_ID 
		LEFT JOIN '+@MainData+'.dbo.ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_Marka as LtoM ON l.Line_ID = LtoM.Line_ID 
		INNER JOIN '+@MainData+'.dbo.Marka as m ON LtoM.Marka_ID = m.Marka_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_TitleObject as LtoTO ON l.Line_ID = LtoTO.Line_ID 
		INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON LtoTO.TitleObject_ID = tio.TitleObject_ID
		WHERE wpq.AKZ_Weld_RegNum is not null and AKZ_Weld_AD_cur_State != N''Аннулирован / Cancelled'';
	'


	declare @SQL9 nvarchar(max) = 
	N'	
		INSERT INTO #TMP_RAW
		SELECT wpq.[Source_File] as FileLOG_Code, wpq.GW_RegNum_RegNum as Register_Number, ISO.ISO_Number,  N''Golden welds'' as PipingWorktype
		FROM '+@MainData+'.dbo.WorkProgressPipingQuantity AS wpq 
		INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 		
		INNER JOIN '+@MainData+'.dbo.Line as l ON wpq.Line_ID = l.Line_ID 
		LEFT JOIN '+@MainData+'.dbo.ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_Marka as LtoM ON l.Line_ID = LtoM.Line_ID 
		INNER JOIN '+@MainData+'.dbo.Marka as m ON LtoM.Marka_ID = m.Marka_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_TitleObject as LtoTO ON l.Line_ID = LtoTO.Line_ID 
		INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON LtoTO.TitleObject_ID = tio.TitleObject_ID
		WHERE wpq.GW_RegNum_RegNum is not null and GW_AD_cur_State != N''Аннулирован / Cancelled'';
	'


	declare @SQL10 nvarchar(max) = 
	N'	
		INSERT INTO #TMP_RAW
		SELECT wpq.[Source_File] as FileLOG_Code, wpq.Insulation_RegNum as Register_Number, ISO.ISO_Number,  N''Insulation'' as PipingWorktype
		FROM '+@MainData+'.dbo.WorkProgressPipingQuantity AS wpq 
		INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		INNER JOIN '+@MainData+'.dbo.Line as l ON wpq.Line_ID = l.Line_ID 
		LEFT JOIN '+@MainData+'.dbo.ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_Marka as LtoM ON l.Line_ID = LtoM.Line_ID 
		INNER JOIN '+@MainData+'.dbo.Marka as m ON LtoM.Marka_ID = m.Marka_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_TitleObject as LtoTO ON l.Line_ID = LtoTO.Line_ID 
		INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON LtoTO.TitleObject_ID = tio.TitleObject_ID
		WHERE wpq.Insulation_RegNum is not null and Insulation_AD_cur_State != N''Аннулирован / Cancelled'';
	'


	declare @SQL11 nvarchar(max) = 
	N'	
		INSERT INTO #TMP_RAW
		SELECT wpq.[Source_File] as FileLOG_Code, wpq.Test_Density_Strength as Register_Number, ISO.ISO_Number, N''Test density strength'' as PipingWorktype
		FROM '+@MainData+'.dbo.WorkProgressPipingQuantity AS wpq 
		INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		INNER JOIN '+@MainData+'.dbo.Line as l ON wpq.Line_ID = l.Line_ID 
		LEFT JOIN '+@MainData+'.dbo.ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_Marka as LtoM ON l.Line_ID = LtoM.Line_ID 
		INNER JOIN '+@MainData+'.dbo.Marka as m ON LtoM.Marka_ID = m.Marka_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_TitleObject as LtoTO ON l.Line_ID = LtoTO.Line_ID 
		INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON LtoTO.TitleObject_ID = tio.TitleObject_ID
		WHERE wpq.Test_Density_Strength is not null;
	'


	declare @SQL12 nvarchar(max) = 
	N'	
		INSERT INTO #TMP_RAW
			SELECT wpq.[Source_File] as FileLOG_Code, wpq.Test_Leak as Register_Number,	ISO.ISO_Number, N''Test leak'' as PipingWorktype
			FROM '+@MainData+'.dbo.WorkProgressPipingQuantity AS wpq 
			INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
			INNER JOIN '+@MainData+'.dbo.Line as l ON wpq.Line_ID = l.Line_ID 
			LEFT JOIN '+@MainData+'.dbo.ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
			INNER JOIN '+@MainData+'.dbo.Line_to_Marka as LtoM ON l.Line_ID = LtoM.Line_ID 
			INNER JOIN '+@MainData+'.dbo.Marka as m ON LtoM.Marka_ID = m.Marka_ID 
			INNER JOIN '+@MainData+'.dbo.Line_to_TitleObject as LtoTO ON l.Line_ID = LtoTO.Line_ID 
			INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON LtoTO.TitleObject_ID = tio.TitleObject_ID
			WHERE wpq.Test_Leak is not null;
	'


	declare @SQL13 nvarchar(max) = 
	N'	
		INSERT INTO #TMP_RAW
		SELECT wpq.[Source_File] as FileLOG_Code, wpq.Certificate_Installation as Register_Number, ISO.ISO_Number, N''Statement of installation'' as PipingWorktype
		FROM '+@MainData+'.dbo.WorkProgressPipingQuantity AS wpq 
		INNER JOIN '+@MainData+'.dbo.WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		INNER JOIN '+@MainData+'.dbo.Line as l ON wpq.Line_ID = l.Line_ID 
		LEFT JOIN '+@MainData+'.dbo.ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_Marka as LtoM ON l.Line_ID = LtoM.Line_ID 
		INNER JOIN '+@MainData+'.dbo.Marka as m ON LtoM.Marka_ID = m.Marka_ID 
		INNER JOIN '+@MainData+'.dbo.Line_to_TitleObject as LtoTO ON l.Line_ID = LtoTO.Line_ID 
		INNER JOIN '+@MainData+'.dbo.TitleObject as TiO ON LtoTO.TitleObject_ID = tio.TitleObject_ID
		WHERE wpq.Certificate_Installation is not null;
	'


	declare @SQL14 nvarchar(max) = 
	N'	
		CREATE TABLE #TMP_Register_to_ISO
		(
			FileLOG nvarchar(255) COLLATE Cyrillic_General_CI_AS, 
			Register_ID uniqueidentifier, 
			ISO_ID uniqueidentifier, 
			PipingWorktype_ID uniqueidentifier
		);
	'

	declare @SQL15 nvarchar(max) = 
	N'	
		INSERT INTO #TMP_Register_to_ISO (FileLOG, Register_ID, ISO_ID, PipingWorktype_ID) 									
		SELECT DISTINCT a.FileLOG, r.Register_ID, i.ISO_ID, pwt.PipingWorkType_ID 
		FROM #TMP_RAW AS a
		JOIN '+@MainData+'.dbo.Register AS r on a.FileLOG = r.FileLOG and a.Register_Number = r.Register_Number
		JOIN '+@MainData+'.dbo.ISO AS i on a.ISO_Number = i.ISO_Number  
		JOIN '+@MainData+'.dbo.PipingWorkType pwt on a.PipingWorktype = pwt.Description_Eng;
	'



	declare @SQL16 nvarchar(max) = 
	N'	
		 SELECT * INTO #TMP_Register_to_ISO_Errors FROM #TMP_Register_to_ISO;
	'



	--left only errors
	declare @SQL17 nvarchar(max) = 
	N'	
		WITH CTE AS
		(
			SELECT t.FileLOG, t.ISO_ID, t.PipingWorktype_ID,
			row_number() OVER(PARTITION BY t.FileLOG, t.ISO_ID, t.PipingWorktype_ID ORDER BY t.FileLOG) AS [rn]
			FROM #TMP_Register_to_ISO_Errors t
		)
		DELETE FROM cte WHERE [rn] = 1;
	'


	--insert errors into error table, left only errors
	declare @SQL18 nvarchar(max) = 
	N'
		INSERT INTO '+@DraftData+'.dbo.s_WPPipingQuantityErrors
			([ISO]
			,[Source_File]
			,[Load_Date]
			,[Reason])
		SELECT i.ISO_Number
			,e.FileLOG
			,getdate()
			,32
		FROM #TMP_Register_to_ISO_Errors e
		join '+@MainData+'.dbo.ISO i on e.ISO_ID = i.ISO_ID;
	'

	--clear errors
	declare @SQL19 nvarchar(max) = 
	N'	
		WITH CTE AS
		(
			SELECT t.FileLOG, t.ISO_ID, t.PipingWorktype_ID,
			row_number() OVER(PARTITION BY t.FileLOG, t.ISO_ID, t.PipingWorktype_ID ORDER BY t.FileLOG) AS [rn]
			from #TMP_Register_to_ISO t
		)
		delete from cte where [rn] > 1;
	'

	-- fill Final Tables
	declare @SQL20 nvarchar(max) = 
	N'	
		INSERT INTO '+@MainData+'.dbo.p_RegisterPipingAction
			([RegisterPipingAction_ID]
			,[Register_ID]
			,[PipingWorkType_ID]
			,[ISO_ID]
			,[Row_Status]
			,[Insert_DTS]
			,[Update_DTS]
			)
		Select 
			newid()
			,Register_ID
			,PipingWorkType_ID
			,ISO_ID
			,0
			,getdate()
			,getdate()	 
		from #TMP_Register_to_ISO;
	'

	declare @SQL99 nvarchar(max) = ''
	--N'		
	--	drop table if exists STL_SA..tem_raw3;
	--	drop table if exists STL_SA..tem_RI3;
	--	drop table if exists STL_SA..tem_RI_Err3;
	--	select * into STL_SA..tem_raw3		from #TMP_RAW						 where 1=2;
	--	select * into STL_SA..tem_RI3		from #TMP_Register_to_ISO			 where 1=2;
	--	select * into STL_SA..tem_RI_Err3	from #TMP_Register_to_ISO_Errors	 where 1=2;
	--	insert into STL_SA..tem_raw3	select * from #TMP_RAW						 where 1=1;
	--	insert into STL_SA..tem_RI3		select * from #TMP_Register_to_ISO			 where 1=1;
	--	insert into STL_SA..tem_RI_Err3	select * from #TMP_Register_to_ISO_Errors	 where 1=1;
	--'

	exec( @SQL4+@SQL5+@SQL6+@SQL7+@SQL8+@SQL9+@SQL10+@SQL11+@SQL12+@SQL13+@SQL14+@SQL15+@SQL16+@SQL17+@SQL18+@SQL19+@SQL20+@SQL99)
END
