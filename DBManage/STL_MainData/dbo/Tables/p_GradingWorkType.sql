CREATE TABLE [dbo].[p_GradingWorkType] (
    [GradingWorkType_ID]   UNIQUEIDENTIFIER NOT NULL,
    [GradingWorkType_Code] NVARCHAR (255)   NOT NULL,
    [Description_Rus]      NVARCHAR (255)   NULL,
    [Description_Eng]      NVARCHAR (255)   NULL,
    [Row_Status]           INT              NULL,
    [Insert_DTS]           DATETIME2 (7)    NULL,
    [Update_DTS]           DATETIME2 (7)    NULL,
    [Created_User_ID]      UNIQUEIDENTIFIER NULL,
    [Modified_User_ID]     UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_GradingWorkType] PRIMARY KEY CLUSTERED ([GradingWorkType_ID] ASC),
    CONSTRAINT [FK_p_GradingWorkType_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_GradingWorkType_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_GradingWorkType_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_GradingWorkType] UNIQUE NONCLUSTERED ([GradingWorkType_Code] ASC)
);

