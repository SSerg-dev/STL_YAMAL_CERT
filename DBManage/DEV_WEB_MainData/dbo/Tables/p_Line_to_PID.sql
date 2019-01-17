CREATE TABLE [dbo].[p_Line_to_PID] (
    [Line_to_PID_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_Line_to_PID_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Line_ID]          UNIQUEIDENTIFIER NOT NULL,
    [PID_ID]           UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Line_to_PID] PRIMARY KEY CLUSTERED ([Line_to_PID_ID] ASC),
    CONSTRAINT [FK_p_Line_to_PID_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Line_to_PID_Line_ID_p_Line] FOREIGN KEY ([Line_ID]) REFERENCES [dbo].[p_Line] ([Line_ID]),
    CONSTRAINT [FK_p_Line_to_PID_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Line_to_PID_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_Line_to_PID_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Line_to_PID] UNIQUE NONCLUSTERED ([Line_ID] ASC, [PID_ID] ASC)
);

