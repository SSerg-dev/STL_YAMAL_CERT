-- =============================================
-- Author: Ivan Vaskov
-- Create date: 16.08.2018
-- =============================================

CREATE procedure [dbo].[AppUser_Insert]	-- not null ->	+
(	 @i_RowStatus			nvarchar(250)	-- sys param	+
	,@i_AppUser_ID			nvarchar(250)	-- sys param	+
	,@i_AppUser_Code		nvarchar(250)	-- usr param	+
	,@i_User_Password		varbinary(8000)	-- usr param	+
	,@i_Comment				nvarchar(250)	-- usr param	+
	,@o_Entity_ID			nvarchar(250)	output
	,@o_IsError				bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Params
	declare 
		 @u_RowStatus			int					= try_cast(ltrim(rtrim(@i_RowStatus		))	as int)
		,@u_Created_User_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID	))	as uniqueidentifier)
		,@u_Modified_User_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID	))	as uniqueidentifier)
		,@u_Insert_DTS			datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Update_DTS			datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_User_Password		varbinary(8000)		= try_cast(ltrim(rtrim(@i_User_Password))	as varbinary(8000))
		,@u_Comment				nvarchar(250)		= try_cast(ltrim(rtrim(@i_Comment		))	as nvarchar(255))
		,@u_AppUser_Code		nvarchar(255)		= try_cast(ltrim(rtrim(@i_AppUser_Code	))	as nvarchar(255))
		,@u_AppUser_ID			uniqueidentifier	= newid()
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@TranCount, @CntParam nvarchar(max) = N'', @User_ID uniqueidentifier = Null, @Operation_Type int = 0
	-- Nested Tran
	if @TranCount = 0 begin transaction	else save transaction trn_AppUser_Insert
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus	is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'		) else if (@u_RowStatus			is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'		,try_cast(@i_RowStatus		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID	is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'		) else if (@u_Created_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'		,try_cast(@i_AppUser_ID		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_Code	is null ) select Id=50101, Msg=formatmessage(50101, 'AppUser_Code'	) else if (@u_AppUser_Code		is null ) select Id=50103, Msg=formatmessage(50103, 'AppUser_Code'	,try_cast(@i_AppUser_Code	as nvarchar(250)));set @e=@e+@@rowcount
		-- data consistency check	
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		--select @CntParam = N'AppUser_Code="'+try_cast(@u_AppUser_Code as nvarchar(max))+N'"', @Cnt=-1
		--exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_AppUser_Code as nvarchar(250)), 'AppUser'); set @e=@e+@@rowcount
		
		select @Cnt = count(1) from master.sys.syslogins where loginname = @u_AppUser_Code; 
		if (@Cnt<=0) select Id=50123, Msg=formatmessage(50124, try_cast(@u_AppUser_Code as nvarchar(250))); set @e=@e+@@rowcount

		Select top 1 @User_ID = AppUser_ID from dbo.p_AppUser where AppUser_Code = @u_AppUser_Code
		
		IF @User_ID IS NULL		SET @Operation_Type = 0
		IF @User_ID IS NOT NULL	SET @Operation_Type = 1


	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'AppUser_Insert.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------		
	-- AppUser
	if (@e = 0) begin try
		IF @Operation_Type = 0 
		begin
			Insert into dbo.p_AppUser
			(	 AppUser_ID
				,RowStatus
				,Insert_DTS
				,Update_DTS	  
				,Created_User_ID
				,Modified_User_ID
				,AppUser_Code
				,User_Password
				,Comment
			) values
			(	 @u_AppUser_ID
				,@u_RowStatus
				,@u_Insert_DTS
				,@u_Update_DTS	  
				,@u_Created_User_ID
				,@u_Modified_User_ID
				,@u_AppUser_Code	
				,@u_User_Password
				,@u_Comment
			)
		END
		else if @Operation_Type = 1
		begin
			update dbo.p_AppUser 
				set RowStatus	 = 0, 
				Update_DTS		 = @u_Update_DTS, 
				Modified_User_ID = @u_Modified_User_ID, 
				User_Password	 = @u_User_Password,
				Comment			 = @u_Comment  
				where AppUser_ID = @User_ID
		end
	end try begin catch 
		select Id=50100, Msg=formatmessage(50100, N'AppUser_Insert.Insert', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Final Action 
	-------------
	if (@TranCount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback														-- rollback if critical transaction error
		if @xstate = 1 and @TranCount = 0 rollback									-- rollback if transaction was created in this procedure
		if @xstate = 1 and @TranCount > 0 rollback transaction trn_AppUser_Insert	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure	
	if @e > 0 select @o_IsError = 1, @o_Entity_ID = null else select @o_IsError = 0, @o_Entity_ID = try_cast(@u_AppUser_ID as nvarchar(36))
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
