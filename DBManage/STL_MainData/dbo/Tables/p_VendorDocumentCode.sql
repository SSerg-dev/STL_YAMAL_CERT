CREATE TABLE [dbo].[p_VendorDocumentCode] (
    [VendorDocumentCode_ID]       UNIQUEIDENTIFIER NOT NULL,
    [VendorDocumentCode_PARENTID] UNIQUEIDENTIFIER NULL,
    [Structure]                   NVARCHAR (50)    NULL,
    [VendorDocumentCode_Name]     NVARCHAR (100)   NOT NULL,
    [Description_Eng]             NVARCHAR (255)   NULL,
    [Description_Rus]             NVARCHAR (255)   NULL,
    [Row_Status]                  INT              NULL,
    [Insert_DTS]                  DATETIME2 (7)    NULL,
    [Update_DTS]                  DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_VendorDocumentCode] PRIMARY KEY CLUSTERED ([VendorDocumentCode_ID] ASC),
    CONSTRAINT [FK_p_VendorDocumentCode_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_VendorDocumentCode] UNIQUE NONCLUSTERED ([VendorDocumentCode_Name] ASC)
);

