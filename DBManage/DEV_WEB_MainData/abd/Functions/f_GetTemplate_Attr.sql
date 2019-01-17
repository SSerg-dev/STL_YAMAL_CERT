CREATE function [abd].[f_GetTemplate_Attr]
(
	@DocumentType_Code	nvarchar(255)
)	returns			table 
as return 
(
	select 
		 DocEntityType_Code			= @DocumentType_Code
		,AttributeType_ID			= dat.AttributeType_ID
		,AttributeType_Code			= dat.AttributeType_Code
		,AttributeType_Name			= dat.AttributeType_Name
		,Attribute_DataType			= dat.Attribute_DataType
		,Attribute_Table			= dat.Attribute_Table
		,Attribute_Format			= dat.Attribute_Format
		,Description_Rus			= dat.Description_Rus
		,Description_Eng			= dat.Description_Eng
		,DocumentAttribute_ID		= da.DocumentAttribute_ID
		,DocumentAttribute_Order	= da.DocumentAttribute_Order
	from
	(select DocumentType_ID from abd.DocumentType where DocumentType_Code = @DocumentType_Code) dt
	join abd.p_Document dp on dt.DocumentType_ID = dp.DocumentType_ID and dp.RowStatus = 300
	left join abd.p_DocumentAttribute da on da.RowStatus in (300,301,302) and da.Document_ID = dp.Document_ID
	left join abd.AttributeType dat on da.AttributeType_ID = dat.AttributeType_ID 
)
