CREATE TABLE [dbo].[p_ABDDocument_to_TestPack] (
    [ABDDocument_to_TestPack_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_TestPack_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Row_Status]                 INT              NULL,
    [Insert_DTS]                 DATETIME2 (7)    NULL,
    [Update_DTS]                 DATETIME2 (7)    NULL,
    [Created_User_ID]            UNIQUEIDENTIFIER NULL,
    [Modified_User_ID]           UNIQUEIDENTIFIER NULL,
    [ABDDocument_ID]             UNIQUEIDENTIFIER NOT NULL,
    [TestPack_ID]                UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ABDDocument_to_TestPack] PRIMARY KEY CLUSTERED ([ABDDocument_to_TestPack_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_TestPack_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_TestPack_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_TestPack_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_TestPack_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ABDDocument_to_TestPack_TestPack_ID_p_TestPack] FOREIGN KEY ([TestPack_ID]) REFERENCES [dbo].[p_TestPack] ([TestPack_ID]),
    CONSTRAINT [UQ_p_ABDDocument_to_TestPack] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [TestPack_ID] ASC)
);

