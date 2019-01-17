
-- =============================================
-- Author: Ivan Vaskov
-- Create date: 17.08.2018
-- =============================================

CREATE procedure [dbo].[Document_Update]	-- not null ->	+
(	 @i_Document_ID	nvarchar(250)	-- sys param	+
	,@i_RowStatus		nvarchar(250)	-- sys param	+
	,@i_AppUser_ID		nvarchar(250)	-- sys param	+
	,@i_Document_Code	nvarchar(250)	-- usr param	+
	--== place your params here ==
	,@i_Document_Number	nvarchar(250)	-- usr param	-
	,@i_DocumentType_ID	nvarchar(250)	-- usr param	+
	,@i_Document_Date	nvarchar(250)	-- usr param	-
	,@i_Issue_Date		nvarchar(250)	-- usr param	+
	,@i_TotalSheets		nvarchar(250)	-- usr param	-
	,@i_Document_Name	nvarchar(250)	-- usr param	-
	,@i_Parent_ID		nvarchar(250)	-- usr param	-
	,@o_IsError					bit				output
) as begin
	-------------
	------------- Prepearing 
	-------------
	set nocount on
	-- Param
	declare 
		 @u_RowStatus			int					= try_cast(ltrim(rtrim(@i_RowStatus	))		as int			)
		,@u_Created_User_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Modified_User_ID	uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID		))	as uniqueidentifier)
		,@u_Insert_DTS			datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Update_DTS			datetime2(7)		= try_cast(getdate()						as datetime2(7))
		,@u_Document_Code		nvarchar(255)		= try_cast(ltrim(rtrim(@i_Document_Code))	as nvarchar(255))
		,@u_Document_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_Document_ID		))	as uniqueidentifier)
		--== place your params here ==
		,@u_Document_Number		nvarchar(255)		= try_cast(ltrim(rtrim(@i_Document_Number	))	as nvarchar(255))
		,@u_DocumentType_ID		uniqueidentifier	= try_cast(ltrim(rtrim(@i_DocumentType_ID	))	as uniqueidentifier)
		,@u_Document_Date		datetime2(7)		= try_cast(ltrim(rtrim(@i_Document_Date		))	as datetime2(7))
		,@u_Issue_Date			datetime2(7)		= try_cast(ltrim(rtrim(@i_Issue_Date		))	as datetime2(7))
		,@u_TotalSheets			int					= try_cast(ltrim(rtrim(@i_TotalSheets		))	as int			)
		,@u_Document_Name		nvarchar(255)		= try_cast(ltrim(rtrim(@i_Document_Name		))	as nvarchar(255))
		,@u_Parent_ID			uniqueidentifier	= try_cast(ltrim(rtrim(@i_Parent_ID			))	as uniqueidentifier)
		,@x_VersionNumber		int				
		,@x_IsActual			bit	
		
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_Document_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus') else if (@u_RowStatus	is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID') else if (@u_Created_User_ID is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID' ,try_cast(@i_AppUser_ID as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Document_ID is null ) select Id=50101, Msg=formatmessage(50101, 'Document_ID' ) else if (@u_Document_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'Document_ID' ,try_cast(@i_Document_ID as nvarchar(36)));set @e=@e+@@rowcount
		if (@i_Document_Code is null ) select Id=50101, Msg=formatmessage(50101, 'Document_Code' ) else if (@u_Document_Code	is null ) select Id=50103, Msg=formatmessage(50103, 'Document_Code' ,try_cast(@i_Document_Code as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =
		if (@i_DocumentType_ID		is null ) select Id=50101, Msg=formatmessage(50101, 'DocumentType_ID'	) else if (@u_DocumentType_ID	is null ) select Id=50108, Msg=formatmessage(50108, 'DocumentType_ID'	,try_cast(@i_DocumentType_ID	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Issue_Date			is null ) select Id=50101, Msg=formatmessage(50101, 'Issue_Date'		) else if (@u_Issue_Date		is null ) select Id=50105, Msg=formatmessage(50105, 'Document_Code'		,try_cast(@i_Document_Code	as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Parent_ID is not null and @u_Parent_ID is null) select Id=50108, Msg=formatmessage(50108, 'Parent_ID' ,try_cast(@i_Parent_ID as nvarchar(250)));set @e=@e+@@rowcount
		

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'Document_ID="'+try_cast(@u_Document_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Document', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Document',try_cast(@u_Document_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		select @CntParam = N'Document_ID="'+try_cast(@u_Document_ID as nvarchar(max))+N'",'+N'Document_Code="'+try_cast(@u_Document_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Document', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_Document_Code as nvarchar(250)), 'Document'); set @e=@e+@@rowcount
		--== place your params here =

		select @CntParam = N'DocumentType_ID="'+try_cast(@u_DocumentType_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_DocumentType', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_DocumentType', try_cast(@i_DocumentType_ID as nvarchar(250))); set @e=@e+@@rowcount

		--TODO add check Parent_ID in Document_ID column

		--set version number
		if (@i_Parent_ID	is null ) set @x_VersionNumber = 1 else (	
																	select @x_VersionNumber = d.VersionNumber + 1
																	from dbo.p_Document d
																	where d.Document_ID = @u_Parent_ID 
																	)
		--set Is actual true if this is first document revision
		if (@i_Parent_ID	is null ) set @x_IsActual	= 1; else set @x_IsActual	= 0;


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
					,Document_Code
					--== place your params here ==
					,Document_Number	
					,DocumentType_ID	
					,Document_Date	
					,Issue_Date		
					,TotalSheets		
					,Document_Name	
					,Parent_ID	
					,VersionNumber	
					,IsActual
					from dbo.p_Document
					where Document_ID = @u_Document_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					 RowStatus						= @u_RowStatus			
					,Document_Code					= @u_Document_Code		
					--== place your params here ==	
					,Document_Number				= @u_Document_Number	
					,DocumentType_ID				= @u_DocumentType_ID	
					,Document_Date					= @u_Document_Date		
					,Issue_Date						= @u_Issue_Date			
					,TotalSheets					= @u_TotalSheets		
					,Document_Name					= @u_Document_Name		
					,Parent_ID						= @u_Parent_ID	
					,VersionNumber					= @x_VersionNumber
					,IsActual						= @x_IsActual
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- Document
		if (@e = 0) begin try
			update dbo.p_Document set
				 RowStatus			= @u_RowStatus	 
				,Update_DTS			= @u_Update_DTS	 
				,Modified_User_ID	= @u_Modified_User_ID
				,Document_Code		= @u_Document_Code		
				--== place your params here ==	
				,Document_Number	= @u_Document_Number	
				,DocumentType_ID	= @u_DocumentType_ID	
				,Document_Date		= @u_Document_Date		
				,Issue_Date			= @u_Issue_Date			
				,TotalSheets		= @u_TotalSheets		
				,Document_Name		= @u_Document_Name		
				,Parent_ID			= @u_Parent_ID	
				,VersionNumber		= @x_VersionNumber
				,IsActual			= @x_IsActual	

			where Document_ID = @u_Document_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'Document_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_Document_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
