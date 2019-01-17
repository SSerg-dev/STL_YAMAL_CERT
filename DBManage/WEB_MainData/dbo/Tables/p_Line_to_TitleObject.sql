CREATE TABLE [dbo].[p_Line_to_TitleObject] (
    [Line_to_TitleObject_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Line_to_TitleObject_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]              INT              NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NOT NULL,
    [Update_DTS]             DATETIME2 (7)    NOT NULL,
    [Created_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]       UNIQUEIDENTIFIER NOT NULL,
    [Line_ID]                UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Line_to_TitleObject] PRIMARY KEY CLUSTERED ([Line_to_TitleObject_ID] ASC),
    CONSTRAINT [FK_p_Line_to_TitleObject_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Line_to_TitleObject_Line_ID_p_Line] FOREIGN KEY ([Line_ID]) REFERENCES [dbo].[p_Line] ([Line_ID]),
    CONSTRAINT [FK_p_Line_to_TitleObject_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Line_to_TitleObject_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_Line_to_TitleObject_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_Line_to_TitleObject] UNIQUE NONCLUSTERED ([Line_ID] ASC, [TitleObject_ID] ASC)
);

