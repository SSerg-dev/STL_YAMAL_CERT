CREATE TABLE [abd].[p_Document] (
    [Document_ID]            UNIQUEIDENTIFIER CONSTRAINT [DF_p_Document] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NOT NULL,
    [Update_DTS]             DATETIME2 (7)    NOT NULL,
    [RowStatus]              INT              NOT NULL,
    [Document_Name]          NVARCHAR (250)   NOT NULL,
    [Document_Title]         NVARCHAR (250)   NOT NULL,
    [DocumentType_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Created_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]       UNIQUEIDENTIFIER NOT NULL,
    [Document_Revision]      NVARCHAR (50)    NOT NULL,
    [Document_Parent_ID]     UNIQUEIDENTIFIER NULL,
    [Reponsible_Employee_ID] UNIQUEIDENTIFIER NULL,
    [Document_Number]        NVARCHAR (255)   NULL,
    [Document_Date]          DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_Document] PRIMARY KEY CLUSTERED ([Document_ID] ASC),
    CONSTRAINT [FK_p_Document_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_p_DocumentType_abd] FOREIGN KEY ([DocumentType_ID]) REFERENCES [abd].[p_DocumentType] ([DocumentType_ID]),
    CONSTRAINT [FK_p_Document_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_Document_Reponsible_Employee_p_Employee] FOREIGN KEY ([Reponsible_Employee_ID]) REFERENCES [dbo].[p_Employee] ([Employee_ID])
);



