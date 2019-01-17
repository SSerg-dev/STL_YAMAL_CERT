


-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-12-29
-- Description:	The procedure updates register 
-- Changed by : RAlizade 2018-07-16 (Changes from p_Register_to_Status to p_Register_to_ABDStatus)
-- =============================================
CREATE PROCEDURE [dbo].[Update_Register]
	-- Add the parameters for the stored procedure here
	 @i_LogId				nvarchar(250),
	 @i_Phase_ID			nvarchar(250),
	 @i_TitleObject_ID		nvarchar(250),
	 @i_ISO_ID				nvarchar(250),
	 @i_Module_ID			nvarchar(250),
	 @i_Marka_ID            nvarchar(250),
	 @i_Work_Desc           nvarchar(4000),
	 @i_CNT_Date            nvarchar(250),
	 @i_SCTR_RESP			nvarchar(250),
	 @i_CTR_RESP			nvarchar(250),
	 @i_ABDStatusDate       nvarchar(250),
	 @i_ABDStatus_ID        nvarchar(250),
	 @i_Notes               nvarchar(4000),
	 @i_User_Name			nvarchar(250),
	 @i_Row_Status			nvarchar(250),
	 @i_UserLanguage		nvarchar(250),
	 @i_WorkPackage_ID		nvarchar(250),
	 @i_Register_ID			nvarchar(250),
	 @i_REG_Number 			nvarchar(250),  
	 @i_Source       		nvarchar(250),  

	 @o_Reg_ID				nvarchar(250) OUTPUT,
	 @o_Reg_Number			nvarchar(250) OUTPUT,
	 @o_Error_ID			nvarchar(250) OUTPUT,
	 @o_Error_Mesage    	nvarchar(250) OUTPUT

AS
BEGIN

Declare @u_LogId 						nvarchar(250)
	   ,@u_Phase_ID 					uniqueidentifier
	   ,@u_TitleObject_ID				uniqueidentifier
	   ,@u_ISO_ID						uniqueidentifier
	   ,@u_Module_ID					uniqueidentifier
	   ,@u_Marka_ID						uniqueidentifier
	   ,@u_Work_Desc					nvarchar(4000)
	   ,@u_CNT_Date 					datetime2(7)
	   ,@u_SCTR_RESP 					nvarchar(250)
	   ,@u_CTR_RESP 					nvarchar(250)
	   ,@u_ABDStatusDate 				datetime2(7)
	   ,@u_ABDStatus_ID 				uniqueidentifier
	   ,@u_Notes 						nvarchar(4000)
	   ,@u_User_Name 					nvarchar(250)
	   ,@u_Row_Status					bigint
	   ,@u_Register_ID					uniqueidentifier
	   ,@u_WorkPackage_ID 				uniqueidentifier
	   ,@u_REG_Number 					nvarchar(100)  
	   ,@u_Source    					nvarchar(50)
	   ,@u_Register_to_TitleObject_ID	uniqueidentifier
	   ,@u_Register_to_Marka_ID			uniqueidentifier
	   ,@u_Register_to_ABDStatus_ID		uniqueidentifier

	   ,@Cur_Date			datetime
	   ,@MText				nvarchar(max)
	   ,@NEW_RTP_ID			uniqueidentifier
	   ,@NEW_RTS_ID			uniqueidentifier
	   ,@NEW_RTT_ID			uniqueidentifier
	   ,@NEW_RTM_ID			uniqueidentifier
	   ,@CNT_Date			datetime2(7)
	   ,@ABDStatusDate		datetime2(7)
	   ,@ABDStatus_ID		uniqueidentifier
	   ,@WorkPackage_ID		uniqueidentifier
	   ,@Phase_ID			uniqueidentifier
	   ,@TitleObject_ID		uniqueidentifier
	   ,@Marka_ID			uniqueidentifier 

	   ,@x_Count			bigint
	   ,@Error_ID			int 

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Message variables initializations
-- User language 0 - English, 1 - Russian

