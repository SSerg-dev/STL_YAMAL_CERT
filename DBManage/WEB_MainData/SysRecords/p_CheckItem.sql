--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate(),
		@CheckList_ID	uniqueidentifier	= (select top 1 CheckList_ID from dbo.p_CheckList where RowStatus = 300);

PRINT N'Inserting CheckItem Template';

INSERT INTO [dbo].[p_CheckItem]
           ([RowStatus]
           ,[Insert_DTS]
           ,[Update_DTS]
           ,[Created_User_ID]
           ,[Modified_User_ID]
           ,[CheckList_ID]
           ,[Document_ID]
           ,[Position]
           ,[Comment]
           ,[CheckItem_Name]
           ,[Issued_Date])
     VALUES
           (300
           ,@DeploymentDate
           ,@DeploymentDate
           ,@RootUser_ID
           ,@RootUser_ID
           ,@CheckList_ID
           ,null
           ,1
           ,null
           ,null
           ,null
		   );