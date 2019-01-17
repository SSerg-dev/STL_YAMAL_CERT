--Post-Deployment
GO
DECLARE @RootUser_ID		uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate		datetime2(7)		= getdate();

PRINT N'Inserting Register Template';

INSERT INTO dbo.p_Register
           (RowStatus
           ,Insert_DTS
           ,Update_DTS
           ,Created_User_ID
           ,Modified_User_ID
           ,Register_Code
           ,Register_Date
           ,Current_Iteration
           ,Customer_ID
           ,Contractor_ID
           ,Resp_Employee_ID
           ,WorkPackage_ID
           ,Comment
           ,SubContractor_ID)
     VALUES
           (300
           ,@DeploymentDate
           ,@DeploymentDate
           ,@RootUser_ID
           ,@RootUser_ID
           ,'0'
           ,'1900-01-01'
           ,0
           ,null
           ,null
           ,null
           ,null
           ,null
           ,null)
		   ;