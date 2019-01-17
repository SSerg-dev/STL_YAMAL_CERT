﻿CREATE TABLE [dbo].[s_WPUndergroundQuantity] (
    [Log_ID]                NVARCHAR (255)  NULL,
    [Num]                   NVARCHAR (255)  NULL,
    [Phase]                 NVARCHAR (255)  NULL,
    [Title]                 NVARCHAR (255)  NULL,
    [Sub_Title]             NVARCHAR (255)  NULL,
    [Unit]                  NVARCHAR (255)  NULL,
    [Marka]                 NVARCHAR (255)  NULL,
    [Activity_Desc]         NVARCHAR (255)  NULL,
    [UOM]                   NVARCHAR (255)  NULL,
    [Design_Target]         NVARCHAR (255)  NULL,
    [Fact_Volume]           NVARCHAR (255)  NULL,
    [Fact_Percent]          NVARCHAR (255)  NULL,
    [Test_Done]             NVARCHAR (255)  NULL,
    [Acts_Prepared_CNT]     NVARCHAR (255)  NULL,
    [Acts_Prepared_Percent] NVARCHAR (255)  NULL,
    [Reg]                   NVARCHAR (4000) NULL,
    [Under_Review_CNT]      NVARCHAR (255)  NULL,
    [Under_Review_Percent]  NVARCHAR (255)  NULL,
    [Commented_CNT]         NVARCHAR (255)  NULL,
    [Commented_Percent]     NVARCHAR (255)  NULL,
    [Approved_CNT]          NVARCHAR (255)  NULL,
    [Approved_Percent]      NVARCHAR (255)  NULL,
    [Multiple]              NVARCHAR (255)  NULL,
    [Issues]                NVARCHAR (255)  NULL,
    [Source_File]           NVARCHAR (255)  NULL,
    [Load_Date]             DATETIME2 (7)   NULL
);
