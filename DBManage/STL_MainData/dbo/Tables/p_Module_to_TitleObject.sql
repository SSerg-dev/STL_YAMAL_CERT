CREATE TABLE [dbo].[p_Module_to_TitleObject] (
    [Module_to_TitleObject_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]               DATETIME2 (7)    NULL,
    [Update_DTS]               DATETIME2 (7)    NULL,
    [Row_Status]               INT              NULL,
    [Module_ID]                UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]           UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Module_to_TitleObject] PRIMARY KEY CLUSTERED ([Module_to_TitleObject_ID] ASC),
    CONSTRAINT [FK_p_Module_to_TitleObject_Module_ID_p_Module] FOREIGN KEY ([Module_ID]) REFERENCES [dbo].[p_Module] ([Module_ID]),
    CONSTRAINT [FK_p_Module_to_TitleObject_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_Module_to_TitleObject_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_Module_to_TitleObject] UNIQUE NONCLUSTERED ([Module_ID] ASC, [TitleObject_ID] ASC)
);

