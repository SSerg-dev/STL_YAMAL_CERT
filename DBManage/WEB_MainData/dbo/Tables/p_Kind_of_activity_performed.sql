CREATE TABLE [dbo].[p_Kind_of_activity_performed] (
    [Kind_of_activity_performed_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_Kind_of_activity_performed_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]                       INT              NOT NULL,
    [Insert_DTS]                      DATETIME2 (7)    NOT NULL,
    [Update_DTS]                      DATETIME2 (7)    NOT NULL,
    [Created_User_ID]                 UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Kind_of_activity_performed_Code] NVARCHAR (255)   NOT NULL,
    [Description_Rus]                 NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_Kind_of_activity_performed] PRIMARY KEY CLUSTERED ([Kind_of_activity_performed_ID] ASC),
    CONSTRAINT [FK_p_Kind_of_activity_performed_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Kind_of_activity_performed_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Kind_of_activity_performed_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Kind_of_activity_performed] UNIQUE NONCLUSTERED ([Kind_of_activity_performed_Code] ASC)
);

