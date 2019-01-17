CREATE TABLE [dbo].[p_WorkPackage_to_SubContractor2] (
    [WorkPackage_to_SubContractor_ID] UNIQUEIDENTIFIER NOT NULL,
    [WorkPackage_ID]                  UNIQUEIDENTIFIER NOT NULL,
    [SubContractor_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                      INT              NULL,
    [Insert_DTS]                      DATETIME2 (7)    NULL,
    [Update_DTS]                      DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_WorkPackage_to_SubContractor2] PRIMARY KEY CLUSTERED ([WorkPackage_to_SubContractor_ID] ASC),
    CONSTRAINT [FK_p_WorkPackage_to_SubContractor2_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_WorkPackage_to_SubContractor2_SubContractor_ID_p_SubContractor2] FOREIGN KEY ([SubContractor_ID]) REFERENCES [dbo].[p_SubContractor2] ([SubContractor_ID]),
    CONSTRAINT [FK_p_WorkPackage_to_SubContractor2_WorkPackage_ID_p_WorkPackage] FOREIGN KEY ([WorkPackage_ID]) REFERENCES [dbo].[p_WorkPackage] ([WorkPackage_ID]),
    CONSTRAINT [UQ_p_WorkPackage_to_SubContractor2] UNIQUE NONCLUSTERED ([WorkPackage_ID] ASC, [SubContractor_ID] ASC)
);

