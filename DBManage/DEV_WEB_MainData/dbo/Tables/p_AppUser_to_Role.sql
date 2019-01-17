CREATE TABLE [dbo].[p_AppUser_to_Role] (
    [AppUser_to_Role_ID] UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]         DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]         DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]    UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]   UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]          INT                NOT NULL,
    [AppUser_ID]         UNIQUEIDENTIFIER   NOT NULL,
    [Role_ID]            UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_p_AppUser_to_Role] PRIMARY KEY CLUSTERED ([AppUser_to_Role_ID] ASC),
    CONSTRAINT [FK_p_AppUser_to_Role_p_AppUser_AppUser_ID] FOREIGN KEY ([AppUser_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUser_to_Role_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUser_to_Role_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUser_to_Role_p_Role_Role_ID] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[p_Role] ([Role_ID]),
    CONSTRAINT [FK_p_AppUser_to_Role_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_AppUser_to_Role_AppUser_ID_Role_ID] UNIQUE NONCLUSTERED ([AppUser_ID] ASC, [Role_ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_p_AppUser_to_Role_Created_User_ID]
    ON [dbo].[p_AppUser_to_Role]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_AppUser_to_Role_Modified_User_ID]
    ON [dbo].[p_AppUser_to_Role]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_AppUser_to_Role_Role_ID]
    ON [dbo].[p_AppUser_to_Role]([Role_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_AppUser_to_Role_RowStatus]
    ON [dbo].[p_AppUser_to_Role]([RowStatus] ASC);

