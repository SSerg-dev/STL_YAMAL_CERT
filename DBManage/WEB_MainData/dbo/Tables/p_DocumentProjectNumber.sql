CREATE TABLE [dbo].[p_DocumentProjectNumber] (
    [DocumentProjectNumber_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_DocumentProjectNumber_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]                  INT              NOT NULL,
    [Insert_DTS]                 DATETIME2 (7)    NOT NULL,
    [Update_DTS]                 DATETIME2 (7)    NOT NULL,
    [Created_User_ID]            UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]           UNIQUEIDENTIFIER NOT NULL,
    [DocumentProjectNumber_Code] NVARCHAR (255)   NOT NULL,
    [Description_Eng]            NVARCHAR (255)   NULL,
    [Description_Rus]            NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_DocumentProjectNumber] PRIMARY KEY CLUSTERED ([DocumentProjectNumber_ID] ASC),
    CONSTRAINT [FK_p_DocumentProjectNumber_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentProjectNumber_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentProjectNumber_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_DocumentProjectNumber] UNIQUE NONCLUSTERED ([DocumentProjectNumber_Code] ASC)
);

