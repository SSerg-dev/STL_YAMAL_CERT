CREATE TABLE [dbo].[p_ISO_to_ProcessPhase] (
    [ISO_to_ProcessPhase_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ISO_to_ProcessPhase_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    [Row_Status]             INT              NULL,
    [ISO_ID]                 UNIQUEIDENTIFIER NOT NULL,
    [ProcessPhase_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_ISO_to_ProcessPhase] PRIMARY KEY CLUSTERED ([ISO_to_ProcessPhase_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_ProcessPhase_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_ProcessPhase_ProcessPhase_ID_p_ProcessPhase] FOREIGN KEY ([ProcessPhase_ID]) REFERENCES [dbo].[p_ProcessPhase] ([ProcessPhase_ID]),
    CONSTRAINT [FK_p_ISO_to_ProcessPhase_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ISO_to_ProcessPhase] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [ProcessPhase_ID] ASC)
);

