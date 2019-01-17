CREATE TABLE [dbo].[p_ISO_to_Marka] (
    [ISO_to_Marka_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ISO_to_Marka_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]      DATETIME2 (7)    NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    [Row_Status]      INT              NULL,
    [ISO_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Marka_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ISO_to_Marka] PRIMARY KEY CLUSTERED ([ISO_to_Marka_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_Marka_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_Marka_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_ISO_to_Marka_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ISO_to_Marka] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [Marka_ID] ASC)
);

