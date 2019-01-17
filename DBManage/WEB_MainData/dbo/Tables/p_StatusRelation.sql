CREATE TABLE [dbo].[p_StatusRelation] (
    [StatusRelation_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_StatusRelation_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]           INT              NOT NULL,
    [Insert_DTS]          DATETIME2 (7)    NOT NULL,
    [Update_DTS]          DATETIME2 (7)    NOT NULL,
    [Created_User_ID]     UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]    UNIQUEIDENTIFIER NOT NULL,
    [From_Status_ID]      UNIQUEIDENTIFIER NOT NULL,
    [To_Status_ID]        UNIQUEIDENTIFIER NOT NULL,
    [StatusRelation_Code] BIGINT           NULL,
    [IterationIncrement]  INT              NULL,
    [CheckType_ID]        UNIQUEIDENTIFIER NULL,
    [ActionType]          INT              NULL,
    CONSTRAINT [PK_p_StatusRelation] PRIMARY KEY CLUSTERED ([StatusRelation_ID] ASC),
    CONSTRAINT [FK_p_StatusRelation_CheckType_ID_p_CheckType] FOREIGN KEY ([CheckType_ID]) REFERENCES [dbo].[p_CheckType] ([CheckType_ID]),
    CONSTRAINT [FK_p_StatusRelation_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_StatusRelation_From_Status_ID_p_Status] FOREIGN KEY ([From_Status_ID]) REFERENCES [dbo].[p_Status] ([Status_ID]),
    CONSTRAINT [FK_p_StatusRelation_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_StatusRelation_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_StatusRelation_To_Status_ID_p_Status] FOREIGN KEY ([To_Status_ID]) REFERENCES [dbo].[p_Status] ([Status_ID]),
    CONSTRAINT [UQ_p_StatusRelation] UNIQUE NONCLUSTERED ([From_Status_ID] ASC, [To_Status_ID] ASC)
);



