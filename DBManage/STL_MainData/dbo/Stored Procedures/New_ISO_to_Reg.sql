-- =============================================
-- Author:		RAlizade
-- Create date: 2017-09-28
-- Description:	The procedure makes assosiation of the ISO and the register
-- =============================================
CREATE PROCEDURE [dbo].[New_ISO_to_Reg] 
	-- Add the parameters for the stored procedure here
	 @i_RegisterNumber_ID	varchar(250),
     @i_IsometricNumber_ID  varchar(250),
     @i_Package_ID			varchar(250),     
     @i_PipingWorkType_ID		varchar(250),
  
	 @i_User_Name			varchar(250),
	 @i_Row_Status			varchar(250),
	 @i_UserLanguage		varchar(250),

	 @o_ISO_To_Action_ID	varchar(250) output,
	 @o_Error_ID			varchar(250) output,
	 @o_Error_Mesage_Eng	varchar(250) output,
	 @o_Error_Mesage_Rus	varchar(250) output


AS
BEGIN
-- ===== Global variables ===========
Declare @x_Identificator uniqueidentifier 
Declare @x_Error_Status integer
Declare @Cur_Date datetime

Declare @x_Count bigint 
Declare @Error_ID int

Declare @User_Sender_Name varchar(max)
Declare @User_Recipient_Name varchar(max)
Declare @MGroup Bigint
Declare @MType Bigint
Declare @MText varchar(max)
Declare @MMemo varchar(50)
Declare @Row_Status bigint
Declare @NEW_ID uniqueidentifier

Declare @ISO_Number varchar(250)
-- ===== Local variables ===========



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Data initialization 
SET @x_Error_Status = 0
SET @Error_ID = 0

SET @MGroup = 30 -- General errors for the user
SET @Cur_Date = getdate()
SET @Row_Status = 0

