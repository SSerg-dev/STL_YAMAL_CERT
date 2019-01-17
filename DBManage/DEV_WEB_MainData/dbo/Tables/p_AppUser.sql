CREATE TABLE [dbo].[p_AppUser] (
    [AppUser_ID]       UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [AppUser_Code]     NVARCHAR (255)     NOT NULL,
    [Comment]          NVARCHAR (250)     NULL,
    [User_Password]    VARBINARY (8000)   NULL,
    CONSTRAINT [PK_p_AppUser] PRIMARY KEY CLUSTERED ([AppUser_ID] ASC),
    CONSTRAINT [FK_p_AppUser_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUser_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUser_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_AppUser_AppUser_Code] UNIQUE NONCLUSTERED ([AppUser_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_AppUser_Created_User_ID]
    ON [dbo].[p_AppUser]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_AppUser_Modified_User_ID]
    ON [dbo].[p_AppUser]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_AppUser_RowStatus]
    ON [dbo].[p_AppUser]([RowStatus] ASC);

