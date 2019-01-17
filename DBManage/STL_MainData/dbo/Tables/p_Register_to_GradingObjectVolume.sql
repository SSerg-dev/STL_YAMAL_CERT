CREATE TABLE [dbo].[p_Register_to_GradingObjectVolume] (
    [Register_to_GradingObjectVolume_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_GradingObjectVolume_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Register_ID]                        UNIQUEIDENTIFIER NOT NULL,
    [GradingObjectVolume_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Qty]                                FLOAT (53)       NULL,
    [Insert_DTS]                         DATETIME2 (7)    NULL,
    [Update_DTS]                         DATETIME2 (7)    NULL,
    [Row_Status]                         INT              NULL,
    [Created_User_ID]                    UNIQUEIDENTIFIER NULL,
    [Modified_User_ID]                   UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_Register_to_GradingObjectVolume] PRIMARY KEY CLUSTERED ([Register_to_GradingObjectVolume_ID] ASC),
    CONSTRAINT [FK_p_Register_to_GradingObjectVolume_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_Register_to_GradingObjectVolume_GradingObjectVolume_ID_p_GradingObjectVolume_m] FOREIGN KEY ([GradingObjectVolume_ID]) REFERENCES [dbo].[p_GradingObjectVolume_m] ([GradingObjectVolume_ID]),
    CONSTRAINT [FK_p_Register_to_GradingObjectVolume_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_Register_to_GradingObjectVolume_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_GradingObjectVolume_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Register_to_GradingObjectVolume] UNIQUE NONCLUSTERED ([Register_ID] ASC, [GradingObjectVolume_ID] ASC)
);

