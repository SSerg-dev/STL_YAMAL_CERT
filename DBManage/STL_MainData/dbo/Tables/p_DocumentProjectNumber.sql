CREATE TABLE [dbo].[p_DocumentProjectNumber] (
    [DocumentProjectNumber_ID]   UNIQUEIDENTIFIER NOT NULL,
    [DocumentProjectNumber_Name] NVARCHAR (50)    NOT NULL,
    [Description_Eng]            NVARCHAR (255)   NULL,
    [Description_Rus]            NVARCHAR (255)   NULL,
    [Row_Status]                 INT              NULL,
    [Insert_DTS]                 DATETIME2 (7)    NULL,
    [Update_DTS]                 DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_DocumentProjectNumber] PRIMARY KEY CLUSTERED ([DocumentProjectNumber_ID] ASC),
    CONSTRAINT [UQ_p_DocumentProjectNumber] UNIQUE NONCLUSTERED ([DocumentProjectNumber_Name] ASC)
);

