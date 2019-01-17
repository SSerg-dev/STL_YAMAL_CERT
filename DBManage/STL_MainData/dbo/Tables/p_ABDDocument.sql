CREATE TABLE [dbo].[p_ABDDocument] (
    [ABDDocument_ID]      UNIQUEIDENTIFIER CONSTRAINT [DF_ABDDocument_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ABDDocument_Number]  NVARCHAR (100)   NOT NULL,
    [ABDDocument_Name]    NVARCHAR (255)   NULL,
    [Issue_Date]          DATETIME2 (7)    NOT NULL,
    [Sheet_Folder_Number] INT              NOT NULL,
    [Total_Sheets]        INT              NOT NULL,
    [Number_in_Folder]    INT              NOT NULL,
    [Row_status]          INT              NULL,
    [Insert_DTS]          DATETIME2 (7)    NULL,
    [Update_DTS]          DATETIME2 (7)    NULL,
    [ABDFinalFolder_Name] NVARCHAR (200)   NOT NULL,
    [Parent_ID]           UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_ABDDocument] PRIMARY KEY CLUSTERED ([ABDDocument_ID] ASC),
    CONSTRAINT [FK_p_ABDDocument_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDDocument] UNIQUE NONCLUSTERED ([ABDFinalFolder_Name] ASC, [Number_in_Folder] ASC)
);

