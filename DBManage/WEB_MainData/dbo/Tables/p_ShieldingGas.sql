CREATE TABLE [dbo].[p_ShieldingGas] (
    [RowStatus]         INT              NOT NULL,
    [Insert_DTS]        DATETIME2 (7)    NOT NULL,
    [Update_DTS]        DATETIME2 (7)    NOT NULL,
    [Created_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [ShieldingGas_ID]   UNIQUEIDENTIFIER NOT NULL,
    [ShieldingGas_Code] NVARCHAR (MAX)   NOT NULL,
    [Description_Rus]   NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_p_ShieldingGas] PRIMARY KEY CLUSTERED ([ShieldingGas_ID] ASC),
    CONSTRAINT [FK_p_ShieldingGas_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_ShieldingGas_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_ShieldingGas_Modified_User_ID]
    ON [dbo].[p_ShieldingGas]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_ShieldingGas_Created_User_ID]
    ON [dbo].[p_ShieldingGas]([Created_User_ID] ASC);

