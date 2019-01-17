CREATE TABLE [dbo].[p_ABDFinalFolder_to_SubContractor2] (
    [ABDFinalFolder_to_SubContractor_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDFinalFolder_to_SubContractor2_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                         DATETIME2 (7)    NULL,
    [Update_DTS]                         DATETIME2 (7)    NULL,
    [Row_Status]                         INT              NULL,
    [ABDFinalFolder_ID]                  UNIQUEIDENTIFIER NULL,
    [SubContractor_ID]                   UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_ABDFinalFolder_to_SubContractor2] PRIMARY KEY CLUSTERED ([ABDFinalFolder_to_SubContractor_ID] ASC),
    CONSTRAINT [FK_p_ABDFinalFolder_to_SubContractor2_ABDFinalFolder_ID_p_ABDFinalFolder] FOREIGN KEY ([ABDFinalFolder_ID]) REFERENCES [dbo].[p_ABDFinalFolder] ([ABDFinalFolder_ID]),
    CONSTRAINT [FK_p_ABDFinalFolder_to_SubContractor2_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ABDFinalFolder_to_SubContractor2_SubContractor_ID_p_SubContractor2] FOREIGN KEY ([SubContractor_ID]) REFERENCES [dbo].[p_SubContractor2] ([SubContractor_ID]),
    CONSTRAINT [UQ_p_ABDFinalFolder_to_SubContractor2] UNIQUE NONCLUSTERED ([ABDFinalFolder_ID] ASC, [SubContractor_ID] ASC)
);

