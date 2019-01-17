CREATE TABLE [dbo].[p_Privilege] (
    [Privilege_ID]     UNIQUEIDENTIFIER CONSTRAINT [DF_Privilege_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Privilege_Code]   NVARCHAR (255)   NOT NULL,
    [Role_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Entity]           NVARCHAR (120)   NOT NULL,
    [EntityKey]        NVARCHAR (MAX)   NOT NULL,
    [prvRead]          BIT              DEFAULT ((0)) NOT NULL,
    [prvCreate]        BIT              DEFAULT ((0)) NOT NULL,
    [prvUpdate]        BIT              DEFAULT ((0)) NOT NULL,
    [prvDelete]        BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_p_Privilege] PRIMARY KEY CLUSTERED ([Privilege_ID] ASC),
    CONSTRAINT [FK_p_Privilege_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Privilege_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Privilege_Role_ID_p_Role] FOREIGN KEY ([Role_ID]) REFERENCES [dbo].[p_Role] ([Role_ID]),
    CONSTRAINT [FK_p_Privilege_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Privilege] UNIQUE NONCLUSTERED ([Privilege_Code] ASC)
);

