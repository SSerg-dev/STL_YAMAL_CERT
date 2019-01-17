CREATE TABLE [dbo].[p_JointKind] (
    [JointKind_ID]     UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [JointKind_Code]   NVARCHAR (255)     NOT NULL,
    [Description_Rus]  NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_JointKind] PRIMARY KEY CLUSTERED ([JointKind_ID] ASC),
    CONSTRAINT [FK_p_JointKind_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_JointKind_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_JointKind_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_JointKind_JointKind_Code] UNIQUE NONCLUSTERED ([JointKind_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_JointKind_Created_User_ID]
    ON [dbo].[p_JointKind]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_JointKind_Modified_User_ID]
    ON [dbo].[p_JointKind]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_JointKind_RowStatus]
    ON [dbo].[p_JointKind]([RowStatus] ASC);

