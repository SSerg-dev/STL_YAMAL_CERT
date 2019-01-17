CREATE TABLE [dbo].[p_JobCard] (
    [JobCard_ID]           UNIQUEIDENTIFIER CONSTRAINT [DF_JobCard_ID] DEFAULT (newsequentialid()) NOT NULL,
    [JobCard_Number]       NVARCHAR (100)   NOT NULL,
    [Activity_Description] NVARCHAR (1000)  NULL,
    [COW_Type]             NVARCHAR (100)   NULL,
    [IsChecked]            BIT              NULL,
    [Row_status]           INT              NULL,
    [Insert_DTS]           DATETIME2 (7)    NULL,
    [Update_DTS]           DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_JobCard] PRIMARY KEY CLUSTERED ([JobCard_ID] ASC),
    CONSTRAINT [FK_p_JobCard_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_JobCard] UNIQUE NONCLUSTERED ([JobCard_Number] ASC)
);

