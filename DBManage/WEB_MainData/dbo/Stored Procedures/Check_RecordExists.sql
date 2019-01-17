create procedure Check_RecordExists
(
	 @TableName		sysname
	,@GUID			uniqueidentifier
	,@Res			bit output
) as
begin
	declare @SQL nvarchaR(max) = N'', @ColumnName sysname  = N''
	declare @e int = 0 -- Error Count

	select @Res = 0
	begin try	
		select @ColumnName = column_name from information_schema.key_column_usage 
		where objectproperty(object_id(constraint_schema + '.' + quotename(constraint_name)), 'isprimarykey') = 1
		and table_schema + '.' + table_name = @TableName
		if (isnull(@ColumnName,'') = '') 
		begin
			select 50121, formatmessage(50100, N'Check_RecordExists','Primary key column did not found. Please check TableName parameter it should be declared with schema without [], for example -> "Schema.Table"')
			set @e=@e+@@rowcount
		end else begin
			select @SQL = N'select @Result = 1 where exists (select 1 from '+@TableName+N' where '+@ColumnName+N'=try_cast('''+cast(@GUID as nvarchar(36))+N''' as uniqueidentifier))'
			execute sp_executesql @SQL, N'@Result bit output', @Result = @Res output
		end
	end try
	begin catch
		select 50121, formatmessage(50100, N'Check_RecordExists',error_message())
		set @e=@e+@@rowcount
	end catch
	-- even if no error appear need to return empty rowset it need to set up @@rowcount for caller procedure  in case when in count errors too 
	select Error_ID = cast(null as int), Error_Msg = cast(null as nvarchaR(max)) where @e > 0 
end
