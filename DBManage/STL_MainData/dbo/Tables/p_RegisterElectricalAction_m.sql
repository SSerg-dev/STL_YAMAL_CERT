CREATE TABLE [dbo].[p_RegisterElectricalAction_m] (
    [RegisterElectricalAction_m_ID] UNIQUEIDENTIFIER NOT NULL,
    [Register_ID]                   UNIQUEIDENTIFIER NULL,
    [ElectricalLogsWorkTypes_ID]    UNIQUEIDENTIFIER NULL,
    [TAG_ID]                        UNIQUEIDENTIFIER NULL,
    [DTS_Strat]                     DATETIME2 (7)    NULL,
    [DTS_End]                       DATETIME2 (7)    NULL,
    [Row_Status]                    INT              NULL,
    [Insert_DTS]                    DATETIME2 (7)    NULL,
    [Update_DTS]                    DATETIME2 (7)    NULL,
    [Created_By]                    NVARCHAR (255)   NULL,
    [Modified_By]                   NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_RegisterElectricalAction_m] PRIMARY KEY CLUSTERED ([RegisterElectricalAction_m_ID] ASC),
    CONSTRAINT [FK_p_RegisterElectricalAction_m_ElectricalLogsWorkTypes_ID_tr_ElectricalLogsWorkTypes] FOREIGN KEY ([ElectricalLogsWorkTypes_ID]) REFERENCES [dbo].[tr_ElectricalLogsWorkTypes] ([ElectricalLogsWorkTypes_ID]),
    CONSTRAINT [FK_p_RegisterElectricalAction_m_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_RegisterElectricalAction_m_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_RegisterElectricalAction_m_TAG_ID_p_TAG] FOREIGN KEY ([TAG_ID]) REFERENCES [dbo].[p_TAG] ([TAG_ID])
);

