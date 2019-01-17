CREATE TABLE [dbo].[p_GradingStad] (
    [GradingStad_ID]   UNIQUEIDENTIFIER NOT NULL,
    [GradingStad_Name] NVARCHAR (100)   NOT NULL,
    [Row_Status]       INT              NULL,
    [Insert_DTS]       DATETIME2 (7)    NULL,
    [Update_DTS]       DATETIME2 (7)    NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_GradingStad] PRIMARY KEY CLUSTERED ([GradingStad_ID] ASC),
    CONSTRAINT [FK_p_GradingStad_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_GradingStad_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_GradingStad_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_GradingStad] UNIQUE NONCLUSTERED ([GradingStad_Name] ASC)
);

