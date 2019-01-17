CREATE TABLE [dbo].[p_ABDFinalSet] (
    [ABDFinalSet_ID]     UNIQUEIDENTIFIER NOT NULL,
    [ABDFinalSet_Number] NVARCHAR (100)   NOT NULL,
    [Row_status]         INT              NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    [TitleObject_ID]     UNIQUEIDENTIFIER NOT NULL,
    [Marka_ID]           UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ABDFinalSet] PRIMARY KEY CLUSTERED ([ABDFinalSet_ID] ASC),
    CONSTRAINT [FK_p_ABDFinalSet_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_ABDFinalSet_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ABDFinalSet_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_ABDFinalSet] UNIQUE NONCLUSTERED ([ABDFinalSet_Number] ASC)
);

