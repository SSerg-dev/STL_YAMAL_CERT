CREATE TABLE [ext].[p_FileList_25_As_Built_Documentation] (
    [FileList_25_As_Built_Documentation_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_FileList_25_As_Built_Documentation_ID] DEFAULT (newsequentialid()) NOT NULL,
    [FileName]                              NVARCHAR (4000)  NULL,
    [Created_By]                            NVARCHAR (255)   NULL,
    [Modified_By]                           NVARCHAR (255)   NULL,
    [Row_Status]                            INT              NOT NULL,
    [Insert_DTS]                            DATETIME2 (7)    NOT NULL,
    [Update_DTS]                            DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_p_FileList_25_As_Built_Documentation] PRIMARY KEY CLUSTERED ([FileList_25_As_Built_Documentation_ID] ASC),
    CONSTRAINT [FK_p_FileList_25_As_Built_Documentation_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status])
);

