CREATE TABLE [dbo].[p_PID_to_ContractorDocument] (
    [PID_to_ContractorDocument_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_PID_to_ContractorDocument_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                   DATETIME2 (7)    NULL,
    [Update_DTS]                   DATETIME2 (7)    NULL,
    [Row_Status]                   INT              NULL,
    [PID_ID]                       UNIQUEIDENTIFIER NOT NULL,
    [ContractorDocument_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_PID_to_ContractorDocument] PRIMARY KEY CLUSTERED ([PID_to_ContractorDocument_ID] ASC),
    CONSTRAINT [FK_p_PID_to_ContractorDocument_ContractorDocument_ID_p_ContractorDocument] FOREIGN KEY ([ContractorDocument_ID]) REFERENCES [dbo].[p_ContractorDocument] ([ContractorDocument_ID]),
    CONSTRAINT [FK_p_PID_to_ContractorDocument_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_PID_to_ContractorDocument_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_PID_to_ContractorDocument] UNIQUE NONCLUSTERED ([PID_ID] ASC, [ContractorDocument_ID] ASC)
);

