CREATE TABLE [dbo].[p_Module_to_WorkPackage_Fab] (
    [Module_to_WorkPackage_Fab_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]                   DATETIME2 (7)    NULL,
    [Update_DTS]                   DATETIME2 (7)    NULL,
    [Row_Status]                   INT              NULL,
    [Module_ID]                    UNIQUEIDENTIFIER NOT NULL,
    [WorkPackage_Fab_ID]           UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Module_to_WorkPackage_Fab] PRIMARY KEY CLUSTERED ([Module_to_WorkPackage_Fab_ID] ASC),
    CONSTRAINT [FK_p_Module_to_WorkPackage_Fab_Module_ID_p_Module] FOREIGN KEY ([Module_ID]) REFERENCES [dbo].[p_Module] ([Module_ID]),
    CONSTRAINT [FK_p_Module_to_WorkPackage_Fab_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_Module_to_WorkPackage_Fab_WorkPackage_Fab_ID_p_WorkPackage] FOREIGN KEY ([WorkPackage_Fab_ID]) REFERENCES [dbo].[p_WorkPackage] ([WorkPackage_ID]),
    CONSTRAINT [UQ_p_Module_to_WorkPackage_Fab] UNIQUE NONCLUSTERED ([Module_ID] ASC, [WorkPackage_Fab_ID] ASC)
);

