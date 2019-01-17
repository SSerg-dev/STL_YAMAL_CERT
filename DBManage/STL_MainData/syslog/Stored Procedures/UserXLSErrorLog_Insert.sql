

-- =============================================
-- Author:		RAlizade
-- Create date: 2018-01-17
-- Description:	The Procedure writes an XLS message 
-- with a detailed information for the UserTaskLog  
-- =============================================
CREATE PROCEDURE [syslog].[UserXLSErrorLog_Insert] 
	-- Add the parameters for the stored procedure here
	
	 @i_UserTaskLog_ID			varchar(250),
	 @i_Sheet_Name				varchar(250),
	 @i_Column_Number			varchar(250),
	 @i_Row_Number				varchar(250),
	 @i_Cell_Value				varchar(250),
	 @i_ErrorDescription_Eng	varchar(250),
	 @i_ErrorDescription_Rus	varchar(250),

	 @i_User_ID					varchar(250),
	 @i_Row_Status				varchar(250),
	 @i_UserLanguage			varchar(250),

	 @o_DB_New_ID				varchar(250) output,

	 @o_Error_ID				varchar(250) output,
	 @o_Error_Message_Eng		varchar(250) output,
	 @o_Error_Message_Rus		varchar(250) output

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

    Select	@x_Count = count(User_ID) from syslog.[User] where [User_ID] = @i_User_ID 
	If	@x_Count = 0  SET @User_Error = @User_Error + 1 

	Select	@x_Count = count(UserTaskLog_ID) from syslog.UserTaskLog where UserTaskLog_ID = @i_UserTaskLog_ID 
	If	@x_Count = 0  SET @Reference_Error = @Reference_Error + 1  


	IF @Reference_Error + @User_Error = 0 
		Begin

		SET @o_DB_New_ID = NEWID()

			Insert into [syslog].[p_UserXLSErrorLog]
			(UserXLSErrorLog_ID, Insert_DTS, Update_DTS, Row_Status, [User_ID], [UserTaskLog_ID], [Sheet_Name], 
			Column_Number, [Row_Number], [Cell_Value], [ErrorDescriptiuon_Eng], [ErrorDescriptiuon_Rus])
			values
			(@o_DB_New_ID, @Cur_Date, @Cur_Date, cast(@i_Row_Status as bigint), @i_User_ID, @i_UserTaskLog_ID, @i_Sheet_Name,
			 @i_Column_Number, @i_Row_Number, @i_Cell_Value, @i_ErrorDescription_Eng, @i_ErrorDescription_Rus)

			 -- Output parameters of the procedure
			SET @Error_ID = 0 -- User ID Error 
			SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
			SET @o_Error_Message_Eng = ''
			SET @o_Error_Message_Rus = ''

		End
	Else
		Begin
			 -- Output parameters of the procedure 
			IF @User_Error <> 0 
			begin
				SET @Error_ID = 10 -- User ID Error 
				SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
				SET @o_Error_Message_Eng = 'User ID Error'
				SET @o_Error_Message_Rus = 'Ошибка идентификации пользователя'
			end

			IF @Reference_Error <> 0 
			begin			
				SET @Error_ID = 50 -- Refernce Error 
				SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
				SET @o_Error_Message_Eng = 'Reference Error'
				SET @o_Error_Message_Rus = 'Ошибка идентификаторов справочников'
			End
		End

END
