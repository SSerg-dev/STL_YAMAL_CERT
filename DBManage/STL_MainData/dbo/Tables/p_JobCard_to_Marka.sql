CREATE TABLE [dbo].[p_JobCard_to_Marka] (
    [JobCard_to_Marka_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_JobCard_to_Marka_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]          DATETIME2 (7)    NULL,
    [Update_DTS]          DATETIME2 (7)    NULL,
    [Row_Status]          INT              NULL,
    [JobCard_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Marka_ID]            UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_JobCard_to_Marka] PRIMARY KEY CLUSTERED ([JobCard_to_Marka_ID] ASC),
    CONSTRAINT [FK_p_JobCard_to_Marka_JobCard_ID_p_JobCard] FOREIGN KEY ([JobCard_ID]) REFERENCES [dbo].[p_JobCard] ([JobCard_ID]),
    CONSTRAINT [FK_p_JobCard_to_Marka_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_JobCard_to_Marka_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_JobCard_to_Marka] UNIQUE NONCLUSTERED ([JobCard_ID] ASC, [Marka_ID] ASC)
);

