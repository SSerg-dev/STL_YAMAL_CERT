CREATE TABLE [dbo].[p_Phase] (
    [Phase_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Phase_Name] NVARCHAR (100)   NOT NULL,
    [Row_Status] INT              NULL,
    [Insert_DTS] DATETIME2 (7)    NULL,
    [Update_DTS] DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_Phase] PRIMARY KEY CLUSTERED ([Phase_ID] ASC),
    CONSTRAINT [FK_p_Phase_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Phase] UNIQUE NONCLUSTERED ([Phase_Name] ASC)
);

