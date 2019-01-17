CREATE TABLE [dbo].[p_CheckItem] (
    [CheckItem_ID]     UNIQUEIDENTIFIER CONSTRAINT [DF_CheckItem_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [CheckList_ID]     UNIQUEIDENTIFIER NOT NULL,
    [Document_ID]      UNIQUEIDENTIFIER NULL,
    [Position]         INT              NOT NULL,
    [Comment]          NVARCHAR (MAX)   NULL,
    [CheckItem_Name]   NVARCHAR (255)   NULL,
    [Issued_Date]      DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_CheckItem] PRIMARY KEY CLUSTERED ([CheckItem_ID] ASC),
    CONSTRAINT [FK_p_CheckItem_CheckList_ID_p_CheckList] FOREIGN KEY ([CheckList_ID]) REFERENCES [dbo].[p_CheckList] ([CheckList_ID]),
    CONSTRAINT [FK_p_CheckItem_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_CheckItem_Document_ID_p_Document] FOREIGN KEY ([Document_ID]) REFERENCES [dbo].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_CheckItem_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_CheckItem_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID])
);







