CREATE TABLE [dbo].[p_UndergroundObject] (
    [UndergroundObject_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_UndergroundObject_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Row_Status]           INT              NOT NULL,
    [Insert_DTS]           DATETIME2 (7)    NOT NULL,
    [Update_DTS]           DATETIME2 (7)    NOT NULL,
    [Created_User_ID]      UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]     UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]       UNIQUEIDENTIFIER NULL,
    [SubTitleObject_ID]    UNIQUEIDENTIFIER NULL,
    [Marka_ID]             UNIQUEIDENTIFIER NULL,
    [ABDFinalSet]          NVARCHAR (100)   NULL,
    CONSTRAINT [PK_p_UndergroundObject] PRIMARY KEY CLUSTERED ([UndergroundObject_ID] ASC),
    CONSTRAINT [FK_p_UndergroundObject_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_UndergroundObject_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_UndergroundObject_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_UndergroundObject_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_UndergroundObject_SubTitleObject_ID_p_TitleObject] FOREIGN KEY ([SubTitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [FK_p_UndergroundObject_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID])
);

