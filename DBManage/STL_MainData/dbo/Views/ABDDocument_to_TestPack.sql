
CREATE view [dbo].[ABDDocument_to_TestPack]
AS
SELECT     ABDDocument_to_TestPack_ID, ABDDocument_ID, TestPack_ID, Insert_DTS, Update_DTS
FROM         dbo.p_ABDDocument_to_TestPack
WHERE     (row_status < 100)
