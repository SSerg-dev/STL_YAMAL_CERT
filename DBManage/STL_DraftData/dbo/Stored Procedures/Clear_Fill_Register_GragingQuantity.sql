




-- =============================================
-- Author:		ASmirnov
-- Create date: 2018-06-13
-- Description:	Used in SSIS package LVI_WorkProgress_Grading
-- Create temp table with data from denormalised tables, databaser params from package, to make easyer Debugging package in 
-- =============================================
CREATE PROCEDURE [dbo].[Clear_Fill_Register_GragingQuantity]
(
	 @DraftData		nvarchar(100) = '',
	 @MainData		nvarchar(100) = ''
)
AS
BEGIN
	set nocount on;

-- Preparation
	declare @SQL1 nvarchar(max) = 
	N'	
		DROP TABLE IF EXISTS #TMP_RegToGrad

		create table #TMP_RegToGrad
				(Register_Number		nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,QTY					nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,FileLOG				nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,TitleObject_Name		nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,SubTitleObject_Name	nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Marka_Name				nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,SubMarka_Name			nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Stad					nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Activity_Desc			nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,UOM					nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Reg					nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,SingleRegQTY			nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Register_ID			uniqueidentifier
				,GradingObjectVolume_ID	uniqueidentifier
				,GradingObject_ID		uniqueidentifier
				,GradingStad_ID			uniqueidentifier
				,GradingWorkType_ID		uniqueidentifier
				,MeasureUnit_ID			uniqueidentifier
				,ErrorCode				int
				);

		delete from '+@MainData+'.dbo.p_Register_to_GradingObjectVolume
		delete from '+@MainData+'.dbo.p_GradingObjectVolume_m 
	'
-- Data GradingObjectVolume check 
-- ======== Doubles =========================================================

	declare @SQL2 nvarchar(max) = 
	N'	
		
		;WITH CTE AS
		(
		SELECT	Log_ID,Num,Stads,Title,SubTitle,
				Unit,Unit_Stage,Unit_Description,Marka,SubMarka,
				Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent,
				Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT,
				Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent,
				Multiple,Issues,Source_File,Load_Date
				,row_number() OVER(PARTITION BY q.Title, q.SubTitle, q.Marka, q.SubMarka, q.Stads, q.Activity_Desc, q.UOM 
									   ORDER BY q.Title, q.SubTitle, q.Marka, q.SubMarka, q.Stads, q.Activity_Desc, q.UOM,Design_Target,Fact_Volume) AS rn
		FROM '+@DraftData+'.dbo.s_WPGradingQuantity q
		)
		INSERT INTO '+@DraftData+'.dbo.s_WPGradingQuantityErrors
				   (Log_ID,Num,Stads,Title,Sub_Title
				   ,Unit,Unit_Stage,Unit_Description,Marka,Sub_Marka
				   ,Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent
				   ,Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT
				   ,Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent
				   ,Multiple,Issues,Source_File,Load_Date
				   ,Reason)
		SELECT		Log_ID,Num,Stads,Title,SubTitle,
					Unit,Unit_Stage,Unit_Description,Marka,SubMarka,
					Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent,
					Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT,
					Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent,
					Multiple,Issues,Source_File,Load_Date,
					32 
		FROM CTE
		WHERE rn <> 1
		

		;WITH CTE AS
			(
			SELECT	Log_ID,Num,Stads,Title,SubTitle,
					Unit,Unit_Stage,Unit_Description,Marka,SubMarka,
					Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent,
					Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT,
					Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent,
					Multiple,Issues,Source_File,Load_Date
					,row_number() OVER(PARTITION BY q.Title, q.SubTitle, q.Marka, q.SubMarka, q.Stads, q.Activity_Desc, q.UOM 
										   ORDER BY q.Title, q.SubTitle, q.Marka, q.SubMarka, q.Stads, q.Activity_Desc, q.UOM, Design_Target,Fact_Volume) AS rn
			FROM '+@DraftData+'.dbo.s_WPGradingQuantity q
			)
		DELETE FROM CTE where rn <> 1
		
	'
-- GradingObjectVolume operation
		declare @SQL3 nvarchar(max) = 
	N'	
		INSERT INTO '+@MainData+'.dbo.p_GradingObjectVolume_m
			(GradingObjectVolume_ID
			,GradingObject_ID
			,GradingStad_ID
			,GradingWorkType_ID
			,MeasureUnit_ID
			,Design_Qty
			,Fact_Qty
			,Insert_DTS
			,Update_DTS
			,Row_Status
			,Created_User_ID
			,Modified_User_ID)
		select
			newid()
			,g.GradingObject_ID
			,gs.GradingStad_ID
			,gw.GradingWorkType_ID
			,mu.MeasureUnit_ID
			,try_cast(q.Design_Target as float) 
			,try_cast(q.Fact_Volume as float) 
			,getdate()
			,getdate()
			,0
			,null
			,null
		from '+@DraftData+'.dbo.s_WPGradingQuantity q
		join '+@MainData+'.dbo.TitleObject t on q.Title = t.TitleObject_Name
		join '+@MainData+'.dbo.Marka m on q.Marka = m.Marka_Name
		join '+@MainData+'.dbo.GradingStad gs on q.Stads = gs.GradingStad_Name
		join '+@MainData+'.dbo.GradingWorkType gw on q.Activity_Desc = gw.GradingWorkType_FullName
		join '+@MainData+'.dbo.GradingObject g	on g.TitleObject_ID 		= t.TitleObject_ID 
												and g.Marka_ID 				= m.Marka_ID
												and g.SubMarka_Name 		= q.SubMarka
												and g.SubTitleObject_Name	= q.SubTitle
		join '+@MainData+'.dbo.MeasureUnit mu on mu.Measure_FullName = q.UOM
	'

