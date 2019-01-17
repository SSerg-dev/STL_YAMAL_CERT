CREATE TABLE [dbo].[p_JobCard_to_Module] (
    [JobCard_to_Module_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_JobCard_to_Module_ID] DEFAULT (newsequentialid()) NOT NULL,
    [JobCard_ID]           UNIQUEIDENTIFIER NOT NULL,
    [Module_ID]            UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]           INT              NULL,
    [Insert_DTS]           DATETIME2 (7)    NULL,
    [Update_DTS]           DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_JobCard_to_Module] PRIMARY KEY CLUSTERED ([JobCard_to_Module_ID] ASC),
    CONSTRAINT [FK_p_JobCard_to_Module_JobCard_ID_p_JobCard] FOREIGN KEY ([JobCard_ID]) REFERENCES [dbo].[p_JobCard] ([JobCard_ID]),
    CONSTRAINT [FK_p_JobCard_to_Module_Module_ID_p_Module] FOREIGN KEY ([Module_ID]) REFERENCES [dbo].[p_Module] ([Module_ID]),
    CONSTRAINT [FK_p_JobCard_to_Module_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_JobCard_to_Module] UNIQUE NONCLUSTERED ([JobCard_ID] ASC, [Module_ID] ASC)
);

