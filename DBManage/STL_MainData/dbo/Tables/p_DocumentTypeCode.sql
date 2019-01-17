CREATE TABLE [dbo].[p_DocumentTypeCode] (
    [DocumentTypeCode_ID]   UNIQUEIDENTIFIER NOT NULL,
    [DocumentTypeCode_Name] NVARCHAR (50)    NOT NULL,
    [Description_Eng]       NVARCHAR (255)   NULL,
    [Description_Rus]       NVARCHAR (255)   NULL,
    [Row_Status]            INT              NULL,
    [Insert_DTS]            DATETIME2 (7)    NULL,
    [Update_DTS]            DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_DocumentTypeCode] PRIMARY KEY CLUSTERED ([DocumentTypeCode_ID] ASC),
    CONSTRAINT [UQ_p_DocumentTypeCode] UNIQUE NONCLUSTERED ([DocumentTypeCode_Name] ASC)
);

