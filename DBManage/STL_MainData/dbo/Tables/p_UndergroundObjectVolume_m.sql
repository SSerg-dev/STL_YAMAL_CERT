CREATE TABLE [dbo].[p_UndergroundObjectVolume_m] (
    [UndergroundObjectVolume_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_p_UndergroundObjectVolume_m] DEFAULT (newsequentialid()) NOT NULL,
    [Row_Status]                 INT              NULL,
    [Insert_DTS]                 DATETIME2 (7)    NULL,
    [Update_DTS]                 DATETIME2 (7)    NULL,
    [Created_User_ID]            UNIQUEIDENTIFIER NULL,
    [Modified_User_ID]           UNIQUEIDENTIFIER NULL,
    [UndergroundObject_ID]       UNIQUEIDENTIFIER NOT NULL,
    [UndergroundWorkType_ID]     UNIQUEIDENTIFIER NOT NULL,
    [MeasureUnit_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Contragent_ID]              UNIQUEIDENTIFIER NULL,
    [Design_Qty]                 FLOAT (53)       NULL,
    [Fact_Qty]                   FLOAT (53)       NULL,
    CONSTRAINT [PK_p_UndergroundObjectVolume_m] PRIMARY KEY CLUSTERED ([UndergroundObjectVolume_ID] ASC),
    CONSTRAINT [FK_p_UndergroundObjectVolume_m_Contragent_ID_p_Contragent] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_UndergroundObjectVolume_m_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_UndergroundObjectVolume_m_MeasureUnit_ID_p_MeasureUnit] FOREIGN KEY ([MeasureUnit_ID]) REFERENCES [dbo].[p_MeasureUnit] ([MeasureUnit_ID]),
    CONSTRAINT [FK_p_UndergroundObjectVolume_m_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_UndergroundObjectVolume_m_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_UndergroundObjectVolume_m_UndergroundObject_ID_p_UndergroundObject] FOREIGN KEY ([UndergroundObject_ID]) REFERENCES [dbo].[p_UndergroundObject] ([UndergroundObject_ID]),
    CONSTRAINT [FK_p_UndergroundObjectVolume_m_UndergroundWorkType_ID_p_UndergroundWorkType] FOREIGN KEY ([UndergroundWorkType_ID]) REFERENCES [dbo].[p_UndergroundWorkType] ([UndergroundWorkType_ID]),
    CONSTRAINT [UQ_p_UndergroundObjectVolume_m] UNIQUE NONCLUSTERED ([UndergroundObject_ID] ASC, [UndergroundWorkType_ID] ASC, [MeasureUnit_ID] ASC)
);

