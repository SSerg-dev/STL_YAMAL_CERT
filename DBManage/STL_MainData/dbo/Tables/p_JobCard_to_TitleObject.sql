CREATE TABLE [dbo].[p_JobCard_to_TitleObject] (
    [JobCard_to_TitleObject_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_JobCard_to_TitleObject_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                DATETIME2 (7)    NULL,
    [Update_DTS]                DATETIME2 (7)    NULL,
    [Row_Status]                INT              NULL,
    [JobCard_ID]                UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]            UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_JobCard_to_TitleObject] PRIMARY KEY CLUSTERED ([JobCard_to_TitleObject_ID] ASC),
    CONSTRAINT [FK_p_JobCard_to_TitleObject_JobCard_ID_p_JobCard] FOREIGN KEY ([JobCard_ID]) REFERENCES [dbo].[p_JobCard] ([JobCard_ID]),
    CONSTRAINT [FK_p_JobCard_to_TitleObject_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_JobCard_to_TitleObject_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_JobCard_to_TitleObject] UNIQUE NONCLUSTERED ([JobCard_ID] ASC, [TitleObject_ID] ASC)
);

