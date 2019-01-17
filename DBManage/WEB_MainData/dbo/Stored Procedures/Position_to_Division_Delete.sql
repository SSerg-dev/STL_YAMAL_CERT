
-- =============================================
-- Author: RAlizade
-- Create date: 2018-09-16
-- =============================================

create procedure dbo.Position_to_Division_Delete	-- not null ->	+
(	 @i_AppUser_ID				nvarchar(250)		-- sys param	+
	,@i_Position_to_Division_ID	nvarchar(250)		-- usr param	+
	,@o_IsError					bit							output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_Modified_User_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID				))	as uniqueidentifier)
		,@u_Update_DTS				datetime2(7)		= try_cast(getdate()									as datetime2(7))
		,@u_Position_to_Division_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_Position_to_Division_ID	))	as uniqueidentifier	)

	declare @e int = 0, @Cnt int = 0, @TranCount int = @@TranCount, @CntParam nvarchar(max) = N'', @RowStatus nvarchar(10) = '200'
	-- Nested Tran
	if @TranCount = 0 begin transaction	else save transaction trn_Position_to_Division_Delete
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_Position_to_Division_ID	is null ) select Id=50101, Msg=formatmessage(50101, 'Position_to_Division_ID'	) else if (@u_Position_to_Division_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'Position_to_Division_ID'	,try_cast(@i_Position_to_Division_ID	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID				is null ) select Id=50101, Msg=formatmessage(50101, 'AppUser_ID'				) else if (@u_Modified_User_ID			is null ) select Id=50108, Msg=formatmessage(50108, 'AppUser_ID'				,try_cast(@i_AppUser_ID					as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Modified_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'Position_to_Division_ID="'+try_cast(@u_Position_to_Division_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Position_to_Division', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Position_to_Division',try_cast(@u_Position_to_Division_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		--== place your params here =

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'Position_to_Division.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------
	-- Position
	if (@e = 0) begin try
		update dbo.p_Position_to_Division set 
			RowStatus = 200, 
			Update_DTS = @u_Update_DTS, 
			Modified_User_ID  = @u_Modified_User_ID
			where Position_to_Division_ID = @u_Position_to_Division_ID
	end try begin catch 
		select Id=50100, Msg=formatmessage(50100, N'Position_to_Division.Delete', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Final Action 
	-------------
	if (@TranCount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback																	-- rollback if critical transaction error
		if @xstate = 1 and @TranCount = 0 rollback												-- rollback if transaction was created in this procedure
		if @xstate = 1 and @TranCount > 0 rollback transaction trn_Position_to_Division_Delete	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id = try_cast(null as int), Msg = try_cast(null as nvarchaR(max)) where 1=2
end