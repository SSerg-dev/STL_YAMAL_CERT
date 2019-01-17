CREATE TABLE [dbo].[p_ABDFinalFolder_to_Phase] (
    [ABDFinalFolder_to_Phase_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDFinalFolder_to_Phase_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                 DATETIME2 (7)    NULL,
    [Update_DTS]                 DATETIME2 (7)    NULL,
    [Row_Status]                 INT              NULL,
    [ABDFinalFolder_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Phase_ID]                   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ABDFinalFolder_to_Phase] PRIMARY KEY CLUSTERED ([ABDFinalFolder_to_Phase_ID] ASC),
    CONSTRAINT [FK_p_ABDFinalFolder_to_Phase_ABDFinalFolder_ID_p_ABDFinalFolder] FOREIGN KEY ([ABDFinalFolder_ID]) REFERENCES [dbo].[p_ABDFinalFolder] ([ABDFinalFolder_ID]),
    CONSTRAINT [FK_p_ABDFinalFolder_to_Phase_Phase_ID_p_Phase] FOREIGN KEY ([Phase_ID]) REFERENCES [dbo].[p_Phase] ([Phase_ID]),
    CONSTRAINT [FK_p_ABDFinalFolder_to_Phase_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDFinalFolder_to_Phase] UNIQUE NONCLUSTERED ([ABDFinalFolder_ID] ASC, [Phase_ID] ASC)
);

