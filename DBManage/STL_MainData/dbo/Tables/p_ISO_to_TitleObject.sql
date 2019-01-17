CREATE TABLE [dbo].[p_ISO_to_TitleObject] (
    [ISO_to_TitleObject_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ISO_to_TitleObject_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]            DATETIME2 (7)    NULL,
    [Update_DTS]            DATETIME2 (7)    NULL,
    [Row_Status]            INT              NULL,
    [ISO_ID]                UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ISO_to_TitleObject] PRIMARY KEY CLUSTERED ([ISO_to_TitleObject_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_TitleObject_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_TitleObject_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ISO_to_TitleObject_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_ISO_to_TitleObject] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [TitleObject_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The table shows a direct link between ISO nd a Title Object. ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'p_ISO_to_TitleObject', @level2type = N'COLUMN', @level2name = N'TitleObject_ID';

