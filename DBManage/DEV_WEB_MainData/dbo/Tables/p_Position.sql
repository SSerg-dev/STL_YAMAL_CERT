CREATE TABLE [dbo].[p_Position] (
    [Position_ID]      UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Position_Code]    NVARCHAR (255)     NOT NULL,
    [Description_Rus]  NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_Position] PRIMARY KEY CLUSTERED ([Position_ID] ASC),
    CONSTRAINT [FK_p_Position_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Position_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Position_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_Position_Position_Code] UNIQUE NONCLUSTERED ([Position_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_Position_Created_User_ID]
    ON [dbo].[p_Position]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Position_Modified_User_ID]
    ON [dbo].[p_Position]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Position_RowStatus]
    ON [dbo].[p_Position]([RowStatus] ASC);

