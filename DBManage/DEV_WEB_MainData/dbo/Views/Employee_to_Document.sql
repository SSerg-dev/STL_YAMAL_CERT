
CREATE VIEW [dbo].[Employee_to_Document]
AS
SELECT        Employee_to_Document_ID, Document_ID, Employee_ID
FROM            dbo.p_Employee_to_Document
WHERE        (RowStatus < 100)
