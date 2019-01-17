﻿CREATE TABLE [dbo].[s_LineListErrors] (
    [Isometric_No]                  NVARCHAR (MAX) NULL,
    [DesignArea]                    NVARCHAR (MAX) NULL,
    [Line_nb]                       NVARCHAR (MAX) NULL,
    [Number_Line_List]              NVARCHAR (MAX) NULL,
    [Russian_Document_Reference_LL] NVARCHAR (MAX) NULL,
    [Title_According_LL]            NVARCHAR (MAX) NULL,
    [Marka_According_LL]            NVARCHAR (MAX) NULL,
    [PID]                           NVARCHAR (MAX) NULL,
    [Source_File]                   NVARCHAR (MAX) NULL,
    [Load_Date]                     DATETIME2 (7)  NULL,
    [Error_Code]                    INT            NULL,
    [Error_Column]                  INT            NULL,
    [Reason]                        NVARCHAR (MAX) NULL,
    [Process_Phase]                 NVARCHAR (MAX) NULL,
    [Insulation Y/N]                NVARCHAR (MAX) NULL
);

