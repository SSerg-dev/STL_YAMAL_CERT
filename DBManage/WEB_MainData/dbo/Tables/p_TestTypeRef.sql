CREATE TABLE [dbo].[p_TestTypeRef] (
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [TestTypeRef_ID]   UNIQUEIDENTIFIER NOT NULL,
    [TestTypeRef_Code] NVARCHAR (MAX)   NOT NULL,
    [Description_Rus]  NVARCHAR (MAX)   NULL,
    [Description_Eng]  NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_p_TestTypeRef] PRIMARY KEY CLUSTERED ([TestTypeRef_ID] ASC),
    CONSTRAINT [FK_p_TestTypeRef_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_TestTypeRef_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_TestTypeRef_Modified_User_ID]
    ON [dbo].[p_TestTypeRef]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_TestTypeRef_Created_User_ID]
    ON [dbo].[p_TestTypeRef]([Created_User_ID] ASC);

