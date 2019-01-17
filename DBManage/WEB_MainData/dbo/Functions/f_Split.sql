
create function [f_Split]
(
	 @InputString		nvarchar(max)
	,@Delimiter			nvarchar(max)
)	returns				table
as return
(
	select 
		 a Val
		,row_number() over (order by (select 1)) Pos
	from openjson(N'[{"z":"' + replace(@InputString,@Delimiter,'"},{"z":"') + N'"}]') with (a nvarchar(max) '$.z')
)
