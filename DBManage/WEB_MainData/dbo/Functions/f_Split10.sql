
create function [f_Split10]
(
	 @InputString		nvarchar(max)
	,@Delimiter			nvarchar(max)
)	returns				table
as return
(
	select *
	from openjson(N'{"Rows":[{"z":"' + replace(@InputString,@Delimiter,'"},{"z":"') + N'"}]}') 
	with 
	(
		 c1		nvarchar(max) '$.Rows[0].z'
		,c2		nvarchar(max) '$.Rows[1].z'
		,c3		nvarchar(max) '$.Rows[2].z'
		,c4		nvarchar(max) '$.Rows[3].z'
		,c5		nvarchar(max) '$.Rows[4].z'
		,c6		nvarchar(max) '$.Rows[5].z'
		,c7		nvarchar(max) '$.Rows[6].z'
		,c8		nvarchar(max) '$.Rows[7].z'
		,c9		nvarchar(max) '$.Rows[8].z'
		,c10	nvarchar(max) '$.Rows[9].z'
	)
)
