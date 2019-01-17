CREATE TABLE [dbo].[p_TestPack] (
    [TestPack_ID]         UNIQUEIDENTIFIER CONSTRAINT [DF_TestPack_ID] DEFAULT (newsequentialid()) NOT NULL,
    [TestPack_Name]       NVARCHAR (255)   NOT NULL,
    [Row_status]          INT              NULL,
    [Insert_DTS]          DATETIME2 (7)    NULL,
    [Update_DTS]          DATETIME2 (7)    NULL,
    [Test_Completed_Date] DATETIME2 (7)    NULL,
    [TestType_ID]         UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_TestPack] PRIMARY KEY CLUSTERED ([TestPack_ID] ASC),
    CONSTRAINT [FK_p_TestPack_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_TestPack_TestType_ID_p_TestType] FOREIGN KEY ([TestType_ID]) REFERENCES [dbo].[p_TestType] ([TestType_ID]),
    CONSTRAINT [UQ_p_TestPack] UNIQUE NONCLUSTERED ([TestPack_Name] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'This table contains Test_Completed_Date field by import of raw data. Later that field becomes an attribute of a table of relationship between an ISO and a TEST Pack', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'p_TestPack', @level2type = N'COLUMN', @level2name = N'Test_Completed_Date';

