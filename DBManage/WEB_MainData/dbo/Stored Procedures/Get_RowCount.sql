
CREATE procedure [dbo].[Get_RowCount]
(--	Процедура нуждается в комментариях
	 @TableName		sysname			-- Имя таблицы 
	,@Params		nvarchar(max)	-- Пример оформления строки параметров. Внимание, нет пробелов до и после запятой - это важно. Param1="value1",Param2="value2" 
	,@Res			int output		-- На выходе число записей
) as
begin
	set nocount on
	declare @debug int = 1
	declare @SQL nvarchar(max) = N'', @e int = 0, @SchemaName sysname=N'', @n int = 0, @TableName_ sysname=N'', @Object_ID int = 0
	-- разбираем все возможные нотации объявления таблицы. Сплитуем параметр и дальше,
	-- в зависимости от количества раздленных строк 1, 2 или 3, выбираем значения нужные
	-- если не подошло ничерта, тогда ошибка
	select * into #1 from f_split(replace(replace(@TableName,'[',''),']',''), '.')
	set @n = @@rowcount
	if		(@n = 1) select @SchemaName = 'dbo', @TableName_ = (select Val from #1 where Pos = 1)
	else if (@n = 2) select @TableName_ = (select Val from #1 where Pos = 2), @SchemaName = (select Val from #1 where Pos = 1)
	else if (@n = 3) and exists (select 1 from #1 where Pos = 1 and Val = db_name()) select @TableName_ = (select Val from #1 where Pos = 3), @SchemaName = (select Val from #1 where Pos = 2)
	else begin
		select Id=50100, Msg=formatmessage(50100, N'Get_RowCount.PrepeareTableName', @TableName); 
		set @e=@e+@@rowcount; 
	end
	if (@debug=1) print 'debug01 Table="'+@SchemaName+'.'+@TableName_+'" e="'+cast(@e as nvarchar(max))+'"'+' n="'+cast(@n as nvarchaR(max))+'"'
	-- проверим наличие таблицы
	select @Object_ID = o.object_id from sys.all_objects o join sys.schemas s on o.schema_id = s.schema_id and o.type = 'U' and s.name = @SchemaName and o.name = @TableName_
	if  (@e = 0) and (isnull(@Object_ID,0) <= 0)
	begin
		select Id=50100, Msg=formatmessage(50100, N'Get_RowCount.PrepeareTableExists', @TableName); 
		set @e=@e+@@rowcount; 
	end
	-- во первых экранируем спец символ \
	select @Params = replace(@Params,'\','\\')
	-- подготавливаем валидный JSON 
	select @Params = '[{"pName":"'+replace(replace(@Params,'",','"},{"pName":"'),'="','","pValue":"')+ '}]'
	if (isjson(@Params) = 0) begin -- проверим на валидность входной JSON
		select Id=50100, Msg=formatmessage(50100, N'Get_RowCount.PrepearParams', @Params); 
		set @e=@e+@@rowcount; 
	end 
	if (@debug=1) print 'e="'+cast(@e as nvarchar(max))+'"'
	if @e = 0 begin
		-- Задаем начало будущего запроса. 1=1 сделано для того, что бы далее пристыковывать всегда and + "новое условиу", на случай если условий (колонок) будет несколько.
		select @SQL = N'select @Cnt = count(1) from '+@SchemaName+N'.'+@TableName_+N' where 1=1' 
		-- если ВДРУГ потребуется проверять ТОЛЬКО записи которые показываются в представлениях и у которых ROWCount < 100 то предыдущую строку нужно закомментировать
		-- и раскомментировать следующую ниже
		-- select @SQL = N'select @Cnt = count(1) from '+@SchemaName+N'.'+@TableName_+N' where RowCount < 100'
		-- далее уже формируем запрос
		begin try 
			select @SQL = @SQL + N' and ' 
			+ isnull(a.ColumnName,'"Column Name Is Null or Not Folund"')
			+ 
			case -- кейс нужен для отрбаотки случаем Update/Delete по одной логике и Insert по другой
				when Is_PK = 1 and c > 1 then N' <> N''' -- Если один из параметров PK и параметр не первый, тогда для логика Update/Delete
				else N' = N'''-- в противном случае мы имеем дело с Insert 
			end
			+ isnull(pValue,'"Value is null"') + N''''
			from
			(--	этот подзапрос возвращает все колонки таблицы и флаг PK 
				select 
					 TableName	= o.name
					,ColumnName	= c.name
					,Is_PK = case when isnull(c.name,'') = isnull(o.COLUMN_NAME,'') then 1 else 0 end
				from 
				(
					select o.name, o.object_id, z.COLUMN_NAME from sys.all_objects o
					left join information_schema.key_column_usage z on left(z.CONSTRAINT_NAME ,3) = 'PK_' 
					and z.ORDINAL_POSITION = 1 and z.TABLE_NAME = @TableName_ and z.TABLE_SCHEMA = @SchemaName
					where o.object_id = @Object_ID
					-- type = 'U' 
					----and objectproperty(object_id, 'TableHasUniqueCnst') = 1 
					--and schema_id = (select schema_id from sys.schemas where name = @SchemaName)
					--and name = @TableName_
				) o
				join sys.all_columns c on c.object_id = o.object_id 
			) a
			right join -- джойним все колонки с нашими параметрами (параметры уже стали табличкой key-value-position)
			(--	здесь происходит транспонирование JSON-а с параметрами в таблицу и добавляется поле сортировки
				select y.*, count(1) over (order by (select 1))/*row_number() over (order by (select 1))*/ c from openjson(@Params, '$') with 
				(	pName	sysname			N'$.pName',
					pValue	nvarchar(max)	N'$.pValue'
				)  y
			) b on a.ColumnName = b.pName
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'Get_RowCount.PrepearSQL', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
		end catch
		-- запускаем динамически сформированный запрос
		begin try
			if( right(@SQL,3) = N'1=1' )select @SQL = N'select @Cnt = count(1) from '+@SchemaName+N'.'+@TableName_+N' where 1=2'
			print @SQL
			exec sp_executesql @SQL, N'@Cnt int output', @Cnt = @Res output
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'Get_RowCount.Execute', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
			-- напечатаем для отладки
			print @SQL
		end catch
	end
	-- вывод ошибок
--	if @e > 0 select 1, @o_Entity_ID = try_cast(@u_Document_ID as nvarchar(36))
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id = try_cast(null as int), Msg = try_cast(null as nvarchaR(max)) where 1=2
end 
