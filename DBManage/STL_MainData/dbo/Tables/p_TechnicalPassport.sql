CREATE TABLE [dbo].[p_TechnicalPassport] (
    [TechnicalPassport_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_TechnicalPassport_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    [Row_Status]             INT              NULL,
    [TechnicalPassport_Code] NVARCHAR (300)   NOT NULL,
    CONSTRAINT [PK_p_TechnicalPassport] PRIMARY KEY CLUSTERED ([TechnicalPassport_ID] ASC),
    CONSTRAINT [FK_p_TechnicalPassport_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_TechnicalPassport] UNIQUE NONCLUSTERED ([TechnicalPassport_Code] ASC)
);

