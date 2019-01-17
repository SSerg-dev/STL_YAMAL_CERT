/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DECLARE @RootUser_ID	uniqueidentifier	= newid(),
		@DeploymentDate	datetime2(7)		= getdate()

PRINT N'Inserting RootUser';

INSERT INTO [dbo].[p_AppUser]
           ([AppUser_ID]
           ,[RowStatus]
           ,[Insert_DTS]
           ,[Update_DTS]
           ,[Created_User_ID]
           ,[Modified_User_ID]
           ,[AppUser_Code]
           ,[User_Password]
           ,[Comment])
     VALUES
           (@RootUser_ID
           ,0
           ,@DeploymentDate
           ,@DeploymentDate
           ,@RootUser_ID
           ,@RootUser_ID
           ,'RootUser'
           ,0
           ,'RootUser')
;

PRINT N'Inserting RowStatuses';

INSERT INTO 
dbo.p_RowStatus	 ( RowStatus_ID ,Insert_DTS			,Update_DTS			,Created_User_ID	,Modified_User_ID	,Status_Name_Eng			,Status_Name_Rus					,Description_Eng							,Description_Rus) 
			SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Basic_Row'				,N'Базовое состояни строки'			,N'Basic row'								,N'Строка данного статуса являетчя базовой или обычно'  
UNION ALL	SELECT 32			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Test_to_correct_Row'		,N'Тестовая строка'					,N'Test Row supposed to be correct'			,N'Строка данного статуса является тестовой, но содер' 
UNION ALL 	SELECT 45			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'External_Source_Row'		,N'Строка внешнего происхождения'	,N'Row came from an external data source'	,N'Строка данного статуса была загружена из внешнего '

UNION ALL	SELECT 120			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Historical_Row'			,N'Историческая строка'				,N'Previous condition of row'				,N'Предыдущие состояния строки'
UNION ALL	SELECT 150			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Plan_Row'				,N'Строка плана'					,N'Planned action for an Entity'			,N'Строка описывает плановое состояние сущности'
UNION ALL	SELECT 200			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Deleted'					,N'Удаленная строка'				,N'Deleted row'								,N'Строка находится в логически удаленном состоянии'
UNION ALL	SELECT 400			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Invalid_Row'				,N'Неверные строки'					,N'Invalid Rows Uploaded from a Source'		,N'Строки не отвечающие условиям загрузки'
UNION ALL	SELECT 300			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'System_Template'			,N'Базовый шаблон сущности'			,N'System Template'							,N'Базовй шаблон для заполнения обязательных атрибуто'
UNION ALL	SELECT 301			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Template_Attr_NotNull'	,N'Атрибут шаблона обязательный'	,N'Not nullable Template Attribute'			,N'Обязательный к заполнению атрибут шаблона'
UNION ALL	SELECT 302			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Template_Attr_Null'		,N'Атрибут шаблона не обязательный'	,N'Nullable Template Attribute'				,N'Не обязательный к заполнению атрибут шаблона'
;

PRINT N'Inserting Statuses';

INSERT INTO 
dbo.p_Status	 ( Status_ID	,RowStatus	,Insert_DTS			,Update_DTS			,Created_User_ID	,Modified_User_ID	,Status_Code	,StatusEntity	,Description_Eng			,Description_Rus				,EntityLocked	,ReportColor	,ReportOrder)
			SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wDd'			,N'Document'	,N'Draft'					,N'Черновик'					,0				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wDa'			,N'Document'	,N'Accepted'				,N'Действующий'					,1				,NULL			,NULL

UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wSCd'		,N'Register'	,N'Draft'					,N'Черновик'					,0				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCCuAr'		,N'Register'	,N'Review'					,N'Проверка'					,1				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wSCce'		,N'Register'	,N'ComentsExists'			,N'Выданы замечания'			,1				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wSCci'		,N'Register'	,N'CommentsIncorporation'	,N'Устранение замечаний'		,0				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCCuAsr'		,N'Register'	,N'SecondReview'			,N'Повторная проверка'			,1				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCCua'		,N'Register'	,N'Approvement'				,N'Утверждение'					,1				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCCuna'		,N'Register'	,N'NotApproved'				,N'Отказано в утверждении'		,1				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCwsmr'		,N'Register'	,N'WaitingSMR'				,N'Ожидание завершения СМР'		,1				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCarh'		,N'Register'	,N'Archived'				,N'Архивирование'				,1				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCcan'		,N'Register'	,N'Cancelled'				,N'Аннулирован'					,1				,NULL			,NULL

UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wСLd'		,N'CheckList'	,N'Draft'					,N'Черновик'					,0				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wСLr'		,N'CheckList'	,N'Review'					,N'Проверка'					,0				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wСLc'		,N'CheckList'	,N'Completed'				,N'Проверка Завершена'			,1				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLf'		,N'CheckList'	,N'Fixed'					,N'Замечания устранены'			,1				,NULL			,NULL

UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLId'		,N'CheckItem'	,N'Draft'					,N'Черновик'					,0				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLIss'		,N'CheckItem'	,N'Issued'					,N'Выпущено'					,0				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLIf'		,N'CheckItem'	,N'Fixed'					,N'Исправлено'					,0				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLIa'		,N'CheckItem'	,N'Approved'				,N'Утверждено'					,1				,NULL			,NULL
UNION ALL	SELECT newid()		,0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLIc'		,N'CheckItem'	,N'Cancelled'				,N'Отменено'					,1				,NULL			,NULL
;


GO