CREATE TABLE [dbo].[p_Register_to_Document] (
    [Register_to_Document_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_Document_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]               INT              NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NOT NULL,
    [Update_DTS]              DATETIME2 (7)    NOT NULL,
    [Created_User_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Register_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Document_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Iteration]               INT              NOT NULL,
    [NumberInRegister]        INT              NULL,
    [SheetFolderNumber]       INT              NULL,
    [Comment]                 NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_Register_to_Document] PRIMARY KEY CLUSTERED ([Register_to_Document_ID] ASC),
    CONSTRAINT [FK_p_Register_to_Document_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Register_to_Document_Document_ID_p_Document] FOREIGN KEY ([Document_ID]) REFERENCES [dbo].[p_Document] ([Document_ID]),
    CONSTRAINT [FK_p_Register_to_Document_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Register_to_Document_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_Document_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Register_to_Document] UNIQUE NONCLUSTERED ([Register_ID] ASC, [Document_ID] ASC, [Iteration] ASC)
);



