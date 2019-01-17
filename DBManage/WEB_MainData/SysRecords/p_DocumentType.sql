--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate();

PRINT N'Inserting DocumentType';

INSERT INTO dbo.p_DocumentType
           (RowStatus
           ,Insert_DTS
           ,Update_DTS
           ,Created_User_ID
           ,Modified_User_ID
           ,DocumentType_Code)
     VALUES
           (300
           ,@DeploymentDate
           ,@DeploymentDate
           ,@RootUser_ID
           ,@RootUser_ID
           ,N'N/A')
		   ;