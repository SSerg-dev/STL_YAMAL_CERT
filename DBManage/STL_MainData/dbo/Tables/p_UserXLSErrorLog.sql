CREATE TABLE [dbo].[p_UserXLSErrorLog] (
    [UserXLSErrorLog_ID]    UNIQUEIDENTIFIER CONSTRAINT [DF_UserXLSErrorLog_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]            DATETIME2 (7)    NULL,
    [Update_DTS]            DATETIME2 (7)    NULL,
    [Row_Status]            INT              NULL,
    [User_ID]               UNIQUEIDENTIFIER NOT NULL,
    [UserTaskLog_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Sheet_Name]            NVARCHAR (120)   NULL,
    [Column_Number]         INT              NULL,
    [Row_Number]            INT              NULL,
    [Cell_Value]            NVARCHAR (250)   NULL,
    [ErrorDescriptiuon_Eng] NVARCHAR (250)   NULL,
    [ErrorDescriptiuon_Rus] NVARCHAR (250)   NULL
);

