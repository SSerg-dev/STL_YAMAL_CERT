CREATE TABLE [dbo].[p_RowStatus] (
    [RowStatus_ID]     INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Status_Name_Eng]  NVARCHAR (100)   NOT NULL,
    [Status_Name_Rus]  NVARCHAR (100)   NOT NULL,
    [Description_Eng]  NVARCHAR (255)   NULL,
    [Description_Rus]  NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_RowStatus] PRIMARY KEY NONCLUSTERED ([RowStatus_ID] ASC),
    CONSTRAINT [FK_p_RowStatus_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_RowStatus_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID])
);

