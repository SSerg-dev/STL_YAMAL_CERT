CREATE TABLE [dbo].[p_PermissionDocumentType] (
    [PermissionDocumentTypes_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_PermissionDocumentType_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                   DATETIME2 (7)    NULL,
    [Update_DTS]                   DATETIME2 (7)    NULL,
    [Row_Status]                   INT              NULL,
    [Description_Eng]              NVARCHAR (255)   NULL,
    [Description_Rus]              NVARCHAR (255)   NULL,
    [PermissionDocumentTypes_Code] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_p_PermissionDocumentType] PRIMARY KEY CLUSTERED ([PermissionDocumentTypes_ID] ASC),
    CONSTRAINT [FK_p_PermissionDocumentType_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_PermissionDocumentType] UNIQUE NONCLUSTERED ([PermissionDocumentTypes_Code] ASC)
);

