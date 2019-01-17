CREATE TABLE [dbo].[p_ContractorDocument] (
    [ContractorDocument_ID]     UNIQUEIDENTIFIER CONSTRAINT [DF_ContractorDocument_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                DATETIME2 (7)    NULL,
    [Update_DTS]                DATETIME2 (7)    NULL,
    [Row_Status]                INT              NULL,
    [ContractorDocument_Number] NVARCHAR (300)   NOT NULL,
    CONSTRAINT [PK_p_ContractorDocument] PRIMARY KEY CLUSTERED ([ContractorDocument_ID] ASC),
    CONSTRAINT [FK_p_ContractorDocument_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ContractorDocument] UNIQUE NONCLUSTERED ([ContractorDocument_Number] ASC)
);

