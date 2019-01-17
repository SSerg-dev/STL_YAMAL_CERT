CREATE TABLE [dbo].[p_Position] (
    [Position_ID]      UNIQUEIDENTIFIER CONSTRAINT [DF_Position_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Position_Code]    NVARCHAR (255)   NOT NULL,
    [Division_ID]      UNIQUEIDENTIFIER NULL,
    [Description_Rus]  NVARCHAR (255)   NULL,
    [Description_Eng]  NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_Position] PRIMARY KEY CLUSTERED ([Position_ID] ASC),
    CONSTRAINT [FK_p_Position_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Position_Division_ID_p_Division] FOREIGN KEY ([Division_ID]) REFERENCES [dbo].[p_Division] ([Division_ID]),
    CONSTRAINT [FK_p_Position_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Position_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Position] UNIQUE NONCLUSTERED ([Position_Code] ASC)
);





