CREATE TABLE [dbo].[p_Contragent] (
    [Contragent_ID]     UNIQUEIDENTIFIER CONSTRAINT [DF_Contragent_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]         INT              NOT NULL,
    [Insert_DTS]        DATETIME2 (7)    NOT NULL,
    [Update_DTS]        DATETIME2 (7)    NOT NULL,
    [Created_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Contragent_Code]   NVARCHAR (255)   NOT NULL,
    [Description_Eng]   NVARCHAR (255)   NULL,
    [Description_Rus]   NVARCHAR (255)   NULL,
    [ContragentRole_ID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_Contragent] PRIMARY KEY CLUSTERED ([Contragent_ID] ASC),
    CONSTRAINT [FK_p_Contragent_ContragentRole_ID_p_ContragentRole] FOREIGN KEY ([ContragentRole_ID]) REFERENCES [dbo].[p_ContragentRole] ([ContragentRole_ID]),
    CONSTRAINT [FK_p_Contragent_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Contragent_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Contragent_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Contragent] UNIQUE NONCLUSTERED ([Contragent_Code] ASC)
);



