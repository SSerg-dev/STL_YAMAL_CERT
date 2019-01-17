CREATE TABLE [dbo].[p_DisciplineDocumentCode] (
    [DisciplineDocumentCode_ID]   UNIQUEIDENTIFIER NOT NULL,
    [DisciplineDocumentCode_Name] NVARCHAR (50)    NOT NULL,
    [Description_Eng]             NVARCHAR (255)   NULL,
    [Description_Rus]             NVARCHAR (255)   NULL,
    [Row_Status]                  INT              NULL,
    [Insert_DTS]                  DATETIME2 (7)    NULL,
    [Update_DTS]                  DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_DisciplineDocumentCode] PRIMARY KEY CLUSTERED ([DisciplineDocumentCode_ID] ASC),
    CONSTRAINT [UQ_p_DisciplineDocumentCode] UNIQUE NONCLUSTERED ([DisciplineDocumentCode_Name] ASC)
);

