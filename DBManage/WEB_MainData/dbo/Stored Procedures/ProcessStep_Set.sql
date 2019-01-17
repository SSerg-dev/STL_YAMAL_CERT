
-- =============================================
-- Author: ASmirnov	
-- Create date: 26.08.2018
-- =============================================
CREATE procedure [dbo].[ProcessStep_Set]		-- not null ->	+
(	 @i_Register_ID			nvarchar(250)	-- sys param	+
	,@i_Status_ID			nvarchar(250)	-- sys param	+
	,@i_RowStatus			nvarchar(250)	-- sys param	+
	,@i_AppUser_ID			nvarchar(250)	-- sys param	+
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
		,@u_Status_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_Status_ID			)) as uniqueidentifier)

	declare
		@x_Current_Status_ID		uniqueidentifier,
		@x_Check_Way				bigint,
		@x_Action_Way				bigint,
		@x_IterationIncrement		int,
		@x_CurrentIteration			int,
		@x_Iteration_New			int,
		@x_Register_to_Status_ID	uniqueidentifier,
		@x_OldStatus_Parent_ID		uniqueidentifier,
		@x_CheckType_ID				uniqueidentifier,
		@x_CheckList_Status_ID		uniqueidentifier,
		@x_Way						int,
		@x_Register_Code			nvarchar(250),
		@x_Register_Date			nvarchar(250),
		@x_Current_Iteration		nvarchar(250),
		@x_Customer_ID				nvarchar(250),
		@x_Contractor_ID			nvarchar(250),
		@x_SubContractor_ID			nvarchar(250),
		@x_Resp_Employee_ID			nvarchar(250),
		@x_WorkPackage_ID			nvarchar(250),
		@x_Comment					nvarchar(250),
		@x_TitleObject_ID			nvarchar(250),
		@x_ActionType				int,
		@x_Action_NewList			int	= 0,
		@x_Action_RefreshLists		int = 0

	declare 
		@e int = 0, 
		@Cnt int = 0, 
		@SCnt int = 0,
		@TranCount int = @@TranCount, 
		@CntParam nvarchar(max) = N'',
		@Entity_ID nvarchar(250),
		@IsError bit,
		@CurrentDate datetime2(7)					= try_cast(getdate()						as datetime2(7))

	-- Nested Tran
	if @TranCount = 0 begin transaction	else save transaction trn_Register_Update
	/*
-------------
------------- Error Handling 
-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus			is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'			) else if (@u_RowStatus		is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'			,try_cast(@i_RowStatus			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'			) else if (@u_AppUser_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'			,try_cast(@i_AppUser_ID			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Register_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'Register_ID'		) else if (@u_Register_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'Register_ID'		,try_cast(@i_Register_ID		as nvarchar(36)));set @e=@e+@@rowcount

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_AppUser_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'Register_ID="'+try_cast(@u_Register_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Register', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Register',try_cast(@u_Register_ID as NVARCHAR(36))); set @e=@e+@@rowcount
			
		-- Get way number
		select 
			@x_Current_Status_ID		= rts.Status_ID, 
			@x_Register_to_Status_ID	= rts.Register_to_Status_ID,
			@x_OldStatus_Parent_ID		= rts.Parent_ID
		from dbo.Register_to_Status rts where rts.Register_ID	= @u_Register_ID
		select @CntParam = N'From_Status_ID="'+try_cast(@x_Current_Status_ID as nvarchar(max))+N'",To_Status_ID="'+try_cast(@u_Status_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_StatusRelation', @CntParam, @Cnt out;

		if (@Cnt<>1) -- is possible relation found? 
			begin
			select Id=50126, Msg=formatmessage(50126,'StatusRelation');set @e=@e+@@rowcount
			end
		else if (@Cnt=1 and @e = 0) -- there is no errors?
			begin

			select	@x_Check_Way			= sr.StatusRelation_Code,
					@x_IterationIncrement	= sr.IterationIncrement,
					@x_CheckType_ID			= sr.CheckType_ID,
					@x_ActionType			= sr.ActionType
			from dbo.StatusRelation sr 
			where sr.From_Status_ID = @x_Current_Status_ID
			  AND sr.To_Status_ID	= @u_Status_ID  

			end

		select @x_CurrentIteration = Current_Iteration
		from dbo.p_Register 
		where Register_ID = @u_Register_ID

		set @x_Iteration_New = @x_CurrentIteration + @x_IterationIncrement  

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'ProcessStep_Set.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
-------------
------------- Check conditions 
-------------
	begin try
		if  (@x_ActionType = 1)  -- before any Review\Approvement

			BEGIN

			--register is not empty
			set @Cnt = 0
			select @Cnt = count(*)
			from dbo.p_Register r
			join dbo.Register_to_Document rtd on r.Register_ID = rtd.Register_ID and r.Current_Iteration = rtd.Iteration
			where r.Register_ID = @u_Register_ID
			if (@Cnt < 1) select Id=50100, Msg=formatmessage(50100,'ProcessStep_Set.Check conditions.No docs in registers');set @e=@e+@@rowcount

			--register contains only approved documents
			set @Cnt = 0
			select @Cnt = count(*)
			from dbo.p_Register r
			join dbo.Register_to_Document rtd on r.Register_ID = rtd.Register_ID and r.Current_Iteration = rtd.Iteration
			join dbo.Document d on rtd.Document_ID = d.Document_ID
			join dbo.Document_to_Status dts on d.Document_ID = dts.Document_ID
			join dbo.Status s on dts.Status_ID = s.Status_ID and s.Status_Code <> 'wDa'
			where rtd.Register_ID = @u_Register_ID
			if (@Cnt > 0) select Id=50100, Msg=formatmessage(50100,'ProcessStep_Set.Check_conditions.Not approved docs in registers');set @e=@e+@@rowcount
			
			--if register once been on approvement checking, it can be sent only to approvement again 
			  set @Cnt = 0
			  select @Cnt = count (*)
			  from dbo.p_Register_to_Status rts 
			  join dbo.p_Register r on rts.Register_ID = r.Register_ID
			  join dbo.p_Status s on rts.Status_ID = s.Status_ID
			  where s.Status_Code = 'wCCua' 
			  and rts.RowStatus = 120
			  and r.Register_ID = @u_Register_ID

			  if (@Cnt > 0 and @u_Status_ID <> (select Status_ID from dbo.Status where Status_Code = 'wCCua' ))
				BEGIN
				select Id=50100, Msg=formatmessage(50100,'ProcessStep_Set.Check_conditions.Cant set Register status');set @e=@e+@@rowcount
				end

			if @x_Check_Way = 1 -- first rewiew
				begin
				set @x_Action_NewList = 1
				end
			else    
				begin 
				set @x_Action_RefreshLists = 1
				end


			end
		else IF (@x_ActionType = 2) or (@x_ActionType = 3) --on every bifurcation
			BEGIN
			
			-- Lists of comments from all CheckPartys Exists
			SELECT @Cnt = case when count(distinct ck.CheckParty_Code) = (select count(*) from dbo.CheckParty ck where ck.CheckType_ID = @x_CheckType_ID) then 0 
							   else 1 end
			from dbo.CheckList cl 
			join dbo.CheckList_to_Status clts on cl.CheckList_ID = clts.CheckList_ID
			join dbo.Status s on clts.Status_ID = s.Status_ID
			join dbo.Register r on cl.Register_ID = r.Register_ID and r.Register_ID =  @u_Register_ID
			join dbo.CheckParty ck on cl.CheckParty_ID = ck.CheckParty_ID and ck.CheckType_ID = @x_CheckType_ID
			if (@Cnt = 1) select Id=50100, Msg=formatmessage(50100,'ProcessStep_Set.Check_conditions. Not all requiered CheckList Exists');set @e=@e+@@rowcount
			
			-- all lists of comments Completed
			SELECT @Cnt = count(distinct ck.CheckParty_Code)
			 --r.Register_Code, cl.CheckList_Code, cl.CheckList_Date, s.Status_Code
			  from dbo.CheckList cl 
			left join dbo.CheckList_to_Status clts on cl.CheckList_ID = clts.CheckList_ID
			left join dbo.Status s on clts.Status_ID = s.Status_ID
			join dbo.Register r on cl.Register_ID = r.Register_ID and r.Register_ID =  @u_Register_ID
			join dbo.CheckParty ck on cl.CheckParty_ID = ck.CheckParty_ID and ck.CheckType_ID = @x_CheckType_ID
			where s.Status_Code is null or s.Status_Code <> 'wСLc'

			if (@Cnt > 0) select Id=50100, Msg=formatmessage(50100,'ProcessStep_Set.Check_conditions. Not all CheckList have certain status');set @e=@e+@@rowcount
			
			-- is all comments resolved? 
			SELECT @Cnt = count(*)
				--r.Register_Code, cl.CheckList_Code, cl.CheckList_Date, sl.Status_Code, ci.Position, ci.Comment, si.Status_Code
			from dbo.CheckList cl 
			left join dbo.CheckList_to_Status clts on cl.CheckList_ID = clts.CheckList_ID
			left join dbo.Status sl on clts.Status_ID = sl.Status_ID
			left join dbo.p_CheckItem ci on cl.CheckList_ID = ci.CheckList_ID
			left join dbo.Status si on ci.Status_ID = si.Status_ID
			join dbo.Register r on cl.Register_ID = r.Register_ID and r.Register_ID = @u_Register_ID 
			join dbo.CheckParty ck on cl.CheckParty_ID = ck.CheckParty_ID and ck.CheckType_ID = @x_CheckType_ID
			where si.Status_Code is null or (si.Status_Code <> 'wCLIc' and si.Status_Code <> 'wCLIa')
			--CheckLists with no CheckItems and status Completed is interpretate as valid and means that Register has "NoComments"
			and cl.CheckList_ID not in (select cl.CheckList_ID
										from dbo.CheckList cl	
										left join dbo.CheckItem ci on cl.CheckList_ID = ci.CheckList_ID
										join dbo.CheckParty ck on cl.CheckParty_ID = ck.CheckParty_ID and ck.CheckType_ID = @x_CheckType_ID
										where ci.CheckList_ID is null
										and cl.Register_ID = @u_Register_ID 
										)

			if (@Cnt > 0 and @x_ActionType = 2) --First/Second Review to
				BEGIN
				set @u_Status_ID = (select Status_ID from dbo.Status where Status_Code = 'wSCce') -- set status to Comments Given
				END
			ELSE if (@Cnt = 0 and @x_ActionType = 2) --First/Second Review to
				BEGIN
				set @u_Status_ID = (select Status_ID from dbo.Status where Status_Code = 'wCCua') -- set status to Approvment
				end
			else If (@Cnt > 0 and @x_ActionType = 3) -- Approvement to
				BEGIN
				set @u_Status_ID = (select Status_ID from dbo.Status where Status_Code = 'wCCuna') -- set status  NotApproved
				end
			else If (@Cnt = 0 and @x_ActionType = 3) -- Approvement to
				BEGIN
				set @u_Status_ID = (select Status_ID from dbo.Status where Status_Code = 'wCarh') -- set status Archived
				end
		end	

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'ProcessStep_Set.Check_conditions', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
-------------
------------- Main Action 
-------------
	if (@e = 0) begin try	
			--advance iteration if needed (if Iteration increment in dbo.StatusRelation > 0)
			select 	
				 @x_Register_Code		=  Register_Code	
				,@x_Register_Date		=  Register_Date	
				,@x_Customer_ID			=  Customer_ID		
				,@x_Contractor_ID		=  Contractor_ID	
				,@x_SubContractor_ID	=  SubContractor_ID	
				,@x_Resp_Employee_ID	=  Resp_Employee_ID
				,@x_WorkPackage_ID		=  WorkPackage_ID	
				,@x_Comment				=  Comment			
			from dbo.p_Register where Register_ID = @u_Register_ID

			EXECUTE [dbo].[Register_Update] 
				 @u_Register_ID
				,@u_RowStatus
				,@u_AppUser_ID
				,@x_Register_Code
				,@x_Register_Date
				,@x_Iteration_New
				,@x_Customer_ID
				,@x_Contractor_ID
				,@x_SubContractor_ID
				,@x_Resp_Employee_ID
				,@x_WorkPackage_ID
				,@x_Comment
				,@o_IsError OUTPUT

			--advance Status
			EXECUTE dbo.Register_to_Status_Insert					
			   @u_RowStatus
			  ,@u_AppUser_ID
			  ,@u_Register_ID
			  ,@u_Status_ID
			  ,@x_Iteration_New
			  ,@CurrentDate
			  ,null--@u_DTS_End
			  ,@x_Register_to_Status_ID
			  ,@Entity_ID OUTPUT
			  ,@IsError OUTPUT

			EXECUTE dbo.Register_to_Status_Update 
			   @x_Register_to_Status_ID
			  ,'120'
			  ,@u_AppUser_ID
			  ,@u_Register_ID
			  ,@x_Current_Status_ID
			  ,@x_CurrentIteration
			  ,null--@u_DTS_Start
			  ,@CurrentDate
			  ,@x_OldStatus_Parent_ID
			  ,@o_IsError OUTPUT

		if  @x_Action_NewList = 1  --create all Party CheckLists drafts	
			BEGIN

			set @x_CheckType_ID	= (select CheckType_ID from dbo.p_CheckType where CheckType_Code = 'Review')		
			set @x_CheckList_Status_ID	= (select status_ID from dbo.p_Status where Status_Code = 'wСLd')
			set @x_Way				= 1	

			EXECUTE  [dbo].[ProcessStep_CheckList_Set] 
			   @i_Register_ID
			  ,@x_CheckType_ID
			  ,@x_CheckList_Status_ID	
			  ,@x_Way	
			  ,@u_RowStatus
			  ,@u_AppUser_ID
			  ,@o_IsError OUTPUT
			
			set @x_CheckType_ID	= (select CheckType_ID from dbo.p_CheckType where CheckType_Code = 'Approvement')	
			EXECUTE  [dbo].[ProcessStep_CheckList_Set] 
			   @i_Register_ID
			  ,@x_CheckType_ID
			  ,@x_CheckList_Status_ID	
			  ,@x_Way	
			  ,@u_RowStatus
			  ,@u_AppUser_ID
			  ,@o_IsError OUTPUT

			END
		 
		IF @x_Action_RefreshLists = 1 --set all relevant lists to Review status
			BEGIN

			set @x_CheckList_Status_ID	= (select status_ID from dbo.p_Status where Status_Code = 'wСLr')
			set @x_Way				= 2	

			EXECUTE [dbo].[ProcessStep_CheckList_Set] 
			   @u_Register_ID
			  ,@x_CheckType_ID
			  ,@x_CheckList_Status_ID
			  ,@x_Way
			  ,@u_RowStatus
			  ,@u_AppUser_ID
			  ,@o_IsError OUTPUT

			end
	
	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'ProcessStep_Set.Main_Action', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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




