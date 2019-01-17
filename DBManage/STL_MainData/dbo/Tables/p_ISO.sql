CREATE TABLE [dbo].[p_ISO] (
    [ISO_ID]     UNIQUEIDENTIFIER NOT NULL,
    [ISO_Number] NVARCHAR (100)   NOT NULL,
    [Insulation] NVARCHAR (100)   NULL,
    [Row_status] INT              NULL,
    [Insert_DTS] DATETIME2 (7)    NULL,
    [Update_DTS] DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ISO] PRIMARY KEY CLUSTERED ([ISO_ID] ASC),
    CONSTRAINT [FK_p_ISO_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ISO] UNIQUE NONCLUSTERED ([ISO_Number] ASC)
);

