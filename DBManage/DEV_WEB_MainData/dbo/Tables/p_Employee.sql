CREATE TABLE [dbo].[p_Employee] (
    [Employee_ID]      UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Employee_Code]    NVARCHAR (255)     NOT NULL,
    [Person_ID]        UNIQUEIDENTIFIER   NOT NULL,
    [Position_ID]      UNIQUEIDENTIFIER   NOT NULL,
    [AppUser_ID]       UNIQUEIDENTIFIER   NULL,
    [Contragent_ID]    UNIQUEIDENTIFIER   NULL,
    CONSTRAINT [PK_p_Employee] PRIMARY KEY CLUSTERED ([Employee_ID] ASC),
    CONSTRAINT [FK_p_Employee_p_AppUser_AppUser_ID] FOREIGN KEY ([AppUser_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Employee_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Employee_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Employee_p_Contragent_Contragent_ID] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_Employee_p_Person_Person_ID] FOREIGN KEY ([Person_ID]) REFERENCES [dbo].[p_Person] ([Person_ID]),
    CONSTRAINT [FK_p_Employee_p_Position_Position_ID] FOREIGN KEY ([Position_ID]) REFERENCES [dbo].[p_Position] ([Position_ID]),
    CONSTRAINT [FK_p_Employee_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_Employee_Employee_Code] UNIQUE NONCLUSTERED ([Employee_Code] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_p_Employee_AppUser_ID]
    ON [dbo].[p_Employee]([AppUser_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Employee_Contragent_ID]
    ON [dbo].[p_Employee]([Contragent_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Employee_Created_User_ID]
    ON [dbo].[p_Employee]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Employee_Modified_User_ID]
    ON [dbo].[p_Employee]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Employee_Person_ID]
    ON [dbo].[p_Employee]([Person_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Employee_Position_ID]
    ON [dbo].[p_Employee]([Position_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Employee_RowStatus]
    ON [dbo].[p_Employee]([RowStatus] ASC);

