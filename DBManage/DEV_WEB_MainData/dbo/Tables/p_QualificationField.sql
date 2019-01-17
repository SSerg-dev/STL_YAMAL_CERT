CREATE TABLE [dbo].[p_QualificationField] (
    [QualificationField_ID]   UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]              DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]              DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]         UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]        UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]               INT                NOT NULL,
    [Parent_ID]               UNIQUEIDENTIFIER   NULL,
    [Structure_Level]         INT                NOT NULL,
    [QualificationField_Code] NVARCHAR (255)     NOT NULL,
    [Description_Rus]         NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_QualificationField] PRIMARY KEY CLUSTERED ([QualificationField_ID] ASC),
    CONSTRAINT [FK_p_QualificationField_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_QualificationField_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_QualificationField_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_QualificationField_QualificationField_Code] UNIQUE NONCLUSTERED ([QualificationField_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_QualificationField_Created_User_ID]
    ON [dbo].[p_QualificationField]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_QualificationField_Modified_User_ID]
    ON [dbo].[p_QualificationField]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_QualificationField_RowStatus]
    ON [dbo].[p_QualificationField]([RowStatus] ASC);

