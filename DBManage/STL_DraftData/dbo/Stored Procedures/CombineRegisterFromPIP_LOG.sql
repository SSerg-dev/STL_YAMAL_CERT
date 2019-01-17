





/*
exec [dbo].[CombineRegisterFromPIP_LOG] 'DEV_STL_DraftData','DEV_STL_MainData'
*/

-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-12-14
-- Description:	Used in SSIS package LVI_WorkProgress_Full
-- Create temp table with data from denormalised tables, databaser params from package, to make easyer Debugging package in DEV_
-- Moified:		2018-04-24 ASmirnov
-- TitleObject And Marka determinates based on aditional information
-- Moified:		2018-10-10 ASmirnov
-- SDM_FEI_SI processing added
-- =============================================
CREATE PROCEDURE [dbo].[CombineRegisterFromPIP_LOG] 
(
	 @DraftData		nvarchar(100) = '',
	 @MainData		nvarchar(100) = ''
)
AS
BEGIN
	set nocount on;

-- Back transformation N/A to NULL

declare @SQL01 nvarchar(max) = 
 
 N'
	Update '+@MainData+'.dbo.p_WorkProgressPipingRegisters 
	set Title = NULL
	where Title = ''N/A''

 ';

 --prepare Piping data R_WorkProgressPipingRegisters
	declare @SQL1 nvarchar(max) = 
		 N'
		 
			DROP TABLE IF EXISTS #TMP_WPPR;
			DROP TABLE IF EXISTS #TMP_WPPQ; 
			DROP TABLE IF EXISTS #TMP_All_PipngRegs;
		 
			 SELECT wpr.LogId, 
					  wpr.Reg, 
					  wp.WorkPackage_Name, 					 
					  wpr.Title,
					  wpr.Unit, 
					  wpr.Work_Desc, 
					  wpr.CNT_Date, 
					  wpr.Repr_SCNT, 
					  wpr.Repr_CNT, 
					  wpr.Status_Date, 
					  s.Description_Rus + N'' / '' + s.Description_Eng AS Status_Name, 
					  SC.Code as SubContractor_Name, 
					  s.ReportColor, 
					  s.ReportOrder,
					  wpr.Source_File,
					  wpr.SDM_FEI_SI
			   INTO #TMP_WPPR
			   FROM '+@MainData+'.dbo.p_WorkProgressPipingRegisters as wpr 
			   INNER JOIN '+@MainData+'.dbo.p_WorkPackage as wp ON wpr.WorkPackage_ID = wp.WorkPackage_ID 
			  
			   LEFT JOIN '+@MainData+'.dbo.p_ABDStatus AS s ON wpr.ABDStatus_ID = s.ABDStatus_ID 
			   LEFT JOIN '+@MainData+'.dbo.p_WorkPackage_to_Contragent as WPtoSC ON wp.WorkPackage_ID = WPtoSC.WorkPackage_ID 
			   LEFT JOIN '+@MainData+'.dbo.p_Contragent as SC ON WPtoSC.Contragent_ID = SC.Contragent_ID
			   WHERE 1=2
			';

	declare @SQL2 nvarchar(max) = 
		 N'			
			INSERT INTO #TMP_WPPR
			 SELECT wpr.LogId, 
					  wpr.Reg, 
					  wp.WorkPackage_Name, 		 
					  wpr.Title,
					  wpr.Unit, 
					  wpr.Work_Desc, 
					  wpr.CNT_Date, 
					  wpr.Repr_SCNT, 
					  wpr.Repr_CNT, 
					  wpr.Status_Date, 
					  s.Description_Rus + N'' / '' + s.Description_Eng AS Status_Name, 
					  SC.Code as SubContractor_Name, 
					  s.ReportColor, 
					  s.ReportOrder,
					  wpr.Source_File,
					  wpr.SDM_FEI_SI
			   FROM '+@MainData+'.dbo.p_WorkProgressPipingRegisters as wpr 
			   INNER JOIN '+@MainData+'.dbo.p_WorkPackage as wp ON wpr.WorkPackage_ID = wp.WorkPackage_ID 
			  
			   LEFT JOIN '+@MainData+'.dbo.p_ABDStatus AS s ON wpr.ABDStatus_ID = s.ABDStatus_ID 
			   LEFT JOIN '+@MainData+'.dbo.p_WorkPackage_to_Contragent as WPtoSC ON wp.WorkPackage_ID = WPtoSC.WorkPackage_ID 
			   LEFT JOIN '+@MainData+'.dbo.p_Contragent as SC ON WPtoSC.Contragent_ID = SC.Contragent_ID
			   WHERE wpr.Row_Status = 0 
  			   AND s.Description_Rus + N'' / '' + s.Description_Eng <> N''Аннулирован / Cancelled''
			';

		   
		   --prepare Piping data R_WorkProgressPipingQuantity

	declare @SQL3 nvarchar(max) = 
		  N'
		    SELECT TiO.TitleObject_Name,       
                   m.Marka_Name, 
                   TiO.TitleObject_ID, 
                   m.Marka_ID,
                   wpq.LogID, 
                   wpq.Shop_Weld_RegNum, 
                   wpq.Field_Weld_RegNum, 
                   wpq.AKZ_Shop_RegNum, 
                   wpq.AKZ_Weld_RegNum, 
                   wpq.GW_RegNum_RegNum, 
                   wpq.Insulation_RegNum, 
                   wpq.Test_Density_Strength, 
                   wpq.Test_Leak, 
                   wpq.Certificate_Installation,
				   wpq.Source_File
				   ,PH.ProcessPhase_ID
				   ,PH.ProcessPhase_Name
			INTO #TMP_WPPQ
		    FROM '+@MainData+'.dbo.p_WorkProgressPipingQuantity AS wpq 
		    INNER JOIN '+@MainData+'.dbo.p_WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 		    
		    INNER JOIN '+@MainData+'.dbo.p_Line as l ON wpq.Line_ID = l.Line_ID 
		    LEFT JOIN '+@MainData+'.dbo.p_ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
		    INNER JOIN '+@MainData+'.dbo.p_ISO_to_Marka as LtoM ON iso.ISO_ID = LtoM.ISO_ID 
		    INNER JOIN '+@MainData+'.dbo.p_Marka as m ON LtoM.Marka_ID = m.Marka_ID 
		    INNER JOIN '+@MainData+'.dbo.p_ISO_to_TitleObject as LtoTO ON iso.ISO_ID = LtoTO.ISO_ID 
		    INNER JOIN '+@MainData+'.dbo.p_TitleObject as TiO ON LtoTO.TitleObject_ID = TiO.TitleObject_ID
			LEFT JOIN '+@MainData+'.dbo.p_ISO_to_ProcessPhase as ItoPH ON iso.ISO_ID = ItoPH.ISO_ID
		    LEFT JOIN '+@MainData+'.dbo.p_ProcessPhase as PH ON ItoPH.ProcessPhase_ID = PH.ProcessPhase_ID
		    WHERE 1=2
			';	
				   
	declare @SQL4 nvarchar(max) = 
		  N'
			INSERT INTO #TMP_WPPQ
		    SELECT TiO.TitleObject_Name,       
                   m.Marka_Name, 
                   TiO.TitleObject_ID, 
                   m.Marka_ID,
                   wpq.LogID, 
                   wpq.Shop_Weld_RegNum, 
                   wpq.Field_Weld_RegNum, 
                   wpq.AKZ_Shop_RegNum, 
                   wpq.AKZ_Weld_RegNum, 
                   wpq.GW_RegNum_RegNum, 
                   wpq.Insulation_RegNum, 
                   wpq.Test_Density_Strength, 
                   wpq.Test_Leak, 
                   wpq.Certificate_Installation,
				   wpq.Source_File
				   ,PH.ProcessPhase_ID
				   ,PH.ProcessPhase_Name
		    FROM '+@MainData+'.dbo.p_WorkProgressPipingQuantity AS wpq 
		    INNER JOIN '+@MainData+'.dbo.p_WorkPackage as wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID 		   
		    INNER JOIN '+@MainData+'.dbo.p_Line as l ON wpq.Line_ID = l.Line_ID 
		    LEFT JOIN '+@MainData+'.dbo.p_ISO as iso ON wpq.ISO_ID = iso.ISO_ID 
		    INNER JOIN '+@MainData+'.dbo.p_ISO_to_Marka as LtoM ON iso.ISO_ID = LtoM.ISO_ID 
		    INNER JOIN '+@MainData+'.dbo.p_Marka as m ON LtoM.Marka_ID = m.Marka_ID 
		    INNER JOIN '+@MainData+'.dbo.p_ISO_to_TitleObject as LtoTO ON iso.ISO_ID = LtoTO.ISO_ID 
		    INNER JOIN '+@MainData+'.dbo.p_TitleObject as TiO ON LtoTO.TitleObject_ID = TiO.TitleObject_ID
			LEFT JOIN '+@MainData+'.dbo.p_ISO_to_ProcessPhase as ItoPH ON iso.ISO_ID = ItoPH.ISO_ID
		    LEFT JOIN '+@MainData+'.dbo.p_ProcessPhase as PH ON ItoPH.ProcessPhase_ID = PH.ProcessPhase_ID
		    WHERE wpq.Row_Status = 0
			';


	--Create combined final temp table by different worktypes on pipes

	declare @SQL5 nvarchar(max) = 
		  N'
			SELECT * 
			INTO #TMP_All_PipngRegs 
		    from (select case 
			      when lead(isnull(TitleObject_Name+Marka_Name+ProcessPhase_Name,'''')) over (partition by Source_File,Reg order by isnull(TitleObject_Name+Marka_Name+ProcessPhase_Name,'''')) <> ''''
                        and isnull(TitleObject_Name+Marka_Name+ProcessPhase_Name,'''') = '''' 
			      then 1
			      else 0
				  end z
		          ,*
				  FROM (Select distinct *
				        FROM (Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
		                      from #TMP_WPPR AS R
		                      left JOIN #TMP_WPPQ AS Q
		                      ON Q.Source_File=R.Source_File AND Q.Shop_Weld_RegNum=R.Reg
							  ) as d
				        ) as p
				  ) as x
		    where x.z=0 and 1=2
			';

    -- Data transformation to normal model 
	declare @SQL6 nvarchar(max) = 
		  N'
			INSERT INTO #TMP_All_PipngRegs 
			SELECT * 
		    from (select case 
			      when lead(isnull(TitleObject_Name+Marka_Name+ProcessPhase_Name,'''')) over (partition by Source_File,Reg order by isnull(TitleObject_Name+Marka_Name+ProcessPhase_Name,'''')) <> ''''
                        and isnull(TitleObject_Name+Marka_Name+ProcessPhase_Name,'''') = '''' 
			      then 1
			      else 0
				  end z
		          ,*
				  FROM (Select distinct *
				        FROM (Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
		                      from #TMP_WPPR AS R
		                      left JOIN #TMP_WPPQ AS Q
		                      ON Q.Source_File=R.Source_File AND Q.Shop_Weld_RegNum=R.Reg
							  union all
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
							  from #TMP_WPPR AS R
							  left JOIN #TMP_WPPQ AS Q
							  ON Q.Source_File=R.Source_File AND Q.Field_Weld_RegNum=R.Reg
							  union all
 							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
							  from #TMP_WPPR AS R 
							  left JOIN #TMP_WPPQ AS Q
							  ON Q.Source_File=R.Source_File AND Q.AKZ_Shop_RegNum=R.Reg
							  union all
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
							  from  #TMP_WPPR AS R
							  left JOIN #TMP_WPPQ AS Q
							  ON Q.Source_File=R.Source_File AND Q.AKZ_Weld_RegNum=R.Reg
							  union all
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
							  from #TMP_WPPR AS R 
							  left JOIN #TMP_WPPQ AS Q
							  ON Q.Source_File=R.Source_File AND Q.GW_RegNum_RegNum=R.Reg
							  union all
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
							  from #TMP_WPPR AS R
							  left JOIN #TMP_WPPQ AS Q
							  ON Q.Source_File=R.Source_File AND Q.Insulation_RegNum=R.Reg
							  union all
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
							  from #TMP_WPPR AS R
							  left JOIN #TMP_WPPQ AS Q
							  ON Q.Source_File=R.Source_File AND Q.Test_Density_Strength=R.Reg
							  union all 
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
							  from #TMP_WPPR AS R
							  left JOIN #TMP_WPPQ AS Q
							  ON Q.Source_File=R.Source_File AND Q.Test_Leak=R.Reg
							  union all 
							  Select distinct Q.TitleObject_Name as ''TitleObject_Name''
											 ,Q.[Marka_Name] as ''Marka_Name''
											 ,Q.TitleObject_ID
											 ,Q.Marka_ID
											 ,Q.ProcessPhase_ID
											 ,Q.ProcessPhase_Name
											 ,R.*
							  from #TMP_WPPR AS R
							  left JOIN #TMP_WPPQ AS Q
							  ON Q.Source_File=R.Source_File AND Q.Certificate_Installation=R.Reg
							  ) as d
				        ) as p
				  ) as x
		    where x.z=0
			';

--Update data based on test table
	declare @SQL7 nvarchar(max) = 
	N'
		merge '+@DraftData+'.[dbo].[s_WPPipingRegisters] as t
		using (select *, row_number() over (partition by Source_File, Reg order by (select null)) Pos from #TMP_All_PipngRegs) s
		on t.Source_File = s.Source_File and t.Reg = s.Reg and s.Pos = 1
		when not matched then 
			INSERT
			([Log_ID]
			,[Reg]			
			,[Title]
			,[Unit]
			,[Marka]
			,[Work_Desc]
			,[CNT_Date]
			,[Repr_SCNT]
			,[Repr_CNT]
			,[Status_Date]
			,[Status]
			,[Source_File]
			,[Load_Date]
			,[WorkPackage]
			,[Process_Phase]
			,[SDM_FEI_SI])
		 VALUES
			(s.LogID
			,s.Reg			
			,s.TitleObject_Name
			,s.Unit
			,s.Marka_Name
			,s.Work_Desc
			,convert(nvarchar(50),s.CNT_Date,101)
			,s.Repr_SCNT
			,s.Repr_CNT
			,convert(nvarchar(50),s.Status_Date,101)
			,s.Status_Name
			,s.Source_File
			,getdate()
			,s.WorkPackage_Name
			,s.ProcessPhase_Name
			,s.SDM_FEI_SI)
		when matched then
			update set 
			 t.Marka = s.Marka_Name
			,t.Title = s.TitleObject_Name
			,t.[Process_Phase] = s.ProcessPhase_Name
			/*,t.CNT_Date = left(s.CNT_Date, 19) ,left(s.CNT_Date, 19)*/
		output $action, inserted.*, deleted.*;
	'

--update data based on interpritation of multi-value Unit field
declare @SQL8 nvarchar(max) = 
	N'
		
		INSERT INTO '+@DraftData+'.[dbo].[s_WPPipingRegisters]
				   ([Log_ID]
				   ,[Reg]				   
				   ,[Title]
				   ,[Unit]
				   ,[Marka]
				   ,[Work_Desc]
				   ,[CNT_Date]
				   ,[Repr_SCNT]
				   ,[Repr_CNT]
				   ,[Status_Date]
				   ,[Status]
				   ,[Source_File]
				   ,[Load_Date]
				   ,[WorkPackage]
				   ,[Process_Phase]
				   ,[SDM_FEI_SI])
		SELECT distinct	
				 x02.Log_ID
				,x02.Reg				
				,COALESCE(x02.Title, i_t.TitleObject_Name, l_t.TitleObject_Name) as TitleObject
				,x02.Unit
				,case when x02.Work_Desc like N''%Входной контроль%'' then N''АВК''
						 else COALESCE(x02.Marka, i_m.Marka_Name, l_m.Marka_Name) end as Marka
				,x02.Work_Desc
				,x02.CNT_Date
				,x02.Repr_SCNT
				,x02.Repr_CNT
				,x02.Status_Date
				,x02.Status
				,x02.Source_File
				,x02.Load_Date
				,x02.WorkPackage
				,COALESCE(pp.ProcessPhase_Name, y02.ProcessPhase_Name) as ProcessPhase
				,x02.SDM_FEI_SI
			FROM	(
					SELECT	
						 x01.Source_File 
						,x01.Log_ID 
						,x01.Reg						
						,x01.Marka 
						,x01.Title
						,x01.Unit 
						,x01.Work_Desc
						,x01.CNT_Date 
						,x01.Repr_SCNT
						,x01.Repr_CNT
						,x01.Status_Date
						,x01.Status
						,x01.Load_Date
						,x01.WorkPackage
						,x01.SDM_FEI_SI
						,value as SingleUnit
					FROM	(	
							SELECT 
								 Source_File 
								,Log_ID 
								,Reg 
								,Unit 
								,Marka
								,Title 
								,Work_Desc 
								,CNT_Date
								,Repr_SCNT 
								,Repr_CNT
								,Status_Date
								,Status
								,Load_Date
								,WorkPackage
								,SDM_FEI_SI
							FROM '+@DraftData+'.dbo.s_WPPipingRegisters
							where title is null or marka is null
							) x01
					CROSS APPLY STRING_SPLIT(x01.Unit, ''/'')
					--WHERE x01.Unit like ''%/%'' and x01.Unit not like ''%N/A%'' 
					) x02
			JOIN '+@MainData+'.dbo.p_Register r on x02.Source_File = r.FileLOG and x02.Log_ID = r.LOG_ID and x02.Reg = r.Register_Number  
			LEFT OUTER JOIN '+@MainData+'.dbo.p_ISO i on x02.SingleUnit = i.ISO_Number
			LEFT OUTER JOIN '+@MainData+'.dbo.p_ISO_to_Marka itm on i.ISO_ID = itm.ISO_ID
			LEFT OUTER JOIN '+@MainData+'.dbo.p_Marka i_m on itm.Marka_ID = i_m.Marka_ID
			LEFT OUTER JOIN '+@MainData+'.dbo.p_ISO_to_ProcessPhase itpp on i.ISO_ID = itpp.ISO_ID
			LEFT OUTER JOIN '+@MainData+'.dbo.p_ProcessPhase pp on itpp.ProcessPhase_ID = pp.ProcessPhase_ID
			LEFT OUTER JOIN '+@MainData+'.dbo.p_Line l on x02.SingleUnit = l.Line_Number
			LEFT OUTER JOIN '+@MainData+'.dbo.p_Line_to_Marka ltm on l.Line_ID = ltm.Line_ID
			LEFT OUTER JOIN '+@MainData+'.dbo.p_Marka l_m on ltm.Marka_ID = l_m.Marka_ID
			LEFT OUTER JOIN '+@MainData+'.dbo.p_ISO_to_TitleObject itt ON i.ISO_ID = itt.ISO_ID
			LEFT OUTER JOIN '+@MainData+'.dbo.p_TitleObject i_t ON itt.TitleObject_ID = i_t.TitleObject_ID
			LEFT OUTER JOIN '+@MainData+'.dbo.p_Line_to_TitleObject ltt ON l.Line_ID = ltt.Line_ID
			LEFT OUTER JOIN '+@MainData+'.dbo.p_TitleObject l_t ON ltt.TitleObject_ID = l_t.TitleObject_ID
			left outer join		(	
								select distinct l.Line_ID, pp.ProcessPhase_Name
								from '+@MainData+'.dbo.p_Line l
								left join '+@MainData+'.dbo.p_ISO_to_Line itl on l.LINE_ID = itl.LINE_ID
								left join '+@MainData+'.dbo.p_ISO i on itl.ISO_ID = i.ISO_ID
								left join '+@MainData+'.dbo.p_ISO_to_ProcessPhase itpp on itpp.ISO_ID = i.ISO_ID
								left join '+@MainData+'.dbo.p_ProcessPhase pp on itpp.ProcessPhase_ID = pp.ProcessPhase_ID
								where pp.ProcessPhase_Name is not NULL
								) y02 on l.Line_ID = y02.Line_ID
			WHERE r.Register_ID is not null and COALESCE(i_t.TitleObject_ID, l_t.TitleObject_ID) is not null

		';


--update data based on Expert decission by Title field for Incoming acceptance control registers
declare @SQL9 nvarchar(max) = 
	N'

		  Update SPR
			SET SPR.Title = TPR.Title,
				SPR.Marka = ''АВК''
			From '+@DraftData+'.[dbo].[s_WPPipingRegisters] AS SPR
			inner join #TMP_All_PipngRegs AS TPR ON TPR.Reg = SPR.Reg and TPR.Source_File = SPR.Source_File
			where SPR.Title is null
			and TPR.Title is not null
			and SPR.Work_Desc LIKE ''%acceptance control%''';


 EXEC(@SQL01+@SQL1+@SQL2+@SQL3+@SQL4+@SQL5+@SQL6+@SQL7+@SQL8+@SQL9);
	
-- 	exec(@SQL01); -- N/A Update SQL

--  exec(@SQL1);  --prepare Piping data R_WorkProgressPipingRegisters

--	EXEC(@SQL2);

--	EXEC(@SQL3); --prepare Piping data R_WorkProgressPipingQuantity

--	EXEC(@SQL4);

--	EXEC(@SQL5); --Create combined final temp table by different worktypes on pipes

--	EXEC(@SQL6); -- Data transformation to normal model 

--	EXEC(@SQL7); --Update data based on test table

--	EXEC(@SQL8); --update data based on interpritation of multi-value Unit field

--	EXEC(@SQL9); --update data based on Expert decission by Title field for Incoming acceptance control registers

END
