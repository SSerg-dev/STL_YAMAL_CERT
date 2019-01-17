CREATE TABLE [dbo].[p_DocumentEmitter] (
    [DocumentEmitter_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_DocumentEmitter_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]           DATETIME2 (7)    NULL,
    [Update_DTS]           DATETIME2 (7)    NULL,
    [Row_Status]           INT              NULL,
    [DocumentEmitter_Code] NVARCHAR (300)   NOT NULL,
    CONSTRAINT [PK_p_DocumentEmitter] PRIMARY KEY CLUSTERED ([DocumentEmitter_ID] ASC),
    CONSTRAINT [FK_p_DocumentEmitter_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_DocumentEmitter] UNIQUE NONCLUSTERED ([DocumentEmitter_Code] ASC)
);

