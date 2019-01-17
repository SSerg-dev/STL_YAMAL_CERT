CREATE TABLE [dbo].[p_Module_to_WorkPackage_Er] (
    [Module_to_WorkPackage_Er_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]                  DATETIME2 (7)    NULL,
    [Update_DTS]                  DATETIME2 (7)    NULL,
    [Row_Status]                  INT              NULL,
    [Module_ID]                   UNIQUEIDENTIFIER NOT NULL,
    [WorkPackage_Er_ID]           UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Module_to_WorkPackage_Er] PRIMARY KEY CLUSTERED ([Module_to_WorkPackage_Er_ID] ASC),
    CONSTRAINT [FK_p_Module_to_WorkPackage_Er_Module_ID_p_Module] FOREIGN KEY ([Module_ID]) REFERENCES [dbo].[p_Module] ([Module_ID]),
    CONSTRAINT [FK_p_Module_to_WorkPackage_Er_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_Module_to_WorkPackage_Er_WorkPackage_Er_ID_p_WorkPackage] FOREIGN KEY ([WorkPackage_Er_ID]) REFERENCES [dbo].[p_WorkPackage] ([WorkPackage_ID]),
    CONSTRAINT [UQ_p_Module_to_WorkPackage_Er] UNIQUE NONCLUSTERED ([Module_ID] ASC, [WorkPackage_Er_ID] ASC)
);

