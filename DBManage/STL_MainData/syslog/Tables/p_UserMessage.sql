CREATE TABLE [syslog].[p_UserMessage] (
    [UserMessage_ID]      UNIQUEIDENTIFIER NOT NULL,
    [DTS]                 DATETIME         NULL,
    [Row_Status]          INT              NULL,
    [User_Sender_Name]    NVARCHAR (MAX)   NULL,
    [User_Recipient_Name] NVARCHAR (MAX)   NULL,
    [Group]               BIGINT           NULL,
    [Type]                BIGINT           NULL,
    [Text]                NVARCHAR (MAX)   NULL,
    [Memo]                VARCHAR (50)     NULL,
    CONSTRAINT [FK_syslog_p_UserMessage_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status])
);

