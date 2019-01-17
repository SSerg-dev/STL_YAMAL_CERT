CREATE TABLE [dbo].[p_Stage] (
    [Stage_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Stage_Name] SMALLINT         NOT NULL,
    [Row_Status] INT              NULL,
    [Insert_DTS] DATETIME2 (7)    NULL,
    [Update_DTS] DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_Stage] PRIMARY KEY CLUSTERED ([Stage_ID] ASC),
    CONSTRAINT [FK_p_Stage_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Stage] UNIQUE NONCLUSTERED ([Stage_Name] ASC)
);

