CREATE TABLE [syslog].[p_UserTaskLog] (
    [UserTaskLog_ID]     UNIQUEIDENTIFIER CONSTRAINT [syslog_DF_UserTaskLog] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    [Row_Status]         INT              NULL,
    [Run_Number]         BIGINT           CONSTRAINT [DF_syslog_UserTaskLog_Run_Number] DEFAULT (NEXT VALUE FOR [syslog].[Sequence_Run_Number]) NOT NULL,
    [User_ID]            UNIQUEIDENTIFIER NOT NULL,
    [UserTask_ID]        UNIQUEIDENTIFIER NOT NULL,
    [UserTaskMessage_ID] UNIQUEIDENTIFIER NULL,
    [FilePath]           NVARCHAR (250)   NULL,
    [FileName]           NVARCHAR (250)   NULL,
    [Description_Eng]    NVARCHAR (250)   NULL,
    [Description_Rus]    NVARCHAR (250)   NULL
);

