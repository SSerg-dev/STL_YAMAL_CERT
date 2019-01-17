
create procedure dbo.TestAct_Update	-- not null ->	+
(	 @i_RowStatus							nvarchar(250)	-- sys	param	+
	,@i_AppUser_ID							nvarchar(250)	-- sys	param	+
	,@i_GeneralDocument_Name				nvarchar(250)	-- Doc	Param	+
	,@i_GeneralDocument_Title				nvarchar(250)	-- Doc	Param	+
	,@i_GeneralDocument_RevisionNumber		nvarchar(250)	-- Doc	Param	+
	,@i_GeneralDocument_RevisionDate		nvarchar(250)	-- Doc	Param	+
	,@i_Contragent_ID						nvarchar(250)	-- Doc	Param	+
	,@i_Marka_ID							nvarchar(250)	-- Attr	Param	-
	,@i_TitleObject_ID						nvarchar(250)	-- Attr	Param	+
	,@o_IsError								bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Params
	declare 
		 @u_RowStatus							int					= try_cast(ltrim(rtrim(@i_RowStatus	))						as int			)
		,@u_Created_User_ID						uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID))						as uniqueidentifier)
		,@u_Modified_User_ID					uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID))						as uniqueidentifier)
		,@u_Insert_DTS							datetime2(7)		= try_cast(getdate()										as datetime2(7))
		,@u_Update_DTS							datetime2(7)		= try_cast(getdate()										as datetime2(7))
		,@u_GeneralDocument_Name				nvarchar(250)		= try_cast(ltrim(rtrim(@i_GeneralDocument_Name))			as nvarchar(250))			
		,@u_GeneralDocument_Title				nvarchar(250)		= try_cast(ltrim(rtrim(@i_GeneralDocument_Title))			as nvarchar(250))
		,@u_GeneralDocument_RevisionNumber		nvarchar(100)		= try_cast(ltrim(rtrim(@i_GeneralDocument_RevisionNumber))	as nvarchar(100))
		,@u_GeneralDocument_RevisionDate		datetime2(7)		= try_cast(ltrim(rtrim(@i_GeneralDocument_RevisionDate))	as datetime2(7))
		,@u_Contragent_ID						nvarchar(250)		= try_cast(ltrim(rtrim(@i_Contragent_ID))					as uniqueidentifier)
		,@u_Marka_ID							nvarchar(250)		= try_cast(ltrim(rtrim(@i_Marka_ID))						as uniqueidentifier)
		,@u_TitleObject_ID						nvarchar(250)		= try_cast(ltrim(rtrim(@i_TitleObject_ID))					as uniqueidentifier)


		,@u_GeneralDocument_ID					uniqueidentifier	= newid()
		,@u_Attributte_TitleObject_ID			uniqueidentifier	= newid()
		,@u_Attribute_Marka_ID					uniqueidentifier	= newid()

		,@u_Parent_Id							uniqueidentifier  



	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_TestAct_Insert
	-------------
	------------- Error Handling
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus		is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'	) else if (@u_RowStatus		is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'		) else if (@u_Created_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'		,try_cast(@i_AppUser_ID		as nvarchar(250)));set @e=@e+@@rowcount


		-- data consistency check	
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		-- template prepeare 
		select @u_Parent_Id = d.GeneralDocument_ID from abd.p_GeneralDocument d join abd.p_EntityType det on d.EntityType_ID = det.EntityType_ID and det.EntityType_Code = 'Act1' and d.Row_Status = 300
		if @@rowcount > 1 select Id=50101, Msg=formatmessage(50101, 'User_ID')

		-- Template prepeare and check Template 
		select @u_Parent_Id = d.GeneralDocument_ID from abd.p_GeneralDocument d join abd.p_EntityType det on d.EntityType_ID = det.EntityType_ID and det.EntityType_Code = 'Act1' and d.Row_Status = 300
		if @@rowcount > 1 select Id=50127, Msg=formatmessage(50127, 'Act1') set @e=@e+@@rowcount

		select @u_Attributte_TitleObject_ID = a.GeneralDocumentAttribute_ID from abd.p_GeneralDocumentAttribute a join abd.p_EntityType aet on a.EntityType_ID = aet.EntityType_ID and aet.EntityType_Code = 'Marka' and a.Row_Status = 302
		if @@rowcount > 1 select Id=50127, Msg=formatmessage(50128, 'Act1', 'TitleObject') set @e=@e+@@rowcount

		select @u_Attribute_Marka_ID = a.GeneralDocumentAttribute_ID from abd.p_GeneralDocumentAttribute a join abd.p_EntityType aet on a.EntityType_ID = aet.EntityType_ID and aet.EntityType_Code = 'Marka' and a.Row_Status = 302
		if @@rowcount > 1 select Id=50127, Msg=formatmessage(50128, 'Act1', 'Marka') set @e=@e+@@rowcount

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'TestAct_Insert.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------	
	

	-------------
	------------- Final Action 
	-------------
	if (@trancount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback																-- rollback if critical transaction error
		if @xstate = 1 and @trancount = 0 rollback											-- rollback if transaction was created in this procedure
		if @xstate = 1 and @trancount > 0 rollback transaction trn_TestAct_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
