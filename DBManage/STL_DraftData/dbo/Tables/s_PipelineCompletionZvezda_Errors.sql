CREATE TABLE [dbo].[s_PipelineCompletionZvezda_Errors] (
    [TestPack]      NVARCHAR (255) NULL,
    [PROCESS_PHASE] NVARCHAR (255) NULL,
    [Weld_SCTR]     NVARCHAR (255) NULL,
    [AKZ_SCTR]      NVARCHAR (255) NULL,
    [Ins_SCTR]      NVARCHAR (255) NULL,
    [Weld_FF]       NVARCHAR (255) NULL,
    [AKZ_FF]        NVARCHAR (255) NULL,
    [Ins_FF]        NVARCHAR (255) NULL,
    [Source_File]   NVARCHAR (255) NULL,
    [Load_Date]     DATETIME2 (7)  NULL,
    [Error_Code]    INT            NULL,
    [Error_Column]  INT            NULL,
    [Reason]        NVARCHAR (255) NULL
);

