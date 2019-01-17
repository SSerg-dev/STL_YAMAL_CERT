﻿CREATE TABLE [dbo].[p_WeldingEquipmentAutomationLevel] (
    [WeldingEquipmentAutomationLevel_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_WeldingEquipmentAutomationLevel_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]                            INT              NOT NULL,
    [Insert_DTS]                           DATETIME2 (7)    NOT NULL,
    [Update_DTS]                           DATETIME2 (7)    NOT NULL,
    [Created_User_ID]                      UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                     UNIQUEIDENTIFIER NOT NULL,
    [WeldingEquipmentAutomationLevel_Code] NVARCHAR (255)   NOT NULL,
    [Description_Rus]                      NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_WeldingEquipmentAutomationLevel] PRIMARY KEY CLUSTERED ([WeldingEquipmentAutomationLevel_ID] ASC),
    CONSTRAINT [FK_p_WeldingEquipmentAutomationLevel_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WeldingEquipmentAutomationLevel_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WeldingEquipmentAutomationLevel_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_WeldingEquipmentAutomationLevel] UNIQUE NONCLUSTERED ([WeldingEquipmentAutomationLevel_Code] ASC)
);

