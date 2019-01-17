


-- =============================================
-- Author: Ivan Vaskov
-- Create date: 19.08.2018
-- Evaluated and refactored by RAlizade (2018-09-17)
-- =============================================

CREATE procedure [dbo].[CheckList_Insert]	-- not null ->	+
(	 @i_RowStatus				nvarchar(250)	-- sys param	+
	,@i_AppUser_ID				nvarchar(250)	-- sys param	+
	,@i_CheckList_Code			nvarchar(250)	-- usr param	+
	,@i_CheckList_Date			nvarchar(250)	-- usr param	+
	,@i_Register_ID				nvarchar(250)	-- usr param	+
	,@i_CheckParty_ID				nvarchar(250)	-- usr param	+
	,@i_Resp_Employee_ID	nvarchar(250)	-- usr param	-
	,@o_Entity_ID				nvarchar(250)	output
	,@o_IsError					bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Params
	declare 
		 @u_RowStatus				int					= try_cast(ltrim(rtrim(@i_RowStatus				))	as int			)
		,@u_Created_User_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier)
		,@u_Modified_User_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier)
		,@u_Insert_DTS				datetime2(7)		= try_cast(getdate()								as datetime2(7))
		,@u_Update_DTS				datetime2(7)		= try_cast(getdate()								as datetime2(7))
		,@u_CheckList_Code			nvarchar(255)		= try_cast(ltrim(rtrim(@i_CheckList_Code		))	as nvarchar(255))

		,@u_CheckList_Date			datetime2(7)		= try_cast(ltrim(rtrim(@i_CheckList_Date		))	as datetime2(7))
		,@u_Register_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_Register_ID			))	as uniqueidentifier)
		,@u_CheckParty_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_CheckParty_ID			))	as uniqueidentifier)
		,@u_Resp_Employee_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_Resp_Employee_ID	))	as uniqueidentifier)

		,@u_CheckList_ID			uniqueidentifier	= newid()
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_CheckList_Insert
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus		is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'		) else if (@u_RowStatus			is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'		,try_cast(@i_RowStatus		as nvarchar));set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'		) else if (@u_Created_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'		,try_cast(@i_AppUser_ID		as nvarchar));set @e=@e+@@rowcount
		if (@i_CheckList_Code	is null ) select Id=50101, Msg=formatmessage(50101, 'CheckList_Code') else if (@u_CheckList_Code	is null ) select Id=50103, Msg=formatmessage(50103, 'CheckList_Code',try_cast(@i_CheckList_Code	as nvarchar));set @e=@e+@@rowcount

		if (@i_CheckList_Date	is null ) select Id=50101, Msg=formatmessage(50101, 'CheckList_Date') else if (@u_CheckList_Date	is null ) select Id=50104, Msg=formatmessage(50104, 'CheckList_Date',try_cast(@i_CheckList_Date	as nvarchar));set @e=@e+@@rowcount
		if (@i_Register_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'Register_ID'	) else if (@u_Register_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'Register_ID'	,try_cast(@i_Register_ID	as nvarchar));set @e=@e+@@rowcount
		if (@i_CheckParty_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'CheckParty_ID	'	) else if (@u_CheckParty_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'CheckParty_ID'	,try_cast(@i_CheckParty_ID		as nvarchar));set @e=@e+@@rowcount
		if (@i_Resp_Employee_ID is not null and @u_Resp_Employee_ID is null) select Id=50108, Msg=formatmessage(50108, 'Resp_Employee_ID'	,try_cast(@i_Resp_Employee_ID	as nvarchar));set @e=@e+@@rowcount


		-- data consistency check	
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(50))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(50))); set @e=@e+@@rowcount

		select @CntParam = N'CheckList_Code="'+try_cast(@u_CheckList_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_CheckList', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_CheckList_Code as nvarchar(50)), 'CheckList'); set @e=@e+@@rowcount
		
		select @CntParam = N'Register_ID="'+try_cast(@u_Register_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Register', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_Register', try_cast(@u_Register_ID as NVARCHAR(50))); set @e=@e+@@rowcount
		
		select @CntParam = N'CheckParty_ID="'+try_cast(@u_CheckParty_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_CheckParty', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_CheckParty', try_cast(@u_CheckParty_ID as NVARCHAR(50))); set @e=@e+@@rowcount
		
		if (@u_Resp_Employee_ID is not null)
			begin
			select @CntParam = N'Employee_ID="'+try_cast(@u_Resp_Employee_ID as nvarchar(max))+N'"', @Cnt=-1
			exec Get_RowCount 'p_Employee', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Resp_Employee', try_cast(@u_Resp_Employee_ID as NVARCHAR(50))); set @e=@e+@@rowcount
			end

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'CheckList_Insert.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------		
	-- CheckList
	if (@e = 0) begin try
		Insert into dbo.p_CheckList
		(	 CheckList_ID
			,RowStatus
			,Insert_DTS
			,Update_DTS	  
			,Created_User_ID
			,Modified_User_ID
			,CheckList_Code
			,CheckList_Date		
			,Register_ID			
			,Checkparty_ID			
			,Resp_Employee_ID			
		) values
		(	 @u_CheckList_ID
			,@u_RowStatus
			,@u_Insert_DTS
			,@u_Update_DTS	  
			,@u_Created_User_ID
			,@u_Modified_User_ID
			,@u_CheckList_Code	
			,@u_CheckList_Date		
			,@u_Register_ID			
			,@u_CheckParty_ID			
			,@u_Resp_Employee_ID			
		)
	end try begin catch 
		select Id=50100, Msg=formatmessage(50100, N'CheckList_Insert.Insert', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Final Action 
	-------------
	if (@trancount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback																-- rollback if critical transaction error
		if @xstate = 1 and @trancount = 0 rollback											-- rollback if transaction was created in this procedure
		if @xstate = 1 and @trancount > 0 rollback transaction trn_CheckList_Insert	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	
	if @e > 0 select @o_IsError = 1, @o_Entity_ID = null else select @o_IsError = 0, @o_Entity_ID = try_cast(@u_CheckList_ID as nvarchar(36))
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
