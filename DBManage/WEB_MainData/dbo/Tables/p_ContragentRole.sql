CREATE TABLE [dbo].[p_ContragentRole] (
    [ContragentRole_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_ContragentRole_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]           INT              NOT NULL,
    [Insert_DTS]          DATETIME2 (7)    NOT NULL,
    [Update_DTS]          DATETIME2 (7)    NOT NULL,
    [Created_User_ID]     UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [ContragentRole_Code] NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_p_ContragentRole] PRIMARY KEY CLUSTERED ([ContragentRole_ID] ASC),
    CONSTRAINT [FK_p_ContragentRole_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_ContragentRole_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_ContragentRole_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_ContragentRole] UNIQUE NONCLUSTERED ([ContragentRole_Code] ASC)
);

