CREATE TABLE [dbo].[p_UnitNumberDocumentCode] (
    [UnitNumberDocumentCode_ID]   UNIQUEIDENTIFIER NOT NULL,
    [UnitNumberDocumentCode_Name] NVARCHAR (50)    NOT NULL,
    [Description_Eng]             NVARCHAR (255)   NULL,
    [Description_Rus]             NVARCHAR (255)   NULL,
    [Row_Status]                  INT              NULL,
    [Insert_DTS]                  DATETIME2 (7)    NULL,
    [Update_DTS]                  DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_UnitNumberDocumentCode] PRIMARY KEY CLUSTERED ([UnitNumberDocumentCode_ID] ASC),
    CONSTRAINT [FK_p_UnitNumberDocumentCode_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_UnitNumberDocumentCode] UNIQUE NONCLUSTERED ([UnitNumberDocumentCode_Name] ASC)
);

