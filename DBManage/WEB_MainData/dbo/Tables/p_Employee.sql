CREATE TABLE [dbo].[p_Employee] (
    [Employee_ID]      UNIQUEIDENTIFIER CONSTRAINT [DF_Employee_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Employee_Code]    NVARCHAR (255)   NOT NULL,
    [Person_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Position_ID]      UNIQUEIDENTIFIER NOT NULL,
    [AppUser_ID]       UNIQUEIDENTIFIER NULL,
    [Contragent_ID]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_Employee] PRIMARY KEY CLUSTERED ([Employee_ID] ASC),
    CONSTRAINT [FK_p_Employee_AppUser_ID_p_AppUser] FOREIGN KEY ([AppUser_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Employee_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Employee_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Employee_Person_ID_p_Person] FOREIGN KEY ([Person_ID]) REFERENCES [dbo].[p_Person] ([Person_ID]),
    CONSTRAINT [FK_p_Employee_Position_ID_p_Position] FOREIGN KEY ([Position_ID]) REFERENCES [dbo].[p_Position] ([Position_ID]),
    CONSTRAINT [FK_p_Employee_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Employee] UNIQUE NONCLUSTERED ([Employee_Code] ASC)
);



