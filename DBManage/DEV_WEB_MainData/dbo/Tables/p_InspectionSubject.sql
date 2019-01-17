CREATE TABLE [dbo].[p_InspectionSubject] (
    [InspectionSubject_ID]   UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]             DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]        UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]       UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]              INT                NOT NULL,
    [Parent_ID]              UNIQUEIDENTIFIER   NULL,
    [Structure_Level]        INT                NOT NULL,
    [InspectionSubject_Code] NVARCHAR (255)     NOT NULL,
    [Description_Rus]        NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_InspectionSubject] PRIMARY KEY CLUSTERED ([InspectionSubject_ID] ASC),
    CONSTRAINT [FK_p_InspectionSubject_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_InspectionSubject_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_InspectionSubject_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_InspectionSubject_InspectionSubject_Code] UNIQUE NONCLUSTERED ([InspectionSubject_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_InspectionSubject_Created_User_ID]
    ON [dbo].[p_InspectionSubject]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_InspectionSubject_Modified_User_ID]
    ON [dbo].[p_InspectionSubject]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_InspectionSubject_RowStatus]
    ON [dbo].[p_InspectionSubject]([RowStatus] ASC);

