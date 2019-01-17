CREATE function [abd].[f_BaseIU_Attrib]
(
	 @AtribType					nvarchar(255)		-- нет значений по умолчанию
	,@DocumentAttribute_ID		uniqueidentifier	= null
	,@DocumentAttribute_Value	nvarchar(300)		= null
	,@Document_ID				uniqueidentifier	= null
	,@DocumentAttribute_Format	nvarchar(300)		= null
	,@DocumentAttribute_Order	int					= null
	,@IsNullable				bit					= null
)	returns						table 
as return 
(	with 
	AttrType(Id) as 
	(-- получаем Тип атрибута по имени обязательно должен быть задан верно
		select EntityType_ID from abd.p_EntityType 
		where EntityType_Code = @AtribType and EntityType_Group = 'Attr'
	)
	select 
		 Insert_DTS					= coalesce(a.Insert_DTS, cast(getdate() as datetime2(7)))
		,Update_DTS					= cast(getdate() as datetime2(7))
		,RowStatus					= case when a.Row_Status is not null then a.Row_Status when @IsNullable = 1 then 302 when @IsNullable = 0 then 301 else 0 end
		,DocumentAttribute_Value	= coalesce(@DocumentAttribute_Value, a.DocumentAttribute_Value, '')
		,EntityType_Id				= atrt.Id
		,Document_ID				= coalesce(@Document_ID, a.Document_ID)
		,DocumentAttribute_Format	= coalesce(@DocumentAttribute_Format, a.DocumentAttribute_Format,'')
		,DocumentAttribute_Order	= coalesce(@DocumentAttribute_Order, a.DocumentAttribute_Order,-1)
	from AttrType atrt
	left join abd.p_DocumentAttribute a on a.DocumentAttribute_ID = @DocumentAttribute_ID
)