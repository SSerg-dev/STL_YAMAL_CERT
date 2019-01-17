/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO
PRINT N'Creating DB FILESTREAM settings'

GO
ALTER DATABASE [$(DatabaseName)] SET FILESTREAM( DIRECTORY_NAME = N'FileShare' ) WITH NO_WAIT

GO
ALTER DATABASE [STL_FileStorage] SET FILESTREAM( NON_TRANSACTED_ACCESS = FULL ) WITH NO_WAIT