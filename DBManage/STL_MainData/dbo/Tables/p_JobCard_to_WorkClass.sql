CREATE TABLE [dbo].[p_JobCard_to_WorkClass] (
    [JobCard_To_WorkClass_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_JobCard_to_WorkClass_ID] DEFAULT (newsequentialid()) NOT NULL,
    [DTS_Start]               DATETIME2 (7)    NULL,
    [DTS_End]                 DATETIME2 (7)    NULL,
    [Row_status]              INT              NULL,
    [JobCard_ID]              UNIQUEIDENTIFIER NOT NULL,
    [WorkClass_ID]            UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]              DATETIME2 (7)    NULL,
    [Update_DTS]              DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_JobCard_to_WorkClass] PRIMARY KEY CLUSTERED ([JobCard_To_WorkClass_ID] ASC),
    CONSTRAINT [FK_p_JobCard_to_WorkClass_JobCard_ID_p_JobCard] FOREIGN KEY ([JobCard_ID]) REFERENCES [dbo].[p_JobCard] ([JobCard_ID]),
    CONSTRAINT [FK_p_JobCard_to_WorkClass_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_JobCard_to_WorkClass_WorkClass_ID_p_WorkClass] FOREIGN KEY ([WorkClass_ID]) REFERENCES [dbo].[p_WorkClass] ([WorkClass_ID]),
    CONSTRAINT [UQ_p_JobCard_to_WorkClass] UNIQUE NONCLUSTERED ([JobCard_ID] ASC, [WorkClass_ID] ASC)
);

