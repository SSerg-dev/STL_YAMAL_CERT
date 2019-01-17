CREATE TABLE [dbo].[p_UserMessage] (
    [UserMessage_ID]      UNIQUEIDENTIFIER NOT NULL,
    [DTS]                 DATETIME         NULL,
    [Row_Status]          INT              NULL,
    [User_Sender_Name]    NVARCHAR (255)   NULL,
    [User_Recipient_Name] NVARCHAR (255)   NULL,
    [Group]               BIGINT           NULL,
    [Type]                BIGINT           NULL,
    [Text]                NVARCHAR (MAX)   NULL,
    [Memo]                VARCHAR (50)     NULL,
    CONSTRAINT [PK_p_UserMessage] PRIMARY KEY CLUSTERED ([UserMessage_ID] ASC),
    CONSTRAINT [FK_p_UserMessage_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status])
);

