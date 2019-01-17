CREATE TABLE [dbo].[p_ABDDocument_to_DisciplineDocumentCode] (
    [ABDDocument_to_DisciplineDocumentCode_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_DisciplineDocumentCode_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]                           UNIQUEIDENTIFIER NOT NULL,
    [DisciplineDocumentCode_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                               INT              NULL,
    [Insert_DTS]                               DATETIME2 (7)    NULL,
    [Update_DTS]                               DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_DisciplineDocumentCode] PRIMARY KEY CLUSTERED ([ABDDocument_to_DisciplineDocumentCode_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_DisciplineDocumentCode_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_DisciplineDocumentCode_ABDDocument_to_DisciplineDocumentCode_ID_p_ABDDocument_to_DisciplineDocumentCode] FOREIGN KEY ([ABDDocument_to_DisciplineDocumentCode_ID]) REFERENCES [dbo].[p_ABDDocument_to_DisciplineDocumentCode] ([ABDDocument_to_DisciplineDocumentCode_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_DisciplineDocumentCode_DisciplineDocumentCode_ID_p_DisciplineDocumentCode] FOREIGN KEY ([DisciplineDocumentCode_ID]) REFERENCES [dbo].[p_DisciplineDocumentCode] ([DisciplineDocumentCode_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_DisciplineDocumentCode_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument_to_DisciplineDocumentCode] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [DisciplineDocumentCode_ID] ASC)
);

