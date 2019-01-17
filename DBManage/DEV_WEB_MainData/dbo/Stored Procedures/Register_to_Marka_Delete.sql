﻿-- =============================================
-- Author: ASmirnov
-- Create date: 11.09.2018
-- =============================================

CREATE procedure [dbo].[Register_to_Marka_Delete]	-- not null ->	+
(	 @i_AppUser_ID					nvarchar(250)		-- sys param	+
	,@i_Register_to_Marka_ID		nvarchar(250)		-- usr param	+
	,@o_IsError						bit					output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_Modified_User_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier)
		,@u_Update_DTS				datetime2(7)		= try_cast(getdate()								as datetime2(7))
		,@u_Register_to_Marka_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_Register_to_Marka_ID	))	as uniqueidentifier	)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N'', @RowStatus nvarchar(10) = '200'
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_Reg_to_Marka_Delete
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_Register_to_Marka_ID	is null ) select Id=50101, Msg=formatmessage(50101, 'Register_to_Marka_ID'	) else if (@u_Register_to_Marka_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'Register_to_Marka_ID'	,try_cast(@i_Register_to_Marka_ID	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'AppUser_ID'			) else if (@u_Modified_User_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'AppUser_ID'			,try_cast(@i_AppUser_ID				as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Modified_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'Register_to_Marka_ID="'+try_cast(@u_Register_to_Marka_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Register_to_Marka', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Register_to_Marka',try_cast(@u_Register_to_Marka_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		--== place your params here =

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'Register_to_Marka.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------
	-- Register
	if (@e = 0) begin try
	update dbo.p_Register_To_Marka set 
			RowStatus = 200, 
			Update_DTS = @u_Update_DTS, 
			Modified_User_ID  = @u_Modified_User_ID
			where Register_To_Marka_ID = @u_Register_To_Marka_ID
	end try begin catch 
		select Id=50100, Msg=formatmessage(50100, N'Register_to_Marka.Delete', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_Reg_to_Marka_Delete		-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id = try_cast(null as int), Msg = try_cast(null as nvarchaR(max)) where 1=2
end
