CREATE TABLE [dbo].[p_Marka] (
    [Marka_ID]                     UNIQUEIDENTIFIER NOT NULL,
    [Marka_Name]                   NVARCHAR (50)    NOT NULL,
    [Code_of_mark]                 NVARCHAR (50)    NULL,
    [Description_Eng]              NVARCHAR (255)   NULL,
    [Description_Rus]              NVARCHAR (255)   NULL,
    [Engineering_Drawing_Type_Eng] NVARCHAR (300)   NULL,
    [Engineering_Drawing_Type_Rus] NVARCHAR (500)   NULL,
    [Row_Status]                   INT              NULL,
    [IsUsedInMatrix]               BIT              NULL,
    [IsPriority]                   BIT              NULL,
    [Insert_DTS]                   DATETIME2 (7)    NULL,
    [Update_DTS]                   DATETIME2 (7)    NULL,
    [ReportColor]                  NVARCHAR (50)    NULL,
    [ReportOrder]                  INT              NULL,
    [Created_By]                   NVARCHAR (255)   NULL,
    [Modified_By]                  NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_Marka] PRIMARY KEY CLUSTERED ([Marka_ID] ASC),
    CONSTRAINT [FK_p_Marka_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Marka] UNIQUE NONCLUSTERED ([Marka_Name] ASC)
);

