
-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-12-15
-- Description:	Used in SSIS package LVI_WorkProgress_Full
-- Create temp table with data from denormalised tables, databaser params from package, to make easyer Debugging package in DEV_
-- =============================================
CREATE PROCEDURE [dbo].[CombineRegisterFromCOW_LOG] 
(
	 @DraftData		nvarchar(100) = '',
	 @MainData		nvarchar(100) = ''
)
AS
BEGIN
	set nocount on;

    --prepare COW data R_WorkProgressCOWQuantity

	declare @SQL00 nvarchar(max) = 
		 N'
			DROP TABLE IF EXISTS #TMP_WPCR;
			DROP TABLE IF EXISTS #TMP_WPCQ; 
			DROP TABLE IF EXISTS #Tmp_All_COWRegs;
			DROP TABLE IF EXISTS #1;
			DROP TABLE IF EXISTS #2;
		 
			SELECT  distinct
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
		   INTO #TMP_WPCQ
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpc 
		   INNER JOIN '+@MainData+'.dbo.p_WorkPackage as wp ON wpc.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.p_Marka as m ON wpc.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.p_TitleObject as TiO ON wpc.TitleObject_ID = tio.TitleObject_ID
		   INNER JOIN '+@MainData+'.dbo.p_WorkClass as wc ON wpc.Swc_WorkClass_ID = wc.WorkClass_ID
		   INNER JOIN '+@MainData+'.dbo.p_Module as u ON wpc.Module_ID = u.Module_ID
		   WHERE  1=2 ';


declare @SQL01 nvarchar(max) =
		 N'INSERT INTO #TMP_WPCQ
		   SELECT  distinct
				   tio.TitleObject_Name 
		   	      ,m.Marka_Name 
				  ,wc.WorkClass_Name
				  ,u.Module_Name
				  ,wpq.JobCard
				  ,tio.TitleObject_ID
				  ,m.Marka_ID
				  ,wpq.Log_ID 
				  ,wc.WorkClass_ID
				  ,u.Module_ID
				  ,wpq.[1_ABD_cur_state_ID]
				  ,wpq.[1_reg]
				  ,wpq.[2_ABD_cur_state_ID]
				  ,wpq.[2_reg]
				  ,wpq.[3_ABD_cur_state_ID]
				  ,wpq.[3_reg]
				  ,wpq.[4_ABD_cur_state_ID]
				  ,wpq.[4_reg]
				  ,wpq.[5_ABD_cur_state_ID]
				  ,wpq.[5_reg]
				  ,wpq.[6_ABD_cur_state_ID]
				  ,wpq.[6_reg]
				  ,wpq.[7_ABD_cur_state_ID]
				  ,wpq.[7_reg]
				  ,wpq.[8_ABD_cur_state_ID]
				  ,wpq.[8_reg]
				  ,wpq.[9_ABD_cur_state_ID]
				  ,wpq.[9_reg]
				  ,wpq.Source_File
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWQuantity AS wpq 
		   INNER JOIN '+@MainData+'.dbo.p_WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.p_Marka as m ON wpq.Marka_ID = m.Marka_ID 
		   INNER JOIN '+@MainData+'.dbo.p_TitleObject as TiO ON wpq.TitleObject_ID = tio.TitleObject_ID
		   INNER JOIN '+@MainData+'.dbo.p_WorkClass as wc ON wpq.Swc_WorkClass_ID = wc.WorkClass_ID
		   INNER JOIN '+@MainData+'.dbo.p_Module as u ON wpq.Module_ID = u.Module_ID
		   WHERE wpq.Row_Status = 0 ';

--prepare COW data R_WorkProgressCOWRegisters

