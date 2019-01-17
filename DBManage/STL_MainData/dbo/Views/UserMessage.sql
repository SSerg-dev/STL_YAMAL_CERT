



CREATE View [dbo].[UserMessage]
AS
(Select 
	[UserMessage_ID],
	[DTS] ,
	
	[User_Sender_Name] ,
	[User_Recipient_Name],
	[Group] ,
	[Type] ,
	[Text] ,
	[Memo] 
	From [dbo].[p_UserMessage]
	where [Row_Status] = 0 

); 
