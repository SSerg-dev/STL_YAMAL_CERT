
-- =============================================
-- Author: Ivan Vaskov
-- Create date: 16.08.2018
-- =============================================

CREATE procedure [dbo].[Person_Delete]	-- not null ->	+
(	 @i_AppUser_ID									nvarchar(250)		-- sys param	+
	,@i_Person_ID	nvarchar(250)		-- usr param	+
	,@o_IsError					bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_Modified_User_ID						uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Update_DTS								datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Person_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_Person_ID	))	as uniqueidentifier	)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@TranCount, @CntParam nvarchar(max) = N'', @RowStatus int = 200
	-- Nested Tran
	if @TranCount = 0 begin transaction	else save transaction trn_Person_Delete
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_Person_ID	is null ) select Id=50101, Msg=formatmessage(50101, 'Person_ID'	) else if (@u_Person_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'Person_ID'	,try_cast(@i_Person_ID	as nvarchar(36)));set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'		) else if (@u_Modified_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'		,try_cast(@i_AppUser_ID		as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Modified_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount


		select @CntParam = N'RowStatus_ID="'+try_cast(@RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'Person_ID="'+try_cast(@u_Person_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Person', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Person',try_cast(@u_Person_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		--== place your params here =

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'Person.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------
	-- Person
	if (@e = 0) begin try
		update dbo.p_Person set RowStatus = @RowStatus, Update_DTS = @u_Update_DTS,Modified_User_ID  = @u_Modified_User_ID where Person_ID = @u_Person_ID
	end try begin catch 
		select Id=50100, Msg=formatmessage(50100, N'Person.Delete', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Final Action 
	-------------
	if (@TranCount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback																-- rollback if critical transaction error
		if @xstate = 1 and @TranCount = 0 rollback											-- rollback if transaction was created in this procedure
		if @xstate = 1 and @TranCount > 0 rollback transaction trn_Person_Delete	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
