CREATE TABLE [dbo].[p_AppUserTaskMessage] (
    [AppUserTaskMessage_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_AppUserTaskMessage_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]               INT              NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NOT NULL,
    [Update_DTS]              DATETIME2 (7)    NOT NULL,
    [Created_User_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [AppUserTaskMessage_Code] INT              NOT NULL,
    [Message_Type]            INT              NOT NULL,
    [Message_Text]            NVARCHAR (250)   NULL,
    [MessageDescription_ENG]  NVARCHAR (250)   NULL,
    [MessageDescription_RUS]  NVARCHAR (250)   NULL,
    CONSTRAINT [PK_p_AppUserTaskMessage] PRIMARY KEY CLUSTERED ([AppUserTaskMessage_ID] ASC),
    CONSTRAINT [FK_p_AppUserTaskMessage_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUserTaskMessage_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_AppUserTaskMessage_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_AppUserTaskMessage] UNIQUE NONCLUSTERED ([AppUserTaskMessage_Code] ASC)
);

