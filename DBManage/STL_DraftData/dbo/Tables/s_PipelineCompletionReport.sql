CREATE TABLE [dbo].[s_PipelineCompletionReport] (
    [Line]                  NVARCHAR (255) NULL,
    [ISO]                   NVARCHAR (255) NULL,
    [NumberLineList]        NVARCHAR (255) NULL,
    [Phase]                 NVARCHAR (255) NULL,
    [Title]                 NVARCHAR (255) NULL,
    [Marka]                 NVARCHAR (255) NULL,
    [Contragent]            NVARCHAR (255) NULL,
    [FinalFolderWelding]    NVARCHAR (255) NULL,
    [FinalFolderAKZ]        NVARCHAR (255) NULL,
    [FinalFolderInsulation] NVARCHAR (255) NULL,
    [FinalFolderWeldBook]   NVARCHAR (255) NULL,
    [FinalFolderABK]        NVARCHAR (255) NULL,
    [RemarksWeld]           NVARCHAR (255) NULL,
    [RemarksAKZ]            NVARCHAR (255) NULL,
    [Source_File]           NVARCHAR (255) NULL,
    [Load_Date]             DATETIME2 (7)  NULL
);

