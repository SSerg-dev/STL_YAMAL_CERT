CREATE TABLE [dbo].[p_Register_to_Marka] (
    [Register_to_Marka_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_Marka_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]            INT              NOT NULL,
    [Insert_DTS]           DATETIME2 (7)    NOT NULL,
    [Update_DTS]           DATETIME2 (7)    NOT NULL,
    [Created_User_ID]      UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]     UNIQUEIDENTIFIER NOT NULL,
    [Register_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Marka_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Iteration]            INT              NOT NULL,
    CONSTRAINT [PK_p_Register_to_Marka] PRIMARY KEY CLUSTERED ([Register_to_Marka_ID] ASC),
    CONSTRAINT [FK_p_Register_to_Marka_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Register_to_Marka_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_Register_to_Marka_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Register_to_Marka_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_Marka_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Register_to_Marka] UNIQUE NONCLUSTERED ([Register_ID] ASC, [Marka_ID] ASC, [Iteration] ASC)
);



