CREATE TABLE [dbo].[p_WorkPackage_to_Contragent] (
    [WorkPackage_to_Contragent_ID] UNIQUEIDENTIFIER NOT NULL,
    [WorkPackage_ID]               UNIQUEIDENTIFIER NOT NULL,
    [Contragent_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                   INT              NULL,
    [Insert_DTS]                   DATETIME2 (7)    NULL,
    [Update_DTS]                   DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_WorkPackage_to_Contragent] PRIMARY KEY CLUSTERED ([WorkPackage_to_Contragent_ID] ASC),
    CONSTRAINT [FK_p_WorkPackage_to_Contragent_Contragent_ID_p_Contragent] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_WorkPackage_to_Contragent_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_WorkPackage_to_Contragent_WorkPackage_ID_p_WorkPackage] FOREIGN KEY ([WorkPackage_ID]) REFERENCES [dbo].[p_WorkPackage] ([WorkPackage_ID]),
    CONSTRAINT [UQ_p_WorkPackage_to_Contragent] UNIQUE NONCLUSTERED ([WorkPackage_ID] ASC, [Contragent_ID] ASC)
);

