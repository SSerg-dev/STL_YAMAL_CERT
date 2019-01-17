CREATE TABLE [dbo].[p_ISO_to_SubContractor2] (
    [ISO_to_SubContractor_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NULL,
    [Update_DTS]              DATETIME2 (7)    NULL,
    [Row_Status]              INT              NULL,
    [ISO_ID]                  UNIQUEIDENTIFIER NULL,
    [WorkType_ID]             UNIQUEIDENTIFIER NULL,
    [SubContractor_ID]        UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_ISO_to_SubContractor2] PRIMARY KEY CLUSTERED ([ISO_to_SubContractor_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_SubContractor2_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_SubContractor2_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_ISO_to_SubContractor2_SubContractor_ID_p_SubContractor2] FOREIGN KEY ([SubContractor_ID]) REFERENCES [dbo].[p_SubContractor2] ([SubContractor_ID]),
    CONSTRAINT [UQ_p_ISO_to_SubContractor2] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [WorkType_ID] ASC)
);

