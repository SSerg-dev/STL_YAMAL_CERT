

-- =============================================
-- Author:		RAlizade
-- Create date: 2018-01-16
-- Description:	The Procedure writes a message 
-- in the user messaage Log  
-- =============================================
CREATE PROCEDURE [dbo].[UserTaskLog_Insert] 
	-- Add the parameters for the stored procedure here
	
	 @i_UserTask_ID			varchar(250),
	 @i_UserTaskMessage_ID	varchar(250),
	 @i_FilePath			varchar(250),
	 @i_FileName			varchar(250),
	 @i_Description_Eng		varchar(250),
	 @i_Description_Rus		varchar(250),

	 @i_User_ID				varchar(250),
	 @i_Row_Status			varchar(250),
	 @i_UserLanguage		varchar(250),

	 @o_DB_New_ID			varchar(250) output,

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

Declare @Row_Status bigint

Declare @Reference_Error int
Declare @User_Error int

-- Data initialization 
SET @x_Error_Status = 0
SET @Error_ID = 0

SET @Cur_Date = getdate()

SET @User_Error = 0
SET @Reference_Error = 0

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- @i_User_ID

    Select	@x_Count = count(User_ID) from dbo.[User] where [User_ID] = @i_User_ID 
	If	@x_Count = 0  SET @User_Error = @User_Error + 1 

	Select	@x_Count = count(UserTask_ID) from dbo.UserTask where UserTask_ID = @i_UserTask_ID 
	If	@x_Count = 0  SET @Reference_Error = @Reference_Error + 1  

	IF @i_UserTaskMessage_ID IS NOT NULL
	begin
		Select	@x_Count = count(UserTaskMessage_ID) from dbo.UserTaskMessage where UserTaskMessage_ID = @i_UserTaskMessage_ID 
		If	@x_Count = 0  SET @Reference_Error = @Reference_Error + 1  
	end 


	IF @Reference_Error + @User_Error = 0 
		Begin

		SET @o_DB_New_ID = NEWID()

			Insert into [dbo].[p_UserTaskLog]
			(UserTaskLog_ID, Insert_DTS, Update_DTS, Row_Status, [User_ID], [UserTask_ID], [UserTaskMessage_ID], 
			[FilePath], [FileName], [Description_Eng], [Description_Rus])
			values
			(@o_DB_New_ID, @Cur_Date, @Cur_Date, cast(@i_Row_Status as bigint), @i_User_ID, @i_UserTask_ID, @i_UserTaskMessage_ID,
			 @i_FilePath, @i_FileName, @i_Description_Eng, @i_Description_Rus)

			 -- Output parameters of the procedure
			SET @Error_ID = 0 -- User ID Error 
			SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
			SET @o_Error_Mesage_Eng = ''
			SET @o_Error_Mesage_Rus = ''

		End
	Else
		Begin
			 -- Output parameters of the procedure 
			IF @User_Error <> 0 
			begin
				SET @Error_ID = 10 -- User ID Error 
				SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
				SET @o_Error_Mesage_Eng = 'User ID Error'
				SET @o_Error_Mesage_Rus = 'Ошибка идентификации пользователя'
			end

			IF @Reference_Error <> 0 
			begin			
				SET @Error_ID = 50 -- Refernce Error 
				SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
				SET @o_Error_Mesage_Eng = 'Reference Error'
				SET @o_Error_Mesage_Rus = 'Ошибка идентификаторов справочников'
			End
		End

END
