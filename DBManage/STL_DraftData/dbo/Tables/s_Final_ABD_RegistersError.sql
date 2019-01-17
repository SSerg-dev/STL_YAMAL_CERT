CREATE TABLE [dbo].[s_Final_ABD_RegistersError] (
    [Title]           NVARCHAR (MAX) NULL,
    [Marka]           NVARCHAR (MAX) NULL,
    [FileLOG]         NVARCHAR (MAX) NULL,
    [LogID]           NVARCHAR (MAX) NULL,
    [Reg]             NVARCHAR (MAX) NULL,
    [NewReg]          NVARCHAR (MAX) NULL,
    [SetFolderNumber] NVARCHAR (MAX) NULL,
    [FolderNumber]    NVARCHAR (MAX) NULL,
    [SourceFile]      NVARCHAR (MAX) NULL,
    [Load_Date]       DATETIME2 (7)  NULL,
    [Error_Code]      INT            NULL,
    [Error_Column]    INT            NULL,
    [Reason]          NVARCHAR (MAX) NULL
);

