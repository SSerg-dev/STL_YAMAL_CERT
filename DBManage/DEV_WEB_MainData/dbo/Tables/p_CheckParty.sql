CREATE TABLE [dbo].[p_CheckParty] (
    [CheckParty_ID]    UNIQUEIDENTIFIER CONSTRAINT [DF_CheckParty_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [CheckParty_Code]  NVARCHAR (255)   NOT NULL,
    [Contragent_ID]    UNIQUEIDENTIFIER NOT NULL,
    [CheckParty_Order] INT              NOT NULL,
    [CheckType_ID]     UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_CheckParty] PRIMARY KEY CLUSTERED ([CheckParty_ID] ASC),
    CONSTRAINT [FK_p_CheckParty_CheckType_ID_p_CheckType] FOREIGN KEY ([CheckType_ID]) REFERENCES [dbo].[p_CheckType] ([CheckType_ID]),
    CONSTRAINT [FK_p_CheckParty_Contragent_ID_p_Contragent] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_CheckParty_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_CheckParty_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_CheckParty_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_CheckParty] UNIQUE NONCLUSTERED ([CheckParty_Code] ASC)
);

