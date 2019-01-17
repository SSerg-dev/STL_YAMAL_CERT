CREATE TABLE [dbo].[tr_ElectricalLogsWorkTypes] (
    [ElectricalLogsWorkTypes_ID] UNIQUEIDENTIFIER NOT NULL,
    [Description_Rus]            NVARCHAR (255)   NULL,
    [Description_Eng]            NVARCHAR (255)   NULL,
    [Row_Status]                 INT              NULL,
    [Insert_DTS]                 DATETIME2 (7)    NULL,
    [Update_DTS]                 DATETIME2 (7)    NULL,
    [Report_Order]               INT              NULL,
    CONSTRAINT [PK_tr_ElectricalLogsWorkTypes] PRIMARY KEY CLUSTERED ([ElectricalLogsWorkTypes_ID] ASC),
    CONSTRAINT [FK_tr_ElectricalLogsWorkTypes_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status])
);

