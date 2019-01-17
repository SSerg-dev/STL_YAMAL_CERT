CREATE TABLE [dbo].[p_Document] (
    [Document_ID]      UNIQUEIDENTIFIER CONSTRAINT [DF_Document_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Document_Code]    NVARCHAR (255)   NOT NULL,
    [Document_Number]  NVARCHAR (255)   NULL,
    [DocumentType_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Document_Date]    DATETIME2 (7)    NULL,
    [Issue_Date]       DATETIME2 (7)    NOT NULL,
    [TotalSheets]      INT              NULL,
    [Document_Name]    NVARCHAR (255)   NULL,
    [Root_ID]		   UNIQUEIDENTIFIER NOT NULL,
    [VersionNumber]    INT              NOT NULL,
    [IsActual]         BIT              NOT NULL,
    [Resp_Employee_ID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_Document] PRIMARY KEY CLUSTERED ([Document_ID] ASC),
    CONSTRAINT [FK_p_Document_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_DocumentType_ID_p_DocumentType] FOREIGN KEY ([DocumentType_ID]) REFERENCES [dbo].[p_DocumentType] ([DocumentType_ID]),
    CONSTRAINT [FK_p_Document_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_Parent_ID_p_Document] FOREIGN KEY ([Root_ID]) REFERENCES [dbo].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_Document_Resp_Employee_ID_p_Employee] FOREIGN KEY ([Resp_Employee_ID]) REFERENCES [dbo].[p_Employee] ([Employee_ID]),
    CONSTRAINT [FK_p_Document_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Document] UNIQUE NONCLUSTERED ([Document_Code] ASC)
);





