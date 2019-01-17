CREATE TABLE [dbo].[p_SubSubContractor_to_PermissionDocumentTypes2] (
    [SubSubContractor_to_PermissionDocumentTypes_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_SubSubContractor_to_PermissionDocumentTypes2_ID] DEFAULT (newsequentialid()) NOT NULL,
    [SubSubContractor_ID]                            UNIQUEIDENTIFIER NOT NULL,
    [PermissionDocumentTypes_ID]                     UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                                     INT              NULL,
    [Insert_DTS]                                     DATETIME2 (7)    NULL,
    [Update_DTS]                                     DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_SubSubContractor_to_PermissionDocumentTypes2] PRIMARY KEY CLUSTERED ([SubSubContractor_to_PermissionDocumentTypes_ID] ASC),
    CONSTRAINT [FK_p_SubSubContractor_to_PermissionDocumentTypes2_PermissionDocumentTypes_ID_p_PermissionDocumentType] FOREIGN KEY ([PermissionDocumentTypes_ID]) REFERENCES [dbo].[p_PermissionDocumentType] ([PermissionDocumentTypes_ID]),
    CONSTRAINT [FK_p_SubSubContractor_to_PermissionDocumentTypes2_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_SubSubContractor_to_PermissionDocumentTypes2] UNIQUE NONCLUSTERED ([SubSubContractor_ID] ASC, [PermissionDocumentTypes_ID] ASC)
);

