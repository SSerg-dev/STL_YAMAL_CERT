CREATE TABLE [dbo].[p_Document_to_GOST] (
    [Document_to_GOST_ID] UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]          DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]          DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]     UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]    UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]           INT                NOT NULL,
    [Document_ID]         UNIQUEIDENTIFIER   NOT NULL,
    [GOST_ID]             UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_p_Document_to_GOST] PRIMARY KEY CLUSTERED ([Document_to_GOST_ID] ASC),
    CONSTRAINT [FK_p_Document_to_GOST_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_GOST_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_GOST_p_Document_Document_ID] FOREIGN KEY ([Document_ID]) REFERENCES [dbo].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_Document_to_GOST_p_GOST_GOST_ID] FOREIGN KEY ([GOST_ID]) REFERENCES [dbo].[p_GOST] ([GOST_ID]),
    CONSTRAINT [FK_p_Document_to_GOST_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_Document_to_GOST_Document_ID_GOST_ID] UNIQUE NONCLUSTERED ([Document_ID] ASC, [GOST_ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_GOST_Created_User_ID]
    ON [dbo].[p_Document_to_GOST]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_GOST_GOST_ID]
    ON [dbo].[p_Document_to_GOST]([GOST_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_GOST_Modified_User_ID]
    ON [dbo].[p_Document_to_GOST]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_to_GOST_RowStatus]
    ON [dbo].[p_Document_to_GOST]([RowStatus] ASC);

