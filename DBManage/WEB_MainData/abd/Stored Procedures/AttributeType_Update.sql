
-- =============================================
-- Author: Ivan Vaskov
-- Create date: 17.10.2018
-- =============================================

create procedure abd.AttributeType_Update	-- not null ->	+
(	 @i_AttributeType_ID			nvarchar(250)	-- sys param	+
	,@i_RowStatus					nvarchar(250)	-- sys param	+
	,@i_AppUser_ID					nvarchar(250)	-- sys param	+
	,@i_AttributeType_Code			nvarchar(250)	-- usr param	+
	,@i_AttributeType_Name			nvarchar(250)
	,@i_AttributeType_Group			nvarchar(250)
	,@i_Attribute_DataType			nvarchar(250)
	,@i_Attribute_Table				nvarchar(250)
	,@i_Attribute_Format			nvarchar(250)
	,@i_Description_Rus				nvarchar(250)
	,@i_Description_Eng				nvarchar(250)
	,@o_IsError						bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus					int					= try_cast(ltrim(rtrim(@i_RowStatus					))	as int			)
		,@u_Created_User_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID				))	as uniqueidentifier)
		,@u_Modified_User_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID				))	as uniqueidentifier)
		,@u_Insert_DTS					datetime2(7)		= try_cast(getdate()									as datetime2(7))
		,@u_Update_DTS					datetime2(7)		= try_cast(getdate()									as datetime2(7))
		,@u_AttributeType_Code			nvarchar(255)		= try_cast(ltrim(rtrim(@i_AttributeType_Code))			as nvarchar(255))
		,@u_AttributeType_Name			nvarchar(250)		= try_cast(ltrim(rtrim(@i_AttributeType_Name		))	as nvarchar(250))
		,@u_AttributeType_Group			nvarchar(50)		= try_cast(ltrim(rtrim(@i_AttributeType_Group		))	as nvarchar(50))
		,@u_Attribute_DataType			nvarchar(250)		= try_cast(ltrim(rtrim(@i_Attribute_DataType		))	as nvarchar(250))
		,@u_Attribute_Table				nvarchar(250)		= try_cast(ltrim(rtrim(@i_Attribute_Table			))	as nvarchar(250))
		,@u_Attribute_Format			nvarchar(250)		= try_cast(ltrim(rtrim(@i_Attribute_Format			))	as nvarchar(250))
		,@u_Description_Rus				nvarchar(250)		= try_cast(ltrim(rtrim(@i_Description_Rus			))	as nvarchar(250))
		,@u_Description_Eng				nvarchar(250)		= try_cast(ltrim(rtrim(@i_Description_Eng			))	as nvarchar(250))

		,@u_AttributeType_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AttributeType_ID			)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@TranCount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @TranCount = 0 begin transaction	else save transaction trn_AttributeType_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus					is null)select Id=50101,Msg=formatmessage(50101,'RowStatus					')else if(@u_RowStatus					is null)select Id=50106,Msg=formatmessage(50106,'RowStatus					',try_cast(@i_RowStatus						as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID					is null)select Id=50101,Msg=formatmessage(50101,'User_ID					')else if(@u_Created_User_ID			is null)select Id=50108,Msg=formatmessage(50108,'User_ID					',try_cast(@i_AppUser_ID					as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AttributeType_ID				is null)select Id=50101,Msg=formatmessage(50101,'AttributeType_ID			')else if(@u_AttributeType_ID			is null)select Id=50108,Msg=formatmessage(50108,'AttributeType_ID			',try_cast(@i_AttributeType_ID				as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AttributeType_Code			is null)select Id=50101,Msg=formatmessage(50101,'AttributeType_Code			')else if(@u_AttributeType_Code			is null)select Id=50103,Msg=formatmessage(50103,'AttributeType_Code			',try_cast(@i_AttributeType_Code			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AttributeType_Name			is null)select Id=50101,Msg=formatmessage(50101,'AttributeType_Name			')else if(@u_AttributeType_Name			is null)select Id=50103,Msg=formatmessage(50103,'AttributeType_Name			',try_cast(@i_AttributeType_Name			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AttributeType_Group			is null)select Id=50101,Msg=formatmessage(50101,'AttributeType_Group		')else if(@u_AttributeType_Group		is null)select Id=50103,Msg=formatmessage(50103,'AttributeType_Group		',try_cast(@i_AttributeType_Group			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Attribute_DataType			is null)select Id=50101,Msg=formatmessage(50101,'Attribute_DataType			')else if(@u_Attribute_DataType			is null)select Id=50103,Msg=formatmessage(50103,'Attribute_DataType			',try_cast(@i_Attribute_DataType			as nvarchar(250)));set @e=@e+@@rowcount
		-- Nullable Check
		if (@i_Attribute_Table	is not null and @u_Attribute_Table	 is null) select Id=50103,Msg=formatmessage(50103,'Attribute_Table	',try_cast(@i_Attribute_Table	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Attribute_Format	is not null and @u_Attribute_Format	 is null) select Id=50103,Msg=formatmessage(50103,'Attribute_Format	',try_cast(@i_Attribute_Format	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Description_Rus	is not null and @u_Description_Rus	 is null) select Id=50103,Msg=formatmessage(50103,'Attribute_Format	',try_cast(@i_Description_Rus	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Description_Eng	is not null and @u_Description_Eng	 is null) select Id=50103,Msg=formatmessage(50103,'Attribute_Format	',try_cast(@i_Description_Eng	as nvarchar(250)));set @e=@e+@@rowcount

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt <=0) 
			select Id=50122,Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt <=0) 
			select Id=50122,Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'AttributeType_ID="'+try_cast(@u_AttributeType_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AttributeType', @CntParam, @Cnt out; if (@Cnt <=0) 
			select Id=50122,Msg=formatmessage(50122,'AttributeType',try_cast(@u_AttributeType_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		select @CntParam = N'AttributeType_ID="'+try_cast(@u_AttributeType_ID as nvarchar(max))+N'",'+N'AttributeType_Code="'+try_cast(@u_AttributeType_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AttributeType', @CntParam, @Cnt out; if (@Cnt>0) 
			select Id=50123,Msg=formatmessage(50123, try_cast(@u_AttributeType_Code as nvarchar(250)), 'AttributeType'); set @e=@e+@@rowcount

	end try	begin catch	
		select Id=50100,Msg=formatmessage(50100, N'AttributeType_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,AttributeType_Code
					,AttributeType_Name			
					,AttributeType_Group			
					,Attribute_DataType			
					,Attribute_Table				
					,Attribute_Format
					,Description_Rus
					,Description_Eng							
					from abd.p_AttributeType
					where AttributeType_ID = @u_AttributeType_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					 RowStatus					= @u_RowStatus
					,AttributeType_Code			= @u_AttributeType_Code
					,AttributeType_Name			= @u_AttributeType_Name			
					,AttributeType_Group		= @u_AttributeType_Group			
					,Attribute_DataType			= @u_Attribute_DataType			
					,Attribute_Table			= @u_Attribute_Table				
					,Attribute_Format			= @u_Attribute_Format		
					,Description_Rus			= @u_Description_Rus
					,Description_Eng			= @u_Description_Eng							

				) x				  
			) b	on a.x = b.x
		)
	begin
		-- AttributeType
		if (@e = 0) begin try
			update abd.p_AttributeType set
				 RowStatus					= @u_RowStatus	 
				,Update_DTS					= @u_Update_DTS	 
				,Modified_User_ID			= @u_Modified_User_ID
				,AttributeType_Code			= @u_AttributeType_Code
				,AttributeType_Name			= @u_AttributeType_Name			
				,AttributeType_Group		= @u_AttributeType_Group			
				,Attribute_DataType			= @u_Attribute_DataType			
				,Attribute_Table			= @u_Attribute_Table				
				,Attribute_Format			= @u_Attribute_Format	
				,Description_Rus			= @u_Description_Rus
				,Description_Eng			= @u_Description_Eng					
			where AttributeType_ID = @u_AttributeType_ID
		end try begin catch 
			select Id=50100,Msg=formatmessage(50100, N'AttributeType_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
		end catch
	end
	-------------
	------------- Final Action 
	-------------
	if (@TranCount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback															-- rollback if critical transaction error
		if @xstate = 1 and @TranCount = 0 rollback										-- rollback if transaction was created in this procedure
		if @xstate = 1 and @TranCount > 0 rollback transaction trn_AttributeType_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int),Msg=try_cast(null as nvarchar(max)) where 1=2
end