CREATE function [abd].[f_GetParticular_Attr]
(
	@DocumentType_Code	nvarchar(255)
)	returns			table 
as return 
(
	select 
		 DocEntityType_Code			= @DocumentType_Code
		,Document_ID				= dp.Document_ID
		,AttributeType_ID			= dat.AttributeType_ID
		,AttributeType_Code			= dat.AttributeType_Code
		,Attribute_DataType			= dat.Attribute_DataType
		,Attribute_Table			= dat.Attribute_Table
		,Attribute_Format			= dat.Attribute_Format
		,AttributeType_Name			= dat.AttributeType_Name
		,Description_Rus			= dat.Description_Rus
		,Description_Eng			= dat.Description_Eng
		,DocumentAttribute_ID		= da.DocumentAttribute_ID
		,DocumentAttribute_Value	= da.DocumentAttribute_Value
		,DocumentAttribute_Order	= da.DocumentAttribute_Order
	from
	(select DocumentType_ID from abd.DocumentType where  DocumentType_Code = @DocumentType_Code) dt
	join abd.p_Document dp on dt.DocumentType_ID = dp.DocumentType_ID and dp.RowStatus < 100
	left join abd.p_DocumentAttribute da on da.RowStatus < 100 and da.Document_ID = dp.Document_ID
	left join abd.AttributeType dat on da.AttributeType_ID = dat.AttributeType_ID 
)