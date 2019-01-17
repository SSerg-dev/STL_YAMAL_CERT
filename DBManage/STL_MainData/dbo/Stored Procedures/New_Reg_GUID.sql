


-- =============================================
-- Author:		RAlizade
-- Create date: 2017-09-26
-- Description:	The procedure adds a new register 
-- Changed by : RAlizade 2018-07-16 (Changes from p_Register_to_Status to p_Register_to_ABDStatus)
-- =============================================
CREATE PROCEDURE [dbo].[New_Reg_GUID]
	-- Add the parameters for the stored procedure here
	 @i_Package_ID			varchar(250),
	 @i_Status_ID			varchar(250),
	 @i_SCTR_RESP			varchar(250),
	 @i_CTR_RESP			varchar(250),
	 @i_User_Name			varchar(250),
	 @i_Row_Status			varchar(250),
	 @i_UserLanguage		varchar(250),

	 @o_Reg_ID				varchar(250) output,
	 @o_Reg_Number			varchar(250) output,
	 @o_Error_ID			varchar(250) output,
	 @o_Error_Mesage_Eng	varchar(250) output,
	 @o_Error_Mesage_Rus	varchar(250) output


AS
BEGIN

Declare @x_Identificator uniqueidentifier 
Declare @x_Error_Status integer

Declare @Cur_Date datetime

Declare @User_Sender_Name varchar(max)
Declare @User_Recipient_Name varchar(max)
Declare @MGroup Bigint
Declare @MType Bigint
Declare @MText varchar(max)
Declare @MMemo varchar(50)
Declare @Row_Status bigint
Declare @NEW_ID uniqueidentifier
Declare @NEW_RTP_ID uniqueidentifier
Declare @NEW_RTS_ID uniqueidentifier
Declare @New_REG_Number bigint

Declare @x_Count bigint 
Declare @Error_ID int

Declare @Package_ID uniqueidentifier
Declare @Package_Name varchar(250)

Declare @Reg_Status_ID uniqueidentifier
Declare @Reg_Status_Name_Eng varchar(250)
Declare @Reg_Status_Name_Rus varchar(250)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Message variables initializations
-- User language 0 - English, 1 - Russian, 2 - French
SET @User_Sender_Name = @i_User_Name
SET @User_Recipient_Name = @i_User_Name
SET @MGroup = 0 -- Message
SET @MType = 0 -- Message 


-- Data initialization 
SET @x_Error_Status = 0
SET @Error_ID = 0

