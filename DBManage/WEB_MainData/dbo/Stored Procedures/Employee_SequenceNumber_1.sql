CREATE PROCEDURE [dbo].[Employee_SequenceNumber]
AS 
BEGIN
    SELECT NEXT VALUE FOR  [dbo].[Sequence_Emp_Number];
END