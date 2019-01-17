CREATE TABLE [dbo].[p_Contragent] (
    [Contragent_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_Contragent_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Code]            NVARCHAR (50)    NOT NULL,
    [Description_Eng] NVARCHAR (255)   NULL,
    [Description_Rus] NVARCHAR (255)   NULL,
    [Row_status]      INT              NULL,
    [Insert_DTS]      DATETIME2 (7)    NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_Contragent] PRIMARY KEY CLUSTERED ([Contragent_ID] ASC),
    CONSTRAINT [FK_p_Contragent_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Contragent] UNIQUE NONCLUSTERED ([Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [p_Contragent_idx_multiple]
    ON [dbo].[p_Contragent]([Contragent_ID] ASC, [Code] ASC);

