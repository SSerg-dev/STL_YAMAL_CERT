CREATE TABLE [dbo].[p_Status] (
    [Status_ID]        UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Status_Code]      NVARCHAR (255)     NOT NULL,
    [StatusEntity]     NVARCHAR (255)     NOT NULL,
    [EntityLocked]     BIT                NOT NULL,
    [Description_Eng]  NVARCHAR (255)     NULL,
    [Description_Rus]  NVARCHAR (255)     NULL,
    [ReportColor]      BIT                NOT NULL,
    [ReportOrder]      INT                NOT NULL,
    CONSTRAINT [PK_p_Status] PRIMARY KEY CLUSTERED ([Status_ID] ASC),
    CONSTRAINT [FK_p_Status_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Status_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Status_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_Status_Created_User_ID]
    ON [dbo].[p_Status]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Status_Modified_User_ID]
    ON [dbo].[p_Status]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Status_RowStatus]
    ON [dbo].[p_Status]([RowStatus] ASC);

