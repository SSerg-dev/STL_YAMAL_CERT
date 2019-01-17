CREATE TABLE [dbo].[p_SubSubContractor2] (
    [SubSubContractor_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_SubSubContractor2_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]            DATETIME2 (7)    NULL,
    [Update_DTS]            DATETIME2 (7)    NULL,
    [Row_Status]            INT              NULL,
    [Description_Eng]       NVARCHAR (255)   NULL,
    [Description_Rus]       NVARCHAR (255)   NULL,
    [SubSubContractor_Name] NVARCHAR (300)   NOT NULL,
    CONSTRAINT [FK_p_SubSubContractor2_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_SubSubContractor2] UNIQUE NONCLUSTERED ([SubSubContractor_Name] ASC)
);

