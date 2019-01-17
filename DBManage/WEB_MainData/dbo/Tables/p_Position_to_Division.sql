CREATE TABLE [dbo].[p_Position_to_Division] (
    [Position_to_Division_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Position_to_Division_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]               INT              NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NOT NULL,
    [Update_DTS]              DATETIME2 (7)    NOT NULL,
    [Created_User_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Position_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Division_ID]             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Position_to_Division] PRIMARY KEY CLUSTERED ([Position_to_Division_ID] ASC),
    CONSTRAINT [FK_p_Position_to_Division_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Position_to_Division_Division_ID_p_Division] FOREIGN KEY ([Division_ID]) REFERENCES [dbo].[p_Division] ([Division_ID]),
    CONSTRAINT [FK_p_Position_to_Division_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Position_to_Division_Position_ID_p_Position] FOREIGN KEY ([Position_ID]) REFERENCES [dbo].[p_Position] ([Position_ID]),
    CONSTRAINT [FK_p_Position_to_Division_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Position_to_Division] UNIQUE NONCLUSTERED ([Position_ID] ASC, [Division_ID] ASC)
);

