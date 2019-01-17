
CREATE view [abd].[Doc_Naks] as
with 
Doc (Document_ID, DocNumber) as
(	select 
		 Document_ID
		,Document_Name
	from abd.f_GetParticular_Doc('НАКС')
), 
Attr(AttrEntityType_ID, Code/*, DataType, DocType, Fmt, Ord*/) as 
(	select
		 a.AttributeType_ID
		,a.AttributeType_Code
		--,AttrAttribute_DataType
		--,AttrDocument_Type
		--,DocumentAttribute_Format
		--,DocumentAttribute_Order
	from abd.f_GetTemplate_Attr('НАКС') a
)
select 
	 e.Employee_ID
	,p.Person_ID
	,p.FirstName
	,p.SecondName
	,p.LastName
	,p.BirthDate
	,c.Contragent_ID
	,c.Contragent_Code
	,Valid_To			= try_cast(a1.DocumentAttribute_Value as date)
	,Stamp_Code			= try_cast(a1.DocumentAttribute_Value as nvarchar(250))
	,WeldType			= b3.WeldType_Code
	,HIFGroup			= b4.HIFGroup_Code
from Employee_to_Document z 
join Employee e on z.Employee_ID = e.Employee_ID
join Person p on e.Person_ID = p.Person_ID
join Contragent c on e.Contragent_ID = c.Contragent_ID
join Doc on Doc.Document_ID = z.Document_ID
join Attr on 1=1
left join abd.DocumentAttribute a1 on Attr.Code = 'Срок действия' and a1.AttributeType_ID = Attr.AttrEntityType_ID and a1.Document_ID = Doc.Document_ID
left join abd.DocumentAttribute a2 on Attr.Code = 'Шифр клейма' and a2.AttributeType_ID = Attr.AttrEntityType_ID and a2.Document_ID = Doc.Document_ID
left join abd.DocumentAttribute a3 on Attr.Code = 'Вид сварки' and a3.AttributeType_ID = Attr.AttrEntityType_ID and a3.Document_ID = Doc.Document_ID
left join WeldType b3 on try_cast(a3.DocumentAttribute_Value as uniqueidentifier) = b3.WeldType_ID
left join abd.DocumentAttribute a4 on Attr.Code = 'Группы технических устройств ОПО' and a4.AttributeType_ID = Attr.AttrEntityType_ID and a4.Document_ID = Doc.Document_ID
left join HIFGroup b4 on try_cast(a4.DocumentAttribute_Value as uniqueidentifier) = b4.HIFGroup_ID
