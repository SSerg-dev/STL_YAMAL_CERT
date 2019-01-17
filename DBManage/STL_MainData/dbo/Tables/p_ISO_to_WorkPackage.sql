CREATE TABLE [dbo].[p_ISO_to_WorkPackage] (
    [ISO_to_WorkPackage_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]            DATETIME2 (7)    NULL,
    [Update_DTS]            DATETIME2 (7)    NULL,
    [Row_Status]            INT              NULL,
    [ISO_ID]                UNIQUEIDENTIFIER NOT NULL,
    [WorkPackage_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ISO_to_WorkPackage] PRIMARY KEY CLUSTERED ([ISO_to_WorkPackage_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_WorkPackage_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_WorkPackage_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ISO_to_WorkPackage_WorkPackage_ID_p_WorkPackage] FOREIGN KEY ([WorkPackage_ID]) REFERENCES [dbo].[p_WorkPackage] ([WorkPackage_ID]),
    CONSTRAINT [UQ_p_ISO_to_WorkPackage] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [WorkPackage_ID] ASC)
);

