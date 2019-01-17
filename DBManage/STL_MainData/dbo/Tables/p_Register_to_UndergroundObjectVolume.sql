CREATE TABLE [dbo].[p_Register_to_UndergroundObjectVolume] (
    [Register_to_UndergroundObjectVolume_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_UndergroundObjectVolume] DEFAULT (newsequentialid()) NOT NULL,
    [Row_Status]                             INT              NULL,
    [Insert_DTS]                             DATETIME2 (7)    NULL,
    [Update_DTS]                             DATETIME2 (7)    NULL,
    [Created_User_ID]                        UNIQUEIDENTIFIER NULL,
    [Modified_User_ID]                       UNIQUEIDENTIFIER NULL,
    [Register_ID]                            UNIQUEIDENTIFIER NOT NULL,
    [UndergroundObjectVolume_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Qty]                                    FLOAT (53)       NULL,
    CONSTRAINT [PK_p_Register_to_UndergroundObjectVolume] PRIMARY KEY CLUSTERED ([Register_to_UndergroundObjectVolume_ID] ASC),
    CONSTRAINT [FK_p_Register_to_UndergroundObjectVolume_Created_User_ID_p_User] FOREIGN KEY ([Created_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_Register_to_UndergroundObjectVolume_Modified_User_ID_p_User] FOREIGN KEY ([Modified_User_ID]) REFERENCES [syslog].[p_User] ([User_ID]),
    CONSTRAINT [FK_p_Register_to_UndergroundObjectVolume_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_UndergroundObjectVolume_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_Register_to_UndergroundObjectVolume_UndergroundObjectVolume_ID_p_UndergroundObjectVolume_m] FOREIGN KEY ([UndergroundObjectVolume_ID]) REFERENCES [dbo].[p_UndergroundObjectVolume_m] ([UndergroundObjectVolume_ID]),
    CONSTRAINT [UQ_p_Register_to_UndergroundObjectVolume] UNIQUE NONCLUSTERED ([Register_ID] ASC, [UndergroundObjectVolume_ID] ASC)
);

