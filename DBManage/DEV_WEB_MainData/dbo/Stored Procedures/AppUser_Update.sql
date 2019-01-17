
CREATE procedure [dbo].[AppUser_Update]	-- not null ->	+
(	 @i_AppUser_ID	nvarchar(250)	-- sys param	+
	,@i_RowStatus			nvarchar(250)	-- sys param	+
	,@i_AppUserField_ID		nvarchar(250)	-- sys param	+
	,@i_User_Password		nvarchar(250)				
	,@i_Comment				nvarchar(250)
	,@i_AppUser_Code		nvarchar(250)	-- usr param	+
	--== place your params here ==
	,@o_IsError					bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus			int					= try_cast(ltrim(rtrim(@i_RowStatus			))	as int)
		,@u_Created_User_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Modified_User_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Insert_DTS			datetime2(7)		= try_cast(getdate()							as datetime2(7))
		,@u_Update_DTS			datetime2(7)		= try_cast(getdate()							as datetime2(7))
		,@u_User_Password		varbinary(8000)		= try_cast(ltrim(rtrim(@i_User_Password		))	as varbinary(8000))
		,@u_Comment				nvarchar(250)		= try_cast(ltrim(rtrim(@i_Comment			))	as nvarchar(255))
		,@u_AppUser_Code		nvarchar(255)		= try_cast(ltrim(rtrim(@i_AppUser_Code		))	as nvarchar(255))
		,@u_AppUserField_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUserField_ID	))	as uniqueidentifier)
		--== place your params here ==
		,@u_AppUser_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_AppUser_ID	)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_AppUser_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus		is null) select Id=50101, Msg=formatmessage(50101, 'RowStatus'		) else if (@u_RowStatus			is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'			,try_cast(@i_RowStatus			as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null) select Id=50101, Msg=formatmessage(50101, 'User_ID'		) else if (@u_Created_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'			,try_cast(@i_AppUser_ID			as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null) select Id=50101, Msg=formatmessage(50101, 'AppUser_ID'		) else if (@u_AppUser_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'AppUser_ID'		,try_cast(@i_AppUser_ID			as nvarchar(36)))	;set @e=@e+@@rowcount
		if (@i_AppUser_Code		is null) select Id=50101, Msg=formatmessage(50101, 'AppUser_Code'	) else if (@u_AppUser_Code		is null ) select Id=50103, Msg=formatmessage(50103, 'AppUser_Code'		,try_cast(@i_AppUser_Code		as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@i_AppUserField_ID	is null) select Id=50101, Msg=formatmessage(50101, 'AppUserField_ID') else if (@u_AppUserField_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'AppUserField_ID'	,try_cast(@i_AppUserField_ID	as nvarchar(36)))	;set @e=@e+@@rowcount
		--== place your params here =

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(max))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(max))); set @e=@e+@@rowcount

		select @CntParam = N'AppUser_ID="'+try_cast(@u_AppUser_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'AppUser',try_cast(@u_AppUser_ID as NVARCHAR(max))); set @e=@e+@@rowcount
		
		select @CntParam = N'AppUser_ID="'+try_cast(@u_AppUserField_ID as nvarchar(max))+N'",'+N'AppUser_Code="'+try_cast(@u_AppUser_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_AppUser_Code as nvarchar(max)), 'AppUser'); set @e=@e+@@rowcount

		select @Cnt = count(1) from master.sys.syslogins where loginname = @u_AppUser_Code; 
		if (@Cnt = 0) select Id=50123, Msg=formatmessage(50124, try_cast(@u_AppUser_Code as nvarchar(250))); set @e=@e+@@rowcount
	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'AppUser_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,AppUser_Code
					,User_Password
					,Comment
					from dbo.p_AppUser
					where AppUser_ID = @u_AppUser_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					  RowStatus			= @u_RowStatus
					 ,AppUser_Codee		= @u_AppUser_Code
					 ,User_Password		= @u_User_Password
					 ,Comment			= @u_Comment
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- AppUser
		if (@e = 0) begin try
			update dbo.p_AppUser set
				 RowStatus			= @u_RowStatus	 
				,Update_DTS			= @u_Update_DTS	 
				,Modified_User_ID	= @u_Modified_User_ID
				,AppUser_Code		= @u_AppUser_Code
				,User_Password		= @u_User_Password
				,Comment			= @u_Comment
			where AppUser_ID		= @u_AppUserField_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'AppUser_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
		end catch
	end
	-------------
	------------- Final Action 
	-------------
	if (@trancount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback														-- rollback if critical transaction error
		if @xstate = 1 and @trancount = 0 rollback									-- rollback if transaction was created in this procedure
		if @xstate = 1 and @trancount > 0 rollback transaction trn_AppUser_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
