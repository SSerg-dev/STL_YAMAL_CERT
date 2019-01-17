CREATE TABLE [dbo].[p_ABDDocument_to_Contragent] (
    [ABDDocument_to_Contragent_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_Contragent_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]               UNIQUEIDENTIFIER NOT NULL,
    [Contragent_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                   INT              NULL,
    [Insert_DTS]                   DATETIME2 (7)    NULL,
    [Update_DTS]                   DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_Contragent] PRIMARY KEY CLUSTERED ([ABDDocument_to_Contragent_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_Contragent_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_Contragent_Contragent_ID_p_Contragent] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_Contragent_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument_to_Contragent] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [Contragent_ID] ASC)
);

