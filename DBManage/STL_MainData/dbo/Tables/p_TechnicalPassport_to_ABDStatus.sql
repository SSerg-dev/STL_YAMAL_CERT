CREATE TABLE [dbo].[p_TechnicalPassport_to_ABDStatus] (
    [TechnicalPassport_To_ABDStatus_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_TechnicalPassport_to_ABDStatus_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Parent_ID]                         UNIQUEIDENTIFIER NULL,
    [DTS_Start]                         DATETIME2 (7)    NULL,
    [DTS_End]                           DATETIME2 (7)    NULL,
    [Insert_DTS]                        DATETIME2 (7)    NULL,
    [Update_DTS]                        DATETIME2 (7)    NULL,
    [Row_status]                        INT              NULL,
    [TechnicalPassport_ID]              UNIQUEIDENTIFIER NOT NULL,
    [ABDStatus_ID]                      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_TechnicalPassport_to_ABDStatus] PRIMARY KEY CLUSTERED ([TechnicalPassport_To_ABDStatus_ID] ASC),
    CONSTRAINT [FK_p_TechnicalPassport_to_ABDStatus_ABDStatus_ID_p_ABDStatus] FOREIGN KEY ([ABDStatus_ID]) REFERENCES [dbo].[p_ABDStatus] ([ABDStatus_ID]),
    CONSTRAINT [FK_p_TechnicalPassport_to_ABDStatus_TechnicalPassport_ID_p_TechnicalPassport] FOREIGN KEY ([TechnicalPassport_ID]) REFERENCES [dbo].[p_TechnicalPassport] ([TechnicalPassport_ID]),
    CONSTRAINT [UQ_p_TechnicalPassport_to_ABDStatus] UNIQUE NONCLUSTERED ([TechnicalPassport_ID] ASC, [ABDStatus_ID] ASC)
);

