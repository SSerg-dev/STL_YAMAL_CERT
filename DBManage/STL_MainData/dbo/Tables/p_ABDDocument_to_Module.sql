CREATE TABLE [dbo].[p_ABDDocument_to_Module] (
    [ABDDocument_to_Module_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_Module_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]           UNIQUEIDENTIFIER NOT NULL,
    [Module_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]               INT              NULL,
    [Insert_DTS]               DATETIME2 (7)    NULL,
    [Update_DTS]               DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_Module] PRIMARY KEY CLUSTERED ([ABDDocument_to_Module_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_Module_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_Module_Module_ID_p_Module] FOREIGN KEY ([Module_ID]) REFERENCES [dbo].[p_Module] ([Module_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_Module_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument_to_Module] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [Module_ID] ASC)
);

