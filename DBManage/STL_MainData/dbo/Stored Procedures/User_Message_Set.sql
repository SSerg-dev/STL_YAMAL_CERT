-- =============================================
-- Author:		RAlizade
-- Create date: 2017-09-29
-- Description:	The Procedure writes a user messaage  
-- =============================================
CREATE PROCEDURE [dbo].[User_Message_Set] 
	-- Add the parameters for the stored procedure here
	 @i_MGroup				varchar(250),
	 @i_MType				varchar(250),
	 @i_MText				varchar(250),
	 @i_MMemo				varchar(250),

	 @i_User_Name			varchar(250),
	 @i_Row_Status			varchar(250),
	 @i_UserLanguage		varchar(250),

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

-- Data initialization 
SET @x_Error_Status = 0
SET @Error_ID = 0

SET @Cur_Date = getdate()

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


		Insert into [dbo].[p_UserMessage]
		(UserMessage_ID, DTS, Row_Status, User_Sender_Name, User_Recipient_Name, [Group], [Type], [Text], Memo)
		values
		(newid(), @Cur_Date, cast(@i_Row_Status as bigint), @i_User_Name, @i_User_Name, 
		cast(@i_MGroup as bigint), cast(@i_MType as bigint), @i_MText, @i_MMemo)

	 -- Output parameters of the procedure 

	SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
	SET @o_Error_Mesage_Eng = 'Test Message'
	SET @o_Error_Mesage_Rus = 'Тестовое сообщение'


END