SET @MGroup = 30

	-- Input data preparation
	 SET @i_RegisterNumber_ID	= Ltrim(Rtrim(@i_RegisterNumber_ID))
	 SET @i_IsometricNumber_ID	= Ltrim(Rtrim(@i_IsometricNumber_ID))
	 SET @i_Package_ID			= Ltrim(Rtrim(@i_Package_ID))
	 SET @i_PipingWorkType_ID	= Ltrim(Rtrim(@i_PipingWorkType_ID))

	 SET @i_User_Name			= Ltrim(Rtrim(@i_User_Name))
	 SET @i_Row_Status			= Ltrim(Rtrim(@i_Row_Status))
	 SET @i_UserLanguage		= Ltrim(Rtrim(@i_UserLanguage))

	-- Input Data check 
	-- ======== Register =========================================================
	SET @x_Identificator = Null
	SET @x_Count = 0 

	-- === Reference Row check =====
	Select @x_Count = count (*) from [dbo].[p_Register] where Register_ID = Cast(@i_RegisterNumber_ID as uniqueidentifier) and Row_Status = 0 

	IF @x_Count <> 1
	begin
		SET @MText = 'Register does not exist!'
		IF cast(@i_UserLanguage as int) = 1 SET @MText = 'Реестр не существует в справочнике!'

        EXEC [dbo].[User_Message_Set] 

				@i_MGroup = "30",	
				@i_MType  = "0",
				@i_MText  = @MText,
				@i_MMemo  = NULL,
									
				@i_User_Name = @i_User_Name,
				@i_Row_Status = "0",
				@i_UserLanguage = @i_UserLanguage,

				@o_Error_ID = 	@o_Error_ID,	
				@o_Error_Mesage_Eng = @o_Error_Mesage_Eng,
				@o_Error_Mesage_Rus = @o_Error_Mesage_Rus	

	    Insert into [dbo].[p_UserMessage]
		(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
		values
		(newid(), @Cur_Date, @Row_Status, @User_Sender_Name, @User_Recipient_Name, @MGroup, @MType, @MText, @MMemo)
		SET @Error_ID = 30 -- General Data Error 
		SET @x_Error_Status = @x_Error_Status + 1 
	end

	-- ======== ISO =========================================================
	SET @x_Identificator = Null
	SET @x_Count = 0 

	-- === Reference Row check =====
	Select @x_Count = count (*) from [dbo].[p_ISO] where ISO_ID = Cast(@i_IsometricNumber_ID as uniqueidentifier) and Row_Status = 0  

	IF @x_Count = 1
	begin
		Select @ISO_Number = ISO_NUMBER from [dbo].[p_ISO] where ISO_ID = Cast(@i_IsometricNumber_ID as uniqueidentifier) and Row_Status = 0 
	end
	Else
	begin
		SET @MText = 'Isometrics does not exist!'
		IF cast(@i_UserLanguage as int) = 1 SET @MText = 'Изометрия - не существует в справочнике!'
	    Insert into [dbo].[p_UserMessage]
		(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
		values
		(newid(), @Cur_Date, @Row_Status, @User_Sender_Name, @User_Recipient_Name, @MGroup, @MType, @MText, @MMemo)
		SET @Error_ID = 30 -- General Data Error 
		SET @x_Error_Status = @x_Error_Status + 1 
	end

	-- ======= Package =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[p_WorkPackage] where WorkPackage_ID = cast(@i_Package_ID as uniqueidentifier) and Row_Status = 0  

	IF @x_Count <> 1
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

	-- ======= Type of Work =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[p_PipingWorkType] where PipingWorkType_ID = cast(@i_PipingWorkType_ID as uniqueidentifier) and Row_Status = 0  

	IF @x_Count <> 1
	begin
		SET @MText = 'Type of Work does not exist!'
		IF cast(@i_UserLanguage as Int) = 1 SET @MText = 'Вид работ - не существует в справочнике!'
	    Insert into [dbo].[p_UserMessage]
		(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
		values
		(newid(), @Cur_Date, @Row_Status, @User_Sender_Name, @User_Recipient_Name, @MGroup, @MType, @MText, @MMemo)
		SET @Error_ID = 30 -- General Data Error 
		SET @x_Error_Status = @x_Error_Status + 1 
	end

	-- ======= Data Consistency Check ========================

	IF @x_Error_Status = 0
	begin
		SET @x_Count = 0 
		SELECT @x_Count = count(*) 
		FROM [dbo].[p_RegisterAction] as ra
		inner join [dbo].[p_Register] as r on r.[Register_ID] = ra.[Register_ID]
		where r.[Register_ID] = Cast(@i_RegisterNumber_ID as uniqueidentifier) 
		and r.[WorkPackage_ID] = Cast(@i_Package_ID as uniqueidentifier) 
		and ra.[ISO_ID] = Cast(@i_IsometricNumber_ID as uniqueidentifier)
		and ra.[PipingWorkType_ID] = Cast(@i_PipingWorkType_ID as uniqueidentifier) 
		and r.[Row_Status] = 0 and ra.[Row_Status] = 0 	


		IF @x_Count > 0 
		begin
			SET @Error_ID = 40 -- Data Consistency Error 
			SET @x_Error_Status = @x_Error_Status + 1

			SET @MText = 'ISO: '+ @ISO_Number + ' - Data Consistency Error'
			IF cast(@i_UserLanguage as Int) = 1 SET @MText = 'ISO: '+ @ISO_Number + 'Указанная комбинация - уже существует!'

			   EXEC [dbo].[User_Message_Set] 

				@i_MGroup = "30",	
				@i_MType  = "0",
				@i_MText  = @MText,
				@i_MMemo  = NULL,
									
				@i_User_Name = @i_User_Name,
				@i_Row_Status = "0",
				@i_UserLanguage = @i_UserLanguage,

				@o_Error_ID = 	@o_Error_ID,	
				@o_Error_Mesage_Eng = @o_Error_Mesage_Eng,
				@o_Error_Mesage_Rus = @o_Error_Mesage_Rus

			/*
			Insert into [dbo].[p_UserMessage]
			(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
			values
			(newid(), @Cur_Date, @Row_Status, @User_Sender_Name, @User_Recipient_Name, @MGroup, @MType, @MText, @MMemo)
			*/

		end
    end

	-- ==== Main data insert operation =======================

	IF @x_Error_Status = 0
	Begin
	 -- SET @x_Error_Status = @x_Error_Status

		SET @NEW_ID = newid()
		-- SET @NEW_ID_str = newid() --cast ()
		
		Begin Transaction MainDataOperation;
		
		Begin try

		INSERT INTO [dbo].[p_RegisterAction]
           ([RegisterAction_ID]
           ,[Register_ID]
           ,[PipingWorkType_ID]
           ,[ISO_ID]
           ,[DTS_Strat]
           ,[DTS_End]
           ,[Row_Status]
           ,[Insert_DTS]
           ,[Update_DTS]
           ,[Created_By]
           ,[Modified_By])
		VALUES
           (@NEW_ID
           ,cast(@i_RegisterNumber_ID as uniqueidentifier)
           ,cast(@i_PipingWorkType_ID as uniqueidentifier)
           ,cast(@i_IsometricNumber_ID as uniqueidentifier)
           ,@Cur_Date
           ,NULL
           ,cast(@i_Row_Status as int)
           ,@Cur_Date
           ,@Cur_Date
           ,@i_User_Name
           ,@i_User_Name)

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
				ROLLBACK TRANSACTION MainDataOperation;  

		END CATCH; 

		IF @@TRANCOUNT > 0  
			COMMIT TRANSACTION MainDataOperation; 
	end;
		--old code based on old tables 22-10-2017 ASmirnov
		/*
		Insert into [dbo].[p_ISO_to_Action]
		(ISO_to_Action_ID, RegisterNumber_ID,
		IsometricNumber_ID, 
		Package_ID, 
		PipingWorkType_ID,
		Insert_DTS, Update_DTS, 
		CREATED_BY, MODIFIED_BY, 
		Row_Status)
		values
		(@NEW_ID, cast(@i_RegisterNumber_ID as uniqueidentifier), 
		cast(@i_IsometricNumber_ID as uniqueidentifier), 
		cast(@i_Package_ID as uniqueidentifier),
		cast(@i_PipingWorkType_ID as uniqueidentifier),
		@Cur_Date, @Cur_Date,
		@i_User_Name, @i_User_Name, 
		cast(@i_Row_Status as int))

    End
	*/
	    -- Output parameters of the procedure 

	SET @o_ISO_To_Action_ID = Ltrim(Rtrim(cast(@NEW_ID as varchar(250))))
	SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
	SET @o_Error_Mesage_Eng = 'Test Message'
	SET @o_Error_Mesage_Rus = 'Тестовое сообщение'


END