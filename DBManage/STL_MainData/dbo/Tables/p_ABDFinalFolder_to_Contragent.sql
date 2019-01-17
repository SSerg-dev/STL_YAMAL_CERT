CREATE TABLE [dbo].[p_ABDFinalFolder_to_Contragent] (
    [ABDFinalFolder_to_Contragent_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDFinalFolder_to_Contragent_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                      DATETIME2 (7)    NULL,
    [Update_DTS]                      DATETIME2 (7)    NULL,
    [Row_Status]                      INT              NULL,
    [ABDFinalFolder_ID]               UNIQUEIDENTIFIER NOT NULL,
    [Contragent_ID]                   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ABDFinalFolder_to_Contragent] PRIMARY KEY CLUSTERED ([ABDFinalFolder_to_Contragent_ID] ASC),
    CONSTRAINT [FK_p_ABDFinalFolder_to_Contragent_ABDFinalFolder_ID_p_ABDFinalFolder] FOREIGN KEY ([ABDFinalFolder_ID]) REFERENCES [dbo].[p_ABDFinalFolder] ([ABDFinalFolder_ID]),
    CONSTRAINT [FK_p_ABDFinalFolder_to_Contragent_Contragent_ID_p_Contragent] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_ABDFinalFolder_to_Contragent_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDFinalFolder_to_Contragent] UNIQUE NONCLUSTERED ([ABDFinalFolder_ID] ASC, [Contragent_ID] ASC)
);

