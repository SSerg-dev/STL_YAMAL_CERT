CREATE TABLE [dbo].[OLE DB Destination_LineTST] (
    [Folder_Number]                         NVARCHAR (255)   NULL,
    [Structure]                             NVARCHAR (255)   NULL,
    [Document_Sequiential_No_in_Folder]     NVARCHAR (255)   NULL,
    [INT_Document_Sequiential_No_in_Folder] INT              NULL,
    [Row_Status]                            INT              NULL,
    [Trimmed Folder]                        NVARCHAR (100)   NULL,
    [Insert_DTS]                            DATETIME         NULL,
    [Update_DTS]                            DATETIME         NULL,
    [line_ID]                               UNIQUEIDENTIFIER NULL,
    [ABDDocument_ID]                        UNIQUEIDENTIFIER NULL,
    [ErrorCode]                             INT              NULL,
    [ErrorColumn]                           INT              NULL
);

