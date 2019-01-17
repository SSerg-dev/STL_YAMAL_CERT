CREATE TABLE [syslog].[p_UserTask] (
    [UserTask_ID]     UNIQUEIDENTIFIER CONSTRAINT [syslog_DF_UserTask] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]      DATETIME2 (7)    NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    [Row_Status]      INT              NULL,
    [TaskNumber]      INT              NOT NULL,
    [TaskName]        NVARCHAR (120)   NOT NULL,
    [Description_Eng] NVARCHAR (250)   NULL,
    [Description_Rus] NVARCHAR (250)   NULL
);

