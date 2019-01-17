CREATE TABLE [dbo].[p_RowStatus_sys] (
    [Row_Status_Sys_ID] UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]        INT              NOT NULL,
    [Status_Name_Eng]   NVARCHAR (100)   NOT NULL,
    [Status_Name_Rus]   NVARCHAR (100)   NOT NULL,
    [Description_Eng]   NVARCHAR (255)   NULL,
    [Description_Rus]   NVARCHAR (255)   NULL,
    [Row_status_sys]    INT              NULL,
    [Insert_DTS]        DATETIME2 (7)    NULL,
    [Update_DTS]        DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_RowStatus_sys] PRIMARY KEY NONCLUSTERED ([Row_Status_Sys_ID] ASC),
    CONSTRAINT [UQ_p_RowStatus_sys] UNIQUE CLUSTERED ([Row_Status] ASC)
);

