CREATE TABLE [dbo].[OLE DB Destination_igost] (
    [Source GOST_ID]              UNIQUEIDENTIFIER NULL,
    [Source TitleObject_ID]       UNIQUEIDENTIFIER NULL,
    [Dest GOST_ID]                UNIQUEIDENTIFIER NULL,
    [Dest TitleObject_ID]         UNIQUEIDENTIFIER NULL,
    [Dest Row_Status]             INT              NULL,
    [Dest GOST_to_TitleObject_ID] UNIQUEIDENTIFIER NULL,
    [Row_Status]                  INT              NULL,
    [Insert_DTS]                  DATETIME         NULL,
    [Update_DTS]                  DATETIME         NULL,
    [ErrorCode]                   INT              NULL,
    [ErrorColumn]                 INT              NULL
);

