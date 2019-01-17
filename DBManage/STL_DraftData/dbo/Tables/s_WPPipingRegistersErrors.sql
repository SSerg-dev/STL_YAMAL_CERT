CREATE TABLE [dbo].[s_WPPipingRegistersErrors] (
    [Log_ID]       NVARCHAR (MAX) NULL,
    [Reg]          NVARCHAR (MAX) NULL,
    [Title]        NVARCHAR (MAX) NULL,
    [Unit]         NVARCHAR (MAX) NULL,
    [Marka]        NVARCHAR (MAX) NULL,
    [Work_Desc]    NVARCHAR (MAX) NULL,
    [CNT_Date]     NVARCHAR (MAX) NULL,
    [Repr_SCNT]    NVARCHAR (MAX) NULL,
    [Repr_CNT]     NVARCHAR (MAX) NULL,
    [Status_Date]  NVARCHAR (MAX) NULL,
    [Status]       NVARCHAR (MAX) NULL,
    [Source_File]  NVARCHAR (MAX) NULL,
    [Load_Date]    DATETIME2 (7)  NULL,
    [Error_Code]   INT            NULL,
    [Error_Column] INT            NULL,
    [Reason]       NVARCHAR (MAX) NULL
);

