CREATE TABLE [dbo].[p_ABDFinalFolder_to_Transmittal] (
    [ABDFinalFolder_to_Transmittal_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDFinalFolder_to_Transmittal_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                       DATETIME2 (7)    NULL,
    [Update_DTS]                       DATETIME2 (7)    NULL,
    [Row_Status]                       INT              NULL,
    [ABDFinalFolder_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Transmittal_ID]                   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ABDFinalFolder_to_Transmittal] PRIMARY KEY CLUSTERED ([ABDFinalFolder_to_Transmittal_ID] ASC),
    CONSTRAINT [FK_p_ABDFinalFolder_to_Transmittal_ABDFinalFolder_ID_p_ABDFinalFolder] FOREIGN KEY ([ABDFinalFolder_ID]) REFERENCES [dbo].[p_ABDFinalFolder] ([ABDFinalFolder_ID]),
    CONSTRAINT [FK_p_ABDFinalFolder_to_Transmittal_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ABDFinalFolder_to_Transmittal_Transmittal_ID_p_Transmittal] FOREIGN KEY ([Transmittal_ID]) REFERENCES [dbo].[p_Transmittal] ([Transmittal_ID]),
    CONSTRAINT [UQ_p_ABDFinalFolder_to_Transmittal] UNIQUE NONCLUSTERED ([ABDFinalFolder_ID] ASC, [Transmittal_ID] ASC)
);

