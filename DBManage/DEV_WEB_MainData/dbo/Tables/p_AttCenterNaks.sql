CREATE TABLE [dbo].[p_AttCenterNaks] (
    [AttCenterNaks_ID]   UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]         DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]         DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]    UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]   UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]          INT                NOT NULL,
    [City]               NVARCHAR (MAX)     NULL,
    [AttCenterNaks_Code] NVARCHAR (255)     NOT NULL,
    [Description_Rus]    NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_AttCenterNaks] PRIMARY KEY CLUSTERED ([AttCenterNaks_ID] ASC),
    CONSTRAINT [FK_p_AttCenterNaks_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AttCenterNaks_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AttCenterNaks_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_AttCenterNaks_AttCenterNaks_Code] UNIQUE NONCLUSTERED ([AttCenterNaks_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_AttCenterNaks_Created_User_ID]
    ON [dbo].[p_AttCenterNaks]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_AttCenterNaks_Modified_User_ID]
    ON [dbo].[p_AttCenterNaks]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_AttCenterNaks_RowStatus]
    ON [dbo].[p_AttCenterNaks]([RowStatus] ASC);

