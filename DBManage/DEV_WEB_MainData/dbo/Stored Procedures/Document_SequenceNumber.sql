

-- =============================================
-- Author:		ASmirnov
-- Create date: 2018-08-28
-- Description:	The procedure marks used as interface for webapp to deliver new sequental document number
-- =============================================

CREATE PROCEDURE [dbo].[Document_SequenceNumber]
AS 
BEGIN
    SELECT NEXT VALUE FOR dbo.Sequence_Document_Number;
END 
