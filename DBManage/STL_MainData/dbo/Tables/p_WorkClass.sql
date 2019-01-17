CREATE TABLE [dbo].[p_WorkClass] (
    [WorkClass_ID]       UNIQUEIDENTIFIER NOT NULL,
    [WorkClass_PARENTID] UNIQUEIDENTIFIER NULL,
    [WorkClass_Name]     NVARCHAR (100)   NOT NULL,
    [Description_Eng]    NVARCHAR (255)   NULL,
    [Description_Rus]    NVARCHAR (255)   NULL,
    [Unit]               NVARCHAR (100)   NULL,
    [Row_Status]         INT              NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    [Structure]          INT              NULL,
    CONSTRAINT [PK_p_WorkClass] PRIMARY KEY CLUSTERED ([WorkClass_ID] ASC),
    CONSTRAINT [FK_p_WorkClass_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_WorkClass] UNIQUE NONCLUSTERED ([WorkClass_Name] ASC)
);

