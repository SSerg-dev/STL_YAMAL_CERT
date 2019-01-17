﻿CREATE TABLE [dbo].[s_MTXFullErrors] (
    [ParentTitleObject]   NVARCHAR (MAX) NULL,
    [TitleObject]         NVARCHAR (MAX) NULL,
    [Marka]               NVARCHAR (MAX) NULL,
    [ABDSet]              NVARCHAR (MAX) NULL,
    [GOST]                NVARCHAR (MAX) NULL,
    [GOST_ModifiedMarka]  NVARCHAR (MAX) NULL,
    [PID]                 NVARCHAR (MAX) NULL,
    [PID_Description_Eng] NVARCHAR (MAX) NULL,
    [PID_Description_Rus] NVARCHAR (MAX) NULL,
    [CONTRACTOR]          NVARCHAR (MAX) NULL,
    [Source_File]         NVARCHAR (MAX) NULL,
    [Load_Date]           DATETIME2 (7)  NULL,
    [Error_Code]          INT            NULL,
    [Error_Column]        INT            NULL,
    [Reason]              NVARCHAR (MAX) NULL
);

