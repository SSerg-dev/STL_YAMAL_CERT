CREATE TABLE [dbo].[p_ISO_to_Module] (
    [ISO_to_Module_ID] UNIQUEIDENTIFIER NOT NULL,
    [ISO_ID]           UNIQUEIDENTIFIER NOT NULL,
    [Module_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]       INT              NULL,
    [Insert_DTS]       DATETIME2 (7)    NULL,
    [Update_DTS]       DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ISO_to_Module] PRIMARY KEY CLUSTERED ([ISO_to_Module_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_Module_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_Module_Module_ID_p_Module] FOREIGN KEY ([Module_ID]) REFERENCES [dbo].[p_Module] ([Module_ID]),
    CONSTRAINT [FK_p_ISO_to_Module_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ISO_to_Module] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [Module_ID] ASC)
);

