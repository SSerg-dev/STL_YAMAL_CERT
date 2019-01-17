CREATE function [abd].[f_GetTemplate_DocRelation]
(
	@DocumentType_Code	nvarchar(255)
)	returns			table 
as return 
(
	select 
		 DocEntityType_Code	= @DocumentType_Code
		,RltEntityType_ID	= drt.RelationType_ID
		,RltEntityType_Code	= drt.RelationType_Code
		,DocumentTo_ID		= dr.DocumentTo_ID
	from
	(select DocumentType_ID from abd.DocumentType where DocumentType_Code = @DocumentType_Code) dt
	join abd.p_Document dp on dt.DocumentType_ID = dp.DocumentType_ID and dp.RowStatus = 300
	left join abd.p_DocumentRelation dr on dr.DocumentFrom_ID = dp.Document_ID
	left join abd.RelationType drt on dr.RelationType_ID = drt.RelationType_ID 
)
