CREATE TABLE [dbo].[p_ABDFinalFolder] (
    [ABDFinalFolder_ID]             UNIQUEIDENTIFIER CONSTRAINT [DF_ABDFinalFolder_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDFinalFolder_Name]           NVARCHAR (100)   NOT NULL,
    [Row_status]                    INT              NULL,
    [Insert_DTS]                    DATETIME2 (7)    NULL,
    [Update_DTS]                    DATETIME2 (7)    NULL,
    [Final_Compilation_Target_Date] DATETIME2 (7)    NULL,
    [Final_Compilation_Start_Date]  DATETIME2 (7)    NULL,
    [CTR_RESP]                      NVARCHAR (255)   NULL,
    [ListCount]                     INT              NULL,
    CONSTRAINT [PK_p_ABDFinalFolder] PRIMARY KEY CLUSTERED ([ABDFinalFolder_ID] ASC),
    CONSTRAINT [FK_p_ABDFinalFolder_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDFinalFolder] UNIQUE NONCLUSTERED ([ABDFinalFolder_Name] ASC)
);

