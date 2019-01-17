CREATE procedure [dbo].[Temp_UpdateID] (@i_TableName		nvarchar(120))-- только имена никаких там префиксов
as begin
	set nocount on
	declare 
		 @Web_TableName		nvarchar(120)
		,@Old_TableName		nvarchar(120)
		,@SQL				nvarchar(max)
	select @Web_TableName = N'p_'+@i_TableName, @Old_TableName = N'p_'+@i_TableName
	-- проверим наличие таблиц
	if		exists (select 1 from DEV_WEB_MainData.sys.all_objects	where name = @Web_TableName and schema_id = 1 and type = 'U')
		and exists (select 1 from STL_MainData.sys.all_objects		where name = @Old_TableName and schema_id = 1 and type = 'U')
	begin
		print 'Таблички '+@i_TableName+' в обеих база найдены...'
		-- получаем ID записи N/A-Z на этот ID будет проивзодиться замена как на временный
		declare @NA_ID uniqueidentifier
		select @SQL = N'select @NA_ID = '+@i_TableName+N'_ID from '+@Web_TableName+N' where '+@i_TableName+N'_Code = N''N/A-Z'''
		execute sp_executesql @SQL, N'@NA_ID uniqueidentifier output', @NA_ID=@NA_ID output;  
		-- если найдена такая запись то работать можно дальше
		if @NA_ID is not null begin
			print 'Запись N/A найдена...' + cast(@NA_ID as nvarchar(36))
			-- создаем курсор для выдерга комбинации сджойнившихся старого и нового ID, собственно вся логика тут - это CASE (^_^)
			select @SQL = 'declare Cur_MainTableData cursor for 
				select 
					 Web_ID	= a.'+@i_TableName+N'_ID
					,Old_ID = b.'+@i_TableName+N'_ID 
				from DEV_WEB_MainData..'+@Web_TableName+N' a join STL_MainData..'+@Old_TableName+N' b 
				on a.'+@i_TableName+N'_Code = b.'+
				case @i_TableName
					when N'Contragent'		then N'Code'
					when N'DesignAreaType'	then N'DesignAreaType_Name'
					when N'GOST'			then N'GOST_Code'
					when N'ISO'				then N'ISO_Number'
					when N'Line'			then N'Line_Number'
					when N'Marka'			then N'Marka_Name'
					when N'Phase'			then N'Phase_Name'
					when N'PID'				then N'PID_Code'
					when N'TitleObject'		then N'TitleObject_Name'
					when N'WorkPackage'		then N'WorkPackage_Name'
					when N'ProcessPhase'	then N'ProcessPhase_Name'
											else null
				end 
				+N' and a.'+@i_TableName+N'_Code <> N''N/A'''
				+N' and a.'+@i_TableName+N'_ID <> b.'+@i_TableName+N'_ID'
			print @SQL
			exec sp_executesql @SQL
			declare @Old_ID uniqueidentifier, @Web_ID uniqueidentifier
			delete from TempUpdateID where TableName = @i_TableName
			-- 
			open Cur_MainTableData
			while 1=1 begin
				fetch next from Cur_MainTableData into @Web_ID, @Old_ID
				if @@fetch_status <> 0 break 
				--print @Old_ID
		
				declare Cur_RelatedTables cursor local fast_forward read_only for
					select 
						 SQL_WEB2NA = 'update '+t.name+' set '+c.name+'=N'''+cast(@NA_ID as nvarchar(36))+''' where '+c.name+'= N'''+cast(@Web_ID as nvarchar(36))+''''
						,SQL_NA2OLD = 'update '+t.name+' set '+c.name+'=N'''+cast(@Old_ID as nvarchar(36))+''' where '+c.name+'= N'''+cast(@NA_ID as nvarchar(36))+''''
					from sys.foreign_key_columns as fk
					inner join sys.tables as t on fk.parent_object_id = t.object_id
					inner join sys.columns as c on fk.parent_object_id = c.object_id and fk.parent_column_id = c.column_id
					where  fk.referenced_object_id = (select object_id from sys.tables where name = @Web_TableName)

				declare @SQL_WEB2NA nvarchar(max) = '', @SQL_NA2OLD nvarchar(max) = ''
				open Cur_RelatedTables

				while 1=1 begin
					fetch next from Cur_RelatedTables into @SQL_WEB2NA, @SQL_NA2OLD
					if @@fetch_status <> 0 break 
					insert into TempUpdateID(TableName,Id,Pos,RunSQL,[UID]) values (@i_TableName, @Web_ID, 1, @SQL_WEB2NA,newid())
					insert into TempUpdateID(TableName,Id,Pos,RunSQL,[UID]) values (@i_TableName, @Web_ID, 3, @SQL_NA2OLD,newid()) 
				end
				close Cur_RelatedTables deallocate Cur_RelatedTables
			
				insert into TempUpdateID(TableName,Id,Pos,RunSQL,[UID]) 
					select @i_TableName, @Web_ID, 2,  N'update '+@Web_TableName+N' set '+@i_TableName+N'_ID = N'''+cast(@Old_ID as nvarchar(36))+N''' where '+@i_TableName+N'_ID = N'''+cast(@Web_ID as nvarchar(36))+N'''', newid()
			end
			close Cur_MainTableData deallocate Cur_MainTableData	
		end else begin
			print 'Запись N/A не найдена!'
		end
	end else begin
		print 'Как минимум в одной из баз табличка отсутствует!'
	end
end
