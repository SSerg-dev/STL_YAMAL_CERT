CREATE function [abd].[f_GetTemplate_Doc]
(
	@DocumentType_Code	nvarchar(255)
)	returns			table 
as return 
(
	select 
		 DocEntityType_Code				= @DocumentType_Code
		,DocEntityType_ID				= dt.DocumentType_ID
		,DocDocument_Type				= dt.DocumentType_Group
		,Document_ID					= dp.Document_ID
		,dp.Document_Name			
		,dp.Document_Title
		,dp.Document_Revision
		,dp.Document_Number
		,dp.Document_Date
	from
	(select DocumentType_ID, DocumentType_Group from abd.DocumentType where DocumentType_Code = @DocumentType_Code) dt
	join abd.p_Document dp on dt.DocumentType_ID = dp.DocumentType_ID and dp.RowStatus = 300
)