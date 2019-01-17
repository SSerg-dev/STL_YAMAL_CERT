CREATE TABLE [dbo].[p_HIFGroup] (
    [HIFGroup_ID]      UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [HIFGroup_Code]    NVARCHAR (255)     NOT NULL,
    [Description_Rus]  NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_HIFGroup] PRIMARY KEY CLUSTERED ([HIFGroup_ID] ASC),
    CONSTRAINT [FK_p_HIFGroup_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_HIFGroup_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_HIFGroup_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_HIFGroup_HIFGroup_Code] UNIQUE NONCLUSTERED ([HIFGroup_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_HIFGroup_Created_User_ID]
    ON [dbo].[p_HIFGroup]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_HIFGroup_Modified_User_ID]
    ON [dbo].[p_HIFGroup]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_HIFGroup_RowStatus]
    ON [dbo].[p_HIFGroup]([RowStatus] ASC);

