
-- =============================================
-- Author: Ivan Vaskov
-- Create date: 28.09.2018
-- =============================================

CREATE procedure [abd].[DocumentAttribute_Update]	-- not null ->	+
(	 @i_DocumentAttribute_ID			nvarchar(250)	-- sys param	+
	,@i_RowStatus							nvarchar(250)	-- sys param	+
	,@i_AppUser_ID							nvarchar(250)	-- sys param	+
	,@i_DocumentAttribute_Value		nvarchar(250)
	,@i_AttributeType_ID						nvarchar(250)
	,@i_Document_ID					nvarchar(250)
	,@i_DocumentAttribute_Order		nvarchar(250)
	,@o_IsError								bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus						int					= try_cast(ltrim(rtrim(@i_RowStatus					))	as int			)
		,@u_Created_User_ID					uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID				))	as uniqueidentifier)
		,@u_Modified_User_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID				))	as uniqueidentifier)
		,@u_Insert_DTS						datetime2(7)		= try_cast(getdate()									as datetime2(7))
		,@u_Update_DTS						datetime2(7)		= try_cast(getdate()									as datetime2(7))
		,@u_DocumentAttribute_Value			nvarchar(250)		= try_cast(ltrim(rtrim(@i_DocumentAttribute_Value	))	as nvarchar(250))
		,@u_AttributeType_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_AttributeType_ID				))	as uniqueidentifier)
		,@u_Document_ID						uniqueidentifier	= try_cast(ltrim(rtrim(@i_Document_ID				))	as uniqueidentifier)
		,@u_DocumentAttribute_Order			int					= try_cast(ltrim(rtrim(@i_DocumentAttribute_Order	))	as int			)

		,@u_DocumentAttribute_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_DocumentAttribute_ID	)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_DocumentAttr_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus') else if (@u_RowStatus	is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID') else if (@u_Created_User_ID is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID' ,try_cast(@i_AppUser_ID as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_DocumentAttribute_ID is null ) select Id=50101, Msg=formatmessage(50101, 'DocumentAttribute_ID' ) else if (@u_DocumentAttribute_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'DocumentAttribute_ID' ,try_cast(@i_DocumentAttribute_ID as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'DocumentAttribute_ID="'+try_cast(@u_DocumentAttribute_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_DocumentAttribute', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'DocumentAttribute',try_cast(@u_DocumentAttribute_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'DocumentAttribute_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,DocumentAttribute_Value
					,AttributeType_ID
					,Document_ID
					,DocumentAttribute_Order
					from abd.p_DocumentAttribute
					where DocumentAttribute_ID = @u_DocumentAttribute_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					 Row_Status					= @u_RowStatus
					,DocumentAttribute_Value	= @u_DocumentAttribute_Value
					,AttributeType_ID			= @u_AttributeType_ID
					,Document_ID				= @u_Document_ID
					,DocumentAttribute_Order	= @u_DocumentAttribute_Order 
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- DocumentAttribute
		if (@e = 0) begin try
			update abd.p_DocumentAttribute set
				 RowStatus					= @u_RowStatus	 
				,Update_DTS					= @u_Update_DTS	 
				,Modified_User_ID			= @u_Modified_User_ID
				,DocumentAttribute_Value	= @u_DocumentAttribute_Value
				,AttributeType_ID			= @u_AttributeType_ID
				,Document_ID				= @u_Document_ID
				,DocumentAttribute_Order	= @u_DocumentAttribute_Order	  
			where DocumentAttribute_ID		= @u_DocumentAttribute_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'DocumentAttribute_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_DocumentAttr_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchar(max)) where 1=2
end
