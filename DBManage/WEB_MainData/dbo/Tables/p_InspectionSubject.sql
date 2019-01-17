CREATE TABLE [dbo].[p_InspectionSubject] (
    [RowStatus]              INT              NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NOT NULL,
    [Update_DTS]             DATETIME2 (7)    NOT NULL,
    [Created_User_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]       UNIQUEIDENTIFIER NOT NULL,
    [InspectionSubject_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Parent_ID]              UNIQUEIDENTIFIER NULL,
    [Structure_Level]        INT              NOT NULL,
    [InspectionSubject_Code] NVARCHAR (MAX)   NOT NULL,
    [Description_Rus]        NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_p_InspectionSubject] PRIMARY KEY CLUSTERED ([InspectionSubject_ID] ASC),
    CONSTRAINT [FK_p_InspectionSubject_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_InspectionSubject_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_InspectionSubject_Modified_User_ID]
    ON [dbo].[p_InspectionSubject]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_InspectionSubject_Created_User_ID]
    ON [dbo].[p_InspectionSubject]([Created_User_ID] ASC);

