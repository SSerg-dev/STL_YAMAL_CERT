CREATE TABLE [dbo].[p_AppUser] (
    [AppUser_ID]       UNIQUEIDENTIFIER CONSTRAINT [DF_AppUser_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [AppUser_Code]     NVARCHAR (255)   NOT NULL,
    [User_Password]    VARBINARY (8000) NOT NULL,
    [Comment]          NVARCHAR (250)   NULL,
    CONSTRAINT [PK_p_AppUser] PRIMARY KEY CLUSTERED ([AppUser_ID] ASC),
    CONSTRAINT [FK_p_AppUser_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUser_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [UQ_p_AppUser] UNIQUE NONCLUSTERED ([AppUser_Code] ASC)
);

