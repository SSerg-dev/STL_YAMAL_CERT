CREATE TABLE [dbo].[p_PID_to_DisciplineDocumentCode] (
    [PID_to_DisciplineDocumentCode_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_PID_to_DisciplineDocumentCode_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                       DATETIME2 (7)    NULL,
    [Update_DTS]                       DATETIME2 (7)    NULL,
    [Row_Status]                       INT              NULL,
    [PID_ID]                           UNIQUEIDENTIFIER NOT NULL,
    [DisciplineDocumentCode_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_PID_to_DisciplineDocumentCode] PRIMARY KEY CLUSTERED ([PID_to_DisciplineDocumentCode_ID] ASC),
    CONSTRAINT [FK_p_PID_to_DisciplineDocumentCode_DisciplineDocumentCode_ID_p_DisciplineDocumentCode] FOREIGN KEY ([DisciplineDocumentCode_ID]) REFERENCES [dbo].[p_DisciplineDocumentCode] ([DisciplineDocumentCode_ID]),
    CONSTRAINT [FK_p_PID_to_DisciplineDocumentCode_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_PID_to_DisciplineDocumentCode_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_PID_to_DisciplineDocumentCode] UNIQUE NONCLUSTERED ([PID_ID] ASC, [DisciplineDocumentCode_ID] ASC)
);

