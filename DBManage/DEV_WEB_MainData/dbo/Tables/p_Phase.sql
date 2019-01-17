CREATE TABLE [dbo].[p_Phase] (
    [Phase_ID]         UNIQUEIDENTIFIER CONSTRAINT [DF_Phase_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Phase_Code]       NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_p_Phase] PRIMARY KEY CLUSTERED ([Phase_ID] ASC),
    CONSTRAINT [FK_p_Phase_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Phase_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Phase_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Phase] UNIQUE NONCLUSTERED ([Phase_Code] ASC)
);

