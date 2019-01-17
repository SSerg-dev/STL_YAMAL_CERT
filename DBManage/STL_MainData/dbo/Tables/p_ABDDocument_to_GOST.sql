CREATE TABLE [dbo].[p_ABDDocument_to_GOST] (
    [ABDDocument_to_GOST_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_GOST_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]         UNIQUEIDENTIFIER NOT NULL,
    [GOST_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]             INT              NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_GOST] PRIMARY KEY CLUSTERED ([ABDDocument_to_GOST_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_GOST_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_GOST_GOST_ID_p_GOST] FOREIGN KEY ([GOST_ID]) REFERENCES [dbo].[p_GOST] ([GOST_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_GOST_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument_to_GOST] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [GOST_ID] ASC)
);

