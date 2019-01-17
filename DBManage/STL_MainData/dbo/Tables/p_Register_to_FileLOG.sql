CREATE TABLE [dbo].[p_Register_to_FileLOG] (
    [Register_To_FileLOG_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_FileLOG_ID] DEFAULT (newsequentialid()) NOT NULL,
    [DTS_Start]              DATETIME2 (7)    NULL,
    [DTS_End]                DATETIME2 (7)    NULL,
    [Row_status]             INT              NULL,
    [Register_ID]            UNIQUEIDENTIFIER NOT NULL,
    [FileLOG_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_Register_to_FileLOG] PRIMARY KEY CLUSTERED ([Register_To_FileLOG_ID] ASC),
    CONSTRAINT [FK_p_Register_to_FileLOG_FileLOG_ID_p_FileLOG] FOREIGN KEY ([FileLOG_ID]) REFERENCES [dbo].[p_FileLOG] ([FileLOG_ID]),
    CONSTRAINT [FK_p_Register_to_FileLOG_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_FileLOG_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Register_to_FileLOG] UNIQUE NONCLUSTERED ([FileLOG_ID] ASC, [Register_ID] ASC)
);

