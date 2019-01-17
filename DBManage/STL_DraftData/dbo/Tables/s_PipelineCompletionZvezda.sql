CREATE TABLE [dbo].[s_PipelineCompletionZvezda] (
    [TestPack]         NVARCHAR (255)   NULL,
    [PROCESS_PHASE]    NVARCHAR (255)   NULL,
    [Weld_SCTR]        NVARCHAR (255)   NULL,
    [AKZ_SCTR]         NVARCHAR (255)   NULL,
    [Ins_SCTR]         NVARCHAR (255)   NULL,
    [Weld_FF]          NVARCHAR (255)   NULL,
    [AKZ_FF]           NVARCHAR (255)   NULL,
    [Ins_FF]           NVARCHAR (255)   NULL,
    [Source_File]      NVARCHAR (255)   NULL,
    [Load_Date]        DATETIME2 (7)    NULL,
    [TestPack_ID]      UNIQUEIDENTIFIER NULL,
    [PROCESS_PHASE_ID] UNIQUEIDENTIFIER NULL,
    [Weld_SCTR_ID]     UNIQUEIDENTIFIER NULL,
    [AKZ_SCTR_ID]      UNIQUEIDENTIFIER NULL,
    [Ins_SCTR_ID]      UNIQUEIDENTIFIER NULL,
    [Weld_FF_ID]       UNIQUEIDENTIFIER NULL,
    [AKZ_FF_ID]        UNIQUEIDENTIFIER NULL,
    [Ins_FF_ID]        UNIQUEIDENTIFIER NULL
);

