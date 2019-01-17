CREATE TABLE [dbo].[p_TestPack_to_ISO] (
    [TestPack_to_ISO_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_TestPack_to_ISO_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ISO_ID]             UNIQUEIDENTIFIER NOT NULL,
    [TestPack_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Row_status]         INT              NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_TestPack_to_ISO] PRIMARY KEY CLUSTERED ([TestPack_to_ISO_ID] ASC),
    CONSTRAINT [FK_p_TestPack_to_ISO_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_TestPack_to_ISO_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_TestPack_to_ISO_TestPack_ID_p_TestPack] FOREIGN KEY ([TestPack_ID]) REFERENCES [dbo].[p_TestPack] ([TestPack_ID]),
    CONSTRAINT [UQ_p_TestPack_to_ISO] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [TestPack_ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [p_Test_Pack_to_ISO_idx_ISO_ID_Test_Pack_ID]
    ON [dbo].[p_TestPack_to_ISO]([ISO_ID] ASC, [TestPack_ID] ASC);

