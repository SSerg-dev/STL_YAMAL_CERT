CREATE TABLE [dbo].[p_TestTypeRef] (
    [TestTypeRef_ID]   UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Description_Eng]  NVARCHAR (255)     NULL,
    [TestTypeRef_Code] NVARCHAR (255)     NOT NULL,
    [Description_Rus]  NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_TestTypeRef] PRIMARY KEY CLUSTERED ([TestTypeRef_ID] ASC),
    CONSTRAINT [FK_p_TestTypeRef_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_TestTypeRef_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_TestTypeRef_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_TestTypeRef_TestTypeRef_Code] UNIQUE NONCLUSTERED ([TestTypeRef_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_TestTypeRef_Created_User_ID]
    ON [dbo].[p_TestTypeRef]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_TestTypeRef_Modified_User_ID]
    ON [dbo].[p_TestTypeRef]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_TestTypeRef_RowStatus]
    ON [dbo].[p_TestTypeRef]([RowStatus] ASC);