declare @SQL02 nvarchar(max) =
		 N'SELECT distinct  
				  wpr.Log_Id
				  ,wpr.Reg
				  ,wp.WorkPackage_Name
				  ,wpr.Module_ID as Module_Name
				  ,m.Marka_Name
				  ,tio.TitleObject_Name
				  ,s.Description_Rus + N'' / '' + s.Description_Eng AS Status_Name 
				  ,wp.WorkPackage_ID
				  ,m.Marka_ID
				  ,tio.TitleObject_ID
				  ,s.ABDStatus_ID
				  ,wpr.Work_Desc
				  ,wpr.CNT_Date 
				  ,wpr.Repr_SCNT 
				  ,wpr.Repr_CNT 
				  ,wpr.Status_Date
				  ,wpr.Source_File
		   INTO #TMP_WPCR 
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWRegisters AS wpr 
		   INNER JOIN '+@MainData+'.dbo.p_WorkPackage as wp ON wpr.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.p_ABDStatus as s on wpr.ABDStatus_ID = s.ABDStatus_ID 
		   LEFT JOIN '+@MainData+'.dbo.p_Marka as m ON wpr.Marka_ID = m.Marka_ID 
		   LEFT JOIN '+@MainData+'.dbo.p_TitleObject as TiO ON wpr.TitleObject_ID = tio.TitleObject_ID
		   WHERE 1 = 2 ';



declare @SQL03 nvarchar(max) =
		 N'INSERT INTO #TMP_WPCR 
		   SELECT distinct  
				  wpr.Log_Id
				  ,wpr.Reg
				  ,wp.WorkPackage_Name
				  ,wpr.Module_ID as Module_Name
				  ,m.Marka_Name
				  ,tio.TitleObject_Name
				  ,s.Description_Rus + N'' / '' + s.Description_Eng AS Status_Name 
				  ,wp.WorkPackage_ID
				  ,m.Marka_ID
				  ,tio.TitleObject_ID
				  ,s.ABDStatus_ID
				  ,wpr.Work_Desc
				  ,wpr.CNT_Date 
				  ,wpr.Repr_SCNT 
				  ,wpr.Repr_CNT 
				  ,wpr.Status_Date
				  ,wpr.Source_File
		   FROM '+@MainData+'.dbo.p_WorkProgressCOWRegisters AS wpr 
		   INNER JOIN '+@MainData+'.dbo.p_WorkPackage as wp ON wpr.WorkPackage_ID = wp.WorkPackage_ID 
		   INNER JOIN '+@MainData+'.dbo.p_ABDStatus as s on wpr.ABDStatus_ID = s.ABDStatus_ID 
		   LEFT JOIN '+@MainData+'.dbo.p_Marka as m ON wpr.Marka_ID = m.Marka_ID 
		   LEFT JOIN '+@MainData+'.dbo.p_TitleObject as TiO ON wpr.TitleObject_ID = tio.TitleObject_ID
		   WHERE wpr.Row_Status = 0 ';

