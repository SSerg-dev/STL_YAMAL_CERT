﻿--Post-Deployment
GO
DECLARE @RootUser_ID	uniqueidentifier	= try_cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier),
		@DeploymentDate	datetime2(7)		= getdate(),
		@CheckItem_ID	uniqueidentifier	= (select top 1 CheckItem_ID from dbo.p_CheckItem where RowStatus = 300),
		@Status_ID		uniqueidentifier	= (select top 1 Status_ID from dbo.p_Status where Status_Code = N'wCLId');


PRINT N'Inserting CheckItem_to_Status Template';

INSERT INTO [dbo].[p_CheckItem_to_Status]
           ([RowStatus]
           ,[Insert_DTS]
           ,[Update_DTS]
           ,[Created_User_ID]
           ,[Modified_User_ID]
           ,[CheckItem_ID]
           ,[Status_ID]
           ,[Parent_ID]
           ,[DTS_Start]
           ,[DTS_End])
     VALUES
           (300
           ,@DeploymentDate
           ,@DeploymentDate
           ,@RootUser_ID
           ,@RootUser_ID
           ,@CheckItem_ID
           ,@Status_ID
           ,null
           ,'1900-01-01'
           ,NULL
		   );