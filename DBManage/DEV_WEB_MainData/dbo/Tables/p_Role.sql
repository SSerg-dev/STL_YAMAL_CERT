CREATE TABLE [dbo].[p_Role] (
    [Role_ID]          UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Role_Code]        NVARCHAR (255)     NOT NULL,
    CONSTRAINT [PK_p_Role] PRIMARY KEY CLUSTERED ([Role_ID] ASC),
    CONSTRAINT [FK_p_Role_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Role_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Role_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_Role_Created_User_ID]
    ON [dbo].[p_Role]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Role_Modified_User_ID]
    ON [dbo].[p_Role]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Role_RowStatus]
    ON [dbo].[p_Role]([RowStatus] ASC);

