CREATE TABLE [dbo].[p_CheckList] (
    [CheckList_ID]     UNIQUEIDENTIFIER CONSTRAINT [DF_CheckList_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [CheckList_Code]   NVARCHAR (255)   NOT NULL,
    [CheckList_Date]   DATETIME2 (7)    NOT NULL,
    [Register_ID]      UNIQUEIDENTIFIER NULL,
    [CheckParty_ID]    UNIQUEIDENTIFIER NULL,
    [Resp_Employee_ID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_CheckList] PRIMARY KEY CLUSTERED ([CheckList_ID] ASC),
    CONSTRAINT [FK_p_CheckList_CheckParty_ID_p_CheckParty] FOREIGN KEY ([CheckParty_ID]) REFERENCES [dbo].[p_CheckParty] ([CheckParty_ID]),
    CONSTRAINT [FK_p_CheckList_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_CheckList_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_CheckList_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_CheckList_Resp_Employee_ID_p_Employee] FOREIGN KEY ([Resp_Employee_ID]) REFERENCES [dbo].[p_Employee] ([Employee_ID]),
    CONSTRAINT [FK_p_CheckList_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_CheckList] UNIQUE NONCLUSTERED ([CheckList_Code] ASC)
);





