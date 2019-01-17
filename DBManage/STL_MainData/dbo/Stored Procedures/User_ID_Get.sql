
-- =============================================
-- Author:		RAlizade
-- Create date: 2018-01-16
-- Description:	The Procedure determines and sends back User_ID by user's Domain Name  
-- =============================================
CREATE PROCEDURE [dbo].[User_ID_Get] 
	-- Add the parameters for the stored procedure here

	 @i_User_Name			varchar(250),
	 @i_Row_Status			varchar(250),
	 @i_UserLanguage		varchar(250),

	 @o_User_ID				varchar(250) output,

	 @o_Error_ID			varchar(250) output,
	 @o_Error_Mesage_Eng	varchar(250) output,
	 @o_Error_Mesage_Rus	varchar(250) output

AS
BEGIN

-- ===== Global variables ===========
Declare @x_Identificator uniqueidentifier 
Declare @x_User_ID uniqueidentifier 
Declare @x_Error_Status integer
Declare @Cur_Date datetime

Declare @x_Count bigint 
Declare @Error_ID int

Declare @Row_Status bigint

-- Data initialization 
SET @x_Error_Status = 0
SET @Error_ID = 0

SET @o_Error_Mesage_Eng = ''
SET @o_Error_Mesage_Rus = ''

SET @Cur_Date = getdate()

SET @o_User_ID = Null

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select  @x_User_ID = [USER_ID] from dbo.[User] where [User_Domain_Name] = @i_User_Name  

	IF @x_User_ID IS not NUll  SET @o_User_ID = @x_User_ID
	Else
	begin
	-- Output parameters of the procedure 
		SET @Error_ID = 100
		SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
		SET @o_Error_Mesage_Eng = 'The DB User does not exist'
		SET @o_Error_Mesage_Rus = 'Пользователь - не существует'
	End  

END
