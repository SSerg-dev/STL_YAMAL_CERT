--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate();

PRINT N'Inserting AppUserTaskMessage';

INSERT INTO 
dbo.p_AppUserTaskMessage ( RowStatus	,Insert_DTS			,Update_DTS			,Created_User_ID	,Modified_User_ID	,AppUserTaskMessage_Code	,Message_Type	,Message_Text						,MessageDescription_ENG	,MessageDescription_RUS)
     				SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,'702'						,2				,'Application DB interaction error'	,NULL					,NULL
		UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,'703'						,3				,'Application Security issue'		,NULL					,NULL
		UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,'701'						,1				,'Application Runtime error'		,NULL					,NULL
