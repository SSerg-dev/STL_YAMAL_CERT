CREATE TABLE [dbo].[TMP_SystemTestObject] (
    [ID]                UNIQUEIDENTIFIER CONSTRAINT [DF_STO_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]        DATETIME2 (7)    NULL,
    [TestObject_ID]     UNIQUEIDENTIFIER NULL,
    [TestObject_Code]   NVARCHAR (255)   NULL,
    [TestObject_Entity] NVARCHAR (255)   NULL,
    [Run_Number]        BIGINT           NULL,
    CONSTRAINT [PK_p_STO] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UQ_p_STO] UNIQUE NONCLUSTERED ([TestObject_ID] ASC)
);

