CREATE TABLE [dbo].[p_TAG] (
    [TAG_ID]          UNIQUEIDENTIFIER CONSTRAINT [DF_TAG_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]      DATETIME2 (7)    NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    [Row_Status]      INT              NULL,
    [TAG_Code]        NVARCHAR (300)   NOT NULL,
    [Description_Eng] NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_TAG] PRIMARY KEY CLUSTERED ([TAG_ID] ASC),
    CONSTRAINT [FK_p_TAG_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_TAG] UNIQUE NONCLUSTERED ([TAG_Code] ASC)
);

