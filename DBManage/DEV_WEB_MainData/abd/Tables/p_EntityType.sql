CREATE TABLE [abd].[p_EntityType] (
    [EntityType_ID]      UNIQUEIDENTIFIER CONSTRAINT [DF_EntityType_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]          INT              NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NOT NULL,
    [Update_DTS]         DATETIME2 (7)    NOT NULL,
    [Created_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [EntityType_Code]    NVARCHAR (255)   NOT NULL,
    [EntityType_Group]   NVARCHAR (50)    NOT NULL,
    [Attribute_DataType] NVARCHAR (120)   NULL,
    [Document_Type]      NVARCHAR (120)   NULL,
    CONSTRAINT [PK_p_EntityType] PRIMARY KEY CLUSTERED ([EntityType_ID] ASC),
    CONSTRAINT [FK_p_EntityType_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_EntityType_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_EntityType_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_EntityType] UNIQUE NONCLUSTERED ([EntityType_Code] ASC)
);

