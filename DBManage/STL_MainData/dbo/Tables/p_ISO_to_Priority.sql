CREATE TABLE [dbo].[p_ISO_to_Priority] (
    [ISO_to_Priority_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    [Row_Status]         INT              NULL,
    [ISO_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Priority_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ISO_to_Priority] PRIMARY KEY CLUSTERED ([ISO_to_Priority_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_Priority_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_Priority_Priority_ID_p_Priority] FOREIGN KEY ([Priority_ID]) REFERENCES [dbo].[p_Priority] ([Priority_ID]),
    CONSTRAINT [FK_p_ISO_to_Priority_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ISO_to_Priority] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [Priority_ID] ASC)
);

