CREATE TABLE [dbo].[p_PID_to_DocumentTypeCode] (
    [PID_to_DocumentTypeCode_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_PID_to_DocumentTypeCode_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                 DATETIME2 (7)    NULL,
    [Update_DTS]                 DATETIME2 (7)    NULL,
    [Row_Status]                 INT              NULL,
    [PID_ID]                     UNIQUEIDENTIFIER NOT NULL,
    [DocumentTypeCode_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_PID_to_DocumentTypeCode] PRIMARY KEY CLUSTERED ([PID_to_DocumentTypeCode_ID] ASC),
    CONSTRAINT [FK_p_PID_to_DocumentTypeCode_DocumentTypeCode_ID_p_DocumentTypeCode] FOREIGN KEY ([DocumentTypeCode_ID]) REFERENCES [dbo].[p_DocumentTypeCode] ([DocumentTypeCode_ID]),
    CONSTRAINT [FK_p_PID_to_DocumentTypeCode_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_PID_to_DocumentTypeCode_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_PID_to_DocumentTypeCode] UNIQUE NONCLUSTERED ([PID_ID] ASC, [DocumentTypeCode_ID] ASC)
);

