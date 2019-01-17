CREATE TABLE [abd].[p_AttributeType] (
    [AttributeType_ID]    UNIQUEIDENTIFIER CONSTRAINT [DF_AttributeType_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]           INT              NOT NULL,
    [Insert_DTS]          DATETIME2 (7)    NOT NULL,
    [Update_DTS]          DATETIME2 (7)    NOT NULL,
    [Created_User_ID]     UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [AttributeType_Code]  NVARCHAR (250)   NOT NULL,
    [AttributeType_Name]  NVARCHAR (250)   NOT NULL,
    [AttributeType_Group] NVARCHAR (50)    NOT NULL,
    [Attribute_DataType]  NVARCHAR (250)   NOT NULL,
    [Attribute_Table]     NVARCHAR (250)   NULL,
    [Attribute_Format]    NVARCHAR (250)   NULL,
    [Description_Rus]     NVARCHAR (250)   NULL,
    [Description_Eng]     NVARCHAR (250)   NULL,
    CONSTRAINT [PK_abd_p_AttributeType] PRIMARY KEY CLUSTERED ([AttributeType_ID] ASC),
    CONSTRAINT [FK_abd_p_AttributeType_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_abd_p_AttributeType_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_abd_p_AttributeType_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_abd_p_AttributeType] UNIQUE NONCLUSTERED ([AttributeType_Code] ASC)
);





