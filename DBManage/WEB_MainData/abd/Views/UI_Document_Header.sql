
CREATE VIEW [abd].[UI_Document_Header]
AS

SELECT
	d.Document_ID, 
	d.Document_Name, 
	d.Document_Title, 
	d.DocumentType_ID, 
	t.DocumentType_Code,
	d.Document_Revision, 
	d.Document_Parent_ID, 
	d.Reponsible_Employee_ID, 
	d.Document_Number, 
	d.Document_Date
FROM abd.p_Document d
join abd.p_DocumentType t on d.DocumentType_ID = t.DocumentType_ID