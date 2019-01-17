CREATE TABLE [dbo].[p_ABDFinalFolder_to_ABDStatus] (
    [ABDFinalFolder_To_ABDStatus_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDFinalFolder_to_ABDStatus_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Parent_ID]                      UNIQUEIDENTIFIER NULL,
    [DTS_Start]                      DATETIME2 (7)    NULL,
    [DTS_End]                        DATETIME2 (7)    NULL,
    [Insert_DTS]                     DATETIME2 (7)    NULL,
    [Update_DTS]                     DATETIME2 (7)    NULL,
    [Row_status]                     INT              NULL,
    [ABDFinalFolder_ID]              UNIQUEIDENTIFIER NOT NULL,
    [ABDStatus_ID]                   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ABDFinalFolder_to_ABDStatus] PRIMARY KEY CLUSTERED ([ABDFinalFolder_To_ABDStatus_ID] ASC),
    CONSTRAINT [FK_p_ABDFinalFolder_to_ABDStatus_ABDFinalFolder_ID_p_ABDFinalFolder] FOREIGN KEY ([ABDFinalFolder_ID]) REFERENCES [dbo].[p_ABDFinalFolder] ([ABDFinalFolder_ID]),
    CONSTRAINT [FK_p_ABDFinalFolder_to_ABDStatus_ABDStatus_ID_p_ABDStatus] FOREIGN KEY ([ABDStatus_ID]) REFERENCES [dbo].[p_ABDStatus] ([ABDStatus_ID]),
    CONSTRAINT [UQ_p_ABDFinalFolder_to_ABDStatus] UNIQUE NONCLUSTERED ([ABDFinalFolder_ID] ASC, [ABDStatus_ID] ASC)
);

