CREATE TABLE [dbo].[p_PID_to_UnitNumberDocumentCode] (
    [PID_to_UnitNumberDocumentCode_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_PID_to_UnitNumberDocumentCode_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                       DATETIME2 (7)    NULL,
    [Update_DTS]                       DATETIME2 (7)    NULL,
    [Row_Status]                       INT              NULL,
    [PID_ID]                           UNIQUEIDENTIFIER NOT NULL,
    [UnitNumberDocumentCode_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_PID_to_UnitNumberDocumentCode] PRIMARY KEY CLUSTERED ([PID_to_UnitNumberDocumentCode_ID] ASC),
    CONSTRAINT [FK_p_PID_to_UnitNumberDocumentCode_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_PID_to_UnitNumberDocumentCode_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_PID_to_UnitNumberDocumentCode_UnitNumberDocumentCode_ID_p_UnitNumberDocumentCode] FOREIGN KEY ([UnitNumberDocumentCode_ID]) REFERENCES [dbo].[p_UnitNumberDocumentCode] ([UnitNumberDocumentCode_ID]),
    CONSTRAINT [UQ_p_PID_to_UnitNumberDocumentCode] UNIQUE NONCLUSTERED ([PID_ID] ASC, [UnitNumberDocumentCode_ID] ASC)
);

