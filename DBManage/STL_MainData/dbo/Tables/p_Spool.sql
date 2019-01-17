CREATE TABLE [dbo].[p_Spool] (
    [Spool_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Row_Status] INT              NULL,
    [Insert_DTS] DATETIME2 (7)    NULL,
    [Update_DTS] DATETIME2 (7)    NULL,
    [Spool_Name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_p_Spool] PRIMARY KEY CLUSTERED ([Spool_ID] ASC),
    CONSTRAINT [FK_p_Spool_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Spool] UNIQUE NONCLUSTERED ([Spool_Name] ASC)
);

