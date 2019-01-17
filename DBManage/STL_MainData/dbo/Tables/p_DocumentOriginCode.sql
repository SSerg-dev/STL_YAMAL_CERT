CREATE TABLE [dbo].[p_DocumentOriginCode] (
    [DocumentOriginCode_ID]   UNIQUEIDENTIFIER NOT NULL,
    [DocumentOriginCode_Name] NVARCHAR (50)    NOT NULL,
    [Description_Eng]         NVARCHAR (255)   NULL,
    [Description_Rus]         NVARCHAR (255)   NULL,
    [Row_Status]              INT              NULL,
    [Insert_DTS]              DATETIME2 (7)    NULL,
    [Update_DTS]              DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_DocumentOriginCode] PRIMARY KEY CLUSTERED ([DocumentOriginCode_ID] ASC),
    CONSTRAINT [UQ_p_DocumentOriginCode] UNIQUE NONCLUSTERED ([DocumentOriginCode_Name] ASC)
);

