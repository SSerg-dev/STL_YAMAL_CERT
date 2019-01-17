CREATE TABLE [dbo].[p_ISO_to_Spool] (
    [ISO_to_Spool_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]      DATETIME2 (7)    NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    [Row_Status]      INT              NULL,
    [ISO_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Spool_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ISO_to_Spool] PRIMARY KEY CLUSTERED ([ISO_to_Spool_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_Spool_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_Spool_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ISO_to_Spool_Spool_ID_p_Spool] FOREIGN KEY ([Spool_ID]) REFERENCES [dbo].[p_Spool] ([Spool_ID]),
    CONSTRAINT [UQ_p_ISO_to_Spool] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [Spool_ID] ASC)
);

