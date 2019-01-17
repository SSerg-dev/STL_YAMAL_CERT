CREATE TABLE [dbo].[OLE DB Destination_imarka] (
    [Source GOST_ID]        UNIQUEIDENTIFIER NULL,
    [Source Marka_ID]       UNIQUEIDENTIFIER NULL,
    [Dest GOST_ID]          UNIQUEIDENTIFIER NULL,
    [Dest Marka_ID]         UNIQUEIDENTIFIER NULL,
    [Dest Row_Status]       INT              NULL,
    [Dest GOST_to_Marka_ID] UNIQUEIDENTIFIER NULL,
    [Row_Status]            INT              NULL,
    [Insert_DTS]            DATETIME         NULL,
    [Update_DTS]            DATETIME         NULL,
    [ErrorCode]             INT              NULL,
    [ErrorColumn]           INT              NULL
);

