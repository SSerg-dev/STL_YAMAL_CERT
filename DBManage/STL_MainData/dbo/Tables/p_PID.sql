CREATE TABLE [dbo].[p_PID] (
    [PID_ID]             UNIQUEIDENTIFIER CONSTRAINT [DF_PID_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    [Row_Status]         INT              NULL,
    [PID_Code]           NVARCHAR (300)   NOT NULL,
    [Description_Eng]    NVARCHAR (255)   NULL,
    [DocumentEmitter_ID] UNIQUEIDENTIFIER NULL,
    [SourceFile]         NVARCHAR (10)    NULL,
    CONSTRAINT [PK_p_PID] PRIMARY KEY CLUSTERED ([PID_ID] ASC),
    CONSTRAINT [FK_p_PID_DocumentEmitter_ID_p_DocumentEmitter] FOREIGN KEY ([DocumentEmitter_ID]) REFERENCES [dbo].[p_DocumentEmitter] ([DocumentEmitter_ID]),
    CONSTRAINT [FK_p_PID_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_PID] UNIQUE NONCLUSTERED ([PID_Code] ASC)
);