-- Data initialization 
SET @Error_ID = 0
SET @Cur_Date = getdate()

	-- Input data preparation
	 SET @i_LogId			= Ltrim(Rtrim(@i_LogId))
	 SET @i_SCTR_RESP		= Ltrim(Rtrim(@i_SCTR_RESP))
	 SET @i_CTR_RESP		= Ltrim(Rtrim(@i_CTR_RESP))
	 SET @i_Work_Desc 		= Ltrim(Rtrim(@i_Work_Desc))
	 SET @i_Notes 			= Ltrim(Rtrim(@i_Notes))
	 SET @i_REG_Number		= Ltrim(Rtrim(@i_REG_Number))
	 SET @i_Source			= Ltrim(Rtrim(@i_Source))

	 	-- Data check 
	-- ======== Status =========================================================
	SET @x_Count = 0 

	-- === Incomeing Date checking ==============
	IF TRY_CONVERT(datetime2(7),@i_CNT_Date) is null
	BEGIN
		SET @MText = 'Date handed over to Contractor error!'
		IF TRY_cast(@i_UserLanguage as int) = 1 SET @MText = 'Дата передачи подрядчику некорректна!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END
	ELSE
	BEGIN
		SET @CNT_Date = CONVERT(datetime2(7),@i_CNT_Date) 	
	END

	IF TRY_CONVERT(datetime2(7),@i_ABDStatusDate) is null
	BEGIN
		SET @MText = 'Date current status started error!'
		IF TRY_cast(@i_UserLanguage as int) = 1 SET @MText = 'Дата начала текщего статуса некорректна!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END
	ELSE
	BEGIN
		SET @ABDStatusDate = CONVERT(datetime2(7),@i_ABDStatusDate) 	
	END

	-- === ABDStatus =====
	Select @x_Count = count (*) from [dbo].[Status] where ABDStatus_ID = TRY_Cast(@i_ABDStatus_ID as uniqueidentifier) 

	IF @x_Count = 1 
	begin
		-- === Ref Data =================
		Select @ABDStatus_ID = ABDStatus_ID
		from [ABDStatus] where ABDStatus_ID = TRY_Cast(@i_ABDStatus_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1   
	begin
		SET @MText = 'Status does not exist!'
		IF TRY_cast(@i_UserLanguage as int) = 1 SET @MText = 'Статус не существует в справочнике!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= WorkPackage =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[WorkPackage] where WorkPackage_ID = TRY_cast(@i_WorkPackage_ID as uniqueidentifier) 

	IF @x_Count = 1 and @i_WorkPackage_ID is not null 
	begin
		-- === Ref Data =================
		Select @WorkPackage_ID = WorkPackage_ID
		from [dbo].[WorkPackage] where WorkPackage_ID = TRY_Cast(@i_WorkPackage_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1 and @i_WorkPackage_ID is not null 
	begin
		SET @MText = 'WorkPackage does not exist!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Пакет работ не существует в справочнике!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= Phase =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[Phase] where Phase_ID = TRY_cast(@i_Phase_ID as uniqueidentifier) 

	IF @x_Count = 1 and @i_Phase_ID is not null 
	begin
		-- === Ref Data =================
		Select @Phase_ID = Phase_ID
		from [dbo].[Phase] where Phase_ID = TRY_Cast(@i_Phase_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1 and @i_Phase_ID is not null 
	begin
		SET @MText = 'Phase does not exist!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Фаза не существует в справочнике!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= TitleObject =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[TitleObject] where TitleObject_ID = TRY_cast(@i_TitleObject_ID as uniqueidentifier) 

	IF @x_Count = 1 and @i_TitleObject_ID is not null 
	begin
		-- === Ref Data =================
		Select @TitleObject_ID = TitleObject_ID
		from [dbo].[TitleObject] where TitleObject_ID = TRY_Cast(@i_TitleObject_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1 and @i_TitleObject_ID is not null 
	begin
		SET @MText = 'Title object does not exist!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Титульный объект не существует в справочнике!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= Marka =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[Marka] where Marka_ID = TRY_cast(@i_Marka_ID as uniqueidentifier) 

	IF @x_Count = 1 and @i_Marka_ID is not null
	begin
		-- === Ref Data =================
		Select @Marka_ID = Marka_ID
		from [dbo].[Marka] where Marka_ID = TRY_Cast(@i_Marka_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1 and @i_Marka_ID is not null 
	begin
		SET @MText = 'Marka does not exist!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Марка не существует в справочнике!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= ISO/Module =======================================================

	--must be there

	-- ======= RowStatus =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[RowStatus_sys] where Row_Status = TRY_cast(@i_Row_Status as int) 

	IF @x_Count <> 1
	begin
		SET @MText = 'Wrong RowStatus!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Ошибка статуса строки!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= Register_ID =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[Register] where Register_ID = TRY_cast(@i_Register_ID as uniqueidentifier) 

	IF @x_Count != 1 
	begin
		SET @MText = 'Register_ID not found!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'GUID реестра не найден!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- === Is Register number is not null not empty and it is Unique =============

	IF @i_REG_Number is null or @i_REG_Number = ''
	BEGIN
		SET @MText = 'Register number is incorrect!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Некорректный номер реестра!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END 

	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[p_Register] where Register_Number = @i_REG_Number and FileLOG = @i_Source and Register_ID <> TRY_CAST(@i_Register_ID as uniqueidentifier)

	IF @x_Count > 0
	BEGIN
		SET @MText = 'That register number allredy exists!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Такой номер реестра уже есть в базе!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END

	-- === Data consistency checking =====

	SET @x_Count = 0 
	SELECT @x_Count = count(*)
	FROM dbo.Register AS r 
	LEFT OUTER JOIN dbo.Register_to_TitleObject AS rtt ON rtt.Register_ID = r.Register_ID 
	LEFT OUTER JOIN dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID 
	LEFT OUTER JOIN dbo.Register_to_Marka AS rtm ON rtm.Register_ID = r.Register_ID 
	LEFT OUTER JOIN dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID 
	LEFT OUTER JOIN dbo.Register_to_ABDStatus AS rts ON rts.Register_ID = r.Register_ID 
	LEFT OUTER JOIN dbo.Status AS s ON rts.ABDStatus_ID = s.ABDSTATUS_ID
	WHERE r.Register_ID = TRY_CAST(@i_Register_ID as uniqueidentifier)

	IF @x_Count > 1
	BEGIN
		SET @MText = 'Ошибка согласованности данных в базе!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Data consistency error!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END

-- ==== Checking for Changed Data ====		

	SELECT  @u_LogId					  = r.LOG_ID	
		   ,@u_Work_Desc				  = r.Work_Desc
		   ,@u_CNT_Date 				  = r.CNT_Date
		   ,@u_SCTR_RESP 				  = r.SCTR_RESP
		   ,@u_CTR_RESP 				  = r.CTR_RESP
		   ,@u_Notes 					  = r.Notes
		   ,@u_WorkPackage_ID 			  = r.WorkPackage_ID
		   ,@u_REG_Number 				  = r.Register_Number
		   ,@u_Source					  = r.FileLOG		
		   ,@u_Phase_ID 				  = null
		   ,@u_TitleObject_ID			  = t.TitleObject_ID	
		   ,@u_ISO_ID					  = null
		   ,@u_Module_ID				  = null
		   ,@u_Marka_ID					  = m.Marka_ID
		   ,@u_ABDStatusDate 			  = rts.ABDStatusDate
		   ,@u_ABDStatus_ID 			  = s.ABDSTATUS_ID
		   ,@u_Register_to_TitleObject_ID = rtt.Register_to_TitleObject_ID 	
		   ,@u_Register_to_Marka_ID		  = rtm.Register_to_Marka_ID		
	       ,@u_Register_to_ABDStatus_ID	  = rts.Register_to_ABDStatus_ID		
	FROM dbo.Register AS r 
	LEFT OUTER JOIN dbo.Register_to_TitleObject AS rtt ON rtt.Register_ID = r.Register_ID 
	LEFT OUTER JOIN dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID 
	LEFT OUTER JOIN dbo.Register_to_Marka AS rtm ON rtm.Register_ID = r.Register_ID 
	LEFT OUTER JOIN dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID 
	LEFT OUTER JOIN dbo.Register_to_ABDStatus AS rts ON rts.Register_ID = r.Register_ID 
	LEFT OUTER JOIN dbo.Status AS s ON rts.ABDStatus_ID = s.ABDSTATUS_ID
	WHERE r.Register_ID = @i_Register_ID


-- ==== Main data insert operation =======================

		SET @NEW_RTP_ID = newid()
		SET @NEW_RTS_ID = newid()
		SET @NEW_RTT_ID = newid()
		SET @NEW_RTM_ID = newid()

		Begin Transaction WTB;
	
		-- ====Register Update ====
		IF  @u_LogId			!= @i_LogId 
		 or	@u_Work_Desc		!= @i_Work_Desc
		 or	@u_CNT_Date			!= @i_CNT_Date 
		 or	@u_SCTR_RESP		!= @i_SCTR_RESP 
		 or	@u_CTR_RESP			!= @i_CTR_RESP 
		 or	@u_Notes			!= @i_Notes 
		 or	@u_WorkPackage_ID	!= @WorkPackage_ID 
		 or	@u_REG_Number		!= @i_REG_Number 
		 or	@u_Source			!= @i_Source 	
		BEGIN
			Begin try
				Update [dbo].[p_Register]
				set LOG_ID			= @i_LogID
				  , Work_Desc		= @i_Work_desc
				  , CNT_Date		= @CNT_Date
				  , SCTR_Resp		= @i_SCTR_RESP
				  , CTR_Resp		= @i_CTR_RESP
				  , Notes			= @i_Notes
				  , WorkPackage_ID	= TRY_Cast(@i_WorkPackage_ID as uniqueidentifier)
				  , Register_Number	= TRY_cast(@i_REG_Number as nvarchar(100))
				  , FileLOG			= TRY_cast(@i_Source as nvarchar(50))
				  , Update_DTS		= @Cur_Date 
				  , Modified_By		= @i_User_Name
				Where Register_ID = TRY_cast(@i_Register_ID as uniqueidentifier);
			END TRY 
		 
			BEGIN CATCH  
				SET @Error_ID = ERROR_NUMBER()
				SET @MText = ERROR_MESSAGE()

				IF @@TRANCOUNT > 0  
					BEGIN
					ROLLBACK TRANSACTION WTB;  
					GOTO Tran_WTB_Rejected;
					END;
			END CATCH; 
		END;

		-- ====Register_to_ABDStatus Update ====
		Begin try
		IF @i_ABDStatus_ID is not null and @u_Register_to_ABDStatus_ID is null --New Connection
		BEGIN
			INSERT INTO [dbo].[p_Register_to_ABDStatus]
					([Register_to_ABDStatus_ID]
					,[Parent_ID]
					,[DTS_Start]
					,[DTS_End]
					,[Row_status]
					,[Register_ID]
					,[ABDStatus_ID]
					,[Created_By]
					,[Modified_By]
					,[ABDStatusDate]
					,[Insert_DTS]
					,[Update_DTS]
					)
				VALUES
					(@NEW_RTS_ID
					,NULL
					,@Cur_Date
					,NULL
					,TRY_cast(@i_Row_Status as int)
					,@i_Register_ID
					,@ABDStatus_ID
					,@i_User_Name
					,@i_User_Name
					,@ABDStatusDate
					,@Cur_Date
					,@Cur_Date );	
		END
		ELSE IF  @i_ABDStatus_ID is not null and @u_Register_to_ABDStatus_ID is not null 
		    and (@ABDStatus_ID != @u_ABDStatus_ID or @ABDStatusDate != @u_ABDStatusDate) -- Row is need to be updated
		BEGIN
			UPDATE [dbo].[p_Register_to_ABDStatus]
			   SET ABDStatus_ID		= @ABDStatus_ID
			     , ABDStatusDate	= @ABDStatusDate
				 , Update_DTS		= @Cur_Date
				 , Modified_By		= @i_User_Name
			WHERE Row_Status = 0 and Register_to_ABDStatus_ID = @u_Register_to_ABDStatus_ID 
		END
		ELSE -- Data is not changed
		BEGIN
			SET @x_Count = @x_Count --notheing to be done there
		END;
		END TRY 
		 
		BEGIN CATCH  
			SET @Error_ID = ERROR_NUMBER()
			SET @MText = ERROR_MESSAGE()

			IF @@TRANCOUNT > 0  
				BEGIN
				ROLLBACK TRANSACTION WTB;  
				GOTO Tran_WTB_Rejected;
				END;
		END CATCH; 			

		-- ====Register_to_TitleObject Update ====
		Begin try
		IF @i_TitleObject_ID is not null and @u_Register_To_TitleObject_ID is null --New Connection
		BEGIN
			INSERT INTO [dbo].[p_Register_to_TitleObject]
					([Register_To_TitleObject_ID]
					,[Row_status]
					,[Register_ID]
					,[TitleObject_ID]
					,[Created_By]
					,[Modified_By]
					,[Insert_DTS]
					,[Update_DTS]
					)
				VALUES
					(@NEW_RTT_ID
					,TRY_cast(@i_Row_Status as int)
					,@i_Register_ID
					,@i_TitleObject_ID
					,@i_User_Name
					,@i_User_Name
					,@Cur_Date
					,@Cur_Date );	
		END
		ELSE IF @i_TitleObject_ID is null and @u_Register_To_TitleObject_ID is not null -- Delete(row_status 200) existing connection
		BEGIN
			DELETE 
			FROM [dbo].[p_Register_to_TitleObject]
			WHERE Row_Status = 0 and Register_To_TitleObject_ID = @u_Register_To_TitleObject_ID 
		END
		ELSE IF @i_TitleObject_ID is not null and @u_Register_To_TitleObject_ID is not null 
		    and @TitleObject_ID != @u_TitleObject_ID -- Row is need to be updated
		BEGIN
			UPDATE [dbo].[p_Register_to_TitleObject]
			   SET TitleObject_ID	= @TitleObject_ID
			     , Update_DTS		= @Cur_Date
				 , Modified_By		= @i_User_Name
			WHERE Row_Status = 0 and Register_To_TitleObject_ID = @u_Register_To_TitleObject_ID 
		END
		ELSE -- Data is not changed
		BEGIN
			SET @x_Count = @x_Count --notheing to be done there
		END;
		END TRY 
		 
		BEGIN CATCH  
			SET @Error_ID = ERROR_NUMBER()
			SET @MText = ERROR_MESSAGE()

			IF @@TRANCOUNT > 0  
				BEGIN
				ROLLBACK TRANSACTION WTB;  
				GOTO Tran_WTB_Rejected;
				END;
		END CATCH; 			

		-- ====Register_to_Marka Update ====
		Begin try
		IF @i_Marka_ID is not null and @u_Register_To_Marka_ID is null --New Connection
		BEGIN
			INSERT INTO [dbo].[p_Register_to_Marka]
					([Register_To_Marka_ID]
					,[Row_status]
					,[Register_ID]
					,[Marka_ID]
					,[Created_By]
					,[Modified_By]
					,[Insert_DTS]
					,[Update_DTS]
					)
				VALUES
					(@NEW_RTM_ID
					,TRY_cast(@i_Row_Status as int)
					,@i_Register_ID
					,@i_Marka_ID
					,@i_User_Name
					,@i_User_Name
					,@Cur_Date
					,@Cur_Date );	
		END
		ELSE IF @i_Marka_ID is null and @u_Register_To_Marka_ID is not null -- Delete(row_status 200) existing connection
		BEGIN
			DELETE 
			FROM [dbo].[p_Register_to_Marka]
			WHERE Row_Status = 0 and Register_To_Marka_ID = @u_Register_To_Marka_ID 
		END
		ELSE IF @i_Marka_ID is not null and @u_Register_To_Marka_ID is not null 
		    and @Marka_ID != @u_Marka_ID -- Row is need to be updated
		BEGIN
			UPDATE [dbo].[p_Register_to_Marka]
			   SET Marka_ID			= @Marka_ID
			     , Update_DTS		= @Cur_Date
				 , Modified_By		= @i_User_Name
			WHERE Row_Status = 0 and Register_To_Marka_ID = @u_Register_To_Marka_ID 
		END
		ELSE -- Data is not changed
		BEGIN
			SET @x_Count = @x_Count --notheing to be done there
		END;
		END TRY 
		 
		BEGIN CATCH  
			SET @Error_ID = ERROR_NUMBER()
			SET @MText = ERROR_MESSAGE() 

			IF @@TRANCOUNT > 0  
				BEGIN
				ROLLBACK TRANSACTION WTB;  
				GOTO Tran_WTB_Rejected;
				END;
		END CATCH;
		
Tran_WTB_Rejected: --all catched errors in WTB transaction lead here	

		IF @@TRANCOUNT > 0 
			BEGIN
			  
			COMMIT TRANSACTION WTB; 
		
			END;

    -- Output parameters of the procedure 
DataErrorWay: --all data checkig errors lead here

	SET @o_Reg_ID = Ltrim(Rtrim(TRY_cast(@i_Register_ID as nvarchar(250))))
	SET @o_Reg_Number = Ltrim(Rtrim(TRY_cast(@i_REG_Number as nvarchar(250))))
	SET @o_Error_ID = Ltrim(Rtrim(TRY_cast(@Error_ID as nvarchar(250))))
	SET @o_Error_Mesage = Ltrim(Rtrim(TRY_cast(@MText as nvarchar(250))))

END
