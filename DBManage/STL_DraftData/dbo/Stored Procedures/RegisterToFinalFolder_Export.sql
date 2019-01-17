
CREATE procedure  [dbo].[RegisterToFinalFolder_Export] 
(
	 @DraftData		nvarchar(100) = '',
	 @MainData		nvarchar(100) = ''
) as
begin
	set nocount on
	declare @SQL1 nvarchar(max), @SQL2 nvarchar(max), @SQL3 nvarchar(max), @SQL4 nvarchar(max)

	select @SQL1 = N'
	drop table if exists #1
	drop table if exists #2
	drop table if exists #3

	select
		 Register_ID 
		,ISO = stuff
		(
			(
				select '','' + b.ISO_Number
				from '+@MainData+'.dbo.p_RegisterPipingAction a
				join '+@MainData+'.dbo.p_ISO b on a.ISO_ID = b.ISO_ID
				where a.Register_Id = x.Register_ID
				for xml path('''')
			)
			,1,1,''''
		)
	into #1
	from '+@MainData+'.dbo.p_RegisterPipingAction x 
	group by Register_ID
	'

	select @SQL2 = N'
	select
		 Title			= isnull(Title			,'''')
		,Marka			= isnull(Marka			,'''')
		,FileLOG		= isnull(FileLOG			,'''')
		,LogID			= isnull(LogID			,'''')
		,Reg			= isnull(Reg			,'''')
		,SetFolderNumber= isnull(SetFolderNumber,'''')
		,FolderNumber	= isnull(FolderNumber	,'''')
		,Unit			= isnull(max(Unit		),'''')
		,WorkDesk		= isnull(max(WorkDesk	),'''')
		,ISO			= isnull(max(ISO		),'''')
		,Status_NameS
		,Register_ID
		,FinalFolder_ID
		,Register_to_FinalFolder_Id
		,Num
	into #2
	from
	(
		select
			 Num
			,a00.Title
			,a00.Marka
			,a04.FileLOG
			,a00.LogID
			,a00.Reg
			,SetFolderNumber = a00.SetFolderNumber
			,FolderNumber = a00.FolderNumber
			,Unit = coalesce(c01.Unit,c02.Unit,'''')
			,WorkDesk = coalesce(c01.Work_Desc,c02.Work_Desc,'''')
			,ISO = x01.ISO
			,Status_NameS = isnull(s01.Description_Rus,'''') + isnull(N'' / '' + s01.Description_Eng,'''')
			,Register_ID = a04.Register_ID
			,FinalFolder_ID = f00.ABDFinalFolder_ID
			,Register_to_FinalFolder_Id = Register_To_ABDFinalFolder_ID
		from
		(
			select
				 Num			 = row_number() over (order by (select 1))
				,Title			 = isnull(rtrim(ltrim(Title)),'''')
				,Marka			 = isnull(rtrim(ltrim(Marka)),'''')
				,FileLOG		 = isnull(rtrim(ltrim(FileLOG)),'''')
				,LogID			 = isnull(rtrim(ltrim(LogID)),'''')
				,Reg			 = isnull(rtrim(ltrim(Reg)),'''')
				,NewReg			 = isnull(rtrim(ltrim(NewReg)),'''')
				,SetFolderNumber = isnull(rtrim(ltrim(SetFolderNumber)),'''')
				,FolderNumber	 = isnull(rtrim(ltrim(FolderNumber)),'''')
			from '+@DraftData+'.[dbo].[s_Final_ABD_Registers_Excel]
			where SourceFile = ''ABD_Registers_Final_Comp_YAM''
			and isnull(FolderNumber,'''') <> N''дубль''
			and isnull(FileLOG + Reg, '''') <> ''''
		)															a00
		left join	'+@MainData+'.dbo.Register							a04	on	a00.FileLOG				= a04.FileLOG
																		and	a00.Reg					= a04.Register_Number
		left join	(select distinct [Source_File] as FileLOG, LogId, Reg, Work_Desc, Unit from '+@MainData+'.dbo.p_WorkProgressRegisters)		
																	c01	on  c01.FileLOG				= a00.FileLOG
																		and c01.Reg					= a00.Reg
		left join	(select distinct [Source_File] as FileLOG, LogId, Reg, Work_Desc, Unit from '+@MainData+'.dbo.p_WorkProgressPipingRegisters)
																	c02	on  c02.FileLOG					= a00.FileLOG
																		and c02.Reg					= a00.Reg
		left join	#1												x01 on	a04.Register_ID			= x01.Register_Id
		left join	'+@MainData+'.dbo.p_ABDFinalFolder					f00	on	a00.FolderNumber		= f00.ABDFinalFolder_Name and a00.FolderNumber <> ''''
		left join	'+@MainData+'.dbo.p_Register_to_ABDFinalFolder		fx  on	a04.Register_ID			= fx.Register_ID
																		and f00.ABDFinalFolder_ID	= fx.ABDFinalFolder_ID
		left join	'+@MainData+'.dbo.p_Register_to_ABDStatus				s00 on	s00.Register_ID			= a04.Register_ID
		left join	'+@MainData+'.dbo.p_ABDStatus						s01	on	s01.ABDStatus_ID		= s00.ABDStatus_ID
	) z
	group by 
		 Num
		,Title			
		,Marka	
		,FileLOG		
		,LogID			
		,Reg			
		,SetFolderNumber
		,FolderNumber
		,Register_Id
		,FinalFolder_ID
		,Register_to_FinalFolder_Id
		,Status_NameS
	'

	select @SQL3 = N'
	select 
		 Title			= isnull(Title			,'''')
		,Marka			= isnull(Marka			,'''')
		,FileLOG		= isnull(FileLOG			,'''')
		,LogID			= isnull(LogID			,'''')
		,Reg			= isnull(Reg			,'''')
		,SetFolderNumber= isnull(max(SetFolderNumber),'''')
		,FolderNumber	= isnull(FolderNumber	,'''')
		,Unit			= isnull(max(Unit		),'''')
		,WorkDesk		= isnull(max(WorkDesk	),'''')
		,ISO			= isnull(max(ISO		),'''')
		,Register_ID
		,Status_NameS
	into #3
	from 
	(
		select  distinct 
			 Title				= a04.TitleObject_Name
			,Marka				= a03.Marka_Name
			,FileLOG			= a00.FileLOG
			,LogID				= a00.LOG_ID
			,Reg				= a00.Register_Number
			,SetFolderNumber	= s01.ABDFinalSet_Number
			,FolderNumber		= ''''
			,Unit				= coalesce(c01.Unit,c02.Unit,'''')
			,WorkDesk			= coalesce(c01.Work_Desc,c02.Work_Desc,'''')
			,ISO				= x01.ISO
			,Register_ID		= a00.Register_ID
			,Status_NameS		= isnull(st1.Description_Rus,'''') + isnull(N'' / '' + st1.Description_Eng ,'''')
		from 
		(
			select distinct a.Register_Id, FileLOG, LOG_ID, Register_Number 
			from '+@MainData+'.dbo.Register a 
			join '+@MainData+'.dbo.Register_to_ABDStatus b0 on a.Register_ID = b0.Register_ID join '+@MainData+'.dbo.Status b on b0.ABDStatus_ID = b.ABDStatus_ID
			where 1=1 
			--and a.FileLOG not like ''%COW%''
			and isnull(b.code,N''N/A'') <> N''N/A''
			and not exists (select 1  from #2 where a.Register_Id = #2.Register_ID) 
		)	a00
		left join	'+@MainData+'.dbo.Register_to_Marka					a01 on	a00.Register_ID			= a01.Register_ID		
		left join	'+@MainData+'.dbo.Register_to_TitleObject			a02	on	a00.Register_ID			= a02.Register_ID
		left join	'+@MainData+'.dbo.Marka								a03	on	a01.Marka_ID			= a03.Marka_ID
		left join	'+@MainData+'.dbo.TitleObject						a04	on	a02.TitleObject_ID		= a04.TitleObject_ID
		left join	(select distinct [Source_File] as FileLOG, LogId, Reg, Work_Desc, Unit from '+@MainData+'.dbo.p_WorkProgressRegisters)
																	c01	on  c01.FileLOG				= a00.FileLOG
																		and c01.Reg					= a00.Register_Number
		left join	(select distinct [Source_File] as FileLOG, LogId, Reg, Work_Desc, Unit from '+@MainData+'.dbo.p_WorkProgressPipingRegisters)
																	c02	on  c02.FileLOG			    = a00.FileLOG
																		and c02.Reg					= a00.Register_Number
		left join	#1												x01 on	a00.Register_ID			= x01.Register_Id
		left join	'+@MainData+'.dbo.ABDFinalSet						s01 on	a03.Marka_ID			= s01.Marka_ID
																		and	a04.TitleObject_ID		= s01.TitleObject_ID
		left join	'+@MainData+'.dbo.Register_to_ABDStatus				st0 on	st0.Register_ID			= a00.Register_ID
		left join	'+@MainData+'.dbo.ABDStatus						st1	on	st1.ABDStatus_ID		= st0.ABDStatus_ID
		where isnull(st1.code,''N/A'') <> N''N/A''
	) z
	group by 
		 Title			
		,Marka		
		,FileLOG	
		,LogID			
		,Reg			
		,FolderNumber	
		,Register_ID
		,Status_NameS
	'

	select @SQL4 = N'
	select 
		 [Title]		= Title				collate Cyrillic_General_CI_AS		
		,[Marka]		= Marka				collate Cyrillic_General_CI_AS
		,FileLOG		= FileLOG			collate Cyrillic_General_CI_AS
		,[LogID]		= LogID				collate Cyrillic_General_CI_AS
		,[Reg]			= Reg				collate Cyrillic_General_CI_AS
		,[new reg]		= N''''				collate Cyrillic_General_CI_AS
		,[Set]			= SetFolderNumber	collate Cyrillic_General_CI_AS
		,[Folder Number]= FolderNumber		collate Cyrillic_General_CI_AS
		,[Unit]			= Unit				collate Cyrillic_General_CI_AS
		,[ISO]			= ISO				collate Cyrillic_General_CI_AS
		,[Work_Desc]	= WorkDesk			collate Cyrillic_General_CI_AS
		,[Status_NameS]	= Status_NameS		collate Cyrillic_General_CI_AS		
	from #2
	union all
	select 
		 Title				collate Cyrillic_General_CI_AS
		,Marka				collate Cyrillic_General_CI_AS
		,FileLOG			collate Cyrillic_General_CI_AS
		,LogID				collate Cyrillic_General_CI_AS
		,Reg				collate Cyrillic_General_CI_AS
		,N''''				collate Cyrillic_General_CI_AS
		,SetFolderNumber	collate Cyrillic_General_CI_AS
		,FolderNumber		collate Cyrillic_General_CI_AS
		,Unit				collate Cyrillic_General_CI_AS
		,ISO				collate Cyrillic_General_CI_AS
		,WorkDesk			collate Cyrillic_General_CI_AS
		,Status_NameS		collate Cyrillic_General_CI_AS
	from #3
	'

	print @SQL1
	print @SQL2
	print @SQL3
	print @SQL4

	exec(@SQL1+@SQL2+@SQL3+@SQL4)
	set nocount off
end
