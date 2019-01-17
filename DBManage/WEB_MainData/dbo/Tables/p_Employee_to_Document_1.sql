CREATE TABLE [dbo].[p_Employee_to_Document] (
    [Employee_to_Document_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Employee_to_GeneralDocument_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]               INT              NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NOT NULL,
    [Update_DTS]              DATETIME2 (7)    NOT NULL,
    [Created_User_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Employee_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Document_ID]             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Employee_to_GeneralDocument] PRIMARY KEY CLUSTERED ([Employee_to_Document_ID] ASC),
    CONSTRAINT [FK_p_Employee_to_GeneralDocument_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Employee_to_GeneralDocument_Employee_ID_p_Employee] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[p_Employee] ([Employee_ID]),
    CONSTRAINT [FK_p_Employee_to_GeneralDocument_GeneralDocument_ID_p_GeneralDocument] FOREIGN KEY ([Document_ID]) REFERENCES [abd].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_Employee_to_GeneralDocument_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Employee_to_GeneralDocument_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Employee_to_GeneralDocument] UNIQUE NONCLUSTERED ([Employee_ID] ASC, [Document_ID] ASC)
);

