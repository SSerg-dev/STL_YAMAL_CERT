CREATE TABLE [abd].[p_DocumentAttributeRelation] (
    [DocumentAttributeRelation_ID]    UNIQUEIDENTIFIER CONSTRAINT [DF_p_DocumentAttributeRelation] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                      DATETIME2 (7)    NOT NULL,
    [Update_DTS]                      DATETIME2 (7)    NOT NULL,
    [RowStatus]                       INT              NOT NULL,
    [DocumentAttributeFrom_ID]        UNIQUEIDENTIFIER NOT NULL,
    [DocumentAttributeTo_ID]          UNIQUEIDENTIFIER NOT NULL,
    [RelationType_ID]                 UNIQUEIDENTIFIER NOT NULL,
    [Document_ID]                     UNIQUEIDENTIFIER NOT NULL,
    [DocumentAttributeRelation_Order] INT              NOT NULL,
    [Created_User_ID]                 UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentAttributeRelation] PRIMARY KEY CLUSTERED ([DocumentAttributeRelation_ID] ASC),
    CONSTRAINT [FK_p_DocumentAttributeRelation_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentAttributeRelation_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentAttributeRelation_p_Document_abd] FOREIGN KEY ([Document_ID]) REFERENCES [abd].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_DocumentAttributeRelation_p_DocumentAttributeFrom_abd] FOREIGN KEY ([DocumentAttributeFrom_ID]) REFERENCES [abd].[p_DocumentAttribute] ([DocumentAttribute_ID]),
    CONSTRAINT [FK_p_DocumentAttributeRelation_p_DocumentAttributeTo_abd] FOREIGN KEY ([DocumentAttributeTo_ID]) REFERENCES [abd].[p_DocumentAttribute] ([DocumentAttribute_ID]),
    CONSTRAINT [FK_p_DocumentAttributeRelation_p_RelationType_abd] FOREIGN KEY ([RelationType_ID]) REFERENCES [abd].[p_RelationType] ([RelationType_ID]),
    CONSTRAINT [FK_p_DocumentAttributeRelation_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID])
);



