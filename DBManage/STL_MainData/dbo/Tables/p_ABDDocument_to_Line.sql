CREATE TABLE [dbo].[p_ABDDocument_to_Line] (
    [ABDDocument_to_Line_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_Line_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Line_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]             INT              NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_Line] PRIMARY KEY CLUSTERED ([ABDDocument_to_Line_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_Line_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_Line_Line_ID_p_Line] FOREIGN KEY ([Line_ID]) REFERENCES [dbo].[p_Line] ([Line_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_Line_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument_to_Line] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [Line_ID] ASC)
);

