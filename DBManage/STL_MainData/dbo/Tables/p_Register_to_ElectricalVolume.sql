CREATE TABLE [dbo].[p_Register_to_ElectricalVolume] (
    [Register_to_ElectricalVolume_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_ElectricalVolume_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Register_ID]                     UNIQUEIDENTIFIER NOT NULL,
    [ElectricalVolume_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                      INT              NULL,
    [Insert_DTS]                      DATETIME2 (7)    NULL,
    [Update_DTS]                      DATETIME2 (7)    NULL,
    [Created_User_ID]                 UNIQUEIDENTIFIER NULL,
    [Modified_User_ID]                UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_Register_to_ElectricalVolume] PRIMARY KEY CLUSTERED ([Register_to_ElectricalVolume_ID] ASC),
    CONSTRAINT [FK_p_Register_to_ElectricalVolume_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_Register_to_ElectricalVolume_ElectricalVolume_ID_p_ElectricalVolume_m] FOREIGN KEY ([ElectricalVolume_ID]) REFERENCES [dbo].[p_ElectricalVolume_m] ([ElectricalVolume_ID]),
    CONSTRAINT [FK_p_Register_to_ElectricalVolume_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_Register_to_ElectricalVolume_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_ElectricalVolume_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Register_to_ElectricalVolume] UNIQUE NONCLUSTERED ([Register_ID] ASC, [ElectricalVolume_ID] ASC)
);

