CREATE TABLE [dbo].[p_GradingObject] (
    [GradingObject_ID]    UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]      UNIQUEIDENTIFIER NULL,
    [SubTitleObject_Name] NVARCHAR (255)   NULL,
    [Marka_ID]            UNIQUEIDENTIFIER NULL,
    [SubMarka_Name]       NVARCHAR (100)   NULL,
    [ABDFinalSet]         NVARCHAR (100)   NULL,
    [Row_Status]          INT              NULL,
    [Update_DTS]          DATETIME2 (7)    NULL,
    [Insert_DTS]          DATETIME2 (7)    NULL,
    [Phase_ID]            UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_GradingObject] PRIMARY KEY CLUSTERED ([GradingObject_ID] ASC),
    CONSTRAINT [FK_p_GradingObject_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_GradingObject_Phase_ID_p_Phase] FOREIGN KEY ([Phase_ID]) REFERENCES [dbo].[p_Phase] ([Phase_ID]),
    CONSTRAINT [FK_p_GradingObject_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_GradingObject_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID])
);

