CREATE TABLE [dbo].[p_LogId_to_FileLOG] (
    [LogId_to_FileLOG_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_LogId_to_FileLOG_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]          DATETIME2 (7)    NULL,
    [Update_DTS]          DATETIME2 (7)    NULL,
    [Row_Status]          INT              NULL,
    [LogId_ID]            UNIQUEIDENTIFIER NOT NULL,
    [FileLOG_ID]          UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_LogId_to_FileLOG] PRIMARY KEY CLUSTERED ([LogId_to_FileLOG_ID] ASC),
    CONSTRAINT [FK_p_LogId_to_FileLOG_FileLOG_ID_p_FileLOG] FOREIGN KEY ([FileLOG_ID]) REFERENCES [dbo].[p_FileLOG] ([FileLOG_ID]),
    CONSTRAINT [FK_p_LogId_to_FileLOG_LogId_ID_p_LogId] FOREIGN KEY ([LogId_ID]) REFERENCES [dbo].[p_LogId] ([LogId_ID]),
    CONSTRAINT [FK_p_LogId_to_FileLOG_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_LogId_to_FileLOG] UNIQUE NONCLUSTERED ([FileLOG_ID] ASC, [LogId_ID] ASC)
);

