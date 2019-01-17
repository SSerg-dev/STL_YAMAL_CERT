CREATE TABLE [dbo].[p_PID] (
    [PID_ID]           UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [PID_Code]         NVARCHAR (255)     NOT NULL,
    [Description_Eng]  NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_PID] PRIMARY KEY CLUSTERED ([PID_ID] ASC),
    CONSTRAINT [FK_p_PID_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_PID_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_PID_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_PID_Created_User_ID]
    ON [dbo].[p_PID]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_PID_Modified_User_ID]
    ON [dbo].[p_PID]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_PID_RowStatus]
    ON [dbo].[p_PID]([RowStatus] ASC);

