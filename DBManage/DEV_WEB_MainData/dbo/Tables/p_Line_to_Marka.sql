CREATE TABLE [dbo].[p_Line_to_Marka] (
    [Line_to_Marka_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Line_to_Marka_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Line_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Marka_ID]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Line_to_Marka] PRIMARY KEY CLUSTERED ([Line_to_Marka_ID] ASC),
    CONSTRAINT [FK_p_Line_to_Marka_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Line_to_Marka_Line_ID_p_Line] FOREIGN KEY ([Line_ID]) REFERENCES [dbo].[p_Line] ([Line_ID]),
    CONSTRAINT [FK_p_Line_to_Marka_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_Line_to_Marka_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Line_to_Marka_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Line_to_Marka] UNIQUE NONCLUSTERED ([Line_ID] ASC, [Marka_ID] ASC)
);

