CREATE TABLE [dbo].[s_COWPreparedConnections] (
    [JobCard]        NVARCHAR (100)   NULL,
    [Reg]            NVARCHAR (100)   NULL,
    [Source_File]    NVARCHAR (50)    NULL,
    [Marka_ID]       UNIQUEIDENTIFIER NULL,
    [TitleObject_ID] UNIQUEIDENTIFIER NULL,
    [Module_ID]      UNIQUEIDENTIFIER NULL,
    [WorkClass_ID]   UNIQUEIDENTIFIER NULL,
    [Activity_Desc]  NVARCHAR (1000)  NULL,
    [Cow]            NVARCHAR (100)   NULL,
    [JCWT]           INT              NULL
);

