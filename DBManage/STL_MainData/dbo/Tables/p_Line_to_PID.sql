CREATE TABLE [dbo].[p_Line_to_PID] (
    [Line_to_PID_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Line_to_PID_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]     DATETIME2 (7)    NULL,
    [Update_DTS]     DATETIME2 (7)    NULL,
    [Row_Status]     INT              NULL,
    [Line_ID]        UNIQUEIDENTIFIER NOT NULL,
    [PID_ID]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Line_to_PID] PRIMARY KEY CLUSTERED ([Line_to_PID_ID] ASC),
    CONSTRAINT [FK_p_Line_to_PID_Line_ID_p_Line] FOREIGN KEY ([Line_ID]) REFERENCES [dbo].[p_Line] ([Line_ID]),
    CONSTRAINT [FK_p_Line_to_PID_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_Line_to_PID_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Line_to_PID] UNIQUE NONCLUSTERED ([Line_ID] ASC, [PID_ID] ASC)
);

