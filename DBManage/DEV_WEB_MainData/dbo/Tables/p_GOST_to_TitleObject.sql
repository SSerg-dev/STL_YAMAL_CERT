CREATE TABLE [dbo].[p_GOST_to_TitleObject] (
    [GOST_to_TitleObject_ID] UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]             DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]        UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]       UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]              INT                NOT NULL,
    [GOST_ID]                UNIQUEIDENTIFIER   NOT NULL,
    [TitleObject_ID]         UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_p_GOST_to_TitleObject] PRIMARY KEY CLUSTERED ([GOST_to_TitleObject_ID] ASC),
    CONSTRAINT [FK_p_GOST_to_TitleObject_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_GOST_to_TitleObject_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_GOST_to_TitleObject_p_GOST_GOST_ID] FOREIGN KEY ([GOST_ID]) REFERENCES [dbo].[p_GOST] ([GOST_ID]),
    CONSTRAINT [FK_p_GOST_to_TitleObject_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_GOST_to_TitleObject_p_TitleObject_TitleObject_ID] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [AK_p_GOST_to_TitleObject_GOST_ID_TitleObject_ID] UNIQUE NONCLUSTERED ([GOST_ID] ASC, [TitleObject_ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_p_GOST_to_TitleObject_Created_User_ID]
    ON [dbo].[p_GOST_to_TitleObject]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_GOST_to_TitleObject_Modified_User_ID]
    ON [dbo].[p_GOST_to_TitleObject]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_GOST_to_TitleObject_RowStatus]
    ON [dbo].[p_GOST_to_TitleObject]([RowStatus] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_GOST_to_TitleObject_TitleObject_ID]
    ON [dbo].[p_GOST_to_TitleObject]([TitleObject_ID] ASC);

