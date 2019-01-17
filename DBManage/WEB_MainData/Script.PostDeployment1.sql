/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\SysRecords\sysmessages.sql

:r .\SysRecords\p_AppUser.sql

:r .\SysRecords\p_RowStatus.sql

:r .\SysRecords\p_AppUserTask.sql

:r .\SysRecords\p_AppUserTaskMessage.sql 

:r .\SysRecords\p_CheckType.sql

:r .\SysRecords\p_Status.sql

:r .\SysRecords\p_StatusRelation.sql

:r .\SysRecords\p_DocumentType.sql

--Templates

	--Document
	:r .\SysRecords\p_Document.sql

	:r .\SysRecords\p_Document_to_Status.sql

	--Register
	:r .\SysRecords\p_Register.sql

	:r .\SysRecords\p_Register_to_Status.sql

	--CheckList
	:r .\SysRecords\p_CheckList.sql

	:r .\SysRecords\p_CheckList_to_Status.sql

	--CheckItem
	:r .\SysRecords\p_CheckItem.sql

	:r .\SysRecords\p_CheckItem_to_Status.sql