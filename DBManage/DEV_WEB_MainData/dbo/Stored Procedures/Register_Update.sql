-- =============================================
-- Author: Ivan Vaskov
-- Create date: 16.08.2018
-- =============================================
CREATE procedure [dbo].[Register_Update]	-- not null ->	+
(	 @i_Register_ID			nvarchar(250)	-- sys param	+
	,@i_RowStatus			nvarchar(250)	-- sys param	+
	,@i_AppUser_ID			nvarchar(250)	-- sys param	+
	,@i_Register_Code		nvarchar(250)	-- usr param	+
	,@i_Register_Date		nvarchar(250)	-- usr param	+
	,@i_Current_Iteration	nvarchar(250)	-- usr param	+
	,@i_Customer_ID			nvarchar(250)	-- usr param	+
	,@i_Contractor_ID		nvarchar(250)	-- usr param	+
	,@i_SubContractor_ID	nvarchar(250)	-- usr param	+
	,@i_Resp_Employee_ID	nvarchar(250)	-- usr param	+
	,@i_WorkPackage_ID		nvarchar(250)	-- usr param	-
	,@i_Comment				nvarchar(250)	-- usr param	-
	,@o_IsError				bit				output
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
		,@u_Insert_DTS			datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Update_DTS			datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Register_Code		nvarchar(255)		= try_cast(ltrim(rtrim(@i_Register_Code))	as nvarchar(255))
		,@u_Register_Date		datetime2(7)		= try_cast(ltrim(rtrim(@i_Register_Date		))	as datetime2(7))
		,@u_Current_Iteration	int					= try_cast(ltrim(rtrim(@i_Current_Iteration	))	as int			)
		,@u_Customer_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_Customer_ID		))	as uniqueidentifier)
		,@u_Contractor_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_Contractor_ID		))	as uniqueidentifier)
		,@u_SubContractor_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_SubContractor_ID	))	as uniqueidentifier)
		,@u_Resp_Employee_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_Resp_Employee_ID	))	as uniqueidentifier)
		,@u_WorkPackage_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_WorkPackage_ID	))	as uniqueidentifier)
		,@u_Comment				nvarchar(255)		= try_cast(ltrim(rtrim(@i_Comment			))	as nvarchar(255))
		,@u_Register_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_Register_ID	)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_Register_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus			is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'			) else if (@u_RowStatus			is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'			,try_cast(@i_RowStatus			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'			) else if (@u_Created_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'			,try_cast(@i_AppUser_ID			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Register_Code		is null ) select Id=50101, Msg=formatmessage(50101, 'Register_Code'		) else if (@u_Register_Code		is null ) select Id=50103, Msg=formatmessage(50103, 'Register_Code'		,try_cast(@i_Register_Code		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Register_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'Register_ID'		) else if (@u_Register_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'Register_ID'		,try_cast(@i_Register_ID		as nvarchar(250)));set @e=@e+@@rowcount

		if (@i_Register_Date		is null ) select Id=50101, Msg=formatmessage(50101, 'Register_Date'		) else if (@u_Register_Date		is null ) select Id=50106, Msg=formatmessage(50106, 'Register_Date'		,try_cast(@i_Register_Date		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Current_Iteration	is null ) select Id=50101, Msg=formatmessage(50101, 'Current_Iteration'	) else if (@u_Current_Iteration	is null ) select Id=50106, Msg=formatmessage(50106, 'Current_Iteration'	,try_cast(@i_Current_Iteration	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Customer_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'Customer_ID'		) else if (@u_Customer_ID		is null ) select Id=50106, Msg=formatmessage(50106, 'Customer_ID'		,try_cast(@i_Customer_ID		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Contractor_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'Contractor_ID'		) else if (@u_Contractor_ID		is null ) select Id=50106, Msg=formatmessage(50106, 'Contractor_ID'		,try_cast(@i_Contractor_ID		as nvarchar(250)));set @e=@e+@@rowcount
		
		if (@i_Resp_Employee_ID	is null ) select Id=50101, Msg=formatmessage(50101, 'Resp_Employee_ID'	) else if (@u_Resp_Employee_ID	is null ) select Id=50103, Msg=formatmessage(50103, 'Resp_Employee_ID'	,try_cast(@i_Resp_Employee_ID	as nvarchar(250)));set @e=@e+@@rowcount
		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'Register_ID="'+try_cast(@u_Register_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Register', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Register',try_cast(@u_Register_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		select @CntParam = N'Register_ID="'+try_cast(@u_Register_ID as nvarchar(max))+N'",'+N'Register_Code="'+try_cast(@u_Register_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Register', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_Register_Code as nvarchar(36)), 'Register'); set @e=@e+@@rowcount

		select @CntParam = N'Contragent_ID="'+try_cast(@u_Customer_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Contragent', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_Contragent', try_cast(@u_Customer_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'Contragent_ID="'+try_cast(@u_Contractor_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Contragent', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_Contragent', try_cast(@u_Contractor_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'Contragent_ID="'+try_cast(@u_SubContractor_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Contragent', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_Contragent', try_cast(@u_SubContractor_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'Employee_ID="'+try_cast(@u_Resp_Employee_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Employee', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_Employee', try_cast(@u_Resp_Employee_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'WorkPackage_ID="'+try_cast(@u_WorkPackage_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_WorkPackage', @CntParam, @Cnt out; if (@Cnt<=0) and (@i_WorkPackage_ID is not null) select Id=50122, Msg=formatmessage(50122, 'p_WorkPackage_ID', try_cast(@u_WorkPackage_ID as NVARCHAR(36))); set @e=@e+@@rowcount


	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'Register_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,Register_Code
					,Register_Date
					,Current_Iteration
					,Customer_ID
					,Contractor_ID
					,SubContractor_ID
					,Resp_Employee_ID
					,WorkPackage_ID
					,Comment
					from dbo.p_Register
					where Register_ID = @u_Register_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					 RowStatus			= @u_RowStatus
					,Register_Codee		= @u_Register_Code
					,Register_Date		= @u_Register_Date		
					,Current_Iteration	= @u_Current_Iteration	
					,Customer_ID		= @u_Customer_ID		
					,Contractor_ID		= @u_Contractor_ID
					,SubContractor_ID	= @u_SubContractor_ID	
					,Resp_Employee_ID	= @u_Resp_Employee_ID	
					,WorkPackage_ID		= @u_WorkPackage_ID		
					,Comment			= @u_Comment			
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- Register
		if (@e = 0) begin try
			update dbo.p_Register set
				 RowStatus			= @u_RowStatus	 
				,Update_DTS			= @u_Update_DTS	 
				,Modified_User_ID	= @u_Modified_User_ID
				,Register_Code		= @u_Register_Code
				,Register_Date		= @u_Register_Date		
				,Current_Iteration	= @u_Current_Iteration	
				,Customer_ID		= @u_Customer_ID		
				,Contractor_ID		= @u_Contractor_ID	
				,SubContractor_ID	= @u_SubContractor_ID		
				,Resp_Employee_ID	= @u_Resp_Employee_ID	
				,WorkPackage_ID		= @u_WorkPackage_ID		
				,Comment			= @u_Comment				
			where Register_ID = @u_Register_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'Register_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_Register_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
