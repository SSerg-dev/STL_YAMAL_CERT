CREATE TABLE [dbo].[s_OverallElectricalCIProgress_TAGBASEErrors] (
    [TAG]          NVARCHAR (MAX) NULL,
    [DRW]          NVARCHAR (MAX) NULL,
    [EP_TOTAL_QTY] NVARCHAR (MAX) NULL,
    [WORKCODE]     NVARCHAR (MAX) NULL,
    [TITLE]        NVARCHAR (MAX) NULL,
    [MARKA]        NVARCHAR (MAX) NULL,
    [SCTR]         NVARCHAR (MAX) NULL,
    [PHASE]        NVARCHAR (MAX) NULL,
    [Source_File]  NVARCHAR (MAX) NULL,
    [Load_Date]    DATETIME2 (7)  NULL,
    [Error_Code]   INT            NULL,
    [Error_Column] INT            NULL,
    [Reason]       NVARCHAR (MAX) NULL
);

