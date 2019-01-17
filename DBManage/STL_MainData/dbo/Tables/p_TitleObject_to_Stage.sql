CREATE TABLE [dbo].[p_TitleObject_to_Stage] (
    [TitleObject_to_Stage_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_TitleObject_to_Stage_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NULL,
    [Update_DTS]              DATETIME2 (7)    NULL,
    [Row_status]              INT              NULL,
    [TitleObject_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Stage_ID]                UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_TitleObject_to_Stage] PRIMARY KEY CLUSTERED ([TitleObject_to_Stage_ID] ASC),
    CONSTRAINT [FK_p_TitleObject_to_Stage_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_TitleObject_to_Stage_Stage_ID_p_Stage] FOREIGN KEY ([Stage_ID]) REFERENCES [dbo].[p_Stage] ([Stage_ID]),
    CONSTRAINT [FK_p_TitleObject_to_Stage_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_TitleObject_to_Stage] UNIQUE NONCLUSTERED ([Stage_ID] ASC, [TitleObject_ID] ASC)
);

