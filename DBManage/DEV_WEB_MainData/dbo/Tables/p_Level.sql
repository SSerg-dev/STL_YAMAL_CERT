CREATE TABLE [dbo].[p_Level] (
    [Level_ID]         UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Level_Code]       NVARCHAR (255)     NOT NULL,
    [Description_Rus]  NVARCHAR (500)     NULL,
    CONSTRAINT [PK_p_Level] PRIMARY KEY CLUSTERED ([Level_ID] ASC),
    CONSTRAINT [FK_p_Level_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Level_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Level_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_Level_Level_Code] UNIQUE NONCLUSTERED ([Level_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_Level_Created_User_ID]
    ON [dbo].[p_Level]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Level_Modified_User_ID]
    ON [dbo].[p_Level]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Level_RowStatus]
    ON [dbo].[p_Level]([RowStatus] ASC);

