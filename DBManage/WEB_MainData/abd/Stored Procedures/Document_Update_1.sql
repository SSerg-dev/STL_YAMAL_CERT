
-- =============================================
-- Author: Ivan Vaskov
-- Create date: 27.09.2018
-- =============================================

CREATE procedure [abd].[Document_Update]	-- not null ->	+
(	 @i_Document_ID	nvarchar(250)	-- sys param	+
	,@i_RowStatus					nvarchar(250)	-- sys param	+
	,@i_AppUser_ID					nvarchar(250)	-- sys param	+
	,@i_DocumentType_ID			nvarchar(250)	-- Doc	param	+
	,@i_Document_Name			nvarchar(250)	-- Doc	Param	+ -- 
	,@i_Document_Title			nvarchar(250)	-- Doc	Param	+ -- 
	,@i_Document_Revision		nvarchar(250)	-- Doc	Param	+
	,@i_Reponsible_Employee_ID	nvarchar(250)	-- Doc	Param	-
	,@i_Document_Number			nvarchar(250)	-- Doc	Param	+ 
	,@i_Document_Date			nvarchar(250)	-- Doc	Param	+
	,@i_Document_Parent_ID		nvarchar(250)	-- Doc	Param	+ 
	,@o_IsError						bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus					int					= try_cast(ltrim(rtrim(@i_RowStatus))				as int			)
		,@u_Created_User_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID))				as uniqueidentifier)
		,@u_Modified_User_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID))				as uniqueidentifier)
		,@u_Insert_DTS					datetime2(7)		= try_cast(getdate()								as datetime2(7))
		,@u_Update_DTS					datetime2(7)		= try_cast(getdate()								as datetime2(7))
		,@u_DocumentType_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_DocumentType_ID))			as uniqueidentifier)
		,@u_Document_Name				nvarchar(250)		= try_cast(ltrim(rtrim(@i_Document_Name))			as nvarchar(250))			
		,@u_Document_Title				nvarchar(250)		= try_cast(ltrim(rtrim(@i_Document_Title))			as nvarchar(250))
		,@u_Document_Revision			nvarchar(50)		= try_cast(ltrim(rtrim(@i_Document_Revision))		as nvarchar(50))
		,@u_Reponsible_Employee_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_Reponsible_Employee_ID))	as uniqueidentifier)
		,@u_Document_Number				nvarchar(250)		= try_cast(ltrim(rtrim(@i_Document_Number	))		as nvarchar(250))	
		,@u_Document_Date				datetime2(7)		= try_cast(ltrim(rtrim(@i_Document_Date))			as datetime2(7))
		,@u_Document_Parent_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_Document_Parent_ID))		as uniqueidentifier)

		,@u_Document_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_Document_ID	)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@TranCount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @TranCount = 0 begin transaction	else save transaction trn_Document_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if(@i_RowStatus is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus') else if (@u_RowStatus	is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus as nvarchar(250)));set @e=@e+@@rowcount
		if(@i_AppUser_ID is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID') else if (@u_Created_User_ID is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID' ,try_cast(@i_AppUser_ID as nvarchar(250)));set @e=@e+@@rowcount
		if(@i_Document_ID is null ) select Id=50101, Msg=formatmessage(50101, 'Document_ID' ) else if (@u_Document_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'Document_ID' ,try_cast(@i_Document_ID as nvarchar(250)));set @e=@e+@@rowcount
		if(@i_DocumentType_ID	is null)select Id=50101,Msg=formatmessage(50101,'Entitytype_ID		')else if(@u_DocumentType_ID	is null)select Id=50108,Msg=formatmessage(50108,'Entitytype_ID		',try_cast(@i_DocumentType_ID	as nvarchar(250)));set @e=@e+@@rowcount
		if(@i_Document_Name		is null)select Id=50101,Msg=formatmessage(50101,'Document_Name		')else if(@u_Document_Name		is null)select Id=50108,Msg=formatmessage(50108,'Document_Name		',try_cast(@i_Document_Name		as nvarchar(250)));set @e=@e+@@rowcount
		if(@i_Document_Title	is null)select Id=50101,Msg=formatmessage(50101,'Document_Title		')else if(@u_Document_Title		is null)select Id=50108,Msg=formatmessage(50108,'Document_Title		',try_cast(@i_Document_Title	as nvarchar(250)));set @e=@e+@@rowcount
		if(@i_Document_Revision	is null)select Id=50101,Msg=formatmessage(50101,'Document_Revision	')else if(@u_Document_Revision	is null)select Id=50108,Msg=formatmessage(50108,'Document_Revision	',try_cast(@i_Document_Revision	as nvarchar(250)));set @e=@e+@@rowcount
		-- nullable 
		if (@i_Reponsible_Employee_ID is not null and @u_Reponsible_Employee_ID is null) select Id=50108,Msg=formatmessage(50108,'Reponsible_Employee_ID',try_cast(@i_Reponsible_Employee_ID as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Document_Number is not null and @u_Document_Number is null) select Id=50108,Msg=formatmessage(50108,'Document_Number',try_cast(@i_Document_Number as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Document_Date is not null and @u_Document_Date is null) select Id=50108,Msg=formatmessage(50108,'Document_Date',try_cast(@i_Document_Date as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Document_Parent_ID is not null and @u_Document_Parent_ID is null) select Id=50108,Msg=formatmessage(50108,'Document_Parent_ID',try_cast(@i_Document_Parent_ID as nvarchar(250)));set @e=@e+@@rowcount
		
		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'Document_ID="'+try_cast(@u_Document_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'abd.p_Document', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Document',try_cast(@u_Document_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'Document_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,Document_Name
					,Document_Title
					,DocumentType_ID
					,Modified_User_ID
					,Document_Revision
					,Document_Parent_ID
					,Reponsible_Employee_ID
					,Document_Number	
					,Document_Date					
					from abd.p_Document
					where Document_ID = @u_Document_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					 RowStatus				 = @u_RowStatus
					,Document_Name				= @u_Document_Name				
					,Document_Title				= @u_Document_Title				
					,DocumentType_ID			= @u_DocumentType_ID			
					,Modified_User_ID			= @u_Modified_User_ID			
					,Document_Revision			= @u_Document_Revision			
					,Document_Parent_ID			= @u_Document_Parent_ID			
					,Reponsible_Employee_ID		= @u_Reponsible_Employee_ID
					,Document_Number			= @u_Document_Number
					,Document_Date				= @u_Document_Date	
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- Document
		if (@e = 0) begin try
			update abd.p_Document set
				 RowStatus	  = @u_RowStatus	 
				,Update_DTS	  = @u_Update_DTS	 
				,Document_Name				= @u_Document_Name				
				,Document_Title				= @u_Document_Title				
				,DocumentType_ID			= @u_DocumentType_ID			
				,Modified_User_ID			= @u_Modified_User_ID			
				,Document_Revision			= @u_Document_Revision			
				,Document_Parent_ID			= @u_Document_Parent_ID			
				,Reponsible_Employee_ID		= @u_Reponsible_Employee_ID	
				,Document_Number			= @u_Document_Number
				,Document_Date				= @u_Document_Date				
			where Document_ID = @u_Document_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'Document_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @TranCount > 0 rollback transaction trn_Document_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchar(max)) where 1=2
end