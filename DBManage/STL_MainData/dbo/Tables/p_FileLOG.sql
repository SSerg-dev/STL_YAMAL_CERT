CREATE TABLE [dbo].[p_FileLOG] (
    [FileLOG_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_FileLOG_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]   DATETIME2 (7)    NULL,
    [Update_DTS]   DATETIME2 (7)    NULL,
    [Row_Status]   INT              NULL,
    [FileLOG_Code] NVARCHAR (300)   NOT NULL,
    CONSTRAINT [PK_p_FileLOG] PRIMARY KEY CLUSTERED ([FileLOG_ID] ASC),
    CONSTRAINT [FK_p_FileLOG_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_FileLOG] UNIQUE NONCLUSTERED ([FileLOG_Code] ASC)
);

