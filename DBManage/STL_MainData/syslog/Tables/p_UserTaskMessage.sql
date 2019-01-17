CREATE TABLE [syslog].[p_UserTaskMessage] (
    [UserTaskMessage_ID]     UNIQUEIDENTIFIER CONSTRAINT [syslog_DF_UserTaskMessage] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    [Row_Status]             INT              NULL,
    [Message_Type]           INT              NOT NULL,
    [Message_Number]         INT              NOT NULL,
    [Message_Text]           NVARCHAR (250)   NULL,
    [MessageDescription_ENG] NVARCHAR (250)   NULL,
    [MessageDescription_RUS] NVARCHAR (250)   NULL
);

