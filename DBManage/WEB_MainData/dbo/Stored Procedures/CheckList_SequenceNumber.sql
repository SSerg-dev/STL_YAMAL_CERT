


-- =============================================
-- Author:		ASmirnov
-- Create date: 2018-08-27
-- Description:	The procedure marks used as interface for webapp to deliver ner sequental CheckList number
-- =============================================

CREATE PROCEDURE [dbo].[CheckList_SequenceNumber]
AS 
BEGIN
    SELECT NEXT VALUE FOR dbo.Sequence_CheckList_Number;
END 
