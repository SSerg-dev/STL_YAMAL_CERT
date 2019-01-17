create procedure Get_UpdLock_FK_Relation
(
	 @TableName	sysname
	,@GUID		uniqueidentifier
	,@SQL		nvarchar(max) output
	,@JsonSQL	nvarchar(max) output
) as
begin 
	declare
		 @SourceName		sysname = N''	
		,@SourceColumn		sysname = N''
		,@Error_Mask		bigint	= 0
		--,@Error_Messages	
	--select 

		

	declare Cur cursor local fast_forward read_only for
		select 
			 SourceName		= pt.name
			,SourceColumn	= pc.name
		from sys.foreign_keys k
		join sys.all_objects pt on k.parent_object_id = pt.object_id
		join sys.all_objects rt on k.referenced_object_id = rt.object_id
		join sys.foreign_key_columns fc on fc.constraint_object_id = k.object_id 
		join sys.all_columns pc on fc.parent_column_id = pc.column_id and pt.object_id = pc.object_id
		join sys.all_columns rc on fc.referenced_column_id = rc.column_id and rt.object_id = rc.object_id
		--where rt.name = 'p_register'
		where rt.name = @TableName

	declare @Out table (s nvarchar(max))
	
	select @SQL = N'select 1 from '+@TableName+N' with (updlock) where '+@TableName+N'_ID = '''+cast(@GUID as nvarchar(36))+N''''
	insert into @Out(S) select N'select 1 from '+@TableName+N' with (updlock) where '+@TableName+N'_ID = '''+cast(@GUID as nvarchar(36))+N''''
	
	open Cur
	while 1=1 begin
		fetch next from Cur into 
			 @SourceName	
			,@SourceColumn	
		if @@fetch_status <> 0 break 
		select @SQL = @SQL + char(10)+char(13) + N'select 1 from '+@SourceName+N' with (updlock) where '+@SourceColumn+N' = try_cast('''+cast(@GUID as nvarchar(36))+N''' as uniqueidentifier)'
		insert into @Out(S) select N'select 1 from '+@SourceName+N' with (updlock) where '+@SourceColumn+N' = try_cast('''+cast(@GUID as nvarchar(36))+N''' as uniqueidentifier)'
	end
	close Cur deallocate Cur
	select top 1 @JsonSQL = (select s from @Out for json path) 
end
