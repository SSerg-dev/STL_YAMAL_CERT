--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate();

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
