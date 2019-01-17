CREATE TABLE [dbo].[p_PipingWorkType] (
    [PipingWorkType_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Description_Rus]     NVARCHAR (255)   NULL,
    [Description_Eng]     NVARCHAR (255)   NULL,
    [Row_Status]          INT              NULL,
    [Insert_DTS]          DATETIME2 (7)    NULL,
    [Update_DTS]          DATETIME2 (7)    NULL,
    [Report_Memo]         NCHAR (10)       NULL,
    [Report_Order]        INT              NULL,
    [PipingWorkType_Code] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_p_PipingWorkType] PRIMARY KEY CLUSTERED ([PipingWorkType_ID] ASC),
    CONSTRAINT [FK_p_PipingWorkType_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_PipingWorkType] UNIQUE NONCLUSTERED ([PipingWorkType_Code] ASC)
);

