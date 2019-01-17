CREATE TABLE [dbo].[p_Responsibility] (
    [RowStatus]           INT              NOT NULL,
    [Insert_DTS]          DATETIME2 (7)    NOT NULL,
    [Update_DTS]          DATETIME2 (7)    NOT NULL,
    [Created_User_ID]     UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [Responsibility_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Responsibility_Code] NVARCHAR (MAX)   NOT NULL,
    [Description_Rus]     NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_p_Responsibility] PRIMARY KEY CLUSTERED ([Responsibility_ID] ASC),
    CONSTRAINT [FK_p_Responsibility_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Responsibility_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_Responsibility_Modified_User_ID]
    ON [dbo].[p_Responsibility]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Responsibility_Created_User_ID]
    ON [dbo].[p_Responsibility]([Created_User_ID] ASC);

