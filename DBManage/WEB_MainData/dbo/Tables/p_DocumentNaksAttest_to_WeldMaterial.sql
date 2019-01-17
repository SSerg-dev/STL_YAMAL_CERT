CREATE TABLE [dbo].[p_DocumentNaksAttest_to_WeldMaterial] (
    [RowStatus]                             INT              NOT NULL,
    [Insert_DTS]                            DATETIME2 (7)    NOT NULL,
    [Update_DTS]                            DATETIME2 (7)    NOT NULL,
    [Created_User_ID]                       UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                      UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_to_WeldMaterial_ID] UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_ID]                 UNIQUEIDENTIFIER NOT NULL,
    [WeldMaterial_ID]                       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest_to_WeldMaterial] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_to_WeldMaterial_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldMaterial_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldMaterial_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldMaterial_p_DocumentNaksAttest_DocumentNaksAttest_ID] FOREIGN KEY ([DocumentNaksAttest_ID]) REFERENCES [dbo].[p_DocumentNaksAttest] ([DocumentNaksAttest_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldMaterial_p_WeldMaterial_WeldMaterial_ID] FOREIGN KEY ([WeldMaterial_ID]) REFERENCES [dbo].[p_WeldMaterial] ([WeldMaterial_ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldMaterial_WeldMaterial_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldMaterial]([WeldMaterial_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldMaterial_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldMaterial]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldMaterial_DocumentNaksAttest_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldMaterial]([DocumentNaksAttest_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldMaterial_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldMaterial]([Created_User_ID] ASC);

