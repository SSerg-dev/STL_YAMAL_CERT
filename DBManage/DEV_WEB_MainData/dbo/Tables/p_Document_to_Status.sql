CREATE TABLE [dbo].[p_Document_to_Status] (
    [Document_to_Status_ID] UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]            DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]            DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]       UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]      UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]             INT                NOT NULL,
    [Document_ID]           UNIQUEIDENTIFIER   NOT NULL,
    [Status_ID]             UNIQUEIDENTIFIER   NOT NULL,
    [DTS_Start]             DATETIMEOFFSET (7) NOT NULL,
    [DTS_End]               DATETIMEOFFSET (7) NULL,
    [Parent_ID]             UNIQUEIDENTIFIER   NULL,
    CONSTRAINT [PK_p_Document_to_Status] PRIMARY KEY CLUSTERED ([Document_to_Status_ID] ASC),
    CONSTRAINT [FK_p_Document_to_Status_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_Status_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_Status_p_Document_Document_ID] FOREIGN KEY ([Document_ID]) REFERENCES [dbo].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_Document_to_Status_p_Document_to_Status_Parent_ID] FOREIGN KEY ([Parent_ID]) REFERENCES [dbo].[p_Document_to_Status] ([Document_to_Status_ID]),
    CONSTRAINT [FK_p_Document_to_Status_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_Document_to_Status_p_Status_Status_ID] FOREIGN KEY ([Status_ID]) REFERENCES [dbo].[p_Status] ([Status_ID])
);




GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_Status_Created_User_ID]
    ON [dbo].[p_Document_to_Status]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_Status_Document_ID]
    ON [dbo].[p_Document_to_Status]([Document_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_Status_Modified_User_ID]
    ON [dbo].[p_Document_to_Status]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_Status_Parent_ID]
    ON [dbo].[p_Document_to_Status]([Parent_ID] ASC);




GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_Status_RowStatus]
    ON [dbo].[p_Document_to_Status]([RowStatus] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_Status_Status_ID]
    ON [dbo].[p_Document_to_Status]([Status_ID] ASC);

