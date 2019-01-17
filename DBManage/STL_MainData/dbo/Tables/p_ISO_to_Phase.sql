CREATE TABLE [dbo].[p_ISO_to_Phase] (
    [ISO_to_Phase_ID] UNIQUEIDENTIFIER NOT NULL,
    [ISO_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Phase_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]      INT              NULL,
    [Insert_DTS]      DATETIME2 (7)    NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ISO_to_Phase] PRIMARY KEY CLUSTERED ([ISO_to_Phase_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_Phase_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_Phase_Phase_ID_p_Phase] FOREIGN KEY ([Phase_ID]) REFERENCES [dbo].[p_Phase] ([Phase_ID]),
    CONSTRAINT [FK_p_ISO_to_Phase_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ISO_to_Phase] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [Phase_ID] ASC)
);

