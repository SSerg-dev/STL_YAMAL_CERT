CREATE TABLE [dbo].[p_DocumentNaksAttest_to_WeldMaterialGroup] (
    [RowStatus]                                  INT              NOT NULL,
    [Insert_DTS]                                 DATETIME2 (7)    NOT NULL,
    [Update_DTS]                                 DATETIME2 (7)    NOT NULL,
    [Created_User_ID]                            UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                           UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_to_WeldMaterialGroup_ID] UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_ID]                      UNIQUEIDENTIFIER NOT NULL,
    [WeldMaterialGroup_ID]                       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest_to_WeldMaterialGroup] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_to_WeldMaterialGroup_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_DocumentNaksAttest_DocumentNaksAttest_ID] FOREIGN KEY ([DocumentNaksAttest_ID]) REFERENCES [dbo].[p_DocumentNaksAttest] ([DocumentNaksAttest_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldMaterialGroup_p_WeldMaterialGroup_WeldMaterialGroup_ID] FOREIGN KEY ([WeldMaterialGroup_ID]) REFERENCES [dbo].[p_WeldMaterialGroup] ([WeldMaterialGroup_ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldMaterialGroup_WeldMaterialGroup_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldMaterialGroup]([WeldMaterialGroup_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldMaterialGroup_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldMaterialGroup]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldMaterialGroup_DocumentNaksAttest_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldMaterialGroup]([DocumentNaksAttest_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldMaterialGroup_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldMaterialGroup]([Created_User_ID] ASC);

