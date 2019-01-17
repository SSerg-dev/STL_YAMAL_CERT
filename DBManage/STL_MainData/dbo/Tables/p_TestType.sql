CREATE TABLE [dbo].[p_TestType] (
    [TestType_ID]     UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]      DATETIME2 (7)    NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    [Row_Status]      INT              NULL,
    [TestType_Name]   NVARCHAR (50)    NOT NULL,
    [Description_Eng] NVARCHAR (100)   NULL,
    [Description_Rus] NVARCHAR (100)   NULL,
    CONSTRAINT [PK_p_TestType] PRIMARY KEY CLUSTERED ([TestType_ID] ASC),
    CONSTRAINT [FK_p_TestType_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_TestType] UNIQUE NONCLUSTERED ([TestType_Name] ASC)
);

