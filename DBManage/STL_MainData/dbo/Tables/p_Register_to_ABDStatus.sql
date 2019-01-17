CREATE TABLE [dbo].[p_Register_to_ABDStatus] (
    [Register_to_ABDStatus_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_Status_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Parent_ID]                UNIQUEIDENTIFIER NULL,
    [DTS_Start]                DATETIME2 (7)    NULL,
    [DTS_End]                  DATETIME2 (7)    NULL,
    [Row_status]               INT              NULL,
    [Register_ID]              UNIQUEIDENTIFIER NOT NULL,
    [ABDStatus_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Created_By]               NVARCHAR (255)   NOT NULL,
    [Modified_By]              NVARCHAR (255)   NOT NULL,
    [Insert_DTS]               DATETIME2 (7)    NULL,
    [Update_DTS]               DATETIME2 (7)    NULL,
    [ABDStatusDate]            DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_Register_to_ABDStatus] PRIMARY KEY CLUSTERED ([Register_to_ABDStatus_ID] ASC),
    CONSTRAINT [FK_p_Register_to_ABDStatus_ABDStatus_ID_p_ABDStatus] FOREIGN KEY ([ABDStatus_ID]) REFERENCES [dbo].[p_ABDStatus] ([ABDStatus_ID]),
    CONSTRAINT [FK_p_Register_to_ABDStatus_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_ABDStatus_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Register_to_ABDStatus] UNIQUE NONCLUSTERED ([ABDStatus_ID] ASC, [Register_ID] ASC)
);

