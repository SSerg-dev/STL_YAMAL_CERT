

-- =============================================
-- Author:		ASmirnov
-- Create date: 2018-04-20
-- Description:	The procedure marks used as interface for webapp to deliver ner sequental register number
-- =============================================

CREATE PROCEDURE [dbo].[Register_SequenceNumber]
AS 
BEGIN
    SELECT NEXT VALUE FOR dbo.Sequence_Register_Number;
END 
