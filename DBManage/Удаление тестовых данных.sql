use DEV_WEB_MainData
go
/*	Подготовительный скрипт создан для того, чтобы удалить из базы все возможные предыдущие тестовые записи,
	Если ВДРУГ в результате сбоя они не были удалены штатными средствами тестирования.

	Скрипт не решате ВСЕХ проблем, так как существуют таблицы,
	которые не содаржат поля вида TableName_Code, 
	что есть не верно, но на данный момент имеет метсо быть. 
	
	Для корректной работы с такими таблицами слдеует руками внести правки в раздел UNION

	Если не удалились записи в _to_ таблицах то скрипт их удалить не сможет */
set nocount on
-- курсор по таблицам/колонкам. выбираем только те, которые входят в схемы 'dbo' и 'abd'
declare Cur cursor local fast_forward read_only for
	select FullName = s.name+'.'+t.name, CodeField = c.name
	from sys.tables t 
	join sys.schemas s on t.schema_id = s.schema_id and s.name in ('dbo','abd')
	join sys.columns c on c.object_id = t.object_id and c.name = right(t.name,len(t.name)-2)+'_Code'
	where left(t.name,2) = 'p_' 
	and t.name not like 'p/_%/_to/_%' escape '/'
	and t.name <> 'p_RowStatus'
	-- Для таблиц в которых поля не соответствуют архитектуре нужно сделать ручное присоединение 
	union all select 'abd.p_Document', 'Document_Name'
	--union all select 'abd.p_DocumentAttribute', 'DocumentAttribute_Format'
-- переменные 
declare 
	 @FullName nvarchar(max) = ''
	,@ColumnName nvarchar(max) = ''
	,@SQL nvarchar (max) = ''
	,@Id uniqueidentifier = '00000000-0000-0000-0000-000000000000' -- нужно для корректного первого условия newid() > @Id
	,@i int = 0
-- временная таблица для запросов на удаление, важно newsequentialid(), так как newid() в теории может привести к бесконечному циклу
drop table if exists #1 
create table #1 (Id uniqueidentifier default newsequentialid(), RunSQL nvarchar(max))   
-- пробегаемся по каждой табличке и находим в не тестовые записи по маске like 'TST#%'
open Cur
while 1=1 begin
	fetch next from Cur into @FullName, @ColumnName
	if @@fetch_status <> 0 break 
	select @SQL = 'select * from '+@FullName+ ' where left('+@ColumnName+',4)=''TST#'''
	-- можно не делать вызова @SQL, а сгенерировать динамику с output но так нагляднее для отладки
	exec (@SQL)
	-- если в таблице есть тестовые записи, добавляем скрипт на удаление в пул
	if @@rowcount > 0 insert into #1 (RunSQL) select 'delete from '+@FullName+ ' where left('+@ColumnName+',4)=''TST#'''
end
close Cur deallocate Cur
-- хитрый цикл крутиться пока в пуле есть запросы на удаление
while exists (select 1 from #1) and (@i < 10) begin
	-- выбираем следующий запрос и ID (которые сгенерированы последовательно и отсортированно)
	select top 1 @SQL = RunSQL, @Id = Id from #1 where Id > @Id
	-- если нет больше Id > @Id (это значит мы прошли от начала до конца всего пула, но он еще не пустой), 
	-- тогда сбрасываем @Id чтобы запустить проход на следующий круг
	if @@rowcount = 0 select @Id = '00000000-0000-0000-0000-000000000000' 
	begin try 
		--RAISERROR (@SQL, 0, 1) WITH NOWAIT
		exec(@SQL)
		-- только если удаление прошло успешно - удаляем записть из пула
		if @@rowcount > 0 delete from #1 where Id = @Id
	end try begin catch
		/* если удалить не удалось (так как есть зависимости), не делаем ничего
		будем крутить запрос цикл пока не удаляться все записи
		есть опасность получить бесконечный цикл, если была создана запись 
		ссылающаяся на одну из записей TST#, но при этом сама она не попала 
		в выборку курсора */
		set @i = @i + 1
	end catch
end
-- если что-то осталось тогда выводим что там есть
if exists (select 1 from #1) select * from #1



