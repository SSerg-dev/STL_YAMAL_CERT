CREATE TABLE [dbo].[p_ABDDocument_to_ABDFinalFolder] (
    [ABDDocument_to_ABDFinalFolder_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_ABDFinalFolder_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]                   UNIQUEIDENTIFIER NOT NULL,
    [ABDFinalFolder_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Number_in_Folder]                 INT              NOT NULL,
    [Sheet_Folder_Number]              INT              NOT NULL,
    [Remark]                           NVARCHAR (255)   NULL,
    [Row_Status]                       INT              NULL,
    [Insert_DTS]                       DATETIME2 (7)    NULL,
    [Update_DTS]                       DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_ABDFinalFolder] PRIMARY KEY CLUSTERED ([ABDDocument_to_ABDFinalFolder_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_ABDFinalFolder_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_ABDFinalFolder_ABDFinalFolder_ID_p_ABDFinalFolder] FOREIGN KEY ([ABDFinalFolder_ID]) REFERENCES [dbo].[p_ABDFinalFolder] ([ABDFinalFolder_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_ABDFinalFolder_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument_to_ABDFinalFolder] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [ABDFinalFolder_ID] ASC)
);

