CREATE TABLE [dbo].[p_ISO_to_RusLabPassport] (
    [p_ISO_to_RusLabPassport_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]                 DATETIME2 (7)    NULL,
    [Update_DTS]                 DATETIME2 (7)    NULL,
    [Row_Status]                 INT              NULL,
    [ISO_ID]                     UNIQUEIDENTIFIER NOT NULL,
    [RusLabPassport_ID]          UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ISO_to_RusLabPassport] PRIMARY KEY CLUSTERED ([p_ISO_to_RusLabPassport_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_RusLabPassport_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_RusLabPassport_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ISO_to_RusLabPassport_RusLabPassport_ID_p_RusLabPassport] FOREIGN KEY ([RusLabPassport_ID]) REFERENCES [dbo].[p_RusLabPassport] ([p_RusLabPassport_ID]),
    CONSTRAINT [UQ_p_ISO_to_RusLabPassport] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [RusLabPassport_ID] ASC)
);

