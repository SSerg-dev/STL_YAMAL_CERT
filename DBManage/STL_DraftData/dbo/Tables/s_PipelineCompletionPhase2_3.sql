CREATE TABLE [dbo].[s_PipelineCompletionPhase2_3] (
    [Line]             NVARCHAR (MAX)   NULL,
    [Isometric]        NVARCHAR (MAX)   NULL,
    [PROCESS_PHASE]    NVARCHAR (MAX)   NULL,
    [Weld_SCTR]        NVARCHAR (MAX)   NULL,
    [AKZ_SCTR]         NVARCHAR (MAX)   NULL,
    [Ins_SCTR]         NVARCHAR (MAX)   NULL,
    [Weld_FF]          NVARCHAR (MAX)   NULL,
    [AKZ_FF]           NVARCHAR (MAX)   NULL,
    [Ins_FF]           NVARCHAR (MAX)   NULL,
    [Source_File]      NVARCHAR (MAX)   NULL,
    [Load_Date]        DATETIME2 (7)    NULL,
    [Isometric_ID]     UNIQUEIDENTIFIER NULL,
    [Line_ID]          UNIQUEIDENTIFIER NULL,
    [PROCESS_PHASE_ID] UNIQUEIDENTIFIER NULL,
    [Weld_SCTR_ID]     UNIQUEIDENTIFIER NULL,
    [AKZ_SCTR_ID]      UNIQUEIDENTIFIER NULL,
    [Ins_SCTR_ID]      UNIQUEIDENTIFIER NULL,
    [Weld_FF_ID]       UNIQUEIDENTIFIER NULL,
    [AKZ_FF_ID]        UNIQUEIDENTIFIER NULL,
    [Ins_FF_ID]        UNIQUEIDENTIFIER NULL
);