-- Register_to_GradingObjectVolume operation

--data preparations	
	declare @SQL4 nvarchar(max) = 
	N'	
		-- ======== Split values Register(volume) from delimited string ==========		
			insert into #TMP_RegToGrad
					(FileLOG, TitleObject_Name, SubTitleObject_Name, Marka_Name, SubMarka_Name,
						Stad, Activity_Desc, UOM, Reg, 
						SingleRegQTY
					)					
			SELECT	
					Source_File, Title, SubTitle, Marka, SubMarka, 
					Stads, Activity_Desc, UOM, Reg,
					ltrim(rtrim(value)) as SingleRegQTY	
			FROM '+@DraftData+'.dbo.s_WPGradingQuantity e
			CROSS APPLY STRING_SPLIT(e.Reg, ''/'')

		--Data validation
		-- ======== Delimiter check =================================================
			update #TMP_RegToGrad
			set ErrorCode = 48 
			from #TMP_RegToGrad
			where SingleRegQTY is null or ltrim(rtrim(SingleRegQTY)) = '''' 
				or LEN(SingleRegQTY)-1 <> LEN(REPLACE(SingleRegQTY, ''('', '''')) 
				or LEN(SingleRegQTY)-1 <> LEN(REPLACE(SingleRegQTY, '')'', ''''))  

		-- ======== Prepare middle data for next checks ==============================	
			update #TMP_RegToGrad
				set Register_Number = ltrim(rtrim(substring(SingleRegQTY,0,charindex(''('',SingleRegQTY,0)))),	
					QTY = ltrim(rtrim(substring(SingleRegQTY,charindex(''('',SingleRegQTY,0)+1,len(SingleRegQTY)-charindex(''('',SingleRegQTY,0)-1)))
			where ErrorCode is null

			--for OLD registers which should be not count in reports.
			update #TMP_RegToGrad
				set FileLOG = ''2_RF_asbuilt_status_LOG_CWP_1''
			where right(Register_Number,1) = ''a'' 

		-- ======== QTY check =================================================
			Update #TMP_RegToGrad
			set QTY = replace(QTY,'','',''.'') 

			update #TMP_RegToGrad
			set ErrorCode = 2 
			where TRY_CAST(QTY as float) is null
			and ErrorCode is null		

		-- ======== Register check ============================================		
			update #TMP_RegToGrad
			set ErrorCode = 40 
			where not exists (	select 1 
								from '+@MainData+'.dbo.p_Register r 
								where r.Register_Number = #TMP_RegToGrad.Register_Number and r.FileLOG = #TMP_RegToGrad.FileLOG)  
			and ErrorCode is null 

		-- ======== Doubles in delimited field check ============================================	
		update t
		set ErrorCode = 32
		from #TMP_RegToGrad t
		join (select Register_Number, FileLOG, TitleObject_Name, SubTitleObject_Name, Stad, Marka_Name, SubMarka_Name, Activity_Desc, UOM, ErrorCode
					from #TMP_RegToGrad
					where ErrorCode is null
					group by Register_Number, FileLOG, TitleObject_Name, SubTitleObject_Name, Stad, Marka_Name, SubMarka_Name, Activity_Desc, UOM, ErrorCode
					having count(QTY) >1
					) t1 on t.Register_Number		= t1.Register_Number 
						and t.FileLOG				= t1.FileLOG
						and t.TitleObject_Name		= t1.TitleObject_Name
						and t.SubTitleObject_Name	= t1.SubTitleObject_Name
						and t.Marka_Name			= t1.Marka_Name
						and t.SubMarka_Name			= t1.SubMarka_Name
						and t.Stad					= t1.Stad
						and t.Activity_Desc			= t1.Activity_Desc
						and t.UOM					= t1.UOM
		where t.ErrorCode is null
	'
-- Write errors to error tablr, remove rows with errors
	declare @SQL5 nvarchar(max) = 
	N'	
		INSERT INTO '+@DraftData+'.dbo.s_WPGradingQuantityErrors
			   (Log_ID,Num,Stads,Title,Sub_Title
			   ,Unit,Unit_Stage,Unit_Description,Marka,Sub_Marka
			   ,Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent
			   ,Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT
			   ,Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent
			   ,Multiple,Issues,Source_File,Load_Date
			   ,Reason)
		select distinct 
					q.Log_ID,q.Num,q.Stads,q.Title,q.SubTitle,
					q.Unit,q.Unit_Stage,q.Unit_Description,q.Marka,q.SubMarka
				   ,q.Activity_Desc,q.UOM,q.Design_Target,q.Fact_Volume,q.Fact_Percent
				   ,q.Test_Done,q.Acts_Prepared_CNT,q.Acts_Prepared_Percent,q.Reg,q.Under_Review_CNT
				   ,q.Under_Review_Percent,q.Commented_CNT,q.Commented_Percent,q.Approved_CNT,q.Approved_Percent
				   ,q.Multiple,q.Issues,q.Source_File,q.Load_Date
				   ,t.ErrorCode
		from '+@DraftData+'.dbo.s_WPGradingQuantity q 
		join #TMP_RegToGrad t on q.Title			= t.TitleObject_Name
							  and q.SubTitle		= t.SubTitleObject_Name	 
							  and q.Marka			= t.Marka_Name 
							  and q.SubMarka		= t.SubMarka_Name
							  and q.Stads			= t.Stad
							  and q.Activity_Desc	= t.Activity_Desc
							  and q.UOM				= t.UOM
							  and q.Reg				= t.Reg				  
		where ErrorCode is not null

		delete from '+@DraftData+'.dbo.s_WPGradingQuantity
		where exists (	select 1 
						from #TMP_RegToGrad t  
						where '+@DraftData+'.dbo.s_WPGradingQuantity.Title			= t.TitleObject_Name
						  and '+@DraftData+'.dbo.s_WPGradingQuantity.SubTitle		= t.SubTitleObject_Name	 
						  and '+@DraftData+'.dbo.s_WPGradingQuantity.Marka			= t.Marka_Name 
						  and '+@DraftData+'.dbo.s_WPGradingQuantity.SubMarka		= t.SubMarka_Name
						  and '+@DraftData+'.dbo.s_WPGradingQuantity.Stads			= t.Stad
						  and '+@DraftData+'.dbo.s_WPGradingQuantity.Activity_Desc	= t.Activity_Desc
						  and '+@DraftData+'.dbo.s_WPGradingQuantity.UOM				= t.UOM
						  and '+@DraftData+'.dbo.s_WPGradingQuantity.Reg				= t.Reg
						  and t.ErrorCode is not null)			  
	
		delete from #TMP_RegToGrad
		where ErrorCode is not null			
	'


	declare @SQL6 nvarchar(max) = 
	N'	
		INSERT INTO '+@MainData+'.dbo.p_Register_to_GradingObjectVolume
			   (Register_to_GradingObjectVolume_ID
			   ,Register_ID
			   ,GradingObjectVolume_ID
			   ,Qty
			   ,Insert_DTS
			   ,Update_DTS
			   ,Row_Status
			   )
		select 
					newid()
				   ,x01.Register_ID
				   ,x01.GradingObjectVolume_ID
				   ,try_cast(x01.QTY as float)
				   ,getdate()
				   ,getdate()
				   ,0
		from (	
				select distinct
					r.Register_ID,
					gv.GradingObjectVolume_ID,
					q.QTY
				from #TMP_RegToGrad q
				join '+@MainData+'.dbo.Register r on q.Register_Number = r.Register_Number and q.FileLOG = r.FileLOG 
				join '+@MainData+'.dbo.TitleObject t on q.TitleObject_Name = t.TitleObject_Name
				join '+@MainData+'.dbo.Marka m on q.Marka_Name = m.Marka_Name
				join '+@MainData+'.dbo.GradingStad gs on q.Stad = gs.GradingStad_Name
				join '+@MainData+'.dbo.GradingWorkType gw on q.Activity_Desc = gw.GradingWorkType_FullName
				join '+@MainData+'.dbo.GradingObject g on g.TitleObject_ID 		= t.TitleObject_ID 
														and g.Marka_ID 			= m.Marka_ID
														and g.SubMarka_Name 		= q.SubMarka_Name
														and g.SubTitleObject_Name	= q.SubTitleObject_Name
				join '+@MainData+'.dbo.MeasureUnit mu on mu.Measure_FullName = q.UOM
				join '+@MainData+'.dbo.GradingObjectVolume_m gv on gv.GradingObject_ID	= g.GradingObject_ID
																and gv.GradingStad_ID	= gs.GradingStad_ID
																and gv.GradingWorkType_ID = gw.GradingWorkType_ID
																and gv.MeasureUnit_ID		= mu.MeasureUnit_ID
			) x01


	DROP TABLE IF EXISTS #TMP_RegToGrad;
	'


	exec( @SQL1+@SQL2+@SQL3+@SQL4+@SQL5+@SQL6)

END
