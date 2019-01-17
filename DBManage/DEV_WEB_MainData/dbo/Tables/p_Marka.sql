CREATE TABLE [dbo].[p_Marka] (
    [Marka_ID]                     UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                   DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]                   DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]              UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]             UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]                    INT                NOT NULL,
    [Marka_Code]                   NVARCHAR (255)     NOT NULL,
    [Marka_Code_Eng]               NVARCHAR (255)     NULL,
    [Description_Eng]              NVARCHAR (255)     NULL,
    [Description_Rus]              NVARCHAR (255)     NULL,
    [Engineering_Drawing_Type_Eng] NVARCHAR (255)     NULL,
    [Engineering_Drawing_Type_Rus] NVARCHAR (255)     NULL,
    [IsUsedInMatrix]               BIT                NULL,
    [IsPriority]                   BIT                NULL,
    [ReportColor]                  NVARCHAR (255)     NULL,
    [ReportOrder]                  INT                NULL,
    CONSTRAINT [PK_p_Marka] PRIMARY KEY CLUSTERED ([Marka_ID] ASC),
    CONSTRAINT [FK_p_Marka_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Marka_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Marka_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_Marka_Marka_Code] UNIQUE NONCLUSTERED ([Marka_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_Marka_Created_User_ID]
    ON [dbo].[p_Marka]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Marka_Modified_User_ID]
    ON [dbo].[p_Marka]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Marka_RowStatus]
    ON [dbo].[p_Marka]([RowStatus] ASC);

