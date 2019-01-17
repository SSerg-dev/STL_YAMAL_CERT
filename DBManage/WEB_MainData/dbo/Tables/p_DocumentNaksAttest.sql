CREATE TABLE [dbo].[p_DocumentNaksAttest] (
    [RowStatus]                          INT              NOT NULL,
    [Insert_DTS]                         DATETIME2 (7)    NOT NULL,
    [Update_DTS]                         DATETIME2 (7)    NOT NULL,
    [Created_User_ID]                    UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]                   UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaksAttest_ID]              UNIQUEIDENTIFIER NOT NULL,
    [DetailWidth]                        NVARCHAR (MAX)   NULL,
    [OuterDiameter]                      NVARCHAR (MAX)   NULL,
    [SDR]                                NVARCHAR (MAX)   NULL,
    [DocumentNaks_ID]                    UNIQUEIDENTIFIER NOT NULL,
    [WeldingEquipmentAutomationLevel_ID] UNIQUEIDENTIFIER NOT NULL,
    [ShieldingGasFlux]                   NVARCHAR (MAX)   NULL,
    [WeldingWire]                        NVARCHAR (MAX)   NULL,
    [WeldPositionCustom]                 NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_p_DocumentNaks_DocumentNaks_ID] FOREIGN KEY ([DocumentNaks_ID]) REFERENCES [dbo].[p_DocumentNaks] ([DocumentNaks_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_p_DocumentNaksAttest_p_WeldingEquipmentAutomationLevel_WeldingEquipmentAutomationLevel_ID] FOREIGN KEY ([WeldingEquipmentAutomationLevel_ID]) REFERENCES [dbo].[p_WeldingEquipmentAutomationLevel] ([WeldingEquipmentAutomationLevel_ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_WeldingEquipmentAutomationLevel_ID]
    ON [dbo].[p_DocumentNaksAttest]([WeldingEquipmentAutomationLevel_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_DocumentNaks_ID]
    ON [dbo].[p_DocumentNaksAttest]([DocumentNaks_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest]([Created_User_ID] ASC);

