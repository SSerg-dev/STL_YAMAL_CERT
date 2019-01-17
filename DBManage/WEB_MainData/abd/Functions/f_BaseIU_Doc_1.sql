CREATE function [abd].[f_BaseIU_Doc]
(
	 @DocType					nvarchar(250)		-- нет значений по умолчанию
	,@Document_Id				uniqueidentifier	= null
	,@Document_Name				nvarchar(300)		= null
	,@Document_Title			nvarchar(300)		= null
	,@Document_User				nvarchaR(250)		= null
	,@Document_RevisionNumber	nvarchar(100)		= null
	,@Document_RevisionDate		datetime2(7)		= null
	,@Contragent				nvarchaR(250)		= null
	,@IsTemplate				bit					= null
)	returns						table 
as return 
(	
	with 
	
	DefaultUser(Id) as 
	(-- получаем пользователя, если не найден, берем пользователя по умолчанию
		select AppUser_ID = isnull(cur.AppUser_ID,def.AppUser_ID) 
		from 
		(select AppUser_ID from AppUser where AppUser_Code = suser_name()) cur 
		cross join 
		(select AppUser_ID from AppUser where AppUser_Code = 'RootUser') def
	),
	DocumentType(Id) as 
	(-- получаем Тип документа по имени обязательно должен быть задан верно
		select EntityType_ID from abd.p_EntityType 
		where EntityType_Code = @DocType and EntityType_Group = 'Doc'
	),
	DocumentUser(Id) as
	(--	
		select AppUser_ID from AppUser where AppUser_Code = @Document_User
	),
	DocumentContragent(Id) as
	(--	
		select Contragent_ID from Contragent z where z.Contragent_Code = @Contragent
	)
	-- ниже для сокращения 
	-- "А" - документ и соответствующее поле в нем для обновления (если @Document_Id не пустой и найден в таблице документов)
	-- "@" - соответствующий параметр
	-- "T" - как в шаблоне
	select 
		 -- если есть А, тогда берем оттуда, иначе берем текущую дату (значит insert)
		 Insert_DTS				= coalesce(a.Insert_DTS, cast(getdate() as datetime2(7))) 
		 -- всегда берем текущую дату
		,Update_DTS				= cast(getdate() as datetime2(7))
		 -- если есть А, тогда берем оттуда, иначе если это шаблон, тогда 300 иначе 0 (обычная запись) 
		,Row_Status				= case when a.Row_Status is not null then a.Row_Status when @IsTemplate = 1 then 300 else 0 end
		 -- По порядку @ -> A -> T+NextNum. Если ничего не задано, то берем имя в шаблоне + индекс зависящий от количества документов заданного типа
		,Document_Name			= coalesce(@Document_Name, a.Document_Name, p.Document_Name+cast(nn.NextNum as nvarchar(max)), '')
		 -- Аналогично имени но без инкрементальной счасти
		,Document_Title			= coalesce(@Document_Title, a.Document_Title, p.Document_Title, '')
		 -- Тип документа должен быть всегда
		,EntityType_ID					= et.ID
		 -- 
		,Document_CreationDate	= cast(getdate() as datetime2(7))
		,Document_ModofiedDate	= cast(getdate() as datetime2(7))
		 -- Логика аналогичная датам для создания берем по умолчанию А -> @ -> Вызывающий пользователь -> Root User
		,Document_CreatedBy		= coalesce(a.Document_CreatedBy, du.ID, u.ID)
		 -- Для обновления наоборот приоритет у параметра  @ -> A -> Вызывающий пользователь -> Root User
		,Document_ModifiedBy	= coalesce(du.ID, a.Document_CreatedBy, u.ID)
		-- 
		,Document_RevisionNumber= coalesce(@Document_RevisionNumber, a.Document_RevisionNumber, p.Document_RevisionNumber, '-1')
		,Document_RevisionDate	= coalesce(@Document_RevisionDate, a.Document_RevisionDate, p.Document_RevisionDate, '1900-01-01')
		,Document_Parent_ID		= case when @IsTemplate = 1 then null else p.Document_ID end
		,Contragent_ID			= coalesce(c.ID, a.Contragent_ID, null)
	from		DocumentType et	
	left join	DefaultUser u	on 1=1
			-- получаем шаблон документа если нужно	(для Parent_Id и значений по умолчанию)				
	left join	abd.p_Document p on @isTemplate = 0 and p.EntityType_ID = et.ID and p.Row_Status = 300
			-- получаем документ если не пустой ID (для обновления) 
	left join	abd.p_Document a on a.Document_ID = @Document_Id
			-- нужно для автоматических счетчиков активных документов (не шаблонов) 
	outer apply (select NextNum = count(1)+1 from abd.p_Document a where a.EntityType_ID = et.ID and a.Row_Status < 100) nn
	left join	DocumentUser du on 1=1 
	left join	DocumentContragent c on 1=1 
)