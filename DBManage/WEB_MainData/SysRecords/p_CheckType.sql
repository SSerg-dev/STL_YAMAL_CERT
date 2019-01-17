--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate();

PRINT N'Inserting CheckType';


INSERT INTO 
dbo.p_CheckType ( RowStatus	,Insert_DTS			,Update_DTS			,Created_User_ID	,Modified_User_ID	,CheckType_Code	,Description_Eng	,Description_Rus)
		   SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Review'		,N'Review'			,N'Проверка'		
UNION ALL  SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'Approvement'	,N'Approvement'		,N'Утверждение'	
;
