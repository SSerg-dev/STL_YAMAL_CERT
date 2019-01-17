﻿CREATE TABLE [dbo].[p_Role] (
    [Role_ID]          UNIQUEIDENTIFIER CONSTRAINT [DF_Role_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Role_Code]        NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_p_Role] PRIMARY KEY CLUSTERED ([Role_ID] ASC),
    CONSTRAINT [FK_p_Role_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Role_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Role_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Role] UNIQUE NONCLUSTERED ([Role_Code] ASC)
);

