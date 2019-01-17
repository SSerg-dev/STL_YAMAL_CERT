CREATE TABLE [dbo].[p_TestMethod] (
    [TestMethod_ID]    UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Parent_ID]        UNIQUEIDENTIFIER   NULL,
    [Structure_Level]  INT                NOT NULL,
    [TestMethod_Code]  NVARCHAR (255)     NOT NULL,
    [Description_Rus]  NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_TestMethod] PRIMARY KEY CLUSTERED ([TestMethod_ID] ASC),
    CONSTRAINT [FK_p_TestMethod_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_TestMethod_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_TestMethod_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_TestMethod_TestMethod_Code] UNIQUE NONCLUSTERED ([TestMethod_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_TestMethod_Created_User_ID]
    ON [dbo].[p_TestMethod]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_TestMethod_Modified_User_ID]
    ON [dbo].[p_TestMethod]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_TestMethod_RowStatus]
    ON [dbo].[p_TestMethod]([RowStatus] ASC);

