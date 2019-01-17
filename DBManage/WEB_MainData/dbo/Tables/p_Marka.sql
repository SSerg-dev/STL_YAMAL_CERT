CREATE TABLE [dbo].[p_Marka] (
    [Marka_ID]                     UNIQUEIDENTIFIER CONSTRAINT [DF_Marka_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]                    INT              NOT NULL,
    [Insert_DTS]                   DATETIME2 (7)    NOT NULL,
    [Update_DTS]                   DATETIME2 (7)    NOT NULL,
    [Created_User_ID]              UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Marka_Code]                   NVARCHAR (255)   NOT NULL,
    [Marka_Code_Eng]               NVARCHAR (255)   NULL,
    [Description_Eng]              NVARCHAR (255)   NULL,
    [Description_Rus]              NVARCHAR (255)   NULL,
    [Engineering_Drawing_Type_Eng] NVARCHAR (255)   NULL,
    [Engineering_Drawing_Type_Rus] NVARCHAR (255)   NULL,
    [IsUsedInMatrix]               BIT              NULL,
    [IsPriority]                   BIT              NULL,
    [ReportColor]                  NVARCHAR (255)   NULL,
    [ReportOrder]                  INT              NULL,
    CONSTRAINT [PK_p_Marka] PRIMARY KEY CLUSTERED ([Marka_ID] ASC),
    CONSTRAINT [FK_p_Marka_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Marka_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Marka_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Marka] UNIQUE NONCLUSTERED ([Marka_Code] ASC)
);

