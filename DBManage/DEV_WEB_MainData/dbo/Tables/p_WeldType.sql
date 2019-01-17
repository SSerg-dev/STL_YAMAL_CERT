CREATE TABLE [dbo].[p_WeldType] (
    [WeldType_ID]      UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [WeldType_Code]    NVARCHAR (255)     NOT NULL,
    [Description_Rus]  NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_WeldType] PRIMARY KEY CLUSTERED ([WeldType_ID] ASC),
    CONSTRAINT [FK_p_WeldType_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WeldType_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WeldType_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_WeldType_WeldType_Code] UNIQUE NONCLUSTERED ([WeldType_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_WeldType_Created_User_ID]
    ON [dbo].[p_WeldType]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_WeldType_Modified_User_ID]
    ON [dbo].[p_WeldType]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_WeldType_RowStatus]
    ON [dbo].[p_WeldType]([RowStatus] ASC);

