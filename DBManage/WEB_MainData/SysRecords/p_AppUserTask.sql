--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate();

PRINT N'Inserting AppUserTask';
INSERT INTO [dbo].[p_AppUserTask]
           ([RowStatus]
           ,[Insert_DTS]
           ,[Update_DTS]
           ,[Created_User_ID]
           ,[Modified_User_ID]
           ,[AppUserTask_Code]
           ,[TaskName]
           ,[Description_Eng]
           ,[Description_Rus])
     VALUES
           (0
           ,@DeploymentDate
           ,@DeploymentDate
           ,@RootUser_ID
           ,@RootUser_ID
           ,'302'
           ,'WebApp'
           ,'SmartPlant'
           ,'Веб-приложение')