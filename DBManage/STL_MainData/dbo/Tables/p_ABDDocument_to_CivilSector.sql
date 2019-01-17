CREATE TABLE [dbo].[p_ABDDocument_to_CivilSector] (
    [ABDDocument_to_CivilSector_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_CivilSector_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]                UNIQUEIDENTIFIER NOT NULL,
    [CivilSector_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                    INT              NULL,
    [Insert_DTS]                    DATETIME2 (7)    NULL,
    [Update_DTS]                    DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_CivilSector] PRIMARY KEY CLUSTERED ([ABDDocument_to_CivilSector_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_CivilSector_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_CivilSector_CivilSector_ID_p_CivilSector] FOREIGN KEY ([CivilSector_ID]) REFERENCES [dbo].[p_CivilSector] ([CivilSector_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_CivilSector_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument_to_CivilSector] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [CivilSector_ID] ASC)
);

