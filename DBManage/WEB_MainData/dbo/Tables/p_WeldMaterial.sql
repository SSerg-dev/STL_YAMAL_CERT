CREATE TABLE [dbo].[p_WeldMaterial] (
    [WeldMaterial_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_WeldMaterial_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]         INT              NOT NULL,
    [Insert_DTS]        DATETIME2 (7)    NOT NULL,
    [Update_DTS]        DATETIME2 (7)    NOT NULL,
    [Created_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [WeldMaterial_Code] NVARCHAR (255)   NOT NULL,
    [Description_Rus]   NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_WeldMaterial] PRIMARY KEY CLUSTERED ([WeldMaterial_ID] ASC),
    CONSTRAINT [FK_p_WeldMaterial_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WeldMaterial_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WeldMaterial_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_WeldMaterial] UNIQUE NONCLUSTERED ([WeldMaterial_Code] ASC)
);

