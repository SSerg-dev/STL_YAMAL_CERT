

-- =============================================
-- Author: Ivan Vaskov
-- Create date: 16.08.2018
-- Modification: RAlizade 2018-09-09 (input parameters, refactoring)
-- =============================================

CREATE procedure [dbo].[Register_to_Document_Update]	-- not null ->	+
(	 @i_Register_to_Document_ID	nvarchar(250)	-- sys param	+
	,@i_RowStatus				nvarchar(250)	-- sys param	+
	,@i_AppUser_ID				nvarchar(250)	-- sys param	+
	,@i_Register_ID				nvarchar(250)	-- usr param	+
	,@i_Document_ID				nvarchar(250)	-- usr param	+
	,@i_Iteration				nvarchar(250)	-- usr param	+
	,@i_NumberInRegister		nvarchar(250)	-- usr param	-
	,@i_SheetFolderNumber		nvarchar(250)	-- usr param	-
	,@i_Comment					nvarchar(250)	-- usr param	-
	,@o_IsError					bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus					int					= try_cast(ltrim(rtrim(@i_RowStatus					))	as int)
		,@u_Created_User_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID				))	as uniqueidentifier)
		,@u_Modified_User_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID				))	as uniqueidentifier)
		,@u_Insert_DTS					datetime2(7)		= try_cast(getdate()									as datetime2(7))
		,@u_Update_DTS					datetime2(7)		= try_cast(getdate()									as datetime2(7))
		,@u_Register_ID					uniqueidentifier	= try_cast(ltrim(rtrim(@i_Register_ID				))	as nvarchar(255))
		,@u_Document_ID					uniqueidentifier	= try_cast(ltrim(rtrim(@i_Document_ID				))	as nvarchar(255))
		,@u_Iteration					int					= try_cast(ltrim(rtrim(@i_Iteration					))	as int)
		,@u_NumberInRegister			int					= try_cast(ltrim(rtrim(@i_NumberInRegister			))	as int)
		,@u_SheetFolderNumber			int					= try_cast(ltrim(rtrim(@i_SheetFolderNumber			))	as int)
		,@u_Comment						nvarchar(250)		= try_cast(ltrim(rtrim(@i_Comment					))	as nvarchar(255))				
		,@u_Register_to_Document_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_Register_to_Document_ID	))	as nvarchar(255))

	declare @e int = 0, @Cnt int = 0, @TranCount int = @@TranCount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @TranCount = 0 begin transaction	else save transaction trn_Register_to_Document_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus		is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'			) else if (@u_RowStatus			is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'		,try_cast(@i_RowStatus		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'AppUser_ID'		) else if (@u_Created_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'AppUser_ID'	,try_cast(@i_AppUser_ID		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Register_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'Register_ID'		) else if (@u_Register_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'Register_ID'	,try_cast(@i_Register_ID	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Document_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'Document_ID'		) else if (@u_Document_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'Document_ID'	,try_cast(@i_Document_ID	as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here ==

		-- data consistency check	
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'Register_ID="'+try_cast(@u_Register_ID as nvarchar(max))+'"', @Cnt=-1
		exec Get_RowCount 'p_Register', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_Register', try_cast(@u_Register_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'Document_ID="'+try_cast(@u_Document_ID as nvarchar(max))+'"', @Cnt=-1
		exec Get_RowCount 'p_Document', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_Document', try_cast(@u_Document_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'Register_to_Document_ID="'+try_cast(@u_Register_to_Document_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Register_to_Document', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Register_to_Document',try_cast(@u_Register_to_Document_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		select @CntParam = N'Register_to_Document_ID="'+try_cast(@u_Register_to_Document_ID as nvarchar(max))+N'",'+N'Register_ID="'+try_cast(@u_Register_ID as nvarchar(max))+N'",'+N'Document_ID="'+try_cast(@u_Document_ID as nvarchar(max))+N'",Iteration="'+try_cast(@u_Iteration as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Register_to_Document', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_Register_to_Document_ID as nvarchar(36)), 'Register_to_Document'); set @e=@e+@@rowcount

		--== place your params here =

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'Register_to_Document_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,Register_ID
					,Document_ID	
					,Iteration				
					,NumberInRegister		
					,SheetFolderNumber		
					,Comment					
					from p_Register_to_Document
					where Register_to_Document_ID = @u_Register_to_Document_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					 RowStatus			= @u_RowStatus
					,Register_ID		= @u_Register_ID
					,Document_ID		= @u_Document_ID	
					,Iteration			= @u_Iteration				
					,NumberInRegister	= @u_NumberInRegister		
					,SheetFolderNumber	= @u_SheetFolderNumber		
					,Comment			= @u_Comment					
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- Register
		if (@e = 0) begin try
			update dbo.p_Register_to_Document set
				 RowStatus			= @u_RowStatus	 
				,Update_DTS			= @u_Update_DTS	 
				,Modified_User_ID	= @u_Modified_User_ID
				,Register_ID		= @u_Register_ID 
				,Document_ID		= @u_Document_ID	
				,Iteration			= @u_Iteration				
				,NumberInRegister	= @u_NumberInRegister		
				,SheetFolderNumber	= @u_SheetFolderNumber		
				,Comment			= @u_Comment					 
			where Register_to_Document_ID = @u_Register_to_Document_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'Register_to_Document_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
		end catch
	end
	-------------
	------------- Final Action 
	-------------
	if (@TranCount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback																-- rollback if critical transaction error
		if @xstate = 1 and @TranCount = 0 rollback											-- rollback if transaction was created in this procedure
		if @xstate = 1 and @TranCount > 0 rollback transaction trn_Register_to_Document_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id = try_cast(null as int), Msg = try_cast(null as nvarchaR(max)) where 1=2
end
