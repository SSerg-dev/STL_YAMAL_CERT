--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate();

PRINT N'Inserting CheckList Template';

INSERT INTO [dbo].[p_CheckList]
           ([RowStatus]
           ,[Insert_DTS]
           ,[Update_DTS]
           ,[Created_User_ID]
           ,[Modified_User_ID]
           ,[CheckList_Code]
           ,[CheckList_Date]
           ,[Register_ID]
           ,[CheckParty_ID]
           ,[Resp_Employee_ID])
     VALUES
           (300
           ,@DeploymentDate
           ,@DeploymentDate
           ,@RootUser_ID
           ,@RootUser_ID
           ,'0'
           ,'1900-01-01'
           ,null
           ,null
           ,null
		   );
