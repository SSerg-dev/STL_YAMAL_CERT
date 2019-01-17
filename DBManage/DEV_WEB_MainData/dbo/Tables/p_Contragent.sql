CREATE TABLE [dbo].[p_Contragent] (
    [Contragent_ID]     UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]        DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]        DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]   UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]         INT                NOT NULL,
    [Description_Eng]   NVARCHAR (255)     NULL,
    [ContragentRole_ID] UNIQUEIDENTIFIER   NULL,
    [Contragent_Code]   NVARCHAR (255)     NOT NULL,
    [Description_Rus]   NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_Contragent] PRIMARY KEY CLUSTERED ([Contragent_ID] ASC),
    CONSTRAINT [FK_p_Contragent_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Contragent_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Contragent_p_ContragentRole_ContragentRole_ID] FOREIGN KEY ([ContragentRole_ID]) REFERENCES [dbo].[p_ContragentRole] ([ContragentRole_ID]),
    CONSTRAINT [FK_p_Contragent_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_Contragent_Contragent_Code] UNIQUE NONCLUSTERED ([Contragent_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_Contragent_ContragentRole_ID]
    ON [dbo].[p_Contragent]([ContragentRole_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Contragent_Created_User_ID]
    ON [dbo].[p_Contragent]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Contragent_Modified_User_ID]
    ON [dbo].[p_Contragent]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Contragent_RowStatus]
    ON [dbo].[p_Contragent]([RowStatus] ASC);

