CREATE TABLE [dbo].[p_ABDDocument_to_UnitNumberDocumentCode] (
    [ABDDocument_to_UnitNumberDocumentCode_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_UnitNumberDocumentCode_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]                           UNIQUEIDENTIFIER NOT NULL,
    [UnitNumberDocumentCode_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                               INT              NULL,
    [Insert_DTS]                               DATETIME2 (7)    NULL,
    [Update_DTS]                               DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_UnitNumberDocumentCode] PRIMARY KEY CLUSTERED ([ABDDocument_to_UnitNumberDocumentCode_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_UnitNumberDocumentCode_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_UnitNumberDocumentCode_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ABDDocument_to_UnitNumberDocumentCode_UnitNumberDocumentCode_ID_p_UnitNumberDocumentCode] FOREIGN KEY ([UnitNumberDocumentCode_ID]) REFERENCES [dbo].[p_UnitNumberDocumentCode] ([UnitNumberDocumentCode_ID]),
    CONSTRAINT [UQ_p_ABDDocument_to_UnitNumberDocumentCode] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [UnitNumberDocumentCode_ID] ASC)
);

