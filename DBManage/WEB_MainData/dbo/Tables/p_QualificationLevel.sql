CREATE TABLE [dbo].[p_QualificationLevel] (
    [RowStatus]               INT              NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NOT NULL,
    [Update_DTS]              DATETIME2 (7)    NOT NULL,
    [Created_User_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [QualificationLevel_ID]   UNIQUEIDENTIFIER NOT NULL,
    [QualificationLevel_Code] NVARCHAR (MAX)   NOT NULL,
    [Description_Rus]         NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_p_QualificationLevel] PRIMARY KEY CLUSTERED ([QualificationLevel_ID] ASC),
    CONSTRAINT [FK_p_QualificationLevel_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_QualificationLevel_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_QualificationLevel_Modified_User_ID]
    ON [dbo].[p_QualificationLevel]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_QualificationLevel_Created_User_ID]
    ON [dbo].[p_QualificationLevel]([Created_User_ID] ASC);

