
-- =============================================
-- Author: Ivan Vaskov
-- Create date: 16.08.2018
-- =============================================

CREATE procedure [dbo].[TitleObject_Update]	-- not null ->	+
(	 @i_TitleObject_ID	nvarchar(250)	-- sys param	+
	,@i_RowStatus								nvarchar(250)	-- sys param	+
	,@i_AppUser_ID								nvarchar(250)	-- sys param	+
	,@i_TitleObject_Code	nvarchar(250)	-- usr param	+
	--== place your params here ==
	,@i_TitleObject_PARENTID					nvarchar(250)	-- usr param	
	,@i_Structure								nvarchar(250)	-- usr param	
	,@i_Description_Eng							nvarchar(250)	-- usr param	
	,@i_Description_Rus							nvarchar(250)	-- usr param	
	,@i_Phase_Name								nvarchar(250)	-- usr param	
	,@i_ReportColor								nvarchar(250)	-- usr param	+
	,@i_ReportOrder								nvarchar(250)	-- usr param	+
	,@i_GLB_Weight								nvarchar(250)	-- usr param	
	,@i_Book1_Pct								nvarchar(250)	-- usr param	
	,@i_Book1_Weight							nvarchar(250)	-- usr param	
	,@i_Book2_Pct								nvarchar(250)	-- usr param	
	,@i_Book2_Weight							nvarchar(250)	-- usr param	
	,@i_Book3_Pct								nvarchar(250)	-- usr param	
	,@i_Book3_Weight							nvarchar(250)	-- usr param	
	,@i_Book4_Weight							nvarchar(250)	-- usr param	
	,@i_TitleObject_for_ABDFinalSet				nvarchar(250)	-- usr param	
	,@i_Book1_Documents_Total					nvarchar(250)	-- usr param	
	,@i_Book1_Documents_received				nvarchar(250)	-- usr param	
	,@i_Book1_Progress							nvarchar(250)	-- usr param	
	,@i_Book1_Documents_transmitted_to_CPY		nvarchar(250)	-- usr param	
	,@i_StageOfConstr							nvarchar(250)	-- usr param

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
		,@u_TitleObject_Code	nvarchar(255)		= try_cast(ltrim(rtrim(@i_TitleObject_Code))	as nvarchar(255))
		--== place your params here ==
		,@u_Parent_ID								uniqueidentifier	= try_cast(ltrim(rtrim(@i_TitleObject_PARENTID					))	as uniqueidentifier)	
		,@u_Structure								nvarchar(50)		= try_cast(ltrim(rtrim(@i_Structure								))	as nvarchar(50))
		,@u_Description_Eng							nvarchar(300)		= try_cast(ltrim(rtrim(@i_Description_Eng						))	as nvarchar(300))
		,@u_Description_Rus							nvarchar(400)		= try_cast(ltrim(rtrim(@i_Description_Rus						))	as nvarchar(400))
		,@u_Phase_Name								nvarchar(100)		= try_cast(ltrim(rtrim(@i_Phase_Name							))	as nvarchar(100))
		,@u_ReportColor								nvarchar(50)		= try_cast(ltrim(rtrim(@i_ReportColor							))	as nvarchar(50))
		,@u_ReportOrder								int					= try_cast(ltrim(rtrim(@i_ReportOrder							))	as int)
		,@u_GLB_Weight								float				= try_cast(ltrim(rtrim(@i_GLB_Weight							))	as float)
		,@u_Book1_Pct								float				= try_cast(ltrim(rtrim(@i_Book1_Pct								))	as float)
		,@u_Book1_Weight							float				= try_cast(ltrim(rtrim(@i_Book1_Weight							))	as float)
		,@u_Book2_Pct								float				= try_cast(ltrim(rtrim(@i_Book2_Pct								))	as float)
		,@u_Book2_Weight							float				= try_cast(ltrim(rtrim(@i_Book2_Weight							))	as float)
		,@u_Book3_Pct								float				= try_cast(ltrim(rtrim(@i_Book3_Pct								))	as float)
		,@u_Book3_Weight							float				= try_cast(ltrim(rtrim(@i_Book3_Weight							))	as float)
		,@u_Book4_Weight							float				= try_cast(ltrim(rtrim(@i_Book4_Weight							))	as float)
		,@u_TitleObject_for_ABDFinalSet				nvarchar(100)		= try_cast(ltrim(rtrim(@i_TitleObject_for_ABDFinalSet			))	as nvarchar(100))
		,@u_Book1_Documents_Total					float				= try_cast(ltrim(rtrim(@i_Book1_Documents_Total					))	as float)
		,@u_Book1_Documents_received				float				= try_cast(ltrim(rtrim(@i_Book1_Documents_received				))	as float)
		,@u_Book1_Progress							float				= try_cast(ltrim(rtrim(@i_Book1_Progress						))	as float)
		,@u_Book1_Documents_transmitted_to_CPY		float				= try_cast(ltrim(rtrim(@i_Book1_Documents_transmitted_to_CPY	))	as float)
		,@u_StageOfConstr							nvarchar(10)		= try_cast(ltrim(rtrim(@i_StageOfConstr							))	as nvarchar(10))

		,@u_TitleObject_ID	uniqueidentifier = try_cast(ltrim(rtrim(@i_TitleObject_ID	)) as uniqueidentifier)
	declare @e int = 0, @Cnt int = 0, @TranCount int = @@TranCount, @CntParam nvarchar(max) = N''
	-- Nested Tran
	if @TranCount = 0 begin transaction	else save transaction trn_TitleObject_Update
	-------------
	------------- Error Handling 
	-------------
	begin try
		-- Not null check and Convert check	
		if (@i_RowStatus is null ) select Id=50101, Msg=formatmessage(50101, 'RowStatus') else if (@u_RowStatus	is null ) select Id=50106, Msg=formatmessage(50106, 'RowStatus'	,try_cast(@i_RowStatus as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_AppUser_ID is null ) select Id=50101, Msg=formatmessage(50101, 'User_ID') else if (@u_Created_User_ID is null ) select Id=50108, Msg=formatmessage(50108, 'User_ID' ,try_cast(@i_AppUser_ID as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_TitleObject_ID is null ) select Id=50101, Msg=formatmessage(50101, 'TitleObject_ID' ) else if (@u_TitleObject_ID		is null ) select Id=50108, Msg=formatmessage(50108, 'TitleObject_ID' ,try_cast(@i_TitleObject_ID as nvarchar(36)));set @e=@e+@@rowcount
		if (@i_TitleObject_Code is null ) select Id=50101, Msg=formatmessage(50101, 'TitleObject_Code' ) else if (@u_TitleObject_Code	is null ) select Id=50103, Msg=formatmessage(50103, 'TitleObject_Code' ,try_cast(@i_TitleObject_Code as nvarchar(250)));set @e=@e+@@rowcount
		--== place your params here =
		if (@i_ReportColor			is null ) select Id=50101, Msg=formatmessage(50101, 'ReportColor'	)		else if (@u_ReportColor			is null ) select Id=50103, Msg=formatmessage(50103, 'ReportColor'		,try_cast(@i_ReportColor		as nvarchar(250)));set @e=@e+@@rowcount
		if (@i_ReportOrder			is null ) select Id=50101, Msg=formatmessage(50101, 'ReportOrder'	)		else if (@u_ReportOrder			is null ) select Id=50106, Msg=formatmessage(50106, 'ReportOrder'		,try_cast(@i_ReportOrder		as nvarchar(250)));set @e=@e+@@rowcount
		if (@u_Parent_ID							is null	and	@i_TitleObject_PARENTID					is not null ) select Id=50108, Msg=formatmessage(50108, 'TitleObject_PARENTID'					,try_cast(@i_TitleObject_PARENTID					as nvarchar(36)));set @e=@e+@@rowcount 			
		if (@u_Structure							is null	and	@i_Structure							is not null ) select Id=50103, Msg=formatmessage(50103, 'Structure'								,try_cast(@i_Structure								as nvarchar(250)));set @e=@e+@@rowcount 
		if (@u_Description_Eng						is null	and	@i_Description_Eng						is not null ) select Id=50103, Msg=formatmessage(50103, 'Description_Eng'						,try_cast(@i_Description_Eng						as nvarchar(250)));set @e=@e+@@rowcount 			
		if (@u_Description_Rus						is null	and	@i_Description_Rus						is not null ) select Id=50103, Msg=formatmessage(50103, 'Description_Rus'						,try_cast(@i_Description_Rus						as nvarchar(250)));set @e=@e+@@rowcount 					
		if (@u_Phase_Name							is null	and	@i_Phase_Name							is not null ) select Id=50103, Msg=formatmessage(50103, 'Phase_Name'							,try_cast(@i_Phase_Name								as nvarchar(250)));set @e=@e+@@rowcount 		
		if (@u_GLB_Weight							is null	and	@i_GLB_Weight							is not null ) select Id=50107, Msg=formatmessage(50107, 'GLB_Weight'							,try_cast(@i_GLB_Weight								as nvarchar(250)));set @e=@e+@@rowcount 				
		if (@u_Book1_Pct							is null	and	@i_Book1_Pct							is not null ) select Id=50107, Msg=formatmessage(50107, 'Book1_Pct'								,try_cast(@i_Book1_Pct								as nvarchar(250)));set @e=@e+@@rowcount		
		if (@u_Book1_Weight							is null	and	@i_Book1_Weight							is not null ) select Id=50107, Msg=formatmessage(50107, 'Book1_Weight'							,try_cast(@i_Book1_Weight							as nvarchar(250)));set @e=@e+@@rowcount	
		if (@u_Book2_Pct							is null	and	@i_Book2_Pct							is not null ) select Id=50107, Msg=formatmessage(50107, 'Book2_Pct'								,try_cast(@i_Book2_Pct								as nvarchar(250)));set @e=@e+@@rowcount 						
		if (@u_Book2_Weight							is null	and	@i_Book2_Weight 						is not null ) select Id=50107, Msg=formatmessage(50107, 'Book2_Weight '							,try_cast(@i_Book2_Weight 							as nvarchar(250)));set @e=@e+@@rowcount			
		if (@u_Book3_Pct							is null	and	@i_Book3_Pct							is not null ) select Id=50107, Msg=formatmessage(50107, 'Book3_Pct'								,try_cast(@i_Book3_Pct								as nvarchar(250)));set @e=@e+@@rowcount			
		if (@u_Book3_Weight							is null	and	@i_Book3_Weight							is not null ) select Id=50107, Msg=formatmessage(50107, 'Book3_Weight'							,try_cast(@i_Book3_Weight							as nvarchar(250)));set @e=@e+@@rowcount 					
		if (@u_Book4_Weight							is null	and	@i_Book4_Weight							is not null ) select Id=50107, Msg=formatmessage(50107, 'Book4_Weight'							,try_cast(@i_Book4_Weight							as nvarchar(250)));set @e=@e+@@rowcount			
		if (@u_TitleObject_for_ABDFinalSet			is null	and	@i_TitleObject_for_ABDFinalSet			is not null ) select Id=50103, Msg=formatmessage(50103, 'TitleObject_for_ABDFinalSet'			,try_cast(@i_TitleObject_for_ABDFinalSet			as nvarchar(250)));set @e=@e+@@rowcount			
		if (@u_Book1_Documents_Total				is null	and	@i_Book1_Documents_Total				is not null ) select Id=50107, Msg=formatmessage(50107, 'Book1_Documents_Total'					,try_cast(@i_Book1_Documents_Total					as nvarchar(250)));set @e=@e+@@rowcount 						
		if (@u_Book1_Documents_received				is null	and	@i_Book1_Documents_received				is not null ) select Id=50107, Msg=formatmessage(50107, 'Book1_Documents_received'				,try_cast(@i_Book1_Documents_received				as nvarchar(250)));set @e=@e+@@rowcount			
		if (@u_Book1_Progress						is null	and	@i_Book1_Progress						is not null ) select Id=50107, Msg=formatmessage(50107, 'Book1_Progress'						,try_cast(@i_Book1_Progress							as nvarchar(250)));set @e=@e+@@rowcount			
		if (@u_Book1_Documents_transmitted_to_CPY	is null	and	@i_Book1_Documents_transmitted_to_CPY	is not null ) select Id=50107, Msg=formatmessage(50107, 'Book1_Documents_transmitted_to_CPY'	,try_cast(@i_Book1_Documents_transmitted_to_CPY		as nvarchar(250)));set @e=@e+@@rowcount 				
		if (@u_StageOfConstr						is null	and	@i_StageOfConstr						is not null ) select Id=50103, Msg=formatmessage(50103, 'StageOfConstr'							,try_cast(@i_StageOfConstr							as nvarchar(250)));set @e=@e+@@rowcount		
		
		-- data consistency check
		select @CntParam = N'AppUser_ID="'+try_cast(@u_Created_User_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_AppUser', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'p_AppUser', try_cast(@i_AppUser_ID as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'RowStatus_ID="'+try_cast(@u_RowStatus as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_RowStatus', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'p_RowStatus', try_cast(@u_RowStatus as nvarchar(250))); set @e=@e+@@rowcount

		select @CntParam = N'TitleObject_ID="'+try_cast(@u_TitleObject_ID as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_TitleObject', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122,'TitleObject',try_cast(@u_TitleObject_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		
		select @CntParam = N'TitleObject_ID="'+try_cast(@u_TitleObject_ID as nvarchar(max))+N'",'+N'TitleObject_Code="'+try_cast(@u_TitleObject_Code as nvarchar(max))+N'"', @Cnt=-1
		exec Get_RowCount 'p_TitleObject', @CntParam, @Cnt out; if (@Cnt>0) select Id=50123, Msg=formatmessage(50123, try_cast(@u_TitleObject_Code as nvarchar(250)), 'TitleObject'); set @e=@e+@@rowcount
		--== place your params here =
		if @u_Parent_ID is not null
		begin
			select @CntParam = N'TitleObject_ID="'+try_cast(@u_Parent_ID as nvarchar(max))+N'"', @Cnt=-1
			exec Get_RowCount 'p_TitleObject', @CntParam, @Cnt out; if (@Cnt<=0) select Id=50122, Msg=formatmessage(50122, 'Parent_ID', try_cast(@u_Parent_ID as NVARCHAR(36))); set @e=@e+@@rowcount
		end

	end try	begin catch	
		select Id=50100, Msg=formatmessage(50100, N'TitleObject_Update.Check', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
					,TitleObject_Code
					--== place your params here =
					,Parent_ID				
					,Structure							
					,Description_Eng					
					,Description_Rus					
					,Phase_Name							
					,ReportColor						
					,ReportOrder						
					,GLB_Weight							
					,Book1_Pct							
					,Book1_Weight						
					,Book2_Pct							
					,Book2_Weight						
					,Book3_Pct							
					,Book3_Weight						
					,Book4_Weight						
					,TitleObject_for_ABDFinalSet		
					,Book1_Documents_Total				
					,Book1_Documents_received			
					,Book1_Progress						
					,Book1_Documents_transmitted_to_CPY	
					,StageOfConstr						

					from dbo.p_TitleObject
					where TitleObject_ID = @u_TitleObject_ID and RowStatus < 100
				) x
			) a
			join
			(select binary_checksum(*) x from
				(select 
					  RowStatus   = @u_RowStatus
					 ,TitleObject_Code  = @u_TitleObject_Code
					 --== place your params here =
					 ,Parent_ID								= @u_Parent_ID							
					 ,Structure								= @u_Structure								
					 ,Description_Eng						= @u_Description_Eng					
					 ,Description_Rus						= @u_Description_Rus					
					 ,Phase_Name							= @u_Phase_Name						
					 ,ReportColor							= @u_ReportColor						
					 ,ReportOrder							= @u_ReportOrder						
					 ,GLB_Weight							= @u_GLB_Weight						
					 ,Book1_Pct								= @u_Book1_Pct							
					 ,Book1_Weight							= @u_Book1_Weight						
					 ,Book2_Pct								= @u_Book2_Pct							
					 ,Book2_Weight							= @u_Book2_Weight						
					 ,Book3_Pct								= @u_Book3_Pct							
					 ,Book3_Weight							= @u_Book3_Weight						
					 ,Book4_Weight							= @u_Book4_Weight						
					 ,TitleObject_for_ABDFinalSet			= @u_TitleObject_for_ABDFinalSet		
					 ,Book1_Documents_Total					= @u_Book1_Documents_Total				
					 ,Book1_Documents_received				= @u_Book1_Documents_received			
					 ,Book1_Progress						= @u_Book1_Progress					
					 ,Book1_Documents_transmitted_to_CPY	= @u_Book1_Documents_transmitted_to_CPY
					 ,StageOfConstr							= @u_StageOfConstr						
				) x				  
			) b	on a.x = b.x
		)
	begin
		-- TitleObject
		if (@e = 0) begin try
			update dbo.p_TitleObject set
				 RowStatus	  = @u_RowStatus	 
				,Update_DTS	  = @u_Update_DTS	 
				,Modified_User_ID  = @u_Modified_User_ID
				,TitleObject_Code	= @u_TitleObject_Code
				--== place your params here = 
				 ,Parent_ID								= @u_Parent_ID							
				 ,Structure								= @u_Structure								
				 ,Description_Eng						= @u_Description_Eng					
				 ,Description_Rus						= @u_Description_Rus					
				 ,Phase_Name							= @u_Phase_Name						
				 ,ReportColor							= @u_ReportColor						
				 ,ReportOrder							= @u_ReportOrder						
				 ,GLB_Weight							= @u_GLB_Weight						
				 ,Book1_Pct								= @u_Book1_Pct							
				 ,Book1_Weight							= @u_Book1_Weight						
				 ,Book2_Pct								= @u_Book2_Pct							
				 ,Book2_Weight							= @u_Book2_Weight						
				 ,Book3_Pct								= @u_Book3_Pct							
				 ,Book3_Weight							= @u_Book3_Weight						
				 ,Book4_Weight							= @u_Book4_Weight						
				 ,TitleObject_for_ABDFinalSet			= @u_TitleObject_for_ABDFinalSet		
				 ,Book1_Documents_Total					= @u_Book1_Documents_Total				
				 ,Book1_Documents_received				= @u_Book1_Documents_received			
				 ,Book1_Progress						= @u_Book1_Progress					
				 ,Book1_Documents_transmitted_to_CPY	= @u_Book1_Documents_transmitted_to_CPY
				 ,StageOfConstr							= @u_StageOfConstr

			where TitleObject_ID = @u_TitleObject_ID
		end try begin catch 
			select Id=50100, Msg=formatmessage(50100, N'TitleObject_Update.Update', error_message()); set @e=@e+@@rowcount; -- Unhandled Eror
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
		if @xstate = 1 and @TranCount > 0 rollback transaction trn_TitleObject_Update	-- rollback if transaction was created outside and this procedure creates only save point
	end
	-- Output parameters of the procedure 
	if @e > 0 set @o_IsError = 1 else set @o_IsError = 0
	-- Even if no error appears, the empty rowset shall be returned to ensure that the caller procedure handles the error via @@rowcount correctly
	-- Put this code in each procedure returning Multiple_Error_Dataset
	if @e = 0 select Id=try_cast(null as int), Msg=try_cast(null as nvarchaR(max)) where 1=2
end
