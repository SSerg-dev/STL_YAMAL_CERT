

-- =============================================
-- Author: Ivan Vaskov
-- Create date: 19.08.2018
-- Evaluated and refactored by RAlizade (2018-09-17)
-- =============================================

CREATE procedure [dbo].[CheckItem_Update]	-- not null ->	+
(	 @i_CheckItem_ID	nvarchar(250)	-- sys param	+
	,@i_RowStatus		nvarchar(250)	-- sys param	+
	,@i_AppUser_ID		nvarchar(250)	-- sys param	+
	,@i_CheckList_ID	nvarchar(250)	-- ust param	+
	,@i_Document_ID		nvarchar(250)	-- ust param	-
	,@i_Position		nvarchar(250)	-- ust param	+
	,@i_Comment			nvarchar(250)	-- ust param	-
	,@o_IsError			bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus			int					= try_cast(ltrim(rtrim(@i_RowStatus			))	as int			)
		,@u_Created_User_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Modified_User_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Insert_DTS			datetime2(7)		= try_cast(getdate()							as datetime2(7))
		,@u_Update_DTS			datetime2(7)		= try_cast(getdate()							as datetime2(7))
		,@u_CheckList_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_CheckList_ID		))	as uniqueidentifier)
		,@u_Document_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_Document_ID		))	as uniqueidentifier)
		,@u_Position			int					= try_cast(ltrim(rtrim(@i_Position			))	as int			)
		,@u_Comment				nvarchar(250)		= try_cast(ltrim(rtrim(@i_Comment			))	as nvarchar(255))

		,@u_CheckItem_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_CheckItem_ID	)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_CheckItem_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus	is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'		) else if (@u_RowStatus			is null )	select Id=50106, Msg=formatmessage(50106, 'RowStatus'		,try_cast(@i_RowStatus		as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@i_AppUser_ID	is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'		) else if (@u_Created_User_ID	is null )	select Id=50108, Msg=formatmessage(50108, 'User_ID'			,try_cast(@i_AppUser_ID		as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@i_CheckItem_ID is null ) select Id=50101, Msg=formatmessage(50101, 'CheckItem_ID'	) else if (@u_CheckItem_ID		is null )	select Id=50108, Msg=formatmessage(50108, 'CheckItem_ID'	,try_cast(@i_CheckItem_ID	as nvarchar(36)))	;set @e=@e+@@rowcount
		if (@i_CheckList_ID	is null ) select Id=50101, Msg=formatmessage(50101, 'CheckList_ID'	) else if (@u_CheckList_ID		is null )	select Id=50108, Msg=formatmessage(50108, 'CheckList_ID'	,try_cast(@i_CheckList_ID	as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@i_Position		is null ) select Id=50101, Msg=formatmessage(50101, 'Position'		) else if (@u_Position			is null )	select Id=50106, Msg=formatmessage(50106, 'Position'		,try_cast(@i_Position		as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@u_Document_ID	is null	) and (@i_Document_ID	is not null)																	select Id=50108, Msg=formatmessage(50108, 'Document_ID'		,try_cast(@i_Document_ID	as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@u_Comment		is null	) and (@i_Comment		is not null)																	select Id=50103, Msg=formatmessage(50103, 'Comment'			,try_cast(@i_Comment		as nvarchar(250)))		;set @e=@e+@@rowcount
	
		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'CheckItem_ID="'+try_cast(@u_CheckItem_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_CheckItem', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'CheckItem',try_cast(@u_CheckItem_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		--select @CntParam = N'CheckList_ID="'+try_cast(@u_CheckList_ID as nvarchar(max))+N'",'+N'Position="'+try_cast(@u_Position as nvarchar(max))+N'"', @Cnt=-1
		--exec Get_RowCount 'p_CheckItem', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast('' as nvarchar(250)), 'Unique'); set @e=@e+@@rowcount

		select @CntParam = N'CheckList_ID="'+try_cast(@u_CheckList_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_CheckList', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_CheckList', try_cast(@u_CheckList_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		if (@u_Document_ID	is not null	)
			begin
			select @CntParam = N'Document_ID="'+try_cast(@u_Document_ID as nvarchar(max))+N'"', @Cnt=-1
			exec Get_RowCount 'p_Document', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_Document', try_cast(@u_Document_ID as NVARCHAR(36))); set @e=@e+@@rowcount
			end

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'CheckItem_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------
	if not exists 
		(-- check if any changes appear
			select 1 from
			(select binary_checksum(*) x from
				(select 
					 RowStatus
					,CheckList_ID
					,Document_ID	
					,Position	
					,Comment		
					from dbo.p_CheckItem
					where CheckItem_ID = @u_CheckItem_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					 RowStatus		= @u_RowStatus
					,CheckList_ID	= @u_CheckList_ID
					,Document_ID	= @u_Document_ID	
					,Position		= @u_Position	
					,Comment		= @u_Comment		
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- CheckItem
		if (@e = 0) begin try
			update dbo.p_CheckItem set
				 RowStatus	  = @u_RowStatus	 
				,Update_DTS	  = @u_Update_DTS	 
				,Modified_User_ID  = @u_Modified_User_ID
				,CheckList_ID	= @u_CheckList_ID
				,Document_ID	= @u_Document_ID	
				,Position		= @u_Position	
				,Comment		= @u_Comment	

			where CheckItem_ID = @u_CheckItem_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'CheckItem_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
		end catch
	end
	-------------
	------------- Final Action 
	-------------
	if (@trancount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback																-- rollback if critical transaction error
		if @xstate = 1 and @trancount = 0 rollback											-- rollback if transaction was created in this procedure
		if @xstate = 1 and @trancount > 0 rollback transaction trn_CheckItem_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
