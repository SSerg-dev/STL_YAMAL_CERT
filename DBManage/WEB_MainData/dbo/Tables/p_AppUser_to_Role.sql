CREATE TABLE [dbo].[p_AppUser_to_Role] (
    [AppUser_to_Role_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_AppUser_to_Role_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]          INT              NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NOT NULL,
    [Update_DTS]         DATETIME2 (7)    NOT NULL,
    [Created_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [AppUser_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Role_ID]            UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_AppUser_to_Role] PRIMARY KEY CLUSTERED ([AppUser_to_Role_ID] ASC),
    CONSTRAINT [FK_p_AppUser_to_Role_AppUser_ID_p_AppUser] FOREIGN KEY ([AppUser_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUser_to_Role_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUser_to_Role_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUser_to_Role_Role_ID_p_Role] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[p_Role] ([Role_ID]),
    CONSTRAINT [FK_p_AppUser_to_Role_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_AppUser_to_Role] UNIQUE NONCLUSTERED ([AppUser_ID] ASC, [Role_ID] ASC)
);

