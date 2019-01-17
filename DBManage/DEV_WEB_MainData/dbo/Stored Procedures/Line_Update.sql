

-- =============================================
-- Author: RAlizade
-- Create date: 2018-08-31
-- =============================================

CREATE procedure [dbo].[Line_Update]	-- not null ->	+
(	 @i_Line_ID									nvarchar(250)	-- sys param	+
	,@i_RowStatus								nvarchar(250)	-- sys param	+
	,@i_AppUser_ID								nvarchar(250)	-- sys param	+
	,@i_Line_Code								nvarchar(250)	-- usr param	+
	--== place your params here ==
	,@i_Location_From							nvarchar(250)
	,@i_Location_To								nvarchar(250)
	,@i_Fluid_Name_Eng							nvarchar(250)
	,@i_Fluid_Name_Rus							nvarchar(250)
	,@i_Fluid_Danger_Code_By_Gost				nvarchar(250)
	,@i_Fluid_Fire_Aand_Explosive_Hazard		nvarchar(250)
	,@i_Fluid_Group_By_TP_TC_032_2013			nvarchar(250)
	,@i_Fluid_Group_By_GOST_32569_2013			nvarchar(250)
	,@i_Pipeline_Category_By_GOST_32569_2013	nvarchar(250)
	,@i_Piprline_Category_By_TP_TC_032_2013		nvarchar(250)
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
		,@u_Created_User_ID							uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID))	as uniqueidentifier)
		,@u_Modified_User_ID						uniqueidentifier	= try_cast(ltrim(rtrim(@i_AppUser_ID))	as uniqueidentifier)
		,@u_Insert_DTS								datetime2(7)		= try_cast(getdate()					as datetime2(7))
		,@u_Update_DTS								datetime2(7)		= try_cast(getdate()					as datetime2(7))
		,@u_Line_Code								nvarchar(255)		= try_cast(ltrim(rtrim(@i_Line_Code))	as nvarchar(255))
		--== place your params here ==
		,@u_Location_From							nvarchar(255)		= try_cast(ltrim(rtrim(@i_Location_From							))	as nvarchar(255))	
		,@u_Location_To								nvarchar(255)		= try_cast(ltrim(rtrim(@i_Location_To							))	as nvarchar(255))
		,@u_Fluid_Name_Eng							nvarchar(255)		= try_cast(ltrim(rtrim(@i_Fluid_Name_Eng						))	as nvarchar(255))
		,@u_Fluid_Name_Rus							nvarchar(255)		= try_cast(ltrim(rtrim(@i_Fluid_Name_Rus						))	as nvarchar(255))
		,@u_Fluid_Danger_Code_By_Gost				nvarchar(255)		= try_cast(ltrim(rtrim(@i_Fluid_Danger_Code_By_Gost				))	as nvarchar(255))
		,@u_Fluid_Fire_Aand_Explosive_Hazard		nvarchar(255)		= try_cast(ltrim(rtrim(@i_Fluid_Fire_Aand_Explosive_Hazard		))	as nvarchar(255))
		,@u_Fluid_Group_By_TP_TC_032_2013			nvarchar(255)		= try_cast(ltrim(rtrim(@i_Fluid_Group_By_TP_TC_032_2013			))	as nvarchar(255))
		,@u_Fluid_Group_By_GOST_32569_2013			nvarchar(255)		= try_cast(ltrim(rtrim(@i_Fluid_Group_By_GOST_32569_2013		))	as nvarchar(255))
		,@u_Pipeline_Category_By_GOST_32569_2013	nvarchar(255)		= try_cast(ltrim(rtrim(@i_Pipeline_Category_By_GOST_32569_2013	))	as nvarchar(255))
		,@u_Piprline_Category_By_TP_TC_032_2013		nvarchar(255)		= try_cast(ltrim(rtrim(@i_Piprline_Category_By_TP_TC_032_2013	))	as nvarchar(255))
	
		-- ---------------------------
		,@u_Line_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_Line_ID	)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@trancount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @trancount = 0 begin transaction	else save transaction trn_Line_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus') else if (@u_RowStatus	is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID') else if (@u_Created_User_ID is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID' ,try_cast(@i_AppUser_ID as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_Line_ID is null ) select Id=50101, Msg=formatmessage(50101, 'Line_ID' ) else if (@u_Line_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'Line_ID' ,try_cast(@i_Line_ID as nvarchar(36)));set @e=@e+@@rowcount
		if (@i_Line_Code is null ) select Id=50101, Msg=formatmessage(50101, 'Line_Code' ) else if (@u_Line_Code	is null ) select Id=50103, Msg=formatmessage(50103, 'Line_Code' ,try_cast(@i_Line_Code as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =

		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as NVARCHAR(50))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as NVARCHAR(50))); set @e=@e+@@rowcount

		select @CntParam = N'Line_ID="'+try_cast(@u_Line_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Line', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'Line',try_cast(@u_Line_ID as NVARCHAR(50))); set @e=@e+@@rowcount
		
		select @CntParam = N'Line_ID="'+try_cast(@u_Line_ID as nvarchar(max))+N'",'+N'Line_Code="'+try_cast(@u_Line_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_Line', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_Line_Code as nvarchar(250)), 'Line'); set @e=@e+@@rowcount
		--== place your params here =

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'Line_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,Line_Code
					--== place your params here =
					,Location_From
					,Location_To
					,Fluid_Name_Eng
					,Fluid_Name_Rus
					,Fluid_Danger_Code_By_Gost
					,Fluid_Fire_Aand_Explosive_Hazard
					,Fluid_Group_By_TP_TC_032_2013
					,Fluid_Group_By_GOST_32569_2013
					,Pipeline_Category_By_GOST_32569_2013
					,Piprline_Category_By_TP_TC_032_2013
					-- --------------------------
					from dbo.p_Line
					where Line_ID = @u_Line_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					  RowStatus   = @u_RowStatus
					 ,Line_Code  = @u_Line_Code
					 --== place your params here =
					  ,Location_From = @u_Location_From
					  ,Location_To = @u_Location_To
					  ,Fluid_Name_Eng = @u_Fluid_Name_Eng
					  ,Fluid_Name_Rus = @u_Fluid_Name_Rus
					  ,Fluid_Danger_Code_By_Gost = @u_Fluid_Danger_Code_By_Gost
					  ,Fluid_Fire_Aand_Explosive_Hazard = @u_Fluid_Fire_Aand_Explosive_Hazard
					  ,Fluid_Group_By_TP_TC_032_2013 = @u_Fluid_Group_By_TP_TC_032_2013
					  ,Fluid_Group_By_GOST_32569_2013 = @u_Fluid_Group_By_GOST_32569_2013
					  ,Pipeline_Category_By_GOST_32569_2013 = @u_Pipeline_Category_By_GOST_32569_2013
					  ,Piprline_Category_By_TP_TC_032_2013  = @u_Piprline_Category_By_TP_TC_032_2013
					-- ---------------------------
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- Line
		if (@e = 0) begin try
			update dbo.p_Line set
				 RowStatus	  = @u_RowStatus	 
				,Update_DTS	  = @u_Update_DTS	 
				,Modified_User_ID  = @u_Modified_User_ID
				,Line_Code	= @u_Line_Code
				--== place your params here =
				,Location_From = @u_Location_From
				,Location_To = @u_Location_To
				,Fluid_Name_Eng = @u_Fluid_Name_Eng
				,Fluid_Name_Rus = @u_Fluid_Name_Rus
				,Fluid_Danger_Code_By_Gost = @u_Fluid_Danger_Code_By_Gost
				,Fluid_Fire_Aand_Explosive_Hazard = @u_Fluid_Fire_Aand_Explosive_Hazard
				,Fluid_Group_By_TP_TC_032_2013 = @u_Fluid_Group_By_TP_TC_032_2013
				,Fluid_Group_By_GOST_32569_2013 = @u_Fluid_Group_By_GOST_32569_2013
				,Pipeline_Category_By_GOST_32569_2013 = @u_Pipeline_Category_By_GOST_32569_2013
				,Piprline_Category_By_TP_TC_032_2013  = @u_Piprline_Category_By_TP_TC_032_2013				 
				-- --------------------------
			where Line_ID = @u_Line_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'Line_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @trancount > 0 rollback transaction trn_Line_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
