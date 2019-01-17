CREATE TABLE [abd].[p_DocumentRelation] (
    [DocumentRelation_ID]    UNIQUEIDENTIFIER CONSTRAINT [DF_p_DocumentRelation] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NOT NULL,
    [Update_DTS]             DATETIME2 (7)    NOT NULL,
    [RowStatus]              INT              NOT NULL,
    [DocumentFrom_ID]        UNIQUEIDENTIFIER NOT NULL,
    [DocumentTo_ID]          UNIQUEIDENTIFIER NOT NULL,
    [RelationType_ID]        UNIQUEIDENTIFIER NOT NULL,
    [DocumentRelation_Order] INT              NOT NULL,
    [Created_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentRelation] PRIMARY KEY CLUSTERED ([DocumentRelation_ID] ASC),
    CONSTRAINT [FK_p_DocumentRelation_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentRelation_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentRelation_p_DocumentFrom_abd] FOREIGN KEY ([DocumentFrom_ID]) REFERENCES [abd].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_DocumentRelation_p_DocumentTo_abd] FOREIGN KEY ([DocumentTo_ID]) REFERENCES [abd].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_DocumentRelation_p_RelationType_abd] FOREIGN KEY ([RelationType_ID]) REFERENCES [abd].[p_RelationType] ([RelationType_ID]),
    CONSTRAINT [FK_p_DocumentRelation_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID])
);







