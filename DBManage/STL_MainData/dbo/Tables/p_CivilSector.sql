CREATE TABLE [dbo].[p_CivilSector] (
    [CivilSector_ID]     UNIQUEIDENTIFIER NOT NULL,
    [CivilSector_Number] NVARCHAR (100)   NOT NULL,
    [Row_status]         INT              NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    [TitleObject_ID]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_CivilSector] PRIMARY KEY CLUSTERED ([CivilSector_ID] ASC),
    CONSTRAINT [FK_p_CivilSector_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_CivilSector_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_CivilSector] UNIQUE NONCLUSTERED ([CivilSector_Number] ASC)
);

