CREATE TABLE [dbo].[p_Person] (
    [Person_ID]        UNIQUEIDENTIFIER CONSTRAINT [DF_Person_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Person_Code]      NVARCHAR (255)   NOT NULL,
    [FirstName]        NVARCHAR (255)   NULL,
    [SecondName]       NVARCHAR (255)   NULL,
    [LastName]         NVARCHAR (255)   NULL,
    [ShortName]        NVARCHAR (255)   NULL,
    [BirthDate]        DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_Person] PRIMARY KEY CLUSTERED ([Person_ID] ASC),
    CONSTRAINT [FK_p_Person_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Person_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Person_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Person] UNIQUE NONCLUSTERED ([Person_Code] ASC)
);



