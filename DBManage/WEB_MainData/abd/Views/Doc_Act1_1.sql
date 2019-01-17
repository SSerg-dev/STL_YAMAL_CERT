
CREATE view [abd].[Doc_Act1] as
with 
Doc (Document_ID, DocName ) as
(	select 
		 Document_ID
		,Document_Name
	from abd.f_GetParticular_Doc('Act1')
), 
Attr(AttrEntityType_ID, Code) as 
(	select
		 a.AttributeType_ID
		,a.AttributeType_Code
	from abd.f_GetTemplate_Attr('Act1') a
)
select 
	 Id				= Doc.Document_ID
	,ParentId		= null
	,EntityLevel	= 'Doc'
	,EntityName		= Doc.DocName
	,EntityValue	= null
from Doc
union all select 
	 Id				= Attr.AttrEntityType_ID
	,ParentId		= Doc.Document_ID
	,EntityLevel	= 'Attr'
	,EntityName		= Attr.Code
	,EntityValue	= null
from Doc join Attr on 1=1
union all select
	 Id				= try_cast(DocumentAttribute_ID as uniqueidentifier)
	,ParentId		= AttrEntityType_ID
	,EntityLevel	= 'Value'
	,EntityName		= AttrCode
	,EntityValue	= AttrValue
from
(
	select 
		 Doc.Document_ID
		,AttrEntityType_ID
		,AttrCode = Code
		,DocumentAttribute_ID= coalesce(a1.DocumentAttribute_ID,a2.DocumentAttribute_ID, a3.DocumentAttribute_ID)
		,AttrValue = coalesce(b1.TitleObject_Code,b2.Marka_Code, a3.DocumentAttribute_Value)
	from Doc join Attr on 1=1
	left join abd.DocumentAttribute a1 on Attr.Code = 'TitleObject' and a1.AttributeType_ID = Attr.AttrEntityType_ID and a1.Document_ID = Doc.Document_ID
	left join TitleObject b1 on try_cast(a1.DocumentAttribute_Value as uniqueidentifier) = b1.TitleObject_ID
	left join abd.DocumentAttribute a2 on Attr.Code = 'Marka' and a2.AttributeType_ID = Attr.AttrEntityType_ID and a2.Document_ID = Doc.Document_ID
	left join Marka b2 on try_cast(a2.DocumentAttribute_Value as uniqueidentifier) = b2.Marka_ID
	left join abd.DocumentAttribute a3 on Attr.Code = 'Шифр клейма' and a3.AttributeType_ID = Attr.AttrEntityType_ID and a3.Document_ID = Doc.Document_ID
) x
where DocumentAttribute_ID is not null
and x.AttrValue is not null
