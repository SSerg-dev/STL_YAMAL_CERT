
-- =============================================
-- Author:		RAlizade
-- Create date: 2017-10-06
-- Description:	The procedure adds a new register 
-- Changed by : RAlizade 2018-07-16 (Changes from p_Register_to_Status to p_Register_to_ABDStatus)
-- =============================================
CREATE PROCEDURE [dbo].[Update_Reg_Status]
	-- Add the parameters for the stored procedure here
	 @i_RegisterNumber_ID	varchar(250),
--	 @i_Package_ID			varchar(250),
	 @i_Status_ID			varchar(250),

	 @i_User_Name			varchar(250),
	 @i_Row_Status			varchar(250),
	 @i_UserLanguage		varchar(250),

	 @o_Error_ID			varchar(250) output,
	 @o_Error_Mesage_Eng	varchar(250) output,
	 @o_Error_Mesage_Rus	varchar(250) output


AS
BEGIN

Declare @x_Identificator uniqueidentifier 
Declare @x_Error_Status integer

Declare @Cur_Date datetime
Declare @x_DTS datetime 
Declare @User_Sender_Name varchar(max)
Declare @User_Recipient_Name varchar(max)
Declare @MGroup Bigint
Declare @MType Bigint
Declare @MText varchar(max)
Declare @MMemo varchar(50)
Declare @Row_Status bigint
Declare @NEW_ID uniqueidentifier
Declare @New_REG_Number bigint
Declare @Reg_to_status_ID uniqueidentifier

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

	 SET @i_RegisterNumber_ID = Ltrim(Rtrim(@i_RegisterNumber_ID))
	 SET @i_Status_ID		  = Ltrim(Rtrim(@i_Status_ID))
	 SET @i_User_Name		  = Ltrim(Rtrim(@i_User_Name))
	 SET @i_Row_Status		  = Ltrim(Rtrim(@i_Row_Status))
	 SET @i_UserLanguage	  = Ltrim(Rtrim(@i_UserLanguage))


	-- Data check 
	-- ======== Status =========================================================
	SET @x_Identificator = Null
	SET @x_Count = 0 

	-- === Reference Row check =====
	Select @x_Count = count (*) from [dbo].[p_ABDStatus] where ABDStatus_ID = Cast(@i_Status_ID as uniqueidentifier) and Row_status = 0 

	IF @x_Count = 1
	begin
		-- === Ref Data =================
		Select @Reg_Status_ID = ABDStatus_ID, @Reg_Status_Name_Eng = Description_Eng, @Reg_Status_Name_Rus = Description_RUS 
		from [p_ABDStatus] where ABDStatus_ID = Cast(@i_Status_ID as uniqueidentifier) and Row_status = 0 
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

-- ==== Main data insert operation =======================

	IF @x_Error_Status = 0
	Begin
	 SET @x_Error_Status = @x_Error_Status
	
		 SET @NEW_ID = newid()
		 SET @x_DTS = getdate()
		 SET @Reg_to_status_ID = (SELECT [Register_to_ABDStatus_ID] FROM [dbo].[p_Register_to_ABDStatus] WHERE [Register_ID]=@i_RegisterNumber_ID and [Row_status] = 0 )

	 Begin Transaction MainDataOperation;
		
		Begin try

		Update p_Register_to_ABDStatus 
		set Row_status = 120, -- Status of Historical Rows
		    DTS_END = @x_DTS 
		where Register_to_ABDStatus_ID = @Reg_to_status_ID

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
				ROLLBACK TRANSACTION MainDataOperation;  
				GOTO Tran_MainDataOperation_Rejected;
				END;
		END CATCH; 

		Begin try

		Insert Into p_Register_to_ABDStatus
		(Register_to_ABDStatus_ID, Parent_ID, DTS_Start, Row_status, Register_ID, ABDSTATUS_ID, MODIFIED_BY, Created_By)
		Values
		(@New_ID, @Reg_to_status_ID, @x_DTS, 0, @i_RegisterNumber_ID,  @i_Status_ID, @i_User_Name, @i_User_Name)

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
				ROLLBACK TRANSACTION MainDataOperation;  
				GOTO Tran_MainDataOperation_Rejected;
				END;
		END CATCH; 

Tran_MainDataOperation_Rejected:

		IF @@TRANCOUNT > 0  
			COMMIT TRANSACTION MainDataOperation; 

	    --old code based on old tables 22-10-2017 ASmirnov
		/*
		Update p_Register_to_ABDStatus 
		set Row_status = 120, -- Status of Historical Rows
		    DTS_END = @x_DTS 
		where Register_to_ABDStatus_ID = @Reg_to_status_ID

		Insert Into p_Register_to_ABDStatus
		(Register_to_ABDStatus_ID, Parent_ID, DTS_Start, Row_status, Register_ID, STATUS_ID, MODIFIED_BY)
		Values
		(@New_ID, @Reg_to_status_ID, @x_DTS, 0, @i_RegisterNumber_ID,  @i_Status_ID, @i_User_Name)
	
	 Commit
	  */
	end;

	-- ====== Test message ===========================

	SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
	SET @o_Error_Mesage_Eng = 'Test Message'
	SET @o_Error_Mesage_Rus = 'Тестовое сообщение'
	


END
