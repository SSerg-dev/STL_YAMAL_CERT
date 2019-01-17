CREATE TABLE [dbo].[s_Final_ABD_Registers] (
    [Title]             NVARCHAR (MAX)   NULL,
    [Marka]             NVARCHAR (MAX)   NULL,
    [FileLOG]           NVARCHAR (MAX)   NULL,
    [LogID]             NVARCHAR (MAX)   NULL,
    [Reg]               NVARCHAR (MAX)   NULL,
    [NewReg]            NVARCHAR (MAX)   NULL,
    [SetFolderNumber]   NVARCHAR (MAX)   NULL,
    [FolderNumber]      NVARCHAR (MAX)   NULL,
    [Register_ID]       UNIQUEIDENTIFIER NULL,
    [ABDFinalFolder_ID] UNIQUEIDENTIFIER NULL,
    [SourceFile]        NVARCHAR (MAX)   NULL,
    [Load_Date]         DATETIME2 (7)    NULL
);

