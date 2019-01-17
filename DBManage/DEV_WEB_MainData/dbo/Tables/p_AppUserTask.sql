CREATE TABLE [dbo].[p_AppUserTask] (
    [AppUserTask_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_AppUserTask_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [AppUserTask_Code] NVARCHAR (255)   NOT NULL,
    [TaskName]         NVARCHAR (120)   NOT NULL,
    [Description_Eng]  NVARCHAR (250)   NULL,
    [Description_Rus]  NVARCHAR (250)   NULL,
    CONSTRAINT [PK_p_AppUserTask] PRIMARY KEY CLUSTERED ([AppUserTask_ID] ASC),
    CONSTRAINT [FK_p_AppUserTask_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUserTask_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUserTask_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_AppUserTask] UNIQUE NONCLUSTERED ([AppUserTask_Code] ASC)
);