-- final tem table with combined data from R and Q
declare @SQL04 nvarchar(max) =
		  N'SELECT z, TitleObject_Name, Marka_Name, Module_Name, WorkClass_Name, JobCard, Reg, Source_File, Log_ID, TitleObject_ID, Marka_ID, Module_ID, WorkClass_ID,JCWT
			INTO #Tmp_All_COWRegs 
		    from (select case 
			      when lead(isnull(TitleObject_Name+Marka_Name,'''')) over (partition by Source_File,Reg order by isnull(TitleObject_Name+Marka_Name,'''')) <> ''''
                        and isnull(TitleObject_Name+Marka_Name,'''') = '''' 
			      then 1
			      else 0
				  end z
		          ,*
				  FROM (Select distinct *
				        FROM (Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.Marka_Name as ''Marka_Name''
											 ,Q.Module_Name as ''Module_Name'' 
											 ,Q.WorkClass_Name as ''WorkClass_Name''
											 ,Q.JobCard 
											 ,R.Reg
											 ,R.Source_File
											 ,Q.Log_ID
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.Module_ID
											 ,Q.WorkClass_ID
											 ,1 as JCWT
				              from #TMP_WPCR AS R
				              left JOIN #TMP_WPCQ AS Q
				              ON Q.Source_File=R.Source_File AND Q.[1_reg]=R.Reg
							  UNION ALL
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.Marka_Name as ''Marka_Name''
											 ,Q.Module_Name as ''Module_Name'' 
											 ,Q.WorkClass_Name as ''WorkClass_Name''
											 ,Q.JobCard 
											 ,R.Reg
											 ,R.Source_File
											 ,Q.Log_ID
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.Module_ID
											 ,Q.WorkClass_ID
											 ,2 as JCWT
				              from #TMP_WPCR AS R
				              left JOIN #TMP_WPCQ AS Q
				              ON Q.Source_File=R.Source_File AND Q.[2_reg]=R.Reg
							  UNION ALL
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.Marka_Name as ''Marka_Name''
											 ,Q.Module_Name as ''Module_Name'' 
											 ,Q.WorkClass_Name as ''WorkClass_Name''
											 ,Q.JobCard 
											 ,R.Reg
											 ,R.Source_File
											 ,Q.Log_ID
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.Module_ID
											 ,Q.WorkClass_ID
											 ,3 as JCWT
				              from #TMP_WPCR AS R
				              left JOIN #TMP_WPCQ AS Q
				              ON Q.Source_File=R.Source_File AND Q.[3_reg]=R.Reg
							  UNION ALL
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.Marka_Name as ''Marka_Name''
											 ,Q.Module_Name as ''Module_Name'' 
											 ,Q.WorkClass_Name as ''WorkClass_Name''
											 ,Q.JobCard 
											 ,R.Reg
											 ,R.Source_File
											 ,Q.Log_ID
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.Module_ID
											 ,Q.WorkClass_ID
											 ,4 as JCWT
				              from #TMP_WPCR AS R
				              left JOIN #TMP_WPCQ AS Q
				              ON Q.Source_File=R.Source_File AND Q.[4_reg]=R.Reg
							  UNION ALL
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.Marka_Name as ''Marka_Name''
											 ,Q.Module_Name as ''Module_Name'' 
											 ,Q.WorkClass_Name as ''WorkClass_Name''
											 ,Q.JobCard 
											 ,R.Reg
											 ,R.Source_File
											 ,Q.Log_ID
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.Module_ID
											 ,Q.WorkClass_ID
											 ,5 as JCWT
				              from #TMP_WPCR AS R
				              left JOIN #TMP_WPCQ AS Q
				              ON Q.Source_File=R.Source_File AND Q.[5_reg]=R.Reg
							  UNION ALL
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.Marka_Name as ''Marka_Name''
											 ,Q.Module_Name as ''Module_Name'' 
											 ,Q.WorkClass_Name as ''WorkClass_Name''
											 ,Q.JobCard 
											 ,R.Reg
											 ,R.Source_File
											 ,Q.Log_ID
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.Module_ID
											 ,Q.WorkClass_ID
											 ,6 as JCWT
				              from #TMP_WPCR AS R
				              left JOIN #TMP_WPCQ AS Q
				              ON Q.Source_File=R.Source_File AND Q.[6_reg]=R.Reg
							  UNION ALL
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.Marka_Name as ''Marka_Name''
											 ,Q.Module_Name as ''Module_Name'' 
											 ,Q.WorkClass_Name as ''WorkClass_Name''
											 ,Q.JobCard 
											 ,R.Reg
											 ,R.Source_File
											 ,Q.Log_ID
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.Module_ID
											 ,Q.WorkClass_ID
											 ,7 as JCWT
				              from #TMP_WPCR AS R
				              left JOIN #TMP_WPCQ AS Q
				              ON Q.Source_File=R.Source_File AND Q.[7_reg]=R.Reg
							  UNION ALL
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.Marka_Name as ''Marka_Name''
											 ,Q.Module_Name as ''Module_Name'' 
											 ,Q.WorkClass_Name as ''WorkClass_Name''
											 ,Q.JobCard 
											 ,R.Reg
											 ,R.Source_File
											 ,Q.Log_ID
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.Module_ID
											 ,Q.WorkClass_ID
											 ,8 as JCWT
				              from #TMP_WPCR AS R
				              left JOIN #TMP_WPCQ AS Q
				              ON Q.Source_File=R.Source_File AND Q.[8_reg]=R.Reg
							  UNION ALL
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.Marka_Name as ''Marka_Name''
											 ,Q.Module_Name as ''Module_Name'' 
											 ,Q.WorkClass_Name as ''WorkClass_Name''
											 ,Q.JobCard 
											 ,R.Reg
											 ,R.Source_File
											 ,Q.Log_ID
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.Module_ID
											 ,Q.WorkClass_ID
											 ,9 as JCWT
				              from #TMP_WPCR AS R
				              left JOIN #TMP_WPCQ AS Q
				              ON Q.Source_File=R.Source_File AND Q.[9_reg]=R.Reg
				              ) as d
				        ) as p
				  ) as x
		    where x.z=0 ';


 -- Update title and marka based on data from final temp table
declare @SQL05 nvarchar(max) =
		  N'Update '+@DraftData+'.[dbo].[s_WPCOWRegisters]
			set '+@DraftData+'.[dbo].[s_WPCOWRegisters].Marka = t.Marka_Name
               ,'+@DraftData+'.[dbo].[s_WPCOWRegisters].Title = t.TitleObject_Name
            from '+@DraftData+'.[dbo].[s_WPCOWRegisters] 
			join (select distinct z, TitleObject_Name, Marka_Name, Reg, Source_File
				  from #Tmp_All_COWRegs
				  where TitleObject_ID is not null and Marka_ID is not null) t on '+@DraftData+'.[dbo].[s_WPCOWRegisters].Source_File = t.Source_File
	                                                                          and '+@DraftData+'.[dbo].[s_WPCOWRegisters].Reg = t.Reg 
			';

	--Delete and fill table with COW fact connections
declare @SQL06 nvarchar(max) =
		  N'delete from '+@DraftData+'.[dbo].[s_COWPreparedConnections] ';



declare @SQL07 nvarchar(max) =
		  N'INSERT INTO '+@DraftData+'.[dbo].[s_COWPreparedConnections]
			SELECT t.JobCard, 
			       t.Reg, 
				   t.Source_File, 
				   t.Marka_ID, 
				   t.TitleObject_ID, 
				   t.Module_ID, 
				   t.WorkClass_ID,
				   '''',
				   '''' ,
				   JCWT
			FROM #Tmp_All_COWRegs t
			WHERE t.JobCard is not null 
			   or t.Marka_ID is not null 
			   or t.TitleObject_ID is not null 
			   or t.Module_ID is not null 
			   or t.WorkClass_ID is not null ';

	-- Write Duplicates to Error Table
declare @SQL08 nvarchar(max) =
		 N'INSERT INTO '+@DraftData+'.[dbo].[s_WPCOWQuantityErrors]
				([Swc]
				,[Title]
				,[Unit]
				,[Marka]
				,[JC]
				,[JC_IsChecked]
				,[Source_File]
				,[Load_Date]
				,[Reason])	
		   SELECT 
				wc.WorkClass_Name
				,t.TitleObject_Name
				,u.Module_Name
				,m.Marka_Name
				,pc.JobCard
				,''YES''
				,Source_File
				,getdate()
				,32
		   FROM '+@DraftData+'.[dbo].[s_COWPreparedConnections] pc
		   join  '+@MainData+'.dbo.p_WorkClass wc on wc.WorkClass_ID = pc.WorkClass_ID
		   join  '+@MainData+'.dbo.p_TitleObject t on pc.TitleObject_ID = t.TitleObject_ID
		   join  '+@MainData+'.dbo.p_Module u on pc.Module_ID = u.Module_ID
		   join  '+@MainData+'.dbo.p_Marka m on pc.Marka_ID = m.Marka_ID
		   where exists (select 1
                         from (select JobCard 
                               from '+@DraftData+'.[dbo].[s_COWPreparedConnections]
                               group by JobCard,JCWT
                               having count(1) > 1) x 
                         where x.JobCard = pc.JobCard
                         ) ';

		--Delete duplicates
declare @SQL09 nvarchar(max) =
		 N'delete 
		   from '+@DraftData+'.[dbo].[s_COWPreparedConnections]
           where JobCard in (select e.JC 
                             from '+@DraftData+'.[dbo].[s_WPCOWQuantityErrors] e
				             WHERE e.Reason = ''32'') ';


--Update Connection table with data Related to JobCards
declare @SQL10 nvarchar(max) =
		 N'UPDATE '+@DraftData+'.[dbo].[s_COWPreparedConnections] 
	       SET Activity_Desc = Substring(q.Activity_Desc,1,1000),
           Cow = Substring(q.Cow,1,100) 
           FROM '+@DraftData+'.[dbo].[s_COWPreparedConnections] as cp 
           left join '+@MainData+'.[dbo].[p_WorkProgressCOWQuantity] q on cp.JobCard = q.JobCard and cp.Source_File = q.Source_File';

-- Write Second layer of Duplicates to Error Table
declare @SQL11 nvarchar(max) =
		 N'	

			select distinct c.JobCard, c.Activity_Desc, c.Cow
			into #1
			from '+@DraftData+'.dbo.s_COWPreparedConnections c

			;WITH CTE AS	(
							SELECT	t.JobCard, t.Activity_Desc, t.Cow,
									row_number() OVER(PARTITION BY t.JobCard ORDER BY t.JobCard) AS [rn]
							from #1 t
							)
			select JobCard, Activity_Desc, Cow   
			into #2
			from CTE
			where [rn] > 1
		 	 
			INSERT INTO '+@DraftData+'.[dbo].[s_WPCOWQuantityErrors]
				([Swc]
				,[Title]
				,[Unit]
				,[Marka]
				,[JC]
				,[JC_IsChecked]
				,[Source_File]
				,[Load_Date]
				,[Reason])	
		   SELECT 
				wc.WorkClass_Name
				,t.TitleObject_Name
				,u.Module_Name
				,m.Marka_Name
				,pc.JobCard
				,''YES''
				,Source_File
				,getdate()
				,32
		   FROM '+@DraftData+'.[dbo].[s_COWPreparedConnections] pc
		   join  '+@MainData+'.dbo.p_WorkClass wc on wc.WorkClass_ID = pc.WorkClass_ID
		   join  '+@MainData+'.dbo.p_TitleObject t on pc.TitleObject_ID = t.TitleObject_ID
		   join  '+@MainData+'.dbo.p_Module u on pc.Module_ID = u.Module_ID
		   join  '+@MainData+'.dbo.p_Marka m on pc.Marka_ID = m.Marka_ID
		   where exists (select 1
                         from (select JobCard 
                               from '+@DraftData+'.[dbo].[s_COWPreparedConnections]
                               group by JobCard,JCWT
                               having count(1) > 1) x 
                         where x.JobCard = pc.JobCard
                         )
			or exists ( select 1
			from #2
			where pc.JobCard = #2.JobCard 
			)
			
			DROP TABLE IF EXISTS #1;
			DROP TABLE IF EXISTS #2; 
			
			';


		--Delete Second layer of duplicates

declare @SQL12 nvarchar(max) = 
		 N'delete 
		   from '+@DraftData+'.[dbo].[s_COWPreparedConnections]
           where JobCard in (select e.JC 
                             from '+@DraftData+'.[dbo].[s_WPCOWQuantityErrors] e
				             WHERE e.Reason = ''32'') ';

exec(@SQL00+@SQL01+@SQL02+@SQL03+@SQL04+@SQL05+@SQL06+@SQL07+@SQL08+@SQL09+@SQL10+@SQL11+@SQL12)
		
END
