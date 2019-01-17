CREATE TABLE [dbo].[p_Person] (
    [Person_ID]        UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Person_Code]      NVARCHAR (MAX)     NOT NULL,
    [FirstName]        NVARCHAR (MAX)     NOT NULL,
    [SecondName]       NVARCHAR (MAX)     NULL,
    [LastName]         NVARCHAR (MAX)     NOT NULL,
    [ShortName]        NVARCHAR (MAX)     NULL,
    [BirthDate]        DATE               NOT NULL,
    CONSTRAINT [PK_p_Person] PRIMARY KEY CLUSTERED ([Person_ID] ASC),
    CONSTRAINT [FK_p_Person_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Person_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Person_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_Person_Created_User_ID]
    ON [dbo].[p_Person]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Person_Modified_User_ID]
    ON [dbo].[p_Person]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Person_RowStatus]
    ON [dbo].[p_Person]([RowStatus] ASC);

