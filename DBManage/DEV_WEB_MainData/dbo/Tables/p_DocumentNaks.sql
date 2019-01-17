CREATE TABLE [dbo].[p_DocumentNaks] (
    [DocumentNaks_ID]       UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]            DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]            DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]       UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]      UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]             INT                NOT NULL,
    [Person_ID]             UNIQUEIDENTIFIER   NOT NULL,
    [ParentDocumentNaks_ID] UNIQUEIDENTIFIER   NULL,
    [Number]                NVARCHAR (MAX)     NOT NULL,
    [IssueDate]             DATE               NOT NULL,
    [ValidUntil]            DATE               NOT NULL,
    [Schifr]                NVARCHAR (MAX)     NULL,
    [WeldType_ID]           UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_p_DocumentNaks] PRIMARY KEY CLUSTERED ([DocumentNaks_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaks_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaks_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaks_p_DocumentNaks_ParentDocumentNaks_ID] FOREIGN KEY ([ParentDocumentNaks_ID]) REFERENCES [dbo].[p_DocumentNaks] ([DocumentNaks_ID]),
    CONSTRAINT [FK_p_DocumentNaks_p_Person_Person_ID] FOREIGN KEY ([Person_ID]) REFERENCES [dbo].[p_Person] ([Person_ID]),
    CONSTRAINT [FK_p_DocumentNaks_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_DocumentNaks_p_WeldType_WeldType_ID] FOREIGN KEY ([WeldType_ID]) REFERENCES [dbo].[p_WeldType] ([WeldType_ID])
);




GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_Created_User_ID]
    ON [dbo].[p_DocumentNaks]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_Modified_User_ID]
    ON [dbo].[p_DocumentNaks]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_ParentDocumentNaks_ID]
    ON [dbo].[p_DocumentNaks]([ParentDocumentNaks_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_Person_ID]
    ON [dbo].[p_DocumentNaks]([Person_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_RowStatus]
    ON [dbo].[p_DocumentNaks]([RowStatus] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_WeldType_ID]
    ON [dbo].[p_DocumentNaks]([WeldType_ID] ASC);

