--Post-Deployment
GO
DECLARE @RootUser_ID		uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate		datetime2(7)		= getdate(),
		@DocumentType_ID	uniqueidentifier	= (select top 1 DocumentType_ID from dbo.p_DocumentType where DocumentType_Code = N'N/A');

PRINT N'Inserting Document Template';

INSERT INTO dbo.p_Document
           (RowStatus
           ,Insert_DTS
           ,Update_DTS
           ,Created_User_ID
           ,Modified_User_ID
           ,Document_Code
           ,Document_Number
           ,DocumentType_ID
           ,Document_Date
           ,Issue_Date
           ,TotalSheets
           ,Document_Name
           ,Parent_ID
           ,VersionNumber
           ,IsActual
           ,Resp_Employee_ID)
     VALUES
           (300
           ,@DeploymentDate
           ,@DeploymentDate
           ,@RootUser_ID
           ,@RootUser_ID
           ,'0'
           ,null
           ,@DocumentType_ID
           ,null
           ,'1900-01-01'
           ,null
           ,null
           ,null
           ,null
           ,null
           ,null)
		   ;