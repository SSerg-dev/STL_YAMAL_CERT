CREATE TABLE [dbo].[p_DocumentNaksAttest_to_DetailsType] (
    [RowStatus]                            INT              NOT NULL,
    [Insert_DTS]                           DATETIME2 (7)    NOT NULL,
    [Update_DTS]                           DATETIME2 (7)    NOT NULL,
    [Created_User_ID]                      UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                     UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_to_DetailsType_ID] UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_ID]                UNIQUEIDENTIFIER NOT NULL,
    [DetailsType_ID]                       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest_to_DetailsType] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_to_DetailsType_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_DetailsType_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_DetailsType_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_DetailsType_p_DetailsType_DetailsType_ID] FOREIGN KEY ([DetailsType_ID]) REFERENCES [dbo].[p_DetailsType] ([DetailsType_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_p_DocumentNaksAttest_to_DetailsType_p_DocumentNaksAttest_DocumentNaksAttest_ID] FOREIGN KEY ([DocumentNaksAttest_ID]) REFERENCES [dbo].[p_DocumentNaksAttest] ([DocumentNaksAttest_ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_DetailsType_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_DetailsType]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_DetailsType_DocumentNaksAttest_ID]
    ON [dbo].[p_DocumentNaksAttest_to_DetailsType]([DocumentNaksAttest_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_DetailsType_DetailsType_ID]
    ON [dbo].[p_DocumentNaksAttest_to_DetailsType]([DetailsType_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_DetailsType_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_DetailsType]([Created_User_ID] ASC);

