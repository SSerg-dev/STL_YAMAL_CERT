CREATE TABLE [dbo].[p_Document_to_GOST] (
    [Document_to_GOST_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Document_to_GOST_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]           INT              NOT NULL,
    [Insert_DTS]          DATETIME2 (7)    NOT NULL,
    [Update_DTS]          DATETIME2 (7)    NOT NULL,
    [Created_User_ID]     UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [Document_ID]         UNIQUEIDENTIFIER NOT NULL,
    [GOST_ID]             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Document_to_GOST] PRIMARY KEY CLUSTERED ([Document_to_GOST_ID] ASC),
    CONSTRAINT [FK_p_Document_to_GOST_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_GOST_Document_ID_p_Document] FOREIGN KEY ([Document_ID]) REFERENCES [dbo].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_Document_to_GOST_GOST_ID_p_GOST] FOREIGN KEY ([GOST_ID]) REFERENCES [dbo].[p_GOST] ([GOST_ID]),
    CONSTRAINT [FK_p_Document_to_GOST_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Document_to_GOST_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Document_to_GOST] UNIQUE NONCLUSTERED ([Document_ID] ASC, [GOST_ID] ASC)
);

