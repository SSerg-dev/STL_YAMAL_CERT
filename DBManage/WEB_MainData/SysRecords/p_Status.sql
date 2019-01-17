--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate();

PRINT N'Inserting Statuses';

INSERT INTO 
dbo.p_Status	 ( RowStatus	,Insert_DTS			,Update_DTS			,Created_User_ID	,Modified_User_ID	,Status_Code	,StatusEntity	,Description_Eng			,Description_Rus				,EntityLocked	,ReportColor	,ReportOrder)
			SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wDd'			,N'Document'	,N'Draft'					,N'Черновик'					,0				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wDa'			,N'Document'	,N'Accepted'				,N'Действующий'					,1				,NULL			,NULL
				   
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wSCd'		,N'Register'	,N'Draft'					,N'Черновик'					,0				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCCuAr'		,N'Register'	,N'Review'					,N'Проверка'					,1				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wSCce'		,N'Register'	,N'ComentsExists'			,N'Выданы замечания'			,1				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wSCci'		,N'Register'	,N'CommentsIncorporation'	,N'Устранение замечаний'		,0				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCCuAsr'		,N'Register'	,N'SecondReview'			,N'Повторная проверка'			,1				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCCua'		,N'Register'	,N'Approvement'				,N'Утверждение'					,1				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCCuna'		,N'Register'	,N'NotApproved'				,N'Отказано в утверждении'		,1				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCwsmr'		,N'Register'	,N'WaitingSMR'				,N'Ожидание завершения СМР'		,1				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCarh'		,N'Register'	,N'Archived'				,N'Архивирование'				,1				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCcan'		,N'Register'	,N'Cancelled'				,N'Аннулирован'					,1				,NULL			,NULL
				   
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wСLd'		,N'CheckList'	,N'Draft'					,N'Черновик'					,0				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wСLr'		,N'CheckList'	,N'Review'					,N'Проверка'					,0				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wСLc'		,N'CheckList'	,N'Completed'				,N'Проверка Завершена'			,1				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLf'		,N'CheckList'	,N'Fixed'					,N'Замечания устранены'			,1				,NULL			,NULL
				   
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLId'		,N'CheckItem'	,N'Draft'					,N'Черновик'					,0				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLIss'		,N'CheckItem'	,N'Issued'					,N'Выпущено'					,0				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLIf'		,N'CheckItem'	,N'Fixed'					,N'Исправлено'					,0				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLIa'		,N'CheckItem'	,N'Approved'				,N'Утверждено'					,1				,NULL			,NULL
UNION ALL	SELECT 0			,@DeploymentDate	,@DeploymentDate	,@RootUser_ID		,@RootUser_ID		,N'wCLIc'		,N'CheckItem'	,N'Cancelled'				,N'Отменено'					,1				,NULL			,NULL
;