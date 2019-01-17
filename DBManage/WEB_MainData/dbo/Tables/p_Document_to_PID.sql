CREATE TABLE [dbo].[p_Document_to_PID] (
    [Document_to_PID_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Document_to_PID_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]          INT              NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NOT NULL,
    [Update_DTS]         DATETIME2 (7)    NOT NULL,
    [Created_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Document_ID]        UNIQUEIDENTIFIER NOT NULL,
    [PID_ID]             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Document_to_PID] PRIMARY KEY CLUSTERED ([Document_to_PID_ID] ASC),
    CONSTRAINT [FK_p_Document_to_PID_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_PID_Document_ID_p_Document] FOREIGN KEY ([Document_ID]) REFERENCES [dbo].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_Document_to_PID_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_PID_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_Document_to_PID_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Document_to_PID] UNIQUE NONCLUSTERED ([Document_ID] ASC, [PID_ID] ASC)
);

