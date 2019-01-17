



-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-12-28
-- Description:	The procedure adds a new register 
-- Changed by : RAlizade 2018-07-16 (Changes from p_Register_to_Status to p_Register_to_ABDStatus)
-- =============================================
CREATE PROCEDURE [dbo].[New_Register]
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
	 @i_New_REG_Number 		nvarchar(250),  
	 @i_Source       		nvarchar(250),  

	 @o_Reg_ID				nvarchar(250) OUTPUT,
	 @o_Reg_Number			nvarchar(250) OUTPUT,
	 @o_Error_ID			nvarchar(250) OUTPUT,
	 @o_Error_Mesage    	nvarchar(250) OUTPUT

AS
BEGIN

Declare @Cur_Date datetime

	   ,@MText nvarchar(max)
	   ,@NEW_ID uniqueidentifier
	   ,@NEW_RTP_ID uniqueidentifier
	   ,@NEW_RTS_ID uniqueidentifier
	   ,@NEW_RTT_ID uniqueidentifier
	   ,@NEW_RTM_ID uniqueidentifier
	   ,@CNT_Date datetime2(7)
	   ,@ABDStatusDate datetime2(7)

	   ,@x_Count bigint 
	   ,@Error_ID int

	   ,@WorkPackage_ID uniqueidentifier
	   ,@WorkPackage_Name nvarchar(250)

	   ,@ABDStatus_ID uniqueidentifier
	   ,@Reg_Status_Name_Eng nvarchar(250)
	   ,@Reg_Status_Name_Rus nvarchar(250)

	   ,@Phase_ID uniqueidentifier
	   ,@Phase_Name int

	   ,@TitleObject_ID uniqueidentifier
	   ,@TitleObject_Name nvarchar(250)

	   ,@Marka_ID uniqueidentifier 
	   ,@Marka_Name nvarchar(250) 

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
	 SET @i_New_REG_Number  = Ltrim(Rtrim(@i_New_REG_Number))
	 SET @i_Source			= Ltrim(Rtrim(@i_Source))
	 
	-- Data check 
	-- ======== Status =========================================================
	SET @x_Count = 0 

	-- === Incomeing Date checking ==============
	IF TRY_CONVERT(datetime2(7),@i_CNT_Date) is null
	BEGIN
		SET @MText = N'Date handed over to Contractor error!'
		IF TRY_cast(@i_UserLanguage as int) = 1 SET @MText = N'Дата передачи подрядчику некорректна!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END
	ELSE
	BEGIN
		SET @CNT_Date = CONVERT(datetime2(7),@i_CNT_Date) 	
	END

	IF TRY_CONVERT(datetime2(7),@i_ABDStatusDate) is null
	BEGIN
		SET @MText = N'Date current status started error!'
		IF TRY_cast(@i_UserLanguage as int) = 1 SET @MText = N'Дата начала текщего статуса некорректна!'
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
		Select @ABDStatus_ID = ABDStatus_ID, @Reg_Status_Name_Eng = Description_Eng, @Reg_Status_Name_Rus = Description_Rus 
		from [ABDStatus] where ABDStatus_ID = TRY_Cast(@i_ABDStatus_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1  
	begin
		SET @MText = N'Status does not exist!'
		IF TRY_cast(@i_UserLanguage as int) = 1 SET @MText = N'Статус не существует в справочнике!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= WorkPackage =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[WorkPackage] where WorkPackage_ID = TRY_cast(@i_WorkPackage_ID as uniqueidentifier) 

	IF @x_Count = 1 and @i_WorkPackage_ID is not null 
	begin
		-- === Ref Data =================
		Select @WorkPackage_ID = WorkPackage_ID, @WorkPackage_Name = WorkPackage_Name
		from [dbo].[WorkPackage] where WorkPackage_ID = TRY_Cast(@i_WorkPackage_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1 and @i_WorkPackage_ID is not null 
	begin
		SET @MText = N'WorkPackage does not exist!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = N'Пакет работ не существует в справочнике!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= Phase =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[Phase] where Phase_ID = TRY_cast(@i_Phase_ID as uniqueidentifier) 

	IF @x_Count = 1 and @i_Phase_ID is not null 
	begin
		-- === Ref Data =================
		Select @Phase_ID = Phase_ID, @Phase_Name = Phase_Name
		from [dbo].[Phase] where Phase_ID = TRY_Cast(@i_Phase_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1 and @i_Phase_ID is not null 
	begin
		SET @MText = N'Phase does not exist!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = N'Фаза не существует в справочнике!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= TitleObject =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[TitleObject] where TitleObject_ID = TRY_cast(@i_TitleObject_ID as uniqueidentifier) 

	IF @x_Count = 1 and @i_TitleObject_ID is not null 
	begin
		-- === Ref Data =================
		Select @TitleObject_ID = TitleObject_ID, @TitleObject_Name = TitleObject_Name
		from [dbo].[TitleObject] where TitleObject_ID = TRY_Cast(@i_TitleObject_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1 and @i_TitleObject_ID is not null 
	begin
		SET @MText = N'Title object does not exist!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = N'Титульный объект не существует в справочнике!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= Marka =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[Marka] where Marka_ID = TRY_cast(@i_Marka_ID as uniqueidentifier) 

	IF @x_Count = 1 and @i_Marka_ID is not null
	begin
		-- === Ref Data =================
		Select @Marka_ID = Marka_ID, @Marka_Name = Marka_Name
		from [dbo].[Marka] where Marka_ID = TRY_Cast(@i_Marka_ID as uniqueidentifier) 
	end
	Else IF @x_Count <> 1 and @i_Marka_ID is not null 
	begin
		SET @MText = N'Marka does not exist!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = N'Марка не существует в справочнике!'
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
		SET @MText = N'Wrong RowStatus!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = N'Ошибка статуса строки!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- === Is New Register is Unique =============
	
	IF @i_New_REG_Number  is null or @i_New_REG_Number  = ''
	BEGIN
		SET @MText = 'Register number is incorrect!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Некорректный номер реестра!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END 
	
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[p_Register] where Register_Number = @i_New_REG_Number and FileLOG = @i_Source

	IF @x_Count > 0
	BEGIN
		SET @MText = N'Такой номер реестра уже есть в базе!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = N'That register number allredy exists!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END

-- ==== Main data insert operation =======================

		SET @NEW_ID = newid()
		SET @NEW_RTP_ID = newid()
		SET @NEW_RTS_ID = newid()
		SET @NEW_RTT_ID = newid()
		SET @NEW_RTM_ID = newid()

		Begin Transaction WTB;
	
		-- ====Register Insertion ====
		Begin try
			Insert into [dbo].[p_Register]
				(Register_ID
				, LOG_ID
				, Register_Number
				, FileLOG
				, Insert_DTS
				, CNT_Date
				, SCTR_Resp
				, CTR_Resp
				, Update_DTS	  
				, Created_By
				, Modified_By
				, Row_Status
				, WorkPackage_ID
				, Work_Desc
				, Notes)
		    values
				(@NEW_ID
				, @i_LogID
				, TRY_cast(@i_New_REG_Number as nvarchar(100))
				, @i_Source
				, @Cur_Date
				, @CNT_Date
				, @i_SCTR_RESP
				, @i_CTR_RESP
				, @Cur_Date		 
				, @i_User_Name
				, @i_User_Name
				, TRY_cast(@i_Row_Status as int)
				, TRY_Cast(@i_WorkPackage_ID as uniqueidentifier)
				, @i_Work_desc
				, @I_Notes);
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

		-- ====Register_to_ABDStatus Insertion ====	
		If @i_ABDStatus_ID is not null
		BEGIN	
			Begin try
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
					,@NEW_ID
					,@ABDStatus_ID
					,@i_User_Name
					,@i_User_Name
					,@ABDStatusDate
					,@Cur_Date
					,@Cur_Date );	
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
		-- ====Register_to_TitleObject Insertion ====
		If @i_TitleObject_ID is not null
		BEGIN
			Begin try
				INSERT INTO [dbo].[p_Register_to_TitleObject]
					([Register_To_TitleObject_ID]
					,[Row_status]
					,[Register_ID]
					,[TitleObject_ID]
					,[Created_By]
					,[Modified_By]
					,[Insert_DTS]
					,[Update_DTS])
				VALUES
					(@NEW_RTT_ID
					,TRY_cast(@i_Row_Status as int)
					,@NEW_ID
					,@TitleObject_ID
					,@i_User_Name
					,@i_User_Name
					,@Cur_Date
					,@Cur_Date);	
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
		-- ====Register_to_Marka Insertion ====
		If @i_Marka_ID is not null
		BEGIN
			Begin try
				INSERT INTO [dbo].[p_Register_to_Marka]
					([Register_To_Marka_ID]
					,[Row_status]
					,[Register_ID]
					,[Marka_ID]
					,[Created_By]
					,[Modified_By]
					,[Insert_DTS]
					,[Update_DTS])
				VALUES
					(@NEW_RTM_ID
					,TRY_cast(@i_Row_Status as int)
					,@NEW_ID
					,@Marka_ID
					,@i_User_Name
					,@i_User_Name
					,@Cur_Date
					,@Cur_Date);	
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
		
Tran_WTB_Rejected: --all catched errors in WTB transaction lead here	

		IF @@TRANCOUNT > 0 
			BEGIN
			  
			COMMIT TRANSACTION WTB; 
		
			END;

    -- Output parameters of the procedure 
DataErrorWay: --all data checkig errors lead here

	SET @o_Reg_ID = Ltrim(Rtrim(TRY_cast(@NEW_ID as nvarchar(250))))
	SET @o_Reg_Number = Ltrim(Rtrim(TRY_cast(@i_New_REG_Number as nvarchar(250))))
	SET @o_Error_ID = Ltrim(Rtrim(TRY_cast(@Error_ID as nvarchar(250))))
	SET @o_Error_Mesage = Ltrim(Rtrim(TRY_cast(@MText as nvarchar(250))))

END
