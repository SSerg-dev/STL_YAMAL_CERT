-- =============================================
-- Author:		RAlizade
-- Create date: 2017-11-23
-- Description:	Function uses data transformation for SSIS
-- =============================================
CREATE FUNCTION String_Concat 
(
	-- Add the parameters for the function here
	@Str_Eng Nvarchar (255),
	@Str_Rus Nvarchar (255)
)
RETURNS nvarchar(255)
AS
BEGIN

declare @x_Out_Value nvarchar(255)

	-- Add the T-SQL statements to compute the return value here
	SET @x_Out_Value = RTRIM(LTRIM(@Str_Rus)) + ' ' + '/' + ' ' + RTRIM(LTRIM(@Str_Eng))

	-- Return the result of the function
	RETURN @x_Out_Value

END
