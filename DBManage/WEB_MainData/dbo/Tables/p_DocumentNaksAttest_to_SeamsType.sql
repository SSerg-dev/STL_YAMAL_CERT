CREATE TABLE [dbo].[p_DocumentNaksAttest_to_SeamsType] (
    [RowStatus]                          INT              NOT NULL,
    [Insert_DTS]                         DATETIME2 (7)    NOT NULL,
    [Update_DTS]                         DATETIME2 (7)    NOT NULL,
    [Created_User_ID]                    UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                   UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_to_SeamsType_ID] UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_ID]              UNIQUEIDENTIFIER NOT NULL,
    [SeamsType_ID]                       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest_to_SeamsType] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_to_SeamsType_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_SeamsType_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_SeamsType_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_SeamsType_p_DocumentNaksAttest_DocumentNaksAttest_ID] FOREIGN KEY ([DocumentNaksAttest_ID]) REFERENCES [dbo].[p_DocumentNaksAttest] ([DocumentNaksAttest_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_p_DocumentNaksAttest_to_SeamsType_p_SeamsType_SeamsType_ID] FOREIGN KEY ([SeamsType_ID]) REFERENCES [dbo].[p_SeamsType] ([SeamsType_ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_SeamsType_SeamsType_ID]
    ON [dbo].[p_DocumentNaksAttest_to_SeamsType]([SeamsType_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_SeamsType_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_SeamsType]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_SeamsType_DocumentNaksAttest_ID]
    ON [dbo].[p_DocumentNaksAttest_to_SeamsType]([DocumentNaksAttest_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_SeamsType_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_SeamsType]([Created_User_ID] ASC);

