CREATE TABLE [dbo].[s_RegistersArchive] (
    [File_LOG]                NVARCHAR (255) NULL,
    [TitleObject_Name]        NVARCHAR (255) NULL,
    [Marka_Name]              NVARCHAR (255) NULL,
    [Log_Id]                  NVARCHAR (255) NULL,
    [Reg]                     NVARCHAR (255) NULL,
    [Status]                  NVARCHAR (255) NULL,
    [Work_Desc]               NVARCHAR (255) NULL,
    [Unit]                    NVARCHAR (255) NULL,
    [ISO]                     NVARCHAR (255) NULL,
    [Sub]                     NVARCHAR (255) NULL,
    [InArchiveDate]           NVARCHAR (255) NULL,
    [Lane_Number]             NVARCHAR (255) NULL,
    [Rack_Number]             NVARCHAR (255) NULL,
    [Box_Number]              NVARCHAR (255) NULL,
    [Contragent]              NVARCHAR (255) NULL,
    [Source_File]             NVARCHAR (255) NULL,
    [Load_Date]               DATETIME2 (7)  NULL,
    [Done]                    NVARCHAR (255) NULL,
    [TakenBySubContractor]    NVARCHAR (255) NULL,
    [Comment]                 NVARCHAR (255) NULL,
    [Compilation_responsible] NVARCHAR (255) NULL
);

