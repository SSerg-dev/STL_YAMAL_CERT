CREATE TABLE [dbo].[s_OverallElectricalCIProgress_REGISTR_CONSTRErrors] (
    [TAG]              NVARCHAR (MAX) NULL,
    [QTY]              NVARCHAR (MAX) NULL,
    [CONSTRUCTION_REG] NVARCHAR (MAX) NULL,
    [Log_ID]           NVARCHAR (MAX) NULL,
    [Source_File]      NVARCHAR (MAX) NULL,
    [Load_Date]        DATETIME2 (7)  NULL,
    [Error_Code]       INT            NULL,
    [Error_Column]     INT            NULL,
    [Reason]           NVARCHAR (MAX) NULL
);

