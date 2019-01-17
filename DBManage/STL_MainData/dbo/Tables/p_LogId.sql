CREATE TABLE [dbo].[p_LogId] (
    [LogId_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_LogId_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS] DATETIME2 (7)    NULL,
    [Update_DTS] DATETIME2 (7)    NULL,
    [Row_Status] INT              NULL,
    [LogId_Code] NVARCHAR (300)   NOT NULL,
    CONSTRAINT [PK_p_LogId] PRIMARY KEY CLUSTERED ([LogId_ID] ASC),
    CONSTRAINT [FK_p_LogId_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_LogId] UNIQUE NONCLUSTERED ([LogId_Code] ASC)
);

