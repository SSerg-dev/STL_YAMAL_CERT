
-- =============================================
-- Author: RAlizade 
-- Create date: 2018-08-31
-- =============================================

create procedure dbo.Marka_Update	-- not null ->	+
(	 @i_Marka_ID				nvarchar(250)	-- sys param	+
	,@i_RowStatus				nvarchar(250)	-- sys param	+
	,@i_AppUser_ID				nvarchar(250)	-- sys param	+
	,@i_Marka_Code				nvarchar(250)	-- usr param	+
	--== place your params here ==
    ,@i_Marka_Code_Eng					nvarchar(250)
    ,@i_Description_Eng					nvarchar(250)
    ,@i_Description_Rus					nvarchar(250)
    ,@i_Engineering_Drawing_Type_Eng	nvarchar(250)
    ,@i_Engineering_Drawing_Type_Rus	nvarchar(250)
    ,@i_IsUsedInMatrix					nvarchar(250)
    ,@i_IsPriority						nvarchar(250)
    ,@i_ReportColor						nvarchar(250)
    ,@i_ReportOrder						nvarchar(250)
	-- ---------------------------
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
		,@u_Marka_Code	nvarchar(255)		= try_cast(ltrim(rtrim(@i_Marka_Code))	as nvarchar(255))
		--== place your params here ==
		,@u_Marka_Code_Eng							nvarchar(255)		= try_cast(ltrim(rtrim(@i_Marka_Code_Eng	))	as nvarchar(255))
		,@u_Description_Eng							nvarchar(255)		= try_cast(ltrim(rtrim(@i_Description_Eng	))	as nvarchar(255))
		,@u_Description_Rus							nvarchar(255)		= try_cast(ltrim(rtrim(@i_Description_Rus	))	as nvarchar(255))
		,@u_Engineering_Drawing_Type_Eng			nvarchar(255)		= try_cast(ltrim(rtrim(@i_Engineering_Drawing_Type_Eng	))	as nvarchar(255))
		,@u_Engineering_Drawing_Type_Rus			nvarchar(255)		= try_cast(ltrim(rtrim(@i_Engineering_Drawing_Type_Rus	))	as nvarchar(255))
		,@u_IsUsedInMatrix							nvarchar(255)		= try_cast(ltrim(rtrim(@i_IsUsedInMatrix	))	as nvarchar(255))
		,@u_IsPriority								nvarchar(255)		= try_cast(ltrim(rtrim(@i_IsPriority		))	as nvarchar(255))
		,@u_ReportColor								nvarchar(255)		= try_cast(ltrim(rtrim(@i_ReportColor		))	as nvarchar(255))
		,@u_ReportOrder								nvarchar(255)		= try_cast(ltrim(rtrim(@i_ReportOrder		))	as nvarchar(255))
		-- ---------------------------
		,@u_Marka_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_Marka_ID	)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_Marka_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus') else if (@u_RowStatus	is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID') else if (@u_Created_User_ID is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID' ,try_cast(@i_AppUser_ID as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Marka_ID is null ) select Id=50101, Msg=formatmessage(50101, 'Marka_ID' ) else if (@u_Marka_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'Marka_ID' ,try_cast(@i_Marka_ID as nvarchar(36)));set @e=@e+@@rowcount
		if (@i_Marka_Code is null ) select Id=50101, Msg=formatmessage(50101, 'Marka_Code' ) else if (@u_Marka_Code	is null ) select Id=50103, Msg=formatmessage(50103, 'Marka_Code' ,try_cast(@i_Marka_Code as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'Marka_ID="'+try_cast(@u_Marka_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Marka', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Marka',try_cast(@u_Marka_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		select @CntParam = N'Marka_ID="'+try_cast(@u_Marka_ID as nvarchar(max))+N'",'+N'Marka_Code="'+try_cast(@u_Marka_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Marka', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_Marka_Code as nvarchar(250)), 'Marka'); set @e=@e+@@rowcount
		--== place your params here =

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'Marka_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,Marka_Code
					--== place your params here =
				  ,Marka_Code_Eng
				  ,Description_Eng
				  ,Description_Rus
				  ,Engineering_Drawing_Type_Eng
				  ,Engineering_Drawing_Type_Rus
				  ,IsUsedInMatrix
				  ,IsPriority
				  ,ReportColor
				  ,ReportOrder
					-- --------------------------
					from dbo.p_Marka
					where Marka_ID = @u_Marka_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					  RowStatus   = @u_RowStatus
					 ,Marka_Code  = @u_Marka_Code
					 --== place your params here =
					,Marka_Code_Eng = @u_Marka_Code_Eng					
					,Description_Eng = @u_Description_Eng					
					,Description_Rus = @u_Description_Rus					
					,Engineering_Drawing_Type_Eng = @u_Engineering_Drawing_Type_Eng	
					,Engineering_Drawing_Type_Rus = @u_Engineering_Drawing_Type_Rus	
					,IsUsedInMatrix = @u_IsUsedInMatrix					
					,IsPriority	 = @u_IsPriority						
					,ReportColor = @u_ReportColor						
					,ReportOrder = @u_ReportOrder						
					 -- --------------------------
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- Marka
		if (@e = 0) begin try
			update dbo.p_Marka set
				 RowStatus	  = @u_RowStatus	 
				,Update_DTS	  = @u_Update_DTS	 
				,Modified_User_ID  = @u_Modified_User_ID
				,Marka_Code	= @u_Marka_Code
				--== place your params here =
				,Marka_Code_Eng = @u_Marka_Code_Eng					
				,Description_Eng = @u_Description_Eng					
				,Description_Rus = @u_Description_Rus					
				,Engineering_Drawing_Type_Eng = @u_Engineering_Drawing_Type_Eng	
				,Engineering_Drawing_Type_Rus = @u_Engineering_Drawing_Type_Rus	
				,IsUsedInMatrix = @u_IsUsedInMatrix					
				,IsPriority	 = @u_IsPriority						
				,ReportColor = @u_ReportColor						
				,ReportOrder = @u_ReportOrder					 
				-- --------------------------
			where Marka_ID = @u_Marka_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'Marka_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_Marka_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
