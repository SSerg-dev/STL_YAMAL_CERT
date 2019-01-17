CREATE TABLE [dbo].[p_PID_to_DocumentOriginCode] (
    [PID_to_DocumentOriginCode_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_PID_to_DocumentOriginCode_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                   DATETIME2 (7)    NULL,
    [Update_DTS]                   DATETIME2 (7)    NULL,
    [Row_Status]                   INT              NULL,
    [PID_ID]                       UNIQUEIDENTIFIER NOT NULL,
    [DocumentOriginCode_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_PID_to_DocumentOriginCode] PRIMARY KEY CLUSTERED ([PID_to_DocumentOriginCode_ID] ASC),
    CONSTRAINT [FK_p_PID_to_DocumentOriginCode_DocumentOriginCode_ID_p_DocumentOriginCode] FOREIGN KEY ([DocumentOriginCode_ID]) REFERENCES [dbo].[p_DocumentOriginCode] ([DocumentOriginCode_ID]),
    CONSTRAINT [FK_p_PID_to_DocumentOriginCode_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_PID_to_DocumentOriginCode_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_PID_to_DocumentOriginCode] UNIQUE NONCLUSTERED ([PID_ID] ASC, [DocumentOriginCode_ID] ASC)
);

