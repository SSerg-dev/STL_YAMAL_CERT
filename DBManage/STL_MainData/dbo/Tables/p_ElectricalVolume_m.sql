CREATE TABLE [dbo].[p_ElectricalVolume_m] (
    [ElectricalVolume_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ElectricalVolume_m_ID] DEFAULT (newsequentialid()) NOT NULL,
    [TAG_ID]              UNIQUEIDENTIFIER NOT NULL,
    [WorkClass_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Contragent_ID]       UNIQUEIDENTIFIER NOT NULL,
    [Design_QTY]          FLOAT (53)       NULL,
    [Fact_QTY]            FLOAT (53)       NULL,
    [Row_Status]          INT              NULL,
    [Insert_DTS]          DATETIME2 (7)    NULL,
    [Update_DTS]          DATETIME2 (7)    NULL,
    [Created_User_ID]     UNIQUEIDENTIFIER NULL,
    [Modified_User_ID]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_ElectricalVolume_m] PRIMARY KEY CLUSTERED ([ElectricalVolume_ID] ASC),
    CONSTRAINT [FK_p_ElectricalVolume_m_Contragent_ID_p_Contragent] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_ElectricalVolume_m_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_ElectricalVolume_m_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_ElectricalVolume_m_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ElectricalVolume_m_TAG_ID_p_TAG] FOREIGN KEY ([TAG_ID]) REFERENCES [dbo].[p_TAG] ([TAG_ID]),
    CONSTRAINT [FK_p_ElectricalVolume_m_WorkClass_ID_p_WorkClass] FOREIGN KEY ([WorkClass_ID]) REFERENCES [dbo].[p_WorkClass] ([WorkClass_ID]),
    CONSTRAINT [UQ_p_ElectricalVolume_m] UNIQUE NONCLUSTERED ([TAG_ID] ASC, [WorkClass_ID] ASC, [Contragent_ID] ASC)
);

