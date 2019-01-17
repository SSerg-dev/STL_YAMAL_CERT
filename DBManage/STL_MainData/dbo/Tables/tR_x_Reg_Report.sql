CREATE TABLE [dbo].[tR_x_Reg_Report] (
    [F1]                 NVARCHAR (255)   NULL,
    [Status_Name]        NVARCHAR (255)   NULL,
    [LogId]              NVARCHAR (255)   NULL,
    [WorkPackage_Name]   NVARCHAR (50)    NULL,
    [SubContractor_Name] NVARCHAR (50)    NULL,
    [reportcolor]        NVARCHAR (50)    NULL,
    [reportorder]        INT              NULL,
    [Reg]                NVARCHAR (100)   NOT NULL,
    [Phase_Name]         SMALLINT         NULL,
    [TitleObject_Name]   NVARCHAR (100)   NULL,
    [Marka_Name]         NVARCHAR (50)    NULL,
    [CNT_Date]           DATETIME2 (7)    NULL,
    [Repr_SCNT]          NVARCHAR (255)   NULL,
    [Repr_CNT]           NVARCHAR (255)   NULL,
    [Status_Date]        DATETIME2 (7)    NULL,
    [LogAndReg]          NVARCHAR (255)   NULL,
    [Status_NameS]       NVARCHAR (255)   NULL,
    [Unit]               NVARCHAR (255)   NULL,
    [Work_Desc]          NVARCHAR (255)   NULL,
    [Register_ID]        UNIQUEIDENTIFIER NOT NULL
);

