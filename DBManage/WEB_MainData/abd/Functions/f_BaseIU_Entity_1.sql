create function abd.f_BaseIU_Entity
(
	 @EntityType_ID			uniqueidentifier	= null
	,@EntityType_Group		nvarchar(50)		= null
	,@EntityType_Code		nvarchar(255)		= null
	,@Attribute_DataType	nvarchar(120)		= null
	,@Document_Type			nvarchar(120)		= null
)	returns					table 
as return 
(	with 
	DefaultUser(Id) as 
	(-- получаем пользователя, если не найден, берем пользователя по умолчанию
		select AppUser_ID = isnull(cur.AppUser_ID,def.AppUser_ID) 
		from 
		(select AppUser_ID from AppUser where AppUser_Code = suser_name()) cur 
		cross join 
		(select AppUser_ID from AppUser where AppUser_Code = 'RootUser') def
	)
	select 
		 RowStatus			  = 0
		,Insert_DTS			  = coalesce(a.Insert_DTS, cast(getdate() as datetime2(7)))
		,Update_DTS			  = cast(getdate() as datetime2(7))
		,Created_User_ID	  = coalesce(a.Created_User_ID, u.ID)
		,Modified_User_ID	  = coalesce(u.ID, a.Created_User_ID)
		,EntityType_Code	  = coalesce(@EntityType_Code, a.EntityType_Code)
		,EntityType_Group	  = coalesce(@EntityType_Group, a.EntityType_Group)
		,Attribute_DataType	  = coalesce(@Attribute_DataType, a.Attribute_DataType)
		,Document_Type		  = coalesce(@Document_Type, a.Document_Type)
	from DefaultUser u 
	left join abd.p_EntityType a on a.EntityType_ID = @EntityType_ID
)