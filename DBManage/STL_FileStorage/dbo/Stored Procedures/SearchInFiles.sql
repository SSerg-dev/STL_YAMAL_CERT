CREATE procedure [dbo].[SearchInFiles]
(
	 @SearchList	nvarchar(max)
	,@SearchString	nvarchar(250)
	,@FoundList		nvarchar(max) output
	,@o_IsError		bit output
) as begin 
	set nocount on
	declare @e int = 0
	DECLARE @formatedSearchString nvarchar(250)='"'+@SearchString+'\+"'
	begin try 
		if @SearchList <> ''
			select @FoundList = 
			(
				select 
					 b.Stream_Id
					--,b.Path_ID
				from 
						[dbo].[p_FileShareTable]	a  
				join	[dbo].[FileShareTable]	b on a.stream_id = b.Stream_Id
				join	
				(
					select stream_id from openjson(@SearchList) with (stream_id nvarchar(36) '$.stream_id')
				) s on s.stream_id = a.stream_id
				where contains (a.file_stream, @formatedSearchString)
				for json auto
			)
		else
			select @FoundList = 
			(
				select 
					 b.Stream_Id
					--,b.Path_ID
				from 
						[dbo].[p_FileShareTable]	a  
				join	[dbo].[FileShareTable]	b on a.stream_id = b.Stream_Id
				where contains (a.file_stream, @formatedSearchString)
				for json auto
			)
	end try	begin catch	
		select Id = 50100, Msg = formatmessage(50100, N'SearchInFiles.Search', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id = try_cast(null as int), Msg = try_cast(null as nvarchaR(max)) where 1=2
end