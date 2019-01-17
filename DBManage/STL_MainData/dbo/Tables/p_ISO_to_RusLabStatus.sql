CREATE TABLE [dbo].[p_ISO_to_RusLabStatus] (
    [ISO_to_RusLabStatus_ID] UNIQUEIDENTIFIER NOT NULL,
    [ISO_ID]                 UNIQUEIDENTIFIER NOT NULL,
    [RusLabStatus_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]             INT              NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ISO_to_RusLabStatus] PRIMARY KEY CLUSTERED ([ISO_to_RusLabStatus_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_RusLabStatus_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_RusLabStatus_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ISO_to_RusLabStatus_RusLabStatus_ID_p_RusLabStatus] FOREIGN KEY ([RusLabStatus_ID]) REFERENCES [dbo].[p_RusLabStatus] ([RusLabStatus_ID]),
    CONSTRAINT [UQ_p_ISO_to_RusLabStatus] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [RusLabStatus_ID] ASC)
);

