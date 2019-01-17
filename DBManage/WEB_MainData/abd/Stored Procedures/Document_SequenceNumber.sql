


CREATE PROCEDURE [abd].[Document_SequenceNumber]
AS 
BEGIN
    SELECT NEXT VALUE FOR abd.Sequence_Document_Number;
END