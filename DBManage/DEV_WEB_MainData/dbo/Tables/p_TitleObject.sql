CREATE TABLE [dbo].[p_TitleObject] (
    [TitleObject_ID]                     UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                         DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]                         DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]                    UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]                   UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]                          INT                NOT NULL,
    [TitleObject_Code]                   NVARCHAR (255)     NOT NULL,
    [Parent_ID]                          UNIQUEIDENTIFIER   NULL,
    [Structure]                          INT                NOT NULL,
    [Description_Eng]                    NVARCHAR (300)     NULL,
    [Description_Rus]                    NVARCHAR (400)     NULL,
    [Phase_Name]                         NVARCHAR (100)     NULL,
    [ReportColor]                        NVARCHAR (50)      NULL,
    [ReportOrder]                        INT                NULL,
    [Book1_Pct]                          REAL               NULL,
    [Book1_Weight]                       REAL               NULL,
    [Book2_Pct]                          REAL               NULL,
    [Book2_Weight]                       REAL               NULL,
    [Book3_Pct]                          REAL               NULL,
    [Book3_Weight]                       REAL               NULL,
    [Book4_Weight]                       REAL               NULL,
    [TitleObject_for_ABDFinalSet]        NVARCHAR (100)     NULL,
    [StageOfConstr]                      NVARCHAR (10)      NULL,
    [Book1_Documents_Total]              REAL               NULL,
    [Book1_Documents_received]           REAL               NULL,
    [Book1_Progress]                     REAL               NULL,
    [Book1_Documents_transmitted_to_CPY] REAL               NULL,
    CONSTRAINT [PK_p_TitleObject] PRIMARY KEY CLUSTERED ([TitleObject_ID] ASC),
    CONSTRAINT [FK_p_TitleObject_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_TitleObject_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_TitleObject_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_TitleObject_TitleObject_Code] UNIQUE NONCLUSTERED ([TitleObject_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_TitleObject_Created_User_ID]
    ON [dbo].[p_TitleObject]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_TitleObject_Modified_User_ID]
    ON [dbo].[p_TitleObject]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_TitleObject_RowStatus]
    ON [dbo].[p_TitleObject]([RowStatus] ASC);

