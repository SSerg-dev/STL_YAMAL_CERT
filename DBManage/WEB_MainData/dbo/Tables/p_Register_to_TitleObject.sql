CREATE TABLE [dbo].[p_Register_to_TitleObject] (
    [Register_to_TitleObject_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_TitleObject_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]                  INT              NOT NULL,
    [Insert_DTS]                 DATETIME2 (7)    NOT NULL,
    [Update_DTS]                 DATETIME2 (7)    NOT NULL,
    [Created_User_ID]            UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]           UNIQUEIDENTIFIER NOT NULL,
    [Register_ID]                UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Iteration]                  INT              NOT NULL,
    CONSTRAINT [PK_p_Register_to_TitleObject] PRIMARY KEY CLUSTERED ([Register_to_TitleObject_ID] ASC),
    CONSTRAINT [FK_p_Register_to_TitleObject_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Register_to_TitleObject_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Register_to_TitleObject_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_TitleObject_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_Register_to_TitleObject_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_Register_to_TitleObject] UNIQUE NONCLUSTERED ([Register_ID] ASC, [TitleObject_ID] ASC, [Iteration] ASC)
);



