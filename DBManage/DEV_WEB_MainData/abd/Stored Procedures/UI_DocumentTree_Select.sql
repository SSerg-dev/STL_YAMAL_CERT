

-- =============================================
-- Author: Anton Smirnov
-- Create date: 21.10.2018
-- Pregenerate treeview of Employee abd.Documents (from abd.documents and abd.documents teemplates) as source data for EntityFramework 
-- =============================================
CREATE procedure [abd].[UI_DocumentTree_Select]	-- not null ->	+
(	 @i_Employee_ID			nvarchar(250)		-- usr	param	+
) as begin
	-------------
	------------- Prepearing 
	-------------
	IF(0=1) SET FMTONLY OFF; --used to pregenerate Complex_type of this procedure in EntityFramework SET FMTONLY ON ignores logic of IF
	
	set nocount on
	-- Params
	declare 
		 @u_Employee_ID uniqueidentifier = try_cast(ltrim(rtrim(@i_Employee_ID)) as uniqueidentifier),
		 @x_ParentChild_RelationType_ID uniqueidentifier = (select top 1 RelationType_ID 
															from abd.p_RelationType 
															where RelationType_Code = 'Parent-Child')
		DROP TABLE IF EXISTS #1
		DROP TABLE IF EXISTS #2
		DROP TABLE IF EXISTS #3

	create table #3
				(P_ID				int --nvarchar(100) COLLATE Cyrillic_General_CI_AS
				,ID					int --nvarchar(100) COLLATE Cyrillic_General_CI_AS
				,Type				nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Name				nvarchar(255) COLLATE Cyrillic_General_CI_AS
				,Document_ID		uniqueidentifier
				,DocumentType_ID	uniqueidentifier
				,EntityType			int
				)
	-------------
	------------- Main Action 
	-------------
	If @u_Employee_ID is not null
		begin
		
		select 
				COALESCE(t.DocumentType_ID,  '00000000-0000-0000-0000-000000000000')	as ParentTypeDoc_ID,
				COALESCE(dr.DocumentFrom_ID, '00000000-0000-0000-0000-000000000000')	as ParentDoc_ID,
				dp.DocumentType_ID  as DocType_ID,
				dp.Document_ID		as Doc_ID,	
				dp.Document_Name	as Type,
				dp.Document_Title	as Name,
				0					as EntType
		into #1	
			from
			(select DocumentType_ID, DocumentType_Group from abd.DocumentType) dt
			join abd.p_Document dp on dt.DocumentType_ID = dp.DocumentType_ID and dp.RowStatus = 300
			left join abd.p_DocumentRelation dr on dp.Document_ID = dr.DocumentTo_ID and dr.RelationType_ID = @x_ParentChild_RelationType_ID
			left join abd.p_Document t on t.Document_ID = dr.DocumentFrom_ID 
			where 1=2

		;WITH
		Templ (ParentTypeDoc_ID,ParentDoc_ID, DocType_ID, Doc_ID, Type, Name, EntType)
		as	(
			select distinct 
				COALESCE(t.DocumentType_ID,  '00000000-0000-0000-0000-000000000000')	as ParentTypeDoc_ID,
				COALESCE(dr.DocumentFrom_ID, '00000000-0000-0000-0000-000000000000')	as ParentDoc_ID,
				dp.DocumentType_ID  as DocType_ID,
				dp.Document_ID		as Doc_ID,	
				dp.Document_Name	as Type,
				dp.Document_Title	as Name,
				0					as EntType
			from
			(select DocumentType_ID, DocumentType_Group from abd.DocumentType) dt
			join abd.p_Document dp on dt.DocumentType_ID = dp.DocumentType_ID and dp.RowStatus = 300
			left join abd.p_DocumentRelation dr on dp.Document_ID = dr.DocumentTo_ID and dr.RelationType_ID = @x_ParentChild_RelationType_ID 
			left join abd.p_Document t on t.Document_ID = dr.DocumentFrom_ID
			union ALL
			SELECT null,null,
				   '00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000', 'Документы', 'Документы', 0
			),
		Docs (Document_Parent_ID, Document_ID, DocumenType_ID, Document_Name, Document_Title, DocumentFrom_ID)
		AS	(
			select d.Document_Parent_ID, d.Document_ID, d.DocumentType_ID, d.Document_Name, d.Document_Title, r.DocumentFrom_ID
			from abd.Document d
			join dbo.Employee_to_Document etd on d.Document_ID = etd.Document_ID
			join dbo.Employee e on etd.Employee_ID = e.Employee_ID
			left join abd.DocumentRelation r on d.Document_ID = r.DocumentTo_ID  and r.RelationType_ID = @x_ParentChild_RelationType_ID
			where e.Employee_ID = @u_Employee_ID
			)	
		insert into #1
		-- insert documents templates for upper elements of tree
		select ParentTypeDoc_ID,ParentDoc_ID, DocType_ID, Doc_ID, Type,Name, EntType
		from Templ
		where ParentTypeDoc_ID= '00000000-0000-0000-0000-000000000000' or ParentTypeDoc_ID is null
		union ALL
		-- insert employee documents
		select DocumenType_ID, COALESCE(DocumentFrom_ID,Document_Parent_ID),DocumenType_ID, Document_ID, Document_Name, Document_Title, 1 as EntType
		from Templ 
		join Docs on Templ.Doc_ID = Docs.Document_Parent_ID 

		select ParentTypeDoc_ID,ParentDoc_ID, DocType_ID, Doc_ID, Type, Name, EntType 
		into #2 -- insert Current 
		from #1
		union ALL
		-- insert DocTypes in the middle of tree structure
		select distinct p.DocType_ID, p.Doc_ID, c.DocType_ID, p.Doc_ID, c.Type, c.Type as Name, '0' as EntType
		from #1 p
		join #1 c on p.Doc_id = c.ParentDoc_ID
		join abd.Document cr on c.Doc_ID = cr.Document_ID
		where p.ParentTypeDoc_ID is not null and p.ParentTypeDoc_ID <> '00000000-0000-0000-0000-000000000000'
		union ALL
		-- insert DocTypes in leaves of tree srtucture, only for existing documents
		select	distinct 
				p.DocType_ID			as ParentTypeDoc_ID,
				p.Doc_ID				as ParentDoc_ID, 
				cdt.DocumentType_ID		as DocType_ID, 
				p.Doc_ID				as Doc_ID, 
				cdt.Document_Name		as Type, 
				cdt.Document_Title		as Name, 
				0						as EntType
		from #1 p
		left join #1 c on p.Doc_id = c.ParentDoc_ID
		join abd.Document d on p.Doc_ID = d.Document_ID
		join abd.p_Document dt on d.Document_Parent_ID = dt.Document_ID and dt.RowStatus = '300'
		left join abd.p_DocumentRelation dr on dt.Document_ID = dr.DocumentFrom_ID  and dr.RelationType_ID = @x_ParentChild_RelationType_ID
		left join abd.p_Document cdt on dr.DocumentTo_ID  = cdt.Document_ID and dt.RowStatus = '300' 
		where c.Doc_ID is null and p.ParentTypeDoc_ID is not null and p.ParentTypeDoc_ID <> '00000000-0000-0000-0000-000000000000'
		and p.EntType = 1 and dr.RelationType_ID is not null
	
		insert into #3 (P_ID, ID, Type, Name, DocumentType_ID, Document_ID, EntityType)
		select 
			binary_checksum(ParentDoc_ID, ParentTypeDoc_ID) as P_ID, 
			binary_checksum(Doc_ID, DocType_ID) as ID, 
			Type,
			Name,
			DocType_ID	as DocumentType_ID, 
			Doc_ID		as Document_ID, 
			EntType		as EntityType
		from #2
		order by DocumentType_ID	

		end
		-------------
		------------- Final Action 
		-------------
		select 
			#3.P_ID,
			#3.ID,
			case when #3.EntityType = 1
				 then cast(#3.[Type] as nvarchar(255))
							+' № '
							+isnull(try_cast(d.Document_Number as nvarchar(255)),'')
							+iif(d.Document_Date is null,'',' от ')
							+isnull(convert(NVARCHAR(10), d.Document_Date, 104),'')
				 when #3.EntityType = 0
				 then #3.type 
			end as Name,
			#3.Document_ID,
			#3.DocumentType_ID,
			#3.EntityType
		from #3
		left join abd.p_Document d on #3.Document_ID = d.Document_ID and #3.EntityType = 1

		DROP TABLE IF EXISTS #1
		DROP TABLE IF EXISTS #2
		DROP TABLE IF EXISTS #3

		RETURN
	
end