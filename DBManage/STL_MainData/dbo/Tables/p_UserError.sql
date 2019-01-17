CREATE TABLE [dbo].[p_UserError] (
    [UserError_ID]         UNIQUEIDENTIFIER CONSTRAINT [DF_UserError_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]           DATETIME2 (7)    NULL,
    [Update_DTS]           DATETIME2 (7)    NULL,
    [Row_Status]           INT              NULL,
    [Error_Number]         INT              NOT NULL,
    [Error_Message]        NVARCHAR (250)   NULL,
    [ErrorDescription_ENG] NVARCHAR (250)   NULL,
    [ErrorDescription_RUS] NVARCHAR (250)   NULL
);

