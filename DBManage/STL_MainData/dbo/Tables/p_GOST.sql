CREATE TABLE [dbo].[p_GOST] (
    [GOST_ID]         UNIQUEIDENTIFIER CONSTRAINT [DF_GOST_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]      DATETIME2 (7)    NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    [Row_Status]      INT              NULL,
    [GOST_Code]       NVARCHAR (300)   NOT NULL,
    [Description_Rus] NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_GOST] PRIMARY KEY CLUSTERED ([GOST_ID] ASC),
    CONSTRAINT [FK_p_GOST_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_GOST] UNIQUE NONCLUSTERED ([GOST_Code] ASC)
);

