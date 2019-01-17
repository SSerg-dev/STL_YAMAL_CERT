






-- =============================================
-- Author:		ASmirnov
-- Create date: 2018-08-19
-- Description:	Used in SSIS package LVI_WorkProgress_Underground
-- Create temp table with data from denormalised tables, databaser params from package, to make easyer Debugging package in 
-- =============================================
CREATE PROCEDURE [dbo].[Clear_Fill_Register_UndergroundQuantity]
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
		DROP TABLE IF EXISTS #TMP_RegToUnder

		create table #TMP_RegToUnder
				(Register_Number			nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,QTY						nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,FileLOG					nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,TitleObject_Name			nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,SubTitleObject_Name		nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Marka_Name					nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Phase						nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Activity_Desc				nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,UOM						nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Reg						nvarchar(4000) COLLATE Cyrillic_General_CI_AS
				,SingleRegQTY				nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Register_ID				uniqueidentifier
				,UndergroundObjectVolume_ID	uniqueidentifier
				,UndergroundObject_ID		uniqueidentifier
				,UndergroundStad_ID			uniqueidentifier
				,UndergroundWorkType_ID		uniqueidentifier
				,MeasureUnit_ID				uniqueidentifier
				,ErrorCode					int
				);

		delete from '+@MainData+'.dbo.p_Register_to_UndergroundObjectVolume
		delete from '+@MainData+'.dbo.p_UndergroundObjectVolume_m 
	'
-- Data UndergroundObjectVolume check 
-- ======== Doubles =========================================================

	declare @SQL2 nvarchar(max) = 
	N'	
		
		;WITH CTE AS
		(
		SELECT	Log_ID,Num,Phase,Title,Sub_Title,
				Unit,Marka,
				Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent,
				Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT,
				Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent,
				Multiple,Issues,Source_File,Load_Date
				,row_number() OVER(PARTITION BY q.Title, q.Sub_Title, q.Marka, q.Activity_Desc, q.UOM 
									   ORDER BY q.Title, q.Sub_Title, q.Marka, q.Activity_Desc, q.UOM,Design_Target,Fact_Volume) AS rn
		FROM '+@DraftData+'.dbo.s_WPUndergroundQuantity q
		)
		INSERT INTO '+@DraftData+'.dbo.s_WPUndergroundQuantityErrors
				   (Log_ID,Num,Phase,Title,Sub_Title,
					Unit,Marka,
					Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent,
					Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT,
					Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent,
					Multiple,Issues,Source_File,Load_Date
				   ,Reason)
		SELECT		Log_ID,Num,Phase,Title,Sub_Title,
					Unit,Marka,
					Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent,
					Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT,
					Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent,
					Multiple,Issues,Source_File,Load_Date,
					32 
		FROM CTE
		WHERE rn <> 1
		

		;WITH CTE AS
			(
			SELECT	Log_ID,Num,Phase,Title,Sub_Title,
				Unit,Marka,
				Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent,
				Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT,
				Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent,
				Multiple,Issues,Source_File,Load_Date
				,row_number() OVER(PARTITION BY q.Title, q.Sub_Title, q.Marka, q.Activity_Desc, q.UOM 
									   ORDER BY q.Title, q.Sub_Title, q.Marka, q.Activity_Desc, q.UOM,Design_Target,Fact_Volume) AS rn
			FROM '+@DraftData+'.dbo.s_WPUndergroundQuantity q
			)
		DELETE FROM CTE where rn <> 1
		
	'
