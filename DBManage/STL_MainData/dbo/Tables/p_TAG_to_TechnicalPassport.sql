CREATE TABLE [dbo].[p_TAG_to_TechnicalPassport] (
    [TAG_to_TechnicalPassport_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_TAG_to_TechnicalPassport_ID] DEFAULT (newsequentialid()) NOT NULL,
    [TechnicalPassport_ID]        UNIQUEIDENTIFIER NOT NULL,
    [TAG_ID]                      UNIQUEIDENTIFIER NOT NULL,
    [Row_status]                  INT              NULL,
    [Insert_DTS]                  DATETIME2 (7)    NULL,
    [Update_DTS]                  DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_TAG_to_TechnicalPassport] PRIMARY KEY CLUSTERED ([TAG_to_TechnicalPassport_ID] ASC),
    CONSTRAINT [FK_p_TAG_to_TechnicalPassport_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_TAG_to_TechnicalPassport_TAG_ID_p_TAG] FOREIGN KEY ([TAG_ID]) REFERENCES [dbo].[p_TAG] ([TAG_ID]),
    CONSTRAINT [FK_p_TAG_to_TechnicalPassport_TechnicalPassport_ID_p_TechnicalPassport] FOREIGN KEY ([TechnicalPassport_ID]) REFERENCES [dbo].[p_TechnicalPassport] ([TechnicalPassport_ID]),
    CONSTRAINT [UQ_p_TAG_to_TechnicalPassport] UNIQUE NONCLUSTERED ([TechnicalPassport_ID] ASC, [TAG_ID] ASC)
);

