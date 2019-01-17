CREATE TABLE [dbo].[p_DocumentNaksAttest_to_SeamsType] (
    [DocumentNaksAttest_to_SeamsType_ID] UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                         DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]                         DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]                    UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]                   UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]                          INT                NOT NULL,
    [DocumentNaksAttest_ID]              UNIQUEIDENTIFIER   NOT NULL,
    [SeamsType_ID]                       UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest_to_SeamsType] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_to_SeamsType_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_SeamsType_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_SeamsType_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_SeamsType_p_DocumentNaksAttest_DocumentNaksAttest_ID] FOREIGN KEY ([DocumentNaksAttest_ID]) REFERENCES [dbo].[p_DocumentNaksAttest] ([DocumentNaksAttest_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_SeamsType_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_SeamsType_p_SeamsType_SeamsType_ID] FOREIGN KEY ([SeamsType_ID]) REFERENCES [dbo].[p_SeamsType] ([SeamsType_ID])
);




GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_SeamsType_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_SeamsType]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_SeamsType_DocumentNaksAttest_ID]
    ON [dbo].[p_DocumentNaksAttest_to_SeamsType]([DocumentNaksAttest_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_SeamsType_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_SeamsType]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_SeamsType_RowStatus]
    ON [dbo].[p_DocumentNaksAttest_to_SeamsType]([RowStatus] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_SeamsType_SeamsType_ID]
    ON [dbo].[p_DocumentNaksAttest_to_SeamsType]([SeamsType_ID] ASC);