SET @Cur_Date = getdate()
SET @Row_Status = 0


	-- Input data preparation

	 SET @i_Package_ID		= Ltrim(Rtrim(@i_Package_ID))
	 SET @i_Status_ID		= Ltrim(Rtrim(@i_Status_ID))
	 SET @i_SCTR_RESP		= Ltrim(Rtrim(@i_SCTR_RESP))
	 SET @i_CTR_RESP		= Ltrim(Rtrim(@i_CTR_RESP))
	 SET @i_User_Name		= Ltrim(Rtrim(@i_User_Name))
	 SET @i_Row_Status		= Ltrim(Rtrim(@i_Row_Status))
	 SET @i_UserLanguage	= Ltrim(Rtrim(@i_UserLanguage))


	-- Data check 
	-- ======== Status =========================================================
	SET @x_Identificator = Null
	SET @x_Count = 0 

	-- === Reference Row check =====
	Select @x_Count = count (*) from [dbo].[p_ABDStatus] where ABDStatus_ID = Cast(@i_Status_ID as uniqueidentifier) 

	IF @x_Count = 1
	begin
		-- === Ref Data =================
		Select @Reg_Status_ID = ABDStatus_ID, @Reg_Status_Name_Eng = Description_Eng, @Reg_Status_Name_Rus = Description_Rus 
		from [p_ABDStatus] where ABDStatus_ID = Cast(@i_Status_ID as uniqueidentifier) 
	end
	Else  
	begin
		SET @MText = 'Status does not exist!'
		IF cast(@i_UserLanguage as int) = 1 SET @MText = 'Статус не существует в справочнике!'
	    Insert into [dbo].[p_UserMessage]
		(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
		values
		(newid(), @Cur_Date, @Row_Status, @User_Sender_Name, @User_Recipient_Name, @MGroup, @MType, @MText, @MMemo)
		SET @Error_ID = 30 -- General Data Error 
		SET @x_Error_Status = @x_Error_Status + 1 
	end

	-- ======= Package =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[p_WorkPackage] where WorkPackage_ID = cast(@i_Package_ID as uniqueidentifier) 

	IF @x_Count = 1
	begin
		-- === Ref Data =================
		Select @Package_ID = WorkPackage_ID, @Package_Name = WorkPackage_Name
		from [dbo].[p_WorkPackage] where WorkPackage_ID = Cast(@i_Package_ID as uniqueidentifier) 
	end
	Else
	begin
		SET @MText = 'Package does not exist!'
		IF cast(@i_UserLanguage as Int) = 1 SET @MText = 'Пакет не существует в справочнике!'
	    Insert into [dbo].[p_UserMessage]
		(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
		values
		(newid(), @Cur_Date, @Row_Status, @User_Sender_Name, @User_Recipient_Name, @MGroup, @MType, @MText, @MMemo)
		SET @Error_ID = 30 -- General Data Error 
		SET @x_Error_Status = @x_Error_Status + 1 
	end

-- ==== Main data insert operation =======================

	IF @x_Error_Status = 0
	Begin
	 SET @x_Error_Status = @x_Error_Status
	
		SET @NEW_ID = newid()
		SET @NEW_RTP_ID = newid()
		SET @NEW_RTS_ID = newid()
		SET @New_REG_Number = NEXT VALUE FOR [dbo].[Sequence_Reg_Number];
		--  SET @Run = NEXT VALUE FOR [TestDB].[dbo].Run_Number;


		Begin Transaction WTB;
		
		Begin try

			Insert into [dbo].[p_Register]
				(Register_ID
				, Register_Number
				, Insert_DTS
				, SCTR_Resp
				, CTR_Resp
				, Update_DTS	  
				, Created_By
				, Modified_By
				, Row_Status
				, WorkPackage_ID)
		    values
				(@NEW_ID
				, cast(@New_REG_Number as varchar(100))
				, @Cur_Date
				, @i_SCTR_RESP
				, @i_CTR_RESP
				, @Cur_Date		 
				, @i_User_Name
				, @i_User_Name
				, cast(@i_Row_Status as int)
				, Cast(@i_Package_ID as uniqueidentifier));

		END TRY 
		 
		BEGIN CATCH  
			SELECT   
				ERROR_NUMBER() AS ErrorNumber  
				,ERROR_SEVERITY() AS ErrorSeverity  
				,ERROR_STATE() AS ErrorState  
				,ERROR_PROCEDURE() AS ErrorProcedure  
				,ERROR_LINE() AS ErrorLine  
				,ERROR_MESSAGE() AS ErrorMessage;  

			IF @@TRANCOUNT > 0  
				BEGIN
				ROLLBACK TRANSACTION WTB;  
				GOTO Tran_WTB_Rejected;
				END;
		END CATCH; 
		
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
				,[Modified_By])
			VALUES
				(@NEW_RTS_ID
				,NULL
				,@Cur_Date
				,NULL
				,cast(@i_Row_Status as int)
				,@NEW_ID
				,@i_Status_ID
				,@i_User_Name
				,@i_User_Name);	
		END TRY 
		
		BEGIN CATCH 
			SELECT   
				ERROR_NUMBER() AS ErrorNumber  
				,ERROR_SEVERITY() AS ErrorSeverity  
				,ERROR_STATE() AS ErrorState  
				,ERROR_PROCEDURE() AS ErrorProcedure  
				,ERROR_LINE() AS ErrorLine  
				,ERROR_MESSAGE() AS ErrorMessage;  

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
		
			SET @MText = 'Register Added! Reg Num = ' + cast(@New_REG_Number as varchar(50))
			Insert into [dbo].[p_UserMessage]
			(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
			values
			(newid(), @Cur_Date, @Row_Status, @User_Sender_Name, @User_Recipient_Name, @MGroup, @MType, @MText, @MMemo)
			END;

		--old code based on old tables 22-10-2017 ASmirnov
		/*
		begin Transaction
		 
		Insert into [dbo].[p_Register]
		(Register_ID
		  , Register_Number
		  , Created_On
		  , SCTR_Resp
		  , CTR_Resp
		  , Modified_On		  
		  , Created_By
		  , Modified_By
		  , Row_Status)
		values
		(@NEW_ID
		 , cast(@New_REG_Number as varchar(100))
		 , @Cur_Date
		 , @i_SCTR_RESP
		 , @i_CTR_RESP
		 , @Cur_Date		 
		 , @i_User_Name
		 , @i_User_Name
		 , cast(@i_Row_Status as int))

		 INSERT INTO [dbo].[p_Register_to_WorkPackage]
           ([Register_To_WorkPackage_ID]
           ,[DTS_Start]
           ,[DTS_End]
           ,[Row_status]
           ,[Register_ID]
           ,[WorkPackage_ID])
		VALUES
           (@NEW_RTP_ID
           ,@Cur_Date
           ,NULL
           ,cast(@i_Row_Status as int)
           ,@NEW_ID
           ,Cast(@i_Package_ID as uniqueidentifier))

		   INSERT INTO [dbo].[p_Register_to_ABDStatus]
           ([Register_to_ABDStatus_ID]
           ,[Parent_ID]
           ,[DTS_Start]
           ,[DTS_End]
           ,[Row_status]
           ,[Register_ID]
           ,[Status_ID]
           ,[Modified_By])
     VALUES
           (@NEW_RTS_ID
           ,NULL
           ,@Cur_Date
           ,NULL
           ,cast(@i_Row_Status as int)
           ,@NEW_ID
           ,@i_Status_ID
           ,@i_User_Name)

		 SET @MText = 'Register Added! Reg Num = ' + cast(@New_REG_Number as varchar(50))
		 Insert into [dbo].[p_UserMessage]
		(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
		values
		(newid(), @Cur_Date, @Row_Status, @User_Sender_Name, @User_Recipient_Name, @MGroup, @MType, @MText, @MMemo)
		
		Commit
	*/
	end;

	-- ====== Test message ===========================
	SET @MText = 'GUID PRC @i_Package_ID = ' + cast(@i_Package_ID as Varchar(250)) + ' @i_Status_ID = ' + cast(@i_Status_ID as Varchar(250)) + ' @i_SCTR_RESP = ' + @i_SCTR_RESP + ' @i_CTR_RESP = ' + @i_CTR_RESP + ' Row Status = ' + @i_Row_Status + ' @i_User_Name = ' + @i_User_Name;
	    

		Insert into [dbo].[p_UserMessage]
		(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
		values
		(newid(), @Cur_Date, @Row_Status, @User_Sender_Name, @User_Recipient_Name, @MGroup, @MType, @MText, @MMemo)

    -- Output parameters of the procedure 

	SET @o_Reg_ID = Ltrim(Rtrim(cast(@NEW_ID as varchar(250))))
	SET @o_Reg_Number = Ltrim(Rtrim(cast(@New_REG_Number as varchar(250))))
	SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
	SET @o_Error_Mesage_Eng = 'Test Message'
	SET @o_Error_Mesage_Rus = 'Тестовое сообщение'


END
