CREATE TABLE [dbo].[p_Document_to_PID] (
    [Document_to_PID_ID] UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]         DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]         DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]    UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]   UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]          INT                NOT NULL,
    [Document_ID]        UNIQUEIDENTIFIER   NOT NULL,
    [PID_ID]             UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_p_Document_to_PID] PRIMARY KEY CLUSTERED ([Document_to_PID_ID] ASC),
    CONSTRAINT [FK_p_Document_to_PID_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_PID_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_PID_p_Document_Document_ID] FOREIGN KEY ([Document_ID]) REFERENCES [dbo].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_Document_to_PID_p_PID_PID_ID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_Document_to_PID_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_Document_to_PID_Document_ID_PID_ID] UNIQUE NONCLUSTERED ([Document_ID] ASC, [PID_ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_PID_Created_User_ID]
    ON [dbo].[p_Document_to_PID]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_PID_Modified_User_ID]
    ON [dbo].[p_Document_to_PID]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_PID_PID_ID]
    ON [dbo].[p_Document_to_PID]([PID_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_PID_RowStatus]
    ON [dbo].[p_Document_to_PID]([RowStatus] ASC);

