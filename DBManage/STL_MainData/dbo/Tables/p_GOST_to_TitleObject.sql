CREATE TABLE [dbo].[p_GOST_to_TitleObject] (
    [GOST_to_TitleObject_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_GOST_to_TitleObject_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    [Row_Status]             INT              NULL,
    [GOST_ID]                UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_GOST_to_TitleObject] PRIMARY KEY CLUSTERED ([GOST_to_TitleObject_ID] ASC),
    CONSTRAINT [FK_p_GOST_to_TitleObject_GOST_ID_p_GOST] FOREIGN KEY ([GOST_ID]) REFERENCES [dbo].[p_GOST] ([GOST_ID]),
    CONSTRAINT [FK_p_GOST_to_TitleObject_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_GOST_to_TitleObject_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_GOST_to_TitleObject] UNIQUE NONCLUSTERED ([GOST_ID] ASC, [TitleObject_ID] ASC)
);

