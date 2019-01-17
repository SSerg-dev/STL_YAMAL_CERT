CREATE TABLE [dbo].[s_WPUndergroundRegistersErrors] (
    [Log_ID]       NVARCHAR (4000) NULL,
    [Reg]          NVARCHAR (4000) NULL,
    [Phase]        NVARCHAR (4000) NULL,
    [Title]        NVARCHAR (4000) NULL,
    [Sub_Title]    NVARCHAR (4000) NULL,
    [Unit]         NVARCHAR (4000) NULL,
    [Marka]        NVARCHAR (4000) NULL,
    [Work_Desc]    NVARCHAR (4000) NULL,
    [CNT_Date]     NVARCHAR (4000) NULL,
    [Repr_SCNT]    NVARCHAR (4000) NULL,
    [Repr_CNT]     NVARCHAR (4000) NULL,
    [Status_Date]  NVARCHAR (4000) NULL,
    [Status]       NVARCHAR (4000) NULL,
    [Source_File]  NVARCHAR (MAX)  NULL,
    [Load_Date]    DATETIME2 (7)   NULL,
    [Error_Code]   INT             NULL,
    [Error_Column] INT             NULL,
    [Reason]       NVARCHAR (MAX)  NULL
);

