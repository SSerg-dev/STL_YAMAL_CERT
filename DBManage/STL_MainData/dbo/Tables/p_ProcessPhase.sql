CREATE TABLE [dbo].[p_ProcessPhase] (
    [ProcessPhase_ID]   UNIQUEIDENTIFIER NOT NULL,
    [ProcessPhase_Name] NVARCHAR (100)   NOT NULL,
    [Row_Status]        INT              NULL,
    [Insert_DTS]        DATETIME2 (7)    NULL,
    [Update_DTS]        DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ProcessPhase] PRIMARY KEY CLUSTERED ([ProcessPhase_ID] ASC),
    CONSTRAINT [FK_p_ProcessPhase_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ProcessPhase] UNIQUE NONCLUSTERED ([ProcessPhase_Name] ASC)
);

