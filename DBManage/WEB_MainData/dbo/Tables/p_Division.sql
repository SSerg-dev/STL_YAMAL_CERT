CREATE TABLE [dbo].[p_Division] (
    [Division_ID]      UNIQUEIDENTIFIER CONSTRAINT [DF_Division_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Division_Code]    NVARCHAR (255)   NOT NULL,
    [Contragent_ID]    UNIQUEIDENTIFIER NULL,
    [Division_Name]    NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_Division] PRIMARY KEY CLUSTERED ([Division_ID] ASC),
    CONSTRAINT [FK_p_Division_Contragеnt_ID_p_Contragеnt] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_Division_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Division_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Division_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Division] UNIQUE NONCLUSTERED ([Division_Code] ASC)
);

