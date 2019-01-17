CREATE TABLE [dbo].[p_Register_to_ABDFinalFolder] (
    [Register_To_ABDFinalFolder_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_ABDFinalFolder_ID] DEFAULT (newid()) NOT NULL,
    [DTS_Start]                     DATETIME2 (7)    NULL,
    [DTS_End]                       DATETIME2 (7)    NULL,
    [Row_status]                    INT              NULL,
    [Register_ID]                   UNIQUEIDENTIFIER NOT NULL,
    [ABDFinalFolder_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]                    DATETIME2 (7)    NULL,
    [Update_DTS]                    DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_Register_to_ABDFinalFolder] PRIMARY KEY CLUSTERED ([Register_To_ABDFinalFolder_ID] ASC),
    CONSTRAINT [FK_p_Register_to_ABDFinalFolder_ABDFinalFolder_ID_p_ABDFinalFolder] FOREIGN KEY ([ABDFinalFolder_ID]) REFERENCES [dbo].[p_ABDFinalFolder] ([ABDFinalFolder_ID]),
    CONSTRAINT [FK_p_Register_to_ABDFinalFolder_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_ABDFinalFolder_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Register_to_ABDFinalFolder] UNIQUE NONCLUSTERED ([ABDFinalFolder_ID] ASC, [Register_ID] ASC)
);

