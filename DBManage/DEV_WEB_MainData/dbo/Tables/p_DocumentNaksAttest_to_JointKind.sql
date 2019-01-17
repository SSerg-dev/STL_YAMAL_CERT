CREATE TABLE [dbo].[p_DocumentNaksAttest_to_JointKind] (
    [DocumentNaksAttest_to_JointKind_ID] UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                         DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]                         DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]                    UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]                   UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]                          INT                NOT NULL,
    [DocumentNaksAttest_ID]              UNIQUEIDENTIFIER   NOT NULL,
    [JointKind_ID]                       UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest_to_JointKind] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_to_JointKind_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_JointKind_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_JointKind_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_JointKind_p_DocumentNaksAttest_DocumentNaksAttest_ID] FOREIGN KEY ([DocumentNaksAttest_ID]) REFERENCES [dbo].[p_DocumentNaksAttest] ([DocumentNaksAttest_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_JointKind_p_JointKind_JointKind_ID] FOREIGN KEY ([JointKind_ID]) REFERENCES [dbo].[p_JointKind] ([JointKind_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_JointKind_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID])
);




GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_JointKind_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_JointKind]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_JointKind_DocumentNaksAttest_ID]
    ON [dbo].[p_DocumentNaksAttest_to_JointKind]([DocumentNaksAttest_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_JointKind_JointKind_ID]
    ON [dbo].[p_DocumentNaksAttest_to_JointKind]([JointKind_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_JointKind_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_JointKind]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_JointKind_RowStatus]
    ON [dbo].[p_DocumentNaksAttest_to_JointKind]([RowStatus] ASC);

