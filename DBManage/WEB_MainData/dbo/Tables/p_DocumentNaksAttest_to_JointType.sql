CREATE TABLE [dbo].[p_DocumentNaksAttest_to_JointType] (
    [RowStatus]                          INT              NOT NULL,
    [Insert_DTS]                         DATETIME2 (7)    NOT NULL,
    [Update_DTS]                         DATETIME2 (7)    NOT NULL,
    [Created_User_ID]                    UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                   UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_to_JointType_ID] UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_ID]              UNIQUEIDENTIFIER NOT NULL,
    [JointType_ID]                       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest_to_JointType] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_to_JointType_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_JointType_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_JointType_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_JointType_p_DocumentNaksAttest_DocumentNaksAttest_ID] FOREIGN KEY ([DocumentNaksAttest_ID]) REFERENCES [dbo].[p_DocumentNaksAttest] ([DocumentNaksAttest_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_p_DocumentNaksAttest_to_JointType_p_JointType_JointType_ID] FOREIGN KEY ([JointType_ID]) REFERENCES [dbo].[p_JointType] ([JointType_ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_JointType_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_JointType]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_JointType_JointType_ID]
    ON [dbo].[p_DocumentNaksAttest_to_JointType]([JointType_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_JointType_DocumentNaksAttest_ID]
    ON [dbo].[p_DocumentNaksAttest_to_JointType]([DocumentNaksAttest_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_JointType_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_JointType]([Created_User_ID] ASC);

