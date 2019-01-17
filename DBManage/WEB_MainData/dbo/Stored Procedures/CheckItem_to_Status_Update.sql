-- =============================================
-- Author: ASmirnov
-- Create date: 16.09.2018
-- =============================================

Create procedure [dbo].[CheckItem_to_Status_Update]	-- not null ->	+
(	 @i_CheckItem_to_Status_ID	nvarchar(250)	-- sys param	+
	,@i_RowStatus				nvarchar(250)	-- sys param	+
	,@i_AppUser_ID				nvarchar(250)	-- sys param	+
	,@i_CheckItem_ID			nvarchar(250)	-- usr param	+
	,@i_Status_ID				nvarchar(250)	-- usr param	+
	,@i_Parent_ID				nvarchar(250)	-- usr param	-
	,@i_DTS_Start				nvarchar(250)	-- usr param	-
	,@i_DTS_End					nvarchar(250)	-- usr param	-
	,@o_IsError					bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus					int					= try_cast(ltrim(rtrim(@i_RowStatus				))	as int				)
		,@u_Created_User_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier	)
		,@u_Modified_User_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier	)
		,@u_Insert_DTS					datetime2(7)		= try_cast(getdate()								as datetime2(7))
		,@u_Update_DTS					datetime2(7)		= try_cast(getdate()								as datetime2(7)		)
		,@u_CheckItem_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_CheckItem_ID			))	as uniqueidentifier	)
		,@u_Status_ID					uniqueidentifier	= try_cast(ltrim(rtrim(@i_Status_ID				))	as uniqueidentifier	)
		,@u_CheckItem_To_Status_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_CheckItem_to_Status_ID	))	as uniqueidentifier	)
		,@u_Parent_ID					uniqueidentifier	= try_cast(ltrim(rtrim(@i_Parent_ID				))	as uniqueidentifier	)
		,@u_DTS_Start					datetime2(7)
		,@u_DTS_End						datetime2(7)	

	if (@i_DTS_End	 is null) set @u_DTS_End	= null	else set @u_DTS_End		= try_cast(@i_DTS_End	as datetime2(7))
	
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_CheckItem_to_Status_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus		is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'			) else if (@u_RowStatus			is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'		,try_cast(@i_RowStatus		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'AppUser_ID'		) else if (@u_Created_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'AppUser_ID'	,try_cast(@i_AppUser_ID		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_CheckItem_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'CheckItem_ID'		) else if (@u_CheckItem_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'CheckItem_ID'	,try_cast(@i_CheckItem_ID	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Status_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'Status_ID'			) else if (@u_Status_ID			is null ) select Id=50108, Msg=formatmessage(50108, 'Status_ID'		,try_cast(@i_Status_ID		as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here ==
		if (@i_DTS_Start		is null ) select Id=50101, Msg=formatmessage(50101, 'DTS_Start'			) else if (@u_DTS_Start			is null ) select Id=50105, Msg=formatmessage(50105, 'DTS_Start'		,try_cast(@i_DTS_Start	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_DTS_End		is not null and @u_DTS_End		is null) select Id=50105, Msg=formatmessage(50105, 'DTS_End'	,try_cast(@i_DTS_End	as nvarchar(250)));set @e=@e+@@rowcount	
		if (@i_Parent_ID	is not null and @u_Parent_ID	is null) select Id=50108, Msg=formatmessage(50108, 'Parent_ID'	,try_cast(@i_Parent_ID	as nvarchar(36)));set @e=@e+@@rowcount

		-- data consistency check	
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'CheckItem_ID="'+try_cast(@u_CheckItem_ID as nvarchar(max))+'"', @Cnt=-1
		exec Get_RowCount 'p_CheckItem', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122,'p_CheckItem', try_cast(@u_CheckItem_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'Status_ID="'+try_cast(@u_Status_ID as nvarchar(max))+'"', @Cnt=-1
		exec Get_RowCount 'p_Status', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122,'p_Status', try_cast(@u_Status_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'CheckItem_to_Status_ID="'+try_cast(@u_CheckItem_to_Status_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_CheckItem_to_Status', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122,'CheckItem_to_Status',try_cast(@u_CheckItem_to_Status_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		--== place your params here =

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'CheckItem_to_Status_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,CheckItem_Id
					,Status_ID
					,Parent_ID
					,DTS_Start
					,DTS_End
					from p_CheckItem_to_Status
					where CheckItem_to_Status_ID = @u_CheckItem_to_Status_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					  RowStatus		= @u_RowStatus
					 ,CheckItem_Id	= @u_CheckItem_Id
					 ,Status_ID		= @u_Status_ID	
					 ,Parent_ID		= @u_Parent_ID
					 ,DTS_Start		= @u_DTS_Start
					 ,DTS_End		= @u_DTS_End
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- CheckItem
		if (@e = 0) begin try
			update dbo.p_CheckItem_to_Status set
				 RowStatus			= @u_RowStatus	 
				,Update_DTS			= @u_Update_DTS	 
				,Modified_User_ID	= @u_Modified_User_ID
				,CheckItem_Id		= @u_CheckItem_Id 
				,Status_ID			= @u_Status_ID	
				,Parent_ID			= @u_Parent_ID
				,DTS_Start			= @u_DTS_Start
				,DTS_End			= @u_DTS_End 
			where CheckItem_to_Status_ID = @u_CheckItem_To_Status_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'CheckItem_to_Status_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_CheckItem_to_Status_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id = try_cast(null as int), Msg = try_cast(null as nvarchaR(max)) where 1=2
end