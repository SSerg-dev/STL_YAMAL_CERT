
-- =============================================
-- Author:		RAlizade
-- Create date: 2017-09-29
-- Description:	The procedure counts all message of a given user
-- =============================================
CREATE PROCEDURE [dbo].[User_MessageList_Check] 
	-- Add the parameters for the stored procedure here

	 @i_Group				varchar(250),   -- Group of messages that should be dropped
	 @i_User_Name			varchar(250),

	 @o_Message_Count		varchar(250) output,
	 @o_Error_ID			varchar(250) output,
	 @o_Error_Mesage_Eng	varchar(250) output,
	 @o_Error_Mesage_Rus	varchar(250) output

AS
BEGIN
-- ===== Global variables ===========
Declare @Error_ID int
Declare @Message_Count bigint
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Data preparation
	SET @i_Group = LTRIM(Rtrim(@i_Group))
	SET @i_User_Name = LTRIM(Rtrim(@i_User_Name))

	SET @Error_ID = 0

	Select @Message_Count = Count(*) from [dbo].[UserMessage] 
	where User_Recipient_Name = @i_User_Name
	and [Group]= cast(@i_Group as bigint)


	SET @o_Message_Count = LTrim(Rtrim(cast(@Message_Count as varchar(250))))
	SET @o_Error_ID = Ltrim(Rtrim(cast(@Error_ID as varchar(250))))
	SET @o_Error_Mesage_Eng = 'Test Message'
	SET @o_Error_Mesage_Rus = 'Тестовое сообщение'

    -- Insert statements for procedure here
	-- SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
END
