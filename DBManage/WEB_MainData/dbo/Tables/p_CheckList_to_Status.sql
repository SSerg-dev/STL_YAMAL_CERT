CREATE TABLE [dbo].[p_CheckList_to_Status] (
    [CheckList_to_Status_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_CheckList_to_Status_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]              INT              NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NOT NULL,
    [Update_DTS]             DATETIME2 (7)    NOT NULL,
    [Created_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]       UNIQUEIDENTIFIER NOT NULL,
    [CheckList_ID]           UNIQUEIDENTIFIER NOT NULL,
    [Status_ID]              UNIQUEIDENTIFIER NOT NULL,
    [Parent_ID]              UNIQUEIDENTIFIER NULL,
    [DTS_Start]              DATETIME2 (7)    NOT NULL,
    [DTS_End]                DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_CheckList_to_Status] PRIMARY KEY CLUSTERED ([CheckList_to_Status_ID] ASC),
    CONSTRAINT [FK_p_CheckList_to_Status_CheckList_ID_p_CheckList] FOREIGN KEY ([CheckList_ID]) REFERENCES [dbo].[p_CheckList] ([CheckList_ID]),
    CONSTRAINT [FK_p_CheckList_to_Status_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_CheckList_to_Status_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_CheckList_to_Status_Parent_ID_ID_p_CheckList_to_Status] FOREIGN KEY ([Parent_ID]) REFERENCES [dbo].[p_CheckList_to_Status] ([CheckList_to_Status_ID]),
    CONSTRAINT [FK_p_CheckList_to_Status_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_CheckList_to_Status_Status_ID_p_Status] FOREIGN KEY ([Status_ID]) REFERENCES [dbo].[p_Status] ([Status_ID])
);



