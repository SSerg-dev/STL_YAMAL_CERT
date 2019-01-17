CREATE TABLE [dbo].[p_ABDDocument_to_DocumentTypeCode] (
    [ABDDocument_to_DocumentTypeCode_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_DocumentTypeCode_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]                     UNIQUEIDENTIFIER NOT NULL,
    [DocumentTypeCode_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                         INT              NULL,
    [Insert_DTS]                         DATETIME2 (7)    NULL,
    [Update_DTS]                         DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_DocumentTypeCode] PRIMARY KEY CLUSTERED ([ABDDocument_to_DocumentTypeCode_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_DocumentTypeCode_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_DocumentTypeCode_ABDDocument_to_DocumentTypeCode_ID_p_ABDDocument_to_DocumentTypeCode] FOREIGN KEY ([ABDDocument_to_DocumentTypeCode_ID]) REFERENCES [dbo].[p_ABDDocument_to_DocumentTypeCode] ([ABDDocument_to_DocumentTypeCode_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_DocumentTypeCode_DocumentTypeCode_ID_p_DocumentTypeCode] FOREIGN KEY ([DocumentTypeCode_ID]) REFERENCES [dbo].[p_DocumentTypeCode] ([DocumentTypeCode_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_DocumentTypeCode_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument_to_DocumentTypeCode] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [DocumentTypeCode_ID] ASC)
);

