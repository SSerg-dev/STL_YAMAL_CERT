
-- =============================================
-- Author: Ivan Vaskov
-- Create date: 16.08.2018
-- =============================================

CREATE procedure [dbo].[CheckList_to_Status_Update]		-- not null ->	+
(	 @i_CheckList_to_Status_ID	nvarchar(250)	-- sys param	+
	,@i_RowStatus				nvarchar(250)	-- sys param	+
	,@i_AppUser_ID				nvarchar(250)	-- sys param	+
	,@i_CheckList_ID			nvarchar(250)	-- usr param	+
	,@i_Status_ID				nvarchar(250)	-- usr param	+
	,@i_DTS_Start				nvarchar(250)	-- usr param	+
	,@i_DTS_End					nvarchar(250)	-- usr param	-
	,@o_IsError					bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus				int					= try_cast(ltrim(rtrim(@i_RowStatus				))	as int			)
		,@u_Created_User_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier)
		,@u_Modified_User_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier)
		,@u_Insert_DTS				datetime2(7)		= try_cast(getdate()								as datetime2(7))
		,@u_Update_DTS				datetime2(7)		= try_cast(getdate()								as datetime2(7))
		,@u_CheckList_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_CheckList_ID			))	as nvarchar(255))
		,@u_Status_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_Status_ID				))	as nvarchar(255))
		,@u_DTS_Start				datetime2(7)		= try_cast(ltrim(rtrim(@i_DTS_Start				))	as datetime2(7))
		,@u_DTS_End					datetime2(7)		= try_cast(ltrim(rtrim(@i_DTS_End				))	as datetime2(7))
		,@u_CheckList_To_Status_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_CheckList_to_Status_ID))	as nvarchar(255))

		if (@i_DTS_Start is null) set @u_DTS_Start	= try_cast(getdate() as datetime2(7))	else set @u_DTS_Start	= try_cast(@i_DTS_Start as datetime2(7)) 
		if (@i_DTS_End	 is null) set @u_DTS_End	= null									else set @u_DTS_End		= try_cast(@i_DTS_End	as datetime2(7))
	

	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_CheckList_to_Status_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus		is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'			) else if (@u_RowStatus			is null )	select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus		as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'AppUser_ID'		) else if (@u_Created_User_ID	is null )	select Id=50108, Msg=formatmessage(50108, 'AppUser_ID'	,try_cast(@i_AppUser_ID		as nvarchar(250)))		;set @e=@e+@@rowcount
		if (@i_CheckList_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'CheckList_ID'		) else if (@u_CheckList_ID		is null )	select Id=50108, Msg=formatmessage(50108, 'CheckList_ID',try_cast(@i_CheckList_ID	as nvarchar(36)))	;set @e=@e+@@rowcount
		if (@i_Status_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'Status_ID'			) else if (@u_Status_ID			is null )	select Id=50108, Msg=formatmessage(50108, 'Status_ID'	,try_cast(@i_Status_ID		as nvarchar(36)))	;set @e=@e+@@rowcount
		if (@u_DTS_Start		is null ) select Id=50105, Msg=formatmessage(50105, 'DTS_Start'	,try_cast(@i_DTS_Start	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_DTS_End is not null and @u_DTS_End is null) select Id=50105, Msg=formatmessage(50105, 'DTS_End'	,try_cast(@i_DTS_End	as nvarchar(250)));set @e=@e+@@rowcount
		
		-- data consistency check	
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'CheckList_ID="'+try_cast(@u_CheckList_ID as nvarchar(max))+'"', @Cnt=-1
		exec Get_RowCount 'p_CheckList', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_CheckList', try_cast(@u_CheckList_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'Status_ID="'+try_cast(@u_Status_ID as nvarchar(max))+'"', @Cnt=-1
		exec Get_RowCount 'p_Status', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_Status', try_cast(@u_Status_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'CheckList_to_Status_ID="'+try_cast(@u_CheckList_to_Status_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_CheckList_to_Status', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'CheckList_to_Status',try_cast(@u_CheckList_to_Status_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		select @CntParam = N'CheckList_to_Status_ID="'+try_cast(@u_CheckList_to_Status_ID as nvarchar(max))+N'",'+N'CheckList_ID="'+try_cast(@u_CheckList_ID as nvarchar(max))+N'",'+N'Status_ID="'+try_cast(@u_Status_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_CheckList_to_Status', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_CheckList_to_Status_ID as nvarchar(36)), 'CheckList_to_Status'); set @e=@e+@@rowcount
		
	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'CheckList_to_Status_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,CheckList_Id	
					,Status_ID
					from p_CheckList_to_Status
					where CheckList_to_Status_ID = @u_CheckList_to_Status_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					  RowStatus   = @u_RowStatus
					 ,CheckList_Id  = @u_CheckList_Id
					 ,Status_ID	   = @u_Status_ID					
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- CheckList
		if (@e = 0) begin try
			update dbo.p_CheckList_to_Status set
				 RowStatus			= @u_RowStatus	 
				,Update_DTS			= @u_Update_DTS	 
				,Modified_User_ID	= @u_Modified_User_ID
				,CheckList_Id		= @u_CheckList_Id 
				,Status_ID			= @u_Status_ID
				,DTS_Start			= @u_DTS_Start
				,DTS_End			= @u_DTS_End	
			where CheckList_to_Status_ID = @u_CheckList_To_Status_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'CheckList_to_Status_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_CheckList_to_Status_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id = try_cast(null as int), Msg = try_cast(null as nvarchaR(max)) where 1=2
end
