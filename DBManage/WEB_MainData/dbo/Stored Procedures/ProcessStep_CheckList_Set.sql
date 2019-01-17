
-- =============================================
-- Author: ASmirnov	
-- Create date: 29.08.2018
-- =============================================
CREATE procedure [dbo].[ProcessStep_CheckList_Set]	-- not null ->	+
(	 @i_Register_ID			nvarchar(250)			-- sys param	+
	,@i_CheckType_ID		nvarchar(250)			-- sys param	+
	,@i_CheckList_Status	nvarchar(250)			-- sys param	-
	,@i_Way					nvarchar(250)			-- sys param	+
	,@i_RowStatus			nvarchar(250)			-- sys param	+
	,@i_AppUser_ID			nvarchar(250)			-- sys param	+
	,@o_IsError				bit				output
) as begin

-------------
------------- Prepearing 
-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus			int					= try_cast(ltrim(rtrim(@i_RowStatus			))	as int			)
		,@u_AppUser_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Insert_DTS			datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Update_DTS			datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Register_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_Register_ID		)) as uniqueidentifier)
		,@u_CheckType_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_CheckType_ID		)) as uniqueidentifier)
		,@u_CheckList_Status    uniqueidentifier	= try_cast(ltrim(rtrim(@i_CheckList_Status	)) as uniqueidentifier)
		,@u_Way					int					= try_cast(ltrim(rtrim(@i_Way				)) as int)
		
	declare
		 @x_CheckList_Code			bigint
		,@x_CheckParty_ID				uniqueidentifier
		,@x_Contragent_ID			uniqueidentifier
		,@x_CheckList_to_Status_ID	uniqueidentifier
		,@x_CheckList_ID			uniqueidentifier
		,@x_CheckItem_ID			uniqueidentifier
		,@x_CheckItem_Status		uniqueidentifier
		,@x_Document_ID				uniqueidentifier	
		,@x_Position				int
		,@x_Item_Comment			nvarchar(1000)
		,@x_FETCH_c_CheckListStatus int
		,@x_FETCH_c_CheckItemStatus int

	declare 
		@e int = 0, 
		@Cnt int = 0, 
		@TranCount int = @@TranCount, 
		@CntParam nvarchar(max) = N'',
		@Entity_ID nvarchar(250),
		@IsError bit,
		@CurrentDate datetime2(7)					= try_cast(getdate()						as datetime2(7)),
		@cursorstatus int

	-- Nested Tran
	if @TranCount = 0 begin transaction	else save transaction trn_Register_Update
