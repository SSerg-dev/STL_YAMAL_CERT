CREATE TABLE [dbo].[p_ABDDocument_to_PID] (
    [ABDDocument_to_PID_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_to_PID_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_ID]        UNIQUEIDENTIFIER NOT NULL,
    [PID_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]            INT              NULL,
    [Insert_DTS]            DATETIME2 (7)    NULL,
    [Update_DTS]            DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ABDDocument_to_PID] PRIMARY KEY CLUSTERED ([ABDDocument_to_PID_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_to_PID_ABDDocument_ID_p_ABDDocument] FOREIGN KEY ([ABDDocument_ID]) REFERENCES [dbo].[p_ABDDocument] ([ABDDocument_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_PID_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_ABDDocument_to_PID_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument_to_PID] UNIQUE NONCLUSTERED ([ABDDocument_ID] ASC, [PID_ID] ASC)
);

