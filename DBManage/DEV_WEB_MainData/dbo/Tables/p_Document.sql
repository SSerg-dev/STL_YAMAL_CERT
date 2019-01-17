CREATE TABLE [dbo].[p_Document] (
    [Document_ID]      UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Document_Code]    NVARCHAR (255)     DEFAULT (NEXT VALUE FOR [Sequence_Document_Number]) NOT NULL,
    [Issue_Date]       DATETIMEOFFSET (7) NOT NULL,
    [Issue_Date_DT]    DATETIME2 (7)      NOT NULL,
    [Document_Number]  NVARCHAR (255)     NULL,
    [Document_Date]    DATE               NULL,
    [TotalSheets]      INT                NULL,
    [Document_Name]    NVARCHAR (255)     NULL,
    [VersionNumber]    INT                NOT NULL,
    [IsActual]         BIT                NOT NULL,
    [DocumentType_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Root_ID]          UNIQUEIDENTIFIER   NOT NULL,
    [Resp_Employee_ID] UNIQUEIDENTIFIER   NULL,
    CONSTRAINT [PK_p_Document] PRIMARY KEY CLUSTERED ([Document_ID] ASC),
    CONSTRAINT [FK_p_Document_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_p_Document_Root_ID] FOREIGN KEY ([Root_ID]) REFERENCES [dbo].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_Document_p_DocumentType_DocumentType_ID] FOREIGN KEY ([DocumentType_ID]) REFERENCES [dbo].[p_DocumentType] ([DocumentType_ID]),
    CONSTRAINT [FK_p_Document_p_Employee_Resp_Employee_ID] FOREIGN KEY ([Resp_Employee_ID]) REFERENCES [dbo].[p_Employee] ([Employee_ID]),
    CONSTRAINT [FK_p_Document_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_Document_Document_Code] UNIQUE NONCLUSTERED ([Document_Code] ASC)
);





GO
CREATE NONCLUSTERED INDEX [IX_p_Document_DocumentType_ID]
    ON [dbo].[p_Document]([DocumentType_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_Modified_User_ID]
    ON [dbo].[p_Document]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_Resp_Employee_ID]
    ON [dbo].[p_Document]([Resp_Employee_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_Root_ID]
    ON [dbo].[p_Document]([Root_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_RowStatus]
    ON [dbo].[p_Document]([RowStatus] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Document_Created_User_ID]
    ON [dbo].[p_Document]([Created_User_ID] ASC);

