CREATE TABLE [dbo].[p_WeldGOST14098] (
    [WeldGOST14098_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_WeldGOST14098_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]          INT              NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NOT NULL,
    [Update_DTS]         DATETIME2 (7)    NOT NULL,
    [Created_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [WeldGOST14098_Code] NVARCHAR (255)   NULL,
    [Description_Rus]    NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_WeldGOST14098] PRIMARY KEY CLUSTERED ([WeldGOST14098_ID] ASC),
    CONSTRAINT [FK_p_WeldGOST14098_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WeldGOST14098_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WeldGOST14098_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_WeldGOST14098] UNIQUE NONCLUSTERED ([WeldGOST14098_Code] ASC)
);

