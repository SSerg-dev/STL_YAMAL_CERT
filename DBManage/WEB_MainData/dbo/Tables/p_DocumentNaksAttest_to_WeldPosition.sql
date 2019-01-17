CREATE TABLE [dbo].[p_DocumentNaksAttest_to_WeldPosition] (
    [RowStatus]                             INT              NOT NULL,
    [Insert_DTS]                            DATETIME2 (7)    NOT NULL,
    [Update_DTS]                            DATETIME2 (7)    NOT NULL,
    [Created_User_ID]                       UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                      UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_to_WeldPosition_ID] UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_ID]                 UNIQUEIDENTIFIER NOT NULL,
    [WeldPosition_ID]                       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest_to_WeldPosition] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_to_WeldPosition_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldPosition_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldPosition_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldPosition_p_DocumentNaksAttest_DocumentNaksAttest_ID] FOREIGN KEY ([DocumentNaksAttest_ID]) REFERENCES [dbo].[p_DocumentNaksAttest] ([DocumentNaksAttest_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldPosition_p_WeldPosition_WeldPosition_ID] FOREIGN KEY ([WeldPosition_ID]) REFERENCES [dbo].[p_WeldPosition] ([WeldPosition_ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldPosition_WeldPosition_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldPosition]([WeldPosition_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldPosition_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldPosition]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldPosition_DocumentNaksAttest_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldPosition]([DocumentNaksAttest_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldPosition_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldPosition]([Created_User_ID] ASC);