/*
-------------
------------- Error Handling 
-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus			is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'			) else if (@u_RowStatus		is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'			,try_cast(@i_RowStatus			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'AppUser_ID'		) else if (@u_AppUser_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'			,try_cast(@i_AppUser_ID			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Register_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'Register_ID'		) else if (@u_Register_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'Register_ID'		,try_cast(@i_Register_ID		as nvarchar(36)));set @e=@e+@@rowcount
		if (@i_CheckType_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'CheckType_ID'		) else if (@u_CheckType_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'CheckType_ID'		,try_cast(@i_CheckType_ID		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_CheckList_Status is not null and @u_CheckList_Status is null )																	  select Id=50108, Msg=formatmessage(50108, 'CheckList_Status'	,try_cast(@i_CheckList_Status	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Way					is null ) select Id=50101, Msg=formatmessage(50101, 'Way'				) else if (@u_Way			is null ) select Id=50106, Msg=formatmessage(50106, 'Way'				,try_cast(@i_Way				as nvarchar(250)));set @e=@e+@@rowcount
		
		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_AppUser_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'CheckType_ID="'+try_cast(@u_CheckType_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_CheckType', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_CheckType', try_cast(@u_CheckType_ID as nvarchar(250))); set @e=@e+@@rowcount

		if (@u_CheckList_Status is not null)
			begin	
			select @CntParam = N'Status_ID="'+try_cast(@u_CheckList_Status as nvarchar(max))+N'"', @Cnt=-1
			exec Get_RowCount 'p_Status', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Status',try_cast(@u_CheckList_Status as NVARCHAR(36))); set @e=@e+@@rowcount
			end
		select @CntParam = N'Register_ID="'+try_cast(@u_Register_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Register', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Register',try_cast(@u_Register_ID as NVARCHAR(36))); set @e=@e+@@rowcount
			
		-- Get way number		

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'ProcessStep_CheckList_Set.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
-------------
------------- Check conditions 
-------------

-------------
------------- Main Action 
-------------
	begin try
		if  @u_Way  = 1 -- Create CheckLists on First Iteration
			BEGIN
			
			DECLARE c_CheckList CURSOR  
			FOR SELECT CheckParty_ID, Contragent_ID FROM dbo.CheckParty where CheckType_ID = @u_CheckType_ID order by CheckParty_Order asc
			OPEN c_CheckList 

			FETCH NEXT FROM c_CheckList Into @x_CheckParty_ID, @x_Contragent_ID 
			set @x_CheckList_Code = NEXT VALUE FOR [dbo].[Sequence_CheckList_Number]

			WHILE @@FETCH_STATUS = 0 
				BEGIN
				EXECUTE dbo.CheckList_Insert
				   @u_RowStatus
				  ,@u_AppUser_ID
				  ,@x_CheckList_Code
				  ,@CurrentDate
				  ,@u_Register_ID
				  ,@x_CheckParty_ID
				  ,null
				  ,@Entity_ID OUTPUT
				  ,@IsError OUTPUT

				EXECUTE [dbo].[CheckList_to_Status_Insert] 
				   @u_RowStatus
				  ,@u_AppUser_ID
				  ,@Entity_ID
				  ,@u_CheckList_Status 
				  ,@CurrentDate
				  ,null
				  ,@Entity_ID OUTPUT
				  ,@IsError OUTPUT
				
				FETCH NEXT FROM c_CheckList Into @x_CheckParty_ID, @x_Contragent_ID 
				set @x_CheckList_Code = NEXT VALUE FOR [dbo].[Sequence_CheckList_Number]
			
				END

			CLOSE c_CheckList;  
			DEALLOCATE c_CheckList;  

			END
		else IF @u_Way = 2 -- Set CheckLists and CheckItem status on Second Iteration
			BEGIN

			--Cursor for Lists
			DECLARE c_CheckListStatus CURSOR 
			FOR select 
					clts.CheckList_to_Status_ID, 
					clts.CheckList_ID
				from dbo.CheckList cl
				join dbo.Register r on cl.Register_ID = r.Register_ID
				join dbo.CheckParty c on cl.CheckParty_ID = c.CheckParty_ID and c.CheckType_ID = @u_CheckType_ID
				join dbo.CheckList_to_Status clts on cl.CheckList_ID = clts.CheckList_ID
				join dbo.Status s on clts.Status_ID = s.Status_ID
				where r.Register_ID = @u_Register_ID

			OPEN c_CheckListStatus 

			FETCH NEXT FROM c_CheckListStatus Into @x_CheckList_to_Status_ID, @x_CheckList_ID

			set @x_FETCH_c_CheckListStatus = @@FETCH_STATUS
	
			WHILE @x_FETCH_c_CheckListStatus = 0 
				BEGIN

				EXECUTE dbo.CheckList_to_Status_Update
					   @x_CheckList_to_Status_ID
					  ,@u_RowStatus
					  ,@u_AppUser_ID
					  ,@x_CheckList_ID
					  ,@u_CheckList_Status
					  ,@CurrentDate
					  ,null
					  ,@o_IsError OUTPUT
				
				--Cursor for Items

				set @x_CheckItem_Status = (select Status_ID from dbo.p_Status where Status_Code = 'wCLIf')

				DECLARE c_CheckItemStatus CURSOR 
				FOR select 
					 ci.CheckItem_ID
					,ci.Document_ID
					,ci.Position
					,ci.Comment
				from dbo.CheckItem ci
				join dbo.Status s on ci.Status_ID = s.Status_ID
				where ci.CheckList_ID = @x_CheckList_ID
				and s.Status_Code = 'wCLId'

				OPEN c_CheckItemStatus 

				FETCH NEXT FROM c_CheckItemStatus Into @x_CheckItem_ID, @x_Document_ID, @x_Position, @x_Item_Comment  

				set @x_FETCH_c_CheckItemStatus = @@FETCH_STATUS

				WHILE @x_FETCH_c_CheckItemStatus = 0 
					BEGIN

					EXECUTE dbo.CheckItem_Update 
					   @x_CheckItem_ID
					  ,@u_RowStatus
					  ,@u_AppUser_ID
					  ,@x_CheckList_ID
					  ,@x_Document_ID
					  ,@x_CheckItem_Status
					  ,@x_Position
					  ,@x_Item_Comment
					  ,@o_IsError OUTPUT

					FETCH NEXT FROM c_CheckItemStatus Into @x_CheckItem_ID, @x_Document_ID, @x_Position, @x_Item_Comment  

					set @x_FETCH_c_CheckItemStatus = @@FETCH_STATUS

					END

				CLOSE c_CheckItemStatus;  
				DEALLOCATE c_CheckItemStatus; 

				FETCH NEXT FROM c_CheckListStatus Into  @x_CheckList_to_Status_ID, @x_CheckList_ID

				set @x_FETCH_c_CheckListStatus = @@FETCH_STATUS

				END

			CLOSE c_CheckListStatus;  
			DEALLOCATE c_CheckListStatus;  
				

			end
		else
			BEGIN
			select 1
			end

	end try	begin catch	
		
		
		SELECT @cursorstatus = cursor_status('global','c_CheckItemStatus')
		IF @cursorstatus > -2
		BEGIN
			DEALLOCATE c_CheckItemStatus
		END

		SELECT @cursorstatus = cursor_status('global','c_CheckListStatus')
		IF @cursorstatus > -2
		BEGIN
			DEALLOCATE c_CheckItemStatus
		END

		select Id=50100, Msg=formatmessage(50100, N'ProcessStep_CheckList_Set.Main_Action', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
*/
	-------------
	------------- Final Action 
	-------------
	if (@TranCount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback																-- rollback if critical transaction error
		if @xstate = 1 and @TranCount = 0 rollback											-- rollback if transaction was created in this procedure
		if @xstate = 1 and @TranCount > 0 rollback transaction trn_Register_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end




