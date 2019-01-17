CREATE TABLE [dbo].[s_MTXFull] (
    [ParentTitleObject]   NVARCHAR (100)   NULL,
    [TitleObject]         NVARCHAR (100)   NULL,
    [Marka]               NVARCHAR (100)   NULL,
    [ABDSet]              NVARCHAR (100)   NULL,
    [GOST]                NVARCHAR (300)   NULL,
    [GOST_ModifiedMarka]  NVARCHAR (300)   NULL,
    [PID]                 NVARCHAR (300)   NULL,
    [PID_Description_Eng] NVARCHAR (255)   NULL,
    [PID_Description_Rus] NVARCHAR (255)   NULL,
    [CONTRACTOR]          NVARCHAR (50)    NULL,
    [TitleObject_ID]      UNIQUEIDENTIFIER NULL,
    [Marka_ID]            UNIQUEIDENTIFIER NULL,
    [GOST_ID]             UNIQUEIDENTIFIER NULL,
    [PID_ID]              UNIQUEIDENTIFIER NULL
);

