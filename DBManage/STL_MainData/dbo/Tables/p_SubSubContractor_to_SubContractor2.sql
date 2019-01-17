CREATE TABLE [dbo].[p_SubSubContractor_to_SubContractor2] (
    [SubSubContractor_to_SubContractor_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]                           DATETIME2 (7)    NULL,
    [Update_DTS]                           DATETIME2 (7)    NULL,
    [Row_Status]                           INT              NULL,
    [SubSubContractor_ID]                  UNIQUEIDENTIFIER NOT NULL,
    [SubContractor_ID]                     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_SubSubContractor_to_SubContractor2] PRIMARY KEY CLUSTERED ([SubSubContractor_to_SubContractor_ID] ASC),
    CONSTRAINT [FK_p_SubSubContractor_to_SubContractor2_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_SubSubContractor_to_SubContractor2_SubContractor_ID_p_SubContractor2] FOREIGN KEY ([SubContractor_ID]) REFERENCES [dbo].[p_SubContractor2] ([SubContractor_ID])
);

