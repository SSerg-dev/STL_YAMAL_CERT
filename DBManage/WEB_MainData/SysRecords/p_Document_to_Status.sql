--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate(),
		@Document_ID	uniqueidentifier	= (select top 1 Document_ID from dbo.p_Document where RowStatus = 300),
		@Status_ID		uniqueidentifier	= (select top 1 Status_ID from dbo.p_Status where Status_Code = N'wDd');

PRINT N'Inserting Document_to_Status Template';

INSERT INTO dbo.p_Document_to_Status
           (RowStatus
           ,Insert_DTS
           ,Update_DTS
           ,Created_User_ID
           ,Modified_User_ID
           ,Document_ID
           ,Status_ID
           ,Parent_ID
           ,DTS_Start
           ,DTS_End)
     VALUES
           (300
           ,@DeploymentDate
           ,@DeploymentDate
           ,@RootUser_ID
           ,@RootUser_ID
           ,@Document_ID
           ,@Status_ID
           ,null
           ,'1900-01-01'
           ,null)
		   ;