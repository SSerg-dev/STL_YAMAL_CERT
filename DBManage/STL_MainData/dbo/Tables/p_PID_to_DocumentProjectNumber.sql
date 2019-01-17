CREATE TABLE [dbo].[p_PID_to_DocumentProjectNumber] (
    [PID_to_DocumentProjectNumber_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_PID_to_DocumentProjectNumber_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                      DATETIME2 (7)    NULL,
    [Update_DTS]                      DATETIME2 (7)    NULL,
    [Row_Status]                      INT              NULL,
    [PID_ID]                          UNIQUEIDENTIFIER NOT NULL,
    [DocumentProjectNumber_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_PID_to_DocumentProjectNumber] PRIMARY KEY CLUSTERED ([PID_to_DocumentProjectNumber_ID] ASC),
    CONSTRAINT [FK_p_PID_to_DocumentProjectNumber_DocumentProjectNumber_ID_p_DocumentProjectNumber] FOREIGN KEY ([DocumentProjectNumber_ID]) REFERENCES [dbo].[p_DocumentProjectNumber] ([DocumentProjectNumber_ID]),
    CONSTRAINT [FK_p_PID_to_DocumentProjectNumber_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_PID_to_DocumentProjectNumber_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_PID_to_DocumentProjectNumber] UNIQUE NONCLUSTERED ([PID_ID] ASC, [DocumentProjectNumber_ID] ASC)
);

