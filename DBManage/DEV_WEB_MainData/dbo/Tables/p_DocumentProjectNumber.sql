CREATE TABLE [dbo].[p_DocumentProjectNumber] (
    [DocumentProjectNumber_ID]   UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                 DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]                 DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]            UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]           UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]                  INT                NOT NULL,
    [DocumentProjectNumber_Code] NVARCHAR (255)     NOT NULL,
    CONSTRAINT [PK_p_DocumentProjectNumber] PRIMARY KEY CLUSTERED ([DocumentProjectNumber_ID] ASC),
    CONSTRAINT [FK_p_DocumentProjectNumber_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentProjectNumber_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentProjectNumber_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_DocumentProjectNumber_DocumentProjectNumber_Code] UNIQUE NONCLUSTERED ([DocumentProjectNumber_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentProjectNumber_Created_User_ID]
    ON [dbo].[p_DocumentProjectNumber]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentProjectNumber_Modified_User_ID]
    ON [dbo].[p_DocumentProjectNumber]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentProjectNumber_RowStatus]
    ON [dbo].[p_DocumentProjectNumber]([RowStatus] ASC);

