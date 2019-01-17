



/*
exec [dbo].[PopulateTitleObjectFromLinesPIP_LOG] 'DEV_STL_DraftData','DEV_STL_MainData'
*/

-- =============================================
-- Author:		KPonizovskaya
-- Create date: 2018-03-18
-- Description:	Used in SSIS package LVI_WorkProgress_Full
-- Create temp table with data from denormalised tables, databaser params from package, to make easyer Debugging package in DEV_
-- =============================================
CREATE PROCEDURE  [dbo].[PopulateTitleObjectFromLinesPIP_LOG] 
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
		 N'UPDATE
				Table_A
			SET
				Table_A.Title = Table_B.TitleObject_Name
			FROM '+@DraftData+'.dbo.s_WPPipingRegisters  AS Table_A 
			    INNER JOIN  '+@MainData+'.dbo.R_Line_to_Phase AS Table_B
			ON Table_A.Unit = Table_B.Line_Number
			WHERE
				Table_A.Title is null';

		   EXECUTE sp_executesql @SQL;	   


END