-- UndergroundObjectVolume operation
		declare @SQL3 nvarchar(max) = 
	N'	
		INSERT INTO '+@MainData+'.dbo.p_UndergroundObjectVolume_m
			(UndergroundObjectVolume_ID
			,UndergroundObject_ID
			,UndergroundWorkType_ID
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
			,g.UndergroundObject_ID
			,gw.UndergroundWorkType_ID
			,mu.MeasureUnit_ID
			,try_cast(q.Design_Target as float) 
			,try_cast(q.Fact_Volume as float) 
			,getdate()
			,getdate()
			,0
			,null
			,null
		from '+@DraftData+'.dbo.s_WPUndergroundQuantity q
		join '+@MainData+'.dbo.TitleObject t on q.Title = t.TitleObject_Name
		join '+@MainData+'.dbo.TitleObject st on q.Sub_Title = st.TitleObject_Name
		join '+@MainData+'.dbo.Marka m on q.Marka = m.Marka_Name
		join '+@MainData+'.dbo.UndergroundWorkType gw on q.Activity_Desc = gw.UndergroundWorkType_FullName
		join '+@MainData+'.dbo.UndergroundObject g	on g.TitleObject_ID 		= t.TitleObject_ID 
												and g.Marka_ID 				= m.Marka_ID
												and g.SubTitleObject_ID	= st.TitleObject_ID 
		join '+@MainData+'.dbo.MeasureUnit mu on mu.Measure_FullName = q.UOM
	'

-- Register_to_UndergroundObjectVolume operation

--data preparations	
	declare @SQL4 nvarchar(max) = 
	N'	
		-- ======== Split values Register(volume) from delimited string ==========		
			insert into #TMP_RegToUnder
					(FileLOG, TitleObject_Name, SubTitleObject_Name, Marka_Name, 
					Activity_Desc, UOM, Reg, 
					SingleRegQTY
					)					
			SELECT	
					Source_File, Title, Sub_Title, Marka,
					Activity_Desc, UOM, Reg,
					ltrim(rtrim(value)) as SingleRegQTY	
			FROM '+@DraftData+'.dbo.s_WPUndergroundQuantity e
			CROSS APPLY STRING_SPLIT(e.Reg, ''/'')

		--Data validation
		-- ======== Delimiter check =================================================
			update #TMP_RegToUnder
			set ErrorCode = 48 
			from #TMP_RegToUnder
			where SingleRegQTY is null or ltrim(rtrim(SingleRegQTY)) = '''' 
				or LEN(SingleRegQTY)-1 <> LEN(REPLACE(SingleRegQTY, ''('', '''')) 
				or LEN(SingleRegQTY)-1 <> LEN(REPLACE(SingleRegQTY, '')'', ''''))  

		-- ======== Prepare middle data for next checks ==============================	
			update #TMP_RegToUnder
				set Register_Number = ltrim(rtrim(substring(SingleRegQTY,0,charindex(''('',SingleRegQTY,0)))),	
					QTY = ltrim(rtrim(substring(SingleRegQTY,charindex(''('',SingleRegQTY,0)+1,len(SingleRegQTY)-charindex(''('',SingleRegQTY,0)-1)))
			where ErrorCode is null

		-- ======== QTY check =================================================
			Update #TMP_RegToUnder
			set QTY = replace(QTY,'','',''.'') 

			update #TMP_RegToUnder
			set ErrorCode = 2 
			where TRY_CAST(QTY as float) is null
			and ErrorCode is null		

		-- ======== Register check ============================================		
			update #TMP_RegToUnder
			set ErrorCode = 40 
			where not exists (	select 1 
								from '+@MainData+'.dbo.p_Register r 
								where r.Register_Number = #TMP_RegToUnder.Register_Number and r.FileLOG = #TMP_RegToUnder.FileLOG)  
			and ErrorCode is null 

		-- ======== Doubles in delimited field check ============================================	
		update t
		set ErrorCode = 32
		from #TMP_RegToUnder t
		join (select Register_Number, FileLOG, TitleObject_Name, SubTitleObject_Name, Marka_Name, Activity_Desc, UOM, ErrorCode
					from #TMP_RegToUnder
					where ErrorCode is null
					group by Register_Number, FileLOG, TitleObject_Name, SubTitleObject_Name, Marka_Name, Activity_Desc, UOM, ErrorCode
					having count(QTY) >1
					) t1 on t.Register_Number		= t1.Register_Number 
						and t.FileLOG				= t1.FileLOG
						and t.TitleObject_Name		= t1.TitleObject_Name
						and t.SubTitleObject_Name	= t1.SubTitleObject_Name
						and t.Marka_Name			= t1.Marka_Name
						and t.Activity_Desc			= t1.Activity_Desc
						and t.UOM					= t1.UOM
		where t.ErrorCode is null
	'
-- Write errors to error tablr, remove rows with errors
	declare @SQL5 nvarchar(max) = 
	N'	
		INSERT INTO '+@DraftData+'.dbo.s_WPUndergroundQuantityErrors
			   (Log_ID,Num,Phase,Title,Sub_Title
			   ,Unit,Marka
			   ,Activity_Desc,UOM,Design_Target,Fact_Volume,Fact_Percent
			   ,Test_Done,Acts_Prepared_CNT,Acts_Prepared_Percent,Reg,Under_Review_CNT
			   ,Under_Review_Percent,Commented_CNT,Commented_Percent,Approved_CNT,Approved_Percent
			   ,Multiple,Issues,Source_File,Load_Date
			   ,Reason)
		select distinct 
					q.Log_ID,q.Num,q.Phase,q.Title,q.Sub_Title
				   ,q.Unit,q.Marka
				   ,q.Activity_Desc,q.UOM,q.Design_Target,q.Fact_Volume,q.Fact_Percent
				   ,q.Test_Done,q.Acts_Prepared_CNT,q.Acts_Prepared_Percent,q.Reg,q.Under_Review_CNT
				   ,q.Under_Review_Percent,q.Commented_CNT,q.Commented_Percent,q.Approved_CNT,q.Approved_Percent
				   ,q.Multiple,q.Issues,q.Source_File,q.Load_Date
				   ,t.ErrorCode
		from '+@DraftData+'.dbo.s_WPUndergroundQuantity q 
		join #TMP_RegToUnder t on q.Title			= t.TitleObject_Name
							  and q.Sub_Title		= t.SubTitleObject_Name	 
							  and q.Marka			= t.Marka_Name 
							  and q.Activity_Desc	= t.Activity_Desc
							  and q.UOM				= t.UOM
							  and q.Reg				= t.Reg				  
		where ErrorCode is not null

		delete from '+@DraftData+'.dbo.s_WPUndergroundQuantity
		where exists (	select 1 
						from #TMP_RegToUnder t  
						where '+@DraftData+'.dbo.s_WPUndergroundQuantity.Title			= t.TitleObject_Name
						  and '+@DraftData+'.dbo.s_WPUndergroundQuantity.Sub_Title		= t.SubTitleObject_Name	 
						  and '+@DraftData+'.dbo.s_WPUndergroundQuantity.Marka			= t.Marka_Name 
						  and '+@DraftData+'.dbo.s_WPUndergroundQuantity.Activity_Desc	= t.Activity_Desc
						  and '+@DraftData+'.dbo.s_WPUndergroundQuantity.UOM				= t.UOM
						  and '+@DraftData+'.dbo.s_WPUndergroundQuantity.Reg				= t.Reg
						  and t.ErrorCode is not null)			  
	
		delete from #TMP_RegToUnder
		where ErrorCode is not null		
	'


	declare @SQL6 nvarchar(max) = 
	N'	
		INSERT INTO '+@MainData+'.dbo.p_Register_to_UndergroundObjectVolume
			   (Register_to_UndergroundObjectVolume_ID
			   ,Register_ID
			   ,UndergroundObjectVolume_ID
			   ,Qty
			   ,Insert_DTS
			   ,Update_DTS
			   ,Row_Status
			   )
		select 
					newid()
				   ,x01.Register_ID
				   ,x01.UndergroundObjectVolume_ID
				   ,try_cast(x01.QTY as float)
				   ,getdate()
				   ,getdate()
				   ,0
		from (	
				select distinct
					r.Register_ID,
					gv.UndergroundObjectVolume_ID,
					q.QTY
				from #TMP_RegToUnder q
				join '+@MainData+'.dbo.Register r on q.Register_Number = r.Register_Number and q.FileLOG = r.FileLOG 
				join '+@MainData+'.dbo.TitleObject t on q.TitleObject_Name = t.TitleObject_Name
				join '+@MainData+'.dbo.TitleObject st on q.SubTitleObject_Name = st.TitleObject_Name
				join '+@MainData+'.dbo.Marka m on q.Marka_Name = m.Marka_Name
				join '+@MainData+'.dbo.UndergroundWorkType gw on q.Activity_Desc = gw.UndergroundWorkType_FullName
				join '+@MainData+'.dbo.UndergroundObject g on g.TitleObject_ID 		= t.TitleObject_ID 
														 and g.Marka_ID 			= m.Marka_ID
														 and g.SubTitleObject_ID	= st.TitleObject_ID
				join '+@MainData+'.dbo.MeasureUnit mu on mu.Measure_FullName = q.UOM
				join '+@MainData+'.dbo.UndergroundObjectVolume_m gv on gv.UndergroundObject_ID	= g.UndergroundObject_ID
																  and gv.UndergroundWorkType_ID = gw.UndergroundWorkType_ID
																  and gv.MeasureUnit_ID		= mu.MeasureUnit_ID
			) x01
	

	DROP TABLE IF EXISTS #TMP_RegToUnder;
	'


	exec( @SQL1+@SQL2+@SQL3+@SQL4+@SQL5+@SQL6)

END
