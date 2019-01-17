CREATE TABLE [dbo].[p_GOST_to_Marka] (
    [GOST_to_Marka_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_GOST_to_Marka_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NULL,
    [Update_DTS]       DATETIME2 (7)    NULL,
    [Row_Status]       INT              NULL,
    [GOST_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Marka_ID]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_GOST_to_Marka] PRIMARY KEY CLUSTERED ([GOST_to_Marka_ID] ASC),
    CONSTRAINT [FK_p_GOST_to_Marka_GOST_ID_p_GOST] FOREIGN KEY ([GOST_ID]) REFERENCES [dbo].[p_GOST] ([GOST_ID]),
    CONSTRAINT [FK_p_GOST_to_Marka_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_GOST_to_Marka_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_GOST_to_Marka] UNIQUE NONCLUSTERED ([GOST_ID] ASC, [Marka_ID] ASC)
);

