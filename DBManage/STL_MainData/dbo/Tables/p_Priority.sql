CREATE TABLE [dbo].[p_Priority] (
    [Priority_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]    DATETIME2 (7)    NULL,
    [Update_DTS]    DATETIME2 (7)    NULL,
    [Row_Status]    INT              NULL,
    [Priority_Name] SMALLINT         NOT NULL,
    CONSTRAINT [PK_p_Priority] PRIMARY KEY CLUSTERED ([Priority_ID] ASC),
    CONSTRAINT [FK_p_Priority_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Priority] UNIQUE NONCLUSTERED ([Priority_Name] ASC)
);

