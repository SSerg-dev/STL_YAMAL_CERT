CREATE TABLE [dbo].[p_JobCardRusABDActivityGroup] (
    [JobCardRusABDActivityGroup_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Description_Rus]                 NVARCHAR (255)   NULL,
    [Description_Eng]                 NVARCHAR (255)   NULL,
    [Row_Status]                      INT              NULL,
    [Insert_DTS]                      DATETIME2 (7)    NULL,
    [Update_DTS]                      DATETIME2 (7)    NULL,
    [Report_Order]                    INT              NULL,
    [JobCardRusABDActivityGroup_Code] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_p_JobCardRusABDActivityGroup] PRIMARY KEY CLUSTERED ([JobCardRusABDActivityGroup_ID] ASC),
    CONSTRAINT [FK_p_JobCardRusABDActivityGroup_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_JobCardRusABDActivityGroup] UNIQUE NONCLUSTERED ([JobCardRusABDActivityGroup_Code] ASC)
);

