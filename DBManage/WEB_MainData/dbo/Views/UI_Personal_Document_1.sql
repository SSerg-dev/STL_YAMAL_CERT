

CREATE VIEW [dbo].[UI_Personal_Document]
AS
SELECT 
	 a.Employee_ID
	,a.Employee_Code
	,b.Person_ID
	,b.Person_Code
	,b.FirstName
	,b.SecondName
	,b.LastName
	,b.ShortName
	,FullName = FirstName + N' ' + SecondName  + N' ' + LastName
	,c.Position_ID
	,c.Position_Code
	,c.Position_Description
	,d.AppUser_ID
	,d.AppUser_Code
	,e.Division_ID
	,e.Division_Code
	,f.Contragent_ID
	,f.Contragent_Code
	,f.Description_Rus
	,b.BirthDate
	,h.Document_Name
	,h.Document_Title
	,et.EntityType_Code
	,ParentName = pr.Document_Name
	,ParentTitle = pr.Document_Title
FROM dbo.Employee AS a LEFT OUTER JOIN
dbo.Person AS b ON a.Person_ID = b.Person_ID LEFT OUTER JOIN
dbo.Position AS c ON a.Position_ID = c.Position_ID LEFT OUTER JOIN
dbo.AppUser AS d ON a.AppUser_ID = d.AppUser_ID LEFT OUTER JOIN
dbo.Position_to_Division AS c2e ON c.Position_ID = c2e.Position_ID LEFT OUTER JOIN
dbo.Division AS e ON c2e.Division_ID = e.Division_ID LEFT OUTER JOIN
dbo.Contragent AS f ON a.Contragent_ID = f.Contragent_ID
left join dbo.Employee_to_Document g on a.Employee_ID = g.Employee_ID
left join abd.p_Document h on g.Document_ID = h.Document_ID
left join abd.p_EntityType et on h.DocumentType_ID = et.EntityType_ID
left join abd.p_Document pr on h.Document_Parent_ID = pr.Document_ID