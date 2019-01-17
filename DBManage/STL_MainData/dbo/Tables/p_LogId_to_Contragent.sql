CREATE TABLE [dbo].[p_LogId_to_Contragent] (
    [LogId_to_Contragent_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_LogId_to_Contragent_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    [Row_status]             INT              NULL,
    [LogId_ID]               UNIQUEIDENTIFIER NOT NULL,
    [Contragent_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Created_By]             NVARCHAR (255)   NULL,
    [Modified_By]            NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_LogId_to_Contragent] PRIMARY KEY CLUSTERED ([LogId_to_Contragent_ID] ASC),
    CONSTRAINT [FK_p_LogId_to_Contragent_Contragent_ID_p_Contragent] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_LogId_to_Contragent_LogId_ID_p_LogId] FOREIGN KEY ([LogId_ID]) REFERENCES [dbo].[p_LogId] ([LogId_ID]),
    CONSTRAINT [FK_p_LogId_to_Contragent_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_LogId_to_Contragent] UNIQUE NONCLUSTERED ([Contragent_ID] ASC, [LogId_ID] ASC)
);

