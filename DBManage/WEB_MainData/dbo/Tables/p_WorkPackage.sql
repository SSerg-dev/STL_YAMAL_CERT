CREATE TABLE [dbo].[p_WorkPackage] (
    [WorkPackage_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_WorkPackage_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [WorkPackage_Code] NVARCHAR (255)   NOT NULL,
    [SiteRussiaYard]   NVARCHAR (100)   NULL,
    [LocationOfWork]   NVARCHAR (100)   NULL,
    [ScopeOfWork]      NVARCHAR (1000)  NULL,
    [AreaOfWork]       NVARCHAR (1000)  NULL,
    CONSTRAINT [PK_p_WorkPackage] PRIMARY KEY CLUSTERED ([WorkPackage_ID] ASC),
    CONSTRAINT [FK_p_WorkPackage_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WorkPackage_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WorkPackage_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_WorkPackage] UNIQUE NONCLUSTERED ([WorkPackage_Code] ASC)
);

