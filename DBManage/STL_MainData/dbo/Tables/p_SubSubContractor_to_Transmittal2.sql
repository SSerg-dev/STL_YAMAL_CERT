CREATE TABLE [dbo].[p_SubSubContractor_to_Transmittal2] (
    [SubSubContractor_to_Transmittal_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_SubSubContractor_to_Transmittal2_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                         DATETIME2 (7)    NULL,
    [Update_DTS]                         DATETIME2 (7)    NULL,
    [Row_Status]                         INT              NULL,
    [SubSubContractor_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Transmittal_ID]                     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_SubSubContractor_to_Transmittal2] PRIMARY KEY CLUSTERED ([SubSubContractor_to_Transmittal_ID] ASC),
    CONSTRAINT [FK_p_SubSubContractor_to_Transmittal2_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_SubSubContractor_to_Transmittal2] UNIQUE NONCLUSTERED ([SubSubContractor_ID] ASC, [Transmittal_ID] ASC)
);

