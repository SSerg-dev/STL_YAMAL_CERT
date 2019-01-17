CREATE TABLE [dbo].[OLE DB Destination_ipid] (
    [Source GOST_ID]      UNIQUEIDENTIFIER NULL,
    [Source PID_ID]       UNIQUEIDENTIFIER NULL,
    [Dest GOST_ID]        UNIQUEIDENTIFIER NULL,
    [Dest PID_ID]         UNIQUEIDENTIFIER NULL,
    [Dest Row_Status]     INT              NULL,
    [Dest GOST_to_PID_ID] UNIQUEIDENTIFIER NULL,
    [Row_Status]          INT              NULL,
    [Insert_DTS]          DATETIME         NULL,
    [Update_DTS]          DATETIME         NULL,
    [ErrorCode]           INT              NULL,
    [ErrorColumn]         INT              NULL
);

