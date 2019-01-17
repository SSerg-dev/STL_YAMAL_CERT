﻿CREATE TABLE [dbo].[s_PipelineCompletionErrors] (
    [Line]          NVARCHAR (MAX) NULL,
    [Isometric]     NVARCHAR (MAX) NULL,
    [PROCESS_PHASE] NVARCHAR (MAX) NULL,
    [Weld_SCTR]     NVARCHAR (MAX) NULL,
    [AKZ_SCTR]      NVARCHAR (MAX) NULL,
    [Ins_SCTR]      NVARCHAR (MAX) NULL,
    [Weld_FF]       NVARCHAR (MAX) NULL,
    [AKZ_FF]        NVARCHAR (MAX) NULL,
    [Ins_FF]        NVARCHAR (MAX) NULL,
    [Source_File]   NVARCHAR (MAX) NULL,
    [Load_Date]     DATETIME2 (7)  NULL,
    [Error_Code]    INT            NULL,
    [Error_Column]  INT            NULL,
    [Reason]        NVARCHAR (MAX) NULL
);

