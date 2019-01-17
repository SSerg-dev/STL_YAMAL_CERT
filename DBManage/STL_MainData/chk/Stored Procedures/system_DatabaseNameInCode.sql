create procedure chk.system_DatabaseNameInCode
as begin
	declare Cur cursor local fast_forward read_only for 
		select xDataBase = name from sys.databases 
		where name not in ('master','tempdb','SSISDB','model','msdb','ReportServer')
	declare 
		 @xDataBase		nvarchar(250) = ''
		,@xSQL			nvarchar(max) = ''

	drop table if exists #xOut
	create table #xOut
	(--  In-Memory temporary table 
		 xType		nvarchar(250)
		,xDataBase	nvarchar(250)
		,xSchema	nvarchar(250)
		,xName		nvarchaR(250)
	)

	open Cur

	while 1=1 begin
		fetch next from Cur into @xDataBase
		if @@fetch_status <> 0 break
		select @xSQL = N'		
			declare @S nvarchar(max) = N''
			select 
				 xType = case a.Type 
					when ''''P'''' then ''''Procedure'''' 
					when ''''V'''' then ''''View'''' 
					when ''''F'''' then ''''Function'''' 
					when ''''IF'''' then ''''InlineFunction'''' 
					else a.type 
				end
				,xDataBase		= b.db
				,xSchema		= c.name 
				,xName			= a.name
			from sys.all_objects a
			join 
			(
				select a.object_id, a.definition, b.name db from sys.sql_modules a
				join (select name from sys.databases where database_id = db_id()) b on 1=1
				where definition like N''''%'''' collate Cyrillic_General_CI_AS +b.name collate Cyrillic_General_CI_AS +N''''%'''' collate Cyrillic_General_CI_AS
			) b on a.object_id = b.object_id
			join sys.schemas c on a.schema_id = c.schema_id
			''
			exec '+@xDataBase+'..sp_executesql @S 
		'
		insert into #xOut exec sp_executesql @xSQL
	end
	close Cur; deallocate Cur;
	select * from #xOut order by xDataBase, xType, xSchema, xName
end
