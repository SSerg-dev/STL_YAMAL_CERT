CREATE TABLE [dbo].[p_TestObject] (
    [TestObject_ID]    UNIQUEIDENTIFIER CONSTRAINT [DF_TestObject_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              DEFAULT ((0)) NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    DEFAULT (getdate()) NOT NULL,
    [Update_DTS]       DATETIME2 (7)    DEFAULT (getdate()) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER DEFAULT ('3B7A2094-A89E-E811-AA07-005056947B15') NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER DEFAULT ('3B7A2094-A89E-E811-AA07-005056947B15') NOT NULL,
    [TestObject_Code]  NVARCHAR (255)   NOT NULL,
    [TestCode]         NVARCHAR (250)   NOT NULL,
    [TestId]           UNIQUEIDENTIFIER NOT NULL,
    [Enity_Schema]     NVARCHAR (250)   NOT NULL,
    [Entity_Table]     NVARCHAR (250)   NOT NULL,
    [Entity_TableId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_TestObject] PRIMARY KEY CLUSTERED ([TestObject_ID] ASC),
    CONSTRAINT [FK_p_TestObject_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_TestObject_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_TestObject_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_TestObject] UNIQUE NONCLUSTERED ([TestObject_Code] ASC)
);

