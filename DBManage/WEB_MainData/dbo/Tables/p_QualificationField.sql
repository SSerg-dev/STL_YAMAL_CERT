CREATE TABLE [dbo].[p_QualificationField] (
    [RowStatus]               INT              NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NOT NULL,
    [Update_DTS]              DATETIME2 (7)    NOT NULL,
    [Created_User_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [QualificationField_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Parent_ID]               UNIQUEIDENTIFIER NULL,
    [Structure_Level]         INT              NOT NULL,
    [QualificationField_Code] NVARCHAR (MAX)   NOT NULL,
    [Description_Rus]         NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_p_QualificationField] PRIMARY KEY CLUSTERED ([QualificationField_ID] ASC),
    CONSTRAINT [FK_p_QualificationField_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_QualificationField_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_QualificationField_Modified_User_ID]
    ON [dbo].[p_QualificationField]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_QualificationField_Created_User_ID]
    ON [dbo].[p_QualificationField]([Created_User_ID] ASC);

