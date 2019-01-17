CREATE TABLE [dbo].[p_ABDFinalFolder_to_ABDFinalSet] (
    [ABDFinalFolder_to_ABDFinalSet_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDFinalFolder_to_ABDFinalSet_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                       DATETIME2 (7)    NULL,
    [Update_DTS]                       DATETIME2 (7)    NULL,
    [Row_Status]                       INT              NULL,
    [ABDFinalFolder_ID]                UNIQUEIDENTIFIER NOT NULL,
    [ABDFinalSet_ID]                   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ABDFinalFolder_to_ABDFinalSet] PRIMARY KEY CLUSTERED ([ABDFinalFolder_to_ABDFinalSet_ID] ASC),
    CONSTRAINT [FK_p_ABDFinalFolder_to_ABDFinalSet_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDFinalFolder_to_ABDFinalSet] UNIQUE NONCLUSTERED ([ABDFinalFolder_ID] ASC, [ABDFinalSet_ID] ASC)
);

