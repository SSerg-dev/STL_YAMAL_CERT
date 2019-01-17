CREATE TABLE [dbo].[p_GOST] (
    [GOST_ID]          UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [GOST_Code]        NVARCHAR (255)     NOT NULL,
    [Description_Rus]  NVARCHAR (255)     NULL,
    [Marka_ID]         UNIQUEIDENTIFIER   NULL,
    CONSTRAINT [PK_p_GOST] PRIMARY KEY CLUSTERED ([GOST_ID] ASC),
    CONSTRAINT [FK_p_GOST_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_GOST_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_GOST_p_Marka_Marka_ID] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_GOST_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_GOST_GOST_Code] UNIQUE NONCLUSTERED ([GOST_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_GOST_Created_User_ID]
    ON [dbo].[p_GOST]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_GOST_Marka_ID]
    ON [dbo].[p_GOST]([Marka_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_GOST_Modified_User_ID]
    ON [dbo].[p_GOST]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_GOST_RowStatus]
    ON [dbo].[p_GOST]([RowStatus] ASC);

