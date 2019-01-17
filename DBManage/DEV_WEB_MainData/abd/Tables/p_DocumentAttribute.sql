CREATE TABLE [abd].[p_DocumentAttribute] (
    [DocumentAttribute_ID]    UNIQUEIDENTIFIER CONSTRAINT [DF_p_DocumentAttribute] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NOT NULL,
    [Update_DTS]              DATETIME2 (7)    NOT NULL,
    [RowStatus]               INT              NOT NULL,
    [DocumentAttribute_Value] NVARCHAR (250)   NOT NULL,
    [AttributeType_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Document_ID]             UNIQUEIDENTIFIER NOT NULL,
    [DocumentAttribute_Order] INT              NOT NULL,
    [Created_User_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentAttribute] PRIMARY KEY CLUSTERED ([DocumentAttribute_ID] ASC),
    CONSTRAINT [FK_p_DocumentAttribute_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentAttribute_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentAttribute_p_AttributeType_abd] FOREIGN KEY ([AttributeType_ID]) REFERENCES [abd].[p_AttributeType] ([AttributeType_ID]),
    CONSTRAINT [FK_p_DocumentAttribute_p_Document_abd] FOREIGN KEY ([Document_ID]) REFERENCES [abd].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_DocumentAttribute_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID])
);







