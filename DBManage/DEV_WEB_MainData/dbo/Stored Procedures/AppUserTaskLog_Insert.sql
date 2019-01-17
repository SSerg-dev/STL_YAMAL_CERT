



-- =============================================
-- Author:		RAlizade
-- Create date: 2018-01-16
-- Description:	The Procedure writes a message 
-- in the user messaage Log
-- Chenages: ASmirnov 2018-09-02
-- Refactored to actual architecture  
-- =============================================
CREATE PROCEDURE [dbo].[AppUserTaskLog_Insert]  -- not null ->	+
	-- Add the parameters for the stored procedure here
	
	 @i_RowStatus				nvarchar(250)	-- sys param	+
	,@i_AppUser_ID				nvarchar(250)	-- sys param	+

	,@i_AppUserTask_ID			varchar(250)    -- usr param	+
	,@i_AppUserTaskMessage_ID	varchar(250)	-- usr param	+
	,@i_FilePath				varchar(250)	-- usr param	-
	,@i_FileName				varchar(250)	-- usr param	-	
	,@i_Description_Eng			varchar(250)	-- usr param	-
	,@i_Description_Rus			varchar(250)	-- usr param	-
	,@i_StackTrace				varchar(2000)	-- usr param	-

	,@o_Entity_ID				nvarchar(250)	output
	,@o_IsError					bit				output

AS
BEGIN
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Params
	declare 
		 @u_RowStatus				int					= try_cast(ltrim(rtrim(@i_RowStatus				))	as int			)
		,@u_Created_User_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier)
		,@u_Modified_User_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier)
		,@u_Insert_DTS				datetime2(7)		= try_cast(getdate()								as datetime2(7))
		,@u_Update_DTS				datetime2(7)		= try_cast(getdate()								as datetime2(7))
		--,@u_AppUserTaskLog_Code		nvarchar(255)		= try_cast(ltrim(rtrim(@i_AppUserTaskLog_Code	))	as nvarchar(255))

		,@u_AppUser_ID				uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID			))	as uniqueidentifier)
		,@u_AppUserTask_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUserTask_ID		))	as uniqueidentifier)
		,@u_AppUserTaskMessage_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUserTaskMessage_ID	))	as uniqueidentifier)
		,@u_FilePath				nvarchar(255)		= try_cast(ltrim(rtrim(@i_FilePath				))	as nvarchar(255))
		,@u_FileName				nvarchar(255)		= try_cast(ltrim(rtrim(@i_FileName				))	as nvarchar(255))
		,@u_Description_Eng			nvarchar(255)		= try_cast(ltrim(rtrim(@i_Description_Eng		))	as nvarchar(255))
		,@u_Description_Rus			nvarchar(255)		= try_cast(ltrim(rtrim(@i_Description_Rus		))	as nvarchar(255))
		,@u_StackTrace				nvarchar(2000)		= try_cast(ltrim(rtrim(@i_StackTrace			))	as nvarchar(2000))

		,@u_AppUserTaskLog_ID		uniqueidentifier	= newid()
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_CheckList_Insert
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus			is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'				) else if (@u_RowStatus				is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'				,try_cast(@i_RowStatus				as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'				) else if (@u_Created_User_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'				,try_cast(@i_AppUser_ID				as nvarchar(250)));set @e=@e+@@rowcount
		--if (@i_AppUserTaskLog_Code	is null ) select Id=50101, Msg=formatmessage(50101, 'AppUserTaskLog_Code'	) else if (@u_AppUserTaskLog_Code	is null ) select Id=50103, Msg=formatmessage(50103, 'AppUserTaskLog_Code'	,try_cast(@i_AppUserTaskLog_Code	as nvarchar(250)));set @e=@e+@@rowcount

		if (@i_AppUserTask_ID			is null ) select Id=50101, Msg=formatmessage(50101, 'AppUserTask_ID'		) else if (@u_AppUserTask_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'AppUserTask_ID'		,try_cast(@i_AppUserTask_ID			as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUserTaskMessage_ID	is null ) select Id=50101, Msg=formatmessage(50101, 'AppUserTaskMessage_ID'	) else if (@u_AppUserTaskMessage_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'AppUserTaskMessage_ID'	,try_cast(@i_AppUserTaskMessage_ID	as nvarchar(250)));set @e=@e+@@rowcount
		
		-- data consistency check	
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		--select @CntParam = N'AppUserTaskLog_Code="'+try_cast(@u_AppUserTaskLog_Code as nvarchar(max))+N'"', @Cnt=-1
		--exec Get_RowCount 'p_AppUserTaskLog', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_AppUserTaskLog_Code as nvarchar(250)), 'AppUserTaskLog'); set @e=@e+@@rowcount
		
		--select @CntParam = N'AppUserTaskLog_ID="'+try_cast(@u_AppUserTaskLog_ID as nvarchar(max))+N'"', @Cnt=-1
		--exec Get_RowCount 'p_AppUserTaskLog', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_AppUserTaskLog', try_cast(@u_AppUserTaskLog_ID as nvarchar(250))); set @e=@e+@@rowcount
		
		select @CntParam = N'AppUserTask_ID="'+try_cast(@u_AppUserTask_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUserTask', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_AppUserTask', try_cast(@u_AppUserTask_ID as nvarchar(250))); set @e=@e+@@rowcount
		
		select @CntParam = N'AppUserTaskMessage_ID="'+try_cast(@u_AppUserTaskMessage_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUserTaskMessage', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_AppUserTaskMessage', try_cast(@u_AppUserTaskMessage_ID as nvarchar(250))); set @e=@e+@@rowcount
	
	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'AppUserTaskLog_Insert.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch

	------------
	----------- Main Action 
	-------------		

	-- AppUserTaskLog
	if (@e = 0) begin try
		INSERT INTO dbo.p_AppUserTaskLog
           (AppUserTaskLog_ID
           ,RowStatus
           ,Insert_DTS
           ,Update_DTS
           ,Created_User_ID
           ,Modified_User_ID
           ,AppUser_ID
           ,AppUserTask_ID
           ,AppUserTaskMessage_ID
           ,FilePath
           ,FileName
           ,Description_Eng
           ,Description_Rus
		   ,StackTrace)
		VALUES
           (@u_AppUserTaskLog_ID
           ,@u_RowStatus
           ,@u_Insert_DTS	
           ,@u_Update_DTS
           ,@u_Created_User_ID	
           ,@u_Modified_User_ID
           ,@u_AppUser_ID
           ,@u_AppUserTask_ID
           ,@u_AppUserTaskMessage_ID
           ,@u_FilePath
           ,@u_FileName
           ,@u_Description_Eng
           ,@u_Description_Rus	
		   ,@u_StackTrace	
		)
	end try begin catch 
		select Id=50100, Msg=formatmessage(50100, N'AppUserTaskLog_Insert.Insert', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Final Action 
	-------------
	if (@trancount = 0) and (@e = 0) -- do commit only in case we opened transaction inside THIS procedure
		commit
	if (@e <> 0) begin -- if any error apper  
		declare @xstate int = xact_state()
		if @xstate =-1 rollback																-- rollback if critical transaction error
		if @xstate = 1 and @trancount = 0 rollback											-- rollback if transaction was created in this procedure
		if @xstate = 1 and @trancount > 0 rollback transaction trn_CheckList_Insert	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	
	if @e > 0 select @o_IsError = 1, @o_Entity_ID = null else select @o_IsError = 0, @o_Entity_ID = try_cast(@u_AppUserTaskLog_ID as nvarchar(36))
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
