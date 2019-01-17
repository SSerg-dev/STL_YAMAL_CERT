CREATE TABLE [dbo].[ABDModDownloaded] (
    [ABDModDownloaded_ID] UNIQUEIDENTIFIER NOT NULL,
    [FileName]            NVARCHAR (4000)  NULL,
    [Created_By]          NVARCHAR (255)   NULL,
    [Modified_By]         NVARCHAR (255)   NULL,
    [Row_Status]          INT              NOT NULL,
    [Insert_DTS]          DATETIME2 (7)    NOT NULL,
    [Update_DTS]          DATETIME2 (7)    NOT NULL,
    [FolderName]          NVARCHAR (4000)  NULL
);

