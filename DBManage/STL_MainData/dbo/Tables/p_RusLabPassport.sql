CREATE TABLE [dbo].[p_RusLabPassport] (
    [p_RusLabPassport_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_RusLabPassport_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]            DATETIME2 (7)    NULL,
    [Update_DTS]            DATETIME2 (7)    NULL,
    [Row_Status]            INT              NULL,
    [p_RusLabPassport_Name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_p_RusLabPassport] PRIMARY KEY CLUSTERED ([p_RusLabPassport_ID] ASC),
    CONSTRAINT [FK_p_RusLabPassport_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_RusLabPassport] UNIQUE NONCLUSTERED ([p_RusLabPassport_Name] ASC)
);

