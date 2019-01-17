CREATE TABLE [abd].[p_DocumentType] (
    [DocumentType_ID]    UNIQUEIDENTIFIER CONSTRAINT [DF_DocumentType_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]          INT              NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NOT NULL,
    [Update_DTS]         DATETIME2 (7)    NOT NULL,
    [Created_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [DocumentType_Code]  NVARCHAR (250)   NOT NULL,
    [DocumentType_Name]  NVARCHAR (250)   NOT NULL,
    [DocumentType_Group] NVARCHAR (50)    NOT NULL,
    [Description_Rus]    NVARCHAR (250)   NULL,
    [Description_Eng]    NVARCHAR (250)   NULL,
    CONSTRAINT [PK_abd_p_DocumentType] PRIMARY KEY CLUSTERED ([DocumentType_ID] ASC),
    CONSTRAINT [FK_abd_p_DocumentType_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_abd_p_DocumentType_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_abd_p_DocumentType_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_abd_p_DocumentType] UNIQUE NONCLUSTERED ([DocumentType_Code] ASC)
);



