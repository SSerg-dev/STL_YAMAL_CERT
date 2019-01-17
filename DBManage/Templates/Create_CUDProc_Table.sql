use <DataBase_Name, sysname, WEB_MainData>

drop procedure if exists dbo.<Table_Name, sysname, Table_Name>_Insert
go

-- =============================================
-- Author: <Author, sysname, Author>
-- Create date: <CreateDate, sysname, 16.08.2018>
-- =============================================

create procedure dbo.<Table_Name, sysname, Table_Name>_Insert	-- not null ->	+
(	 @i_RowStatus			nvarchar(250)	-- sys param	+
	,@i_AppUser_ID			nvarchar(250)	-- sys param	+
	,@i_<Table_Name, sysname, Table_Name>_Code		nvarchar(250)	-- usr param	+
	--== place your params here ==
	,@o_Entity_ID			nvarchar(250)	output
	,@o_IsError				bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Params
	declare 
		 @u_RowStatus								int					= try_cast(ltrim(rtrim(@i_RowStatus			))	as int			)
		,@u_Created_User_ID							uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Modified_User_ID						uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Insert_DTS								datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Update_DTS								datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_<Table_Name, sysname, Table_Name>_Code	nvarchar(255)		= try_cast(ltrim(rtrim(@i_<Table_Name, sysname, Table_Name>_Code	))	as nvarchar(255))
		--== place your params here ==

		,@u_<Table_Name, sysname, Table_Name>_ID			uniqueidentifier	= newid()
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_<Table_Name, sysname, Table_Name>_Insert
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus	is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus'	) else if (@u_RowStatus		is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'		) else if (@u_Created_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'		,try_cast(@i_AppUser_ID		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_<Table_Name, sysname, Table_Name>_Code		is null ) select Id=50101, Msg=formatmessage(50101, '<Table_Name, sysname, Table_Name>_Code'	) else if (@u_<Table_Name, sysname, Table_Name>_Code	is null ) select Id=50103, Msg=formatmessage(50103, '<Table_Name, sysname, Table_Name>_Code'	,try_cast(@i_<Table_Name, sysname, Table_Name>_Code	as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here ==

		-- data consistency check	
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'<Table_Name, sysname, Table_Name>_Code="'+try_cast(@u_<Table_Name, sysname, Table_Name>_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_<Table_Name, sysname, Table_Name>', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_<Table_Name, sysname, Table_Name>_Code as nvarchar(250)), '<Table_Name, sysname, Table_Name>'); set @e=@e+@@rowcount
		
		--== place your params here ==

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'<Table_Name, sysname, Table_Name>_Insert.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------		
	-- <Table_Name, sysname, Table_Name>
	if (@e = 0) begin try
		Insert into dbo.p_<Table_Name, sysname, Table_Name>
		(	 <Table_Name, sysname, Table_Name>_ID
			,RowStatus
			,Insert_DTS
			,Update_DTS	  
			,Created_User_ID
			,Modified_User_ID
			,<Table_Name, sysname, Table_Name>_Code
			--== place your params here ==
		) values
		(	 @u_<Table_Name, sysname, Table_Name>_ID
			,@u_RowStatus
			,@u_Insert_DTS
			,@u_Update_DTS	  
			,@u_Created_User_ID
			,@u_Modified_User_ID
			,@u_<Table_Name, sysname, Table_Name>_Code	
			--== place your params here ==
		)
	end try begin catch 
		select Id=50100, Msg=formatmessage(50100, N'<Table_Name, sysname, Table_Name>_Insert.Insert', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_<Table_Name, sysname, Table_Name>_Insert	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	
	if @e > 0 select @o_IsError = 1, @o_Entity_ID = null else select @o_IsError = 0, @o_Entity_ID = try_cast(@u_<Table_Name, sysname, Table_Name>_ID as nvarchar(36))
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
go

drop procedure if exists dbo.<Table_Name, sysname, Table_Name>_Update
go

-- =============================================
-- Author: <Author, sysname, Ivan Vaskov>
-- Create date: <CreateDate, sysname, 16.08.2018>
-- =============================================

create procedure dbo.<Table_Name, sysname, Table_Name>_Update	-- not null ->	+
(	 @i_<Table_Name, sysname, Table_Name>_ID	nvarchar(250)	-- sys param	+
	,@i_RowStatus								nvarchar(250)	-- sys param	+
	,@i_AppUser_ID								nvarchar(250)	-- sys param	+
	,@i_<Table_Name, sysname, Table_Name>_Code	nvarchar(250)	-- usr param	+
	--== place your params here ==
	,@o_IsError					bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus								int					= try_cast(ltrim(rtrim(@i_RowStatus	))	as int			)
		,@u_Created_User_ID							uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Modified_User_ID						uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Insert_DTS								datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Update_DTS								datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_<Table_Name, sysname, Table_Name>_Code	nvarchar(255)		= try_cast(ltrim(rtrim(@i_<Table_Name, sysname, Table_Name>_Code))	as nvarchar(255))
		--== place your params here ==

		,@u_<Table_Name, sysname, Table_Name>_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_<Table_Name, sysname, Table_Name>_ID	)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_<Table_Name, sysname, Table_Name>_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus') else if (@u_RowStatus	is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID') else if (@u_Created_User_ID is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID' ,try_cast(@i_AppUser_ID as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_<Table_Name, sysname, Table_Name>_ID is null ) select Id=50101, Msg=formatmessage(50101, '<Table_Name, sysname, Table_Name>_ID' ) else if (@u_<Table_Name, sysname, Table_Name>_ID		is null ) select Id=50108, Msg=formatmessage(50108, '<Table_Name, sysname, Table_Name>_ID' ,try_cast(@i_<Table_Name, sysname, Table_Name>_ID as nvarchar(250))));set @e=@e+@@rowcount
		if (@i_<Table_Name, sysname, Table_Name>_Code is null ) select Id=50101, Msg=formatmessage(50101, '<Table_Name, sysname, Table_Name>_Code' ) else if (@u_<Table_Name, sysname, Table_Name>_Code	is null ) select Id=50103, Msg=formatmessage(50103, '<Table_Name, sysname, Table_Name>_Code' ,try_cast(@i_<Table_Name, sysname, Table_Name>_Code as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'<Table_Name, sysname, Table_Name>_ID="'+try_cast(@u_<Table_Name, sysname, Table_Name>_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_<Table_Name, sysname, Table_Name>', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122,'<Table_Name, sysname, Table_Name>',try_cast(@u_<Table_Name, sysname, Table_Name>_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		select @CntParam = N'<Table_Name, sysname, Table_Name>_ID="'+try_cast(@u_<Table_Name, sysname, Table_Name>_ID as nvarchar(max))+N'",'+N'<Table_Name, sysname, Table_Name>_Code="'+try_cast(@u_<Table_Name, sysname, Table_Name>_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_<Table_Name, sysname, Table_Name>', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_<Table_Name, sysname, Table_Name>_Code as nvarchar(250)), '<Table_Name, sysname, Table_Name>'); set @e=@e+@@rowcount
		--== place your params here =

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'<Table_Name, sysname, Table_Name>_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,<Table_Name, sysname, Table_Name>_Code
					--== place your params here =

					from dbo.p_<Table_Name, sysname, Table_Name>
					where <Table_Name, sysname, Table_Name>_ID = @u_<Table_Name, sysname, Table_Name>_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					  RowStatus   = @u_RowStatus
					 ,<Table_Name, sysname, Table_Name>_Code  = @u_<Table_Name, sysname, Table_Name>_Code
					 --== place your params here =

				) x				  
			) b	on a.x = b.x
		)
	begin
		-- <Table_Name, sysname, Table_Name>
		if (@e = 0) begin try
			update dbo.p_<Table_Name, sysname, Table_Name> set
				 RowStatus	  = @u_RowStatus	 
				,Update_DTS	  = @u_Update_DTS	 
				,Modified_User_ID  = @u_Modified_User_ID
				,<Table_Name, sysname, Table_Name>_Code	= @u_<Table_Name, sysname, Table_Name>_Code
				--== place your params here = 

			where <Table_Name, sysname, Table_Name>_ID = @u_<Table_Name, sysname, Table_Name>_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'<Table_Name, sysname, Table_Name>_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_<Table_Name, sysname, Table_Name>_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchar(max)) where 1=2
end
go


drop procedure if exists dbo.<Table_Name, sysname, Table_Name>_Delete
go

-- =============================================
-- Author: <Author, sysname, Ivan Vaskov>
-- Create date: <CreateDate, sysname, 16.08.2018>
-- =============================================

create procedure dbo.<Table_Name, sysname, Table_Name>_Delete	-- not null ->	+
(	 @i_<Table_Name, sysname, Table_Name>_ID	nvarchar(250)		-- usr param	+
	,@i_AppUser_ID		nvarchar(250)	-- sys param	+
	,@o_IsError			bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_Modified_User_ID						uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Update_DTS								datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_<Table_Name, sysname, Table_Name>_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_<Table_Name, sysname, Table_Name>_ID	))	as uniqueidentifier	)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N'', @RowStatus int = 200
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_<Table_Name, sysname, Table_Name>_Delete
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_<Table_Name, sysname, Table_Name>_ID	is null ) select Id=50101, Msg=formatmessage(50101, '<Table_Name, sysname, Table_Name>_ID'	) else if (@u_<Table_Name, sysname, Table_Name>_ID	is null ) select Id=50108, Msg=formatmessage(50108, '<Table_Name, sysname, Table_Name>_ID'	,try_cast(@i_<Table_Name, sysname, Table_Name>_ID	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID'		) else if (@u_Modified_User_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID'		,try_cast(@i_AppUser_ID		as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Modified_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(36))); set @e=@e+@@rowcount


		select @CntParam = N'RowStatus_ID="'+try_cast(@RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@RowStatus as NVARCHAR(250))); set @e=@e+@@rowcount

		select @CntParam = N'<Table_Name, sysname, Table_Name>_ID="'+try_cast(@u_<Table_Name, sysname, Table_Name>_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_<Table_Name, sysname, Table_Name>', @CntParam, @Cnt out; if (@Cnt=0) select Id=50122, Msg=formatmessage(50122,'<Table_Name, sysname, Table_Name>',try_cast(@u_<Table_Name, sysname, Table_Name>_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		--== place your params here =

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'<Table_Name, sysname, Table_Name>.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
	end catch
	-------------
	------------- Main Action 
	-------------
	-- <Table_Name, sysname, Table_Name>
	if (@e = 0) begin try
		update dbo.p_<Table_Name, sysname, Table_Name> set RowStatus = @RowStatus, Update_DTS = @u_Update_DTS,Modified_User_ID  = @u_Modified_User_ID where <Table_Name, sysname, Table_Name>_ID = @u_<Table_Name, sysname, Table_Name>_ID
	end try begin catch 
		select Id=50100, Msg=formatmessage(50100, N'<Table_Name, sysname, Table_Name>.Delete', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_<Table_Name, sysname, Table_Name>_Delete	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
go

