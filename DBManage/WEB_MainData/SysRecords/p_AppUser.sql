--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate();

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