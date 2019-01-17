

-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-12-16
-- Description:	Used in SSIS package Load_Register_to_FinalFolder
-- Replases Lat symbols in RegisterNumber with same Cyr symbols
-- =============================================
Create PROCEDURE [dbo].[Repl_LatCyr_Final_ABD_Registers] 
(
	 @DraftData		nvarchar(100) = '',
	 @MainData		nvarchar(100) = ''
)
AS
BEGIN
	set nocount on;

	declare 
		 @SQL		nvarchar(max);
 
	SET @SQL = 
		 N'UPDATE '+@DraftData+'.[dbo].[s_Final_ABD_Registers_Excel]
		   SET FolderNumber = 
				SUBSTRING ( FolderNumber, 1, CHARINDEX(''-'', FolderNumber,6))+
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
				Replace(
					Replace(SUBSTRING ( FolderNumber, CHARINDEX(''-'', FolderNumber,6)+1 , len(FolderNumber)-CHARINDEX(''-'', FolderNumber,6)),''E'',''Е'')	
				,''T'',''Т'') --Eng to Rus
				,''O'',''О'') --Eng to Rus
				,''P'',''Р'') --Eng to Rus
				,''A'',''А'') --Eng to Rus
				,''H'',''Н'') --Eng to Rus
				,''K'',''К'') --Eng to Rus
				,''X'',''Х'') --Eng to Rus
				,''C'',''С'') --Eng to Rus
				,''B'',''В'') --Eng to Rus
				,''M'',''М'') --Eng to Rus
		   WHERE FolderNumber not like ''%COW%'' and FolderNumber not like ''%REG%''';

		EXECUTE sp_executesql @SQL;



END
