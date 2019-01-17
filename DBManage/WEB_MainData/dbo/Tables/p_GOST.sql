CREATE TABLE [dbo].[p_GOST] (
    [GOST_ID]          UNIQUEIDENTIFIER CONSTRAINT [DF_GOST_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [GOST_Code]        NVARCHAR (255)   NOT NULL,
    [Description_Rus]  NVARCHAR (255)   NULL,
    [Marka_ID]         UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_GOST] PRIMARY KEY CLUSTERED ([GOST_ID] ASC),
    CONSTRAINT [FK_p_GOST_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_GOST_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_GOST_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_GOST_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_GOST] UNIQUE NONCLUSTERED ([GOST_Code] ASC)
);



