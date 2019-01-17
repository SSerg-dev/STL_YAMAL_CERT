CREATE TABLE [abd].[p_RelationType] (
    [RelationType_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_RelationType_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]         INT              NOT NULL,
    [Insert_DTS]        DATETIME2 (7)    NOT NULL,
    [Update_DTS]        DATETIME2 (7)    NOT NULL,
    [Created_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [RelationType_Code] NVARCHAR (250)   NOT NULL,
    CONSTRAINT [PK_abd_p_RelationType] PRIMARY KEY CLUSTERED ([RelationType_ID] ASC),
    CONSTRAINT [FK_abd_p_RelationType_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_abd_p_RelationType_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_abd_p_RelationType_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_abd_p_RelationType] UNIQUE NONCLUSTERED ([RelationType_Code] ASC)
);



