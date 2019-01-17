CREATE TABLE [dbo].[p_VendorRequisition] (
    [VendorRequisition_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_VendorRequisition_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    [Row_Status]             INT              NULL,
    [VendorRequisition_Code] NVARCHAR (300)   NOT NULL,
    CONSTRAINT [PK_p_VendorRequisition] PRIMARY KEY CLUSTERED ([VendorRequisition_ID] ASC),
    CONSTRAINT [FK_p_VendorRequisition_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_VendorRequisition] UNIQUE NONCLUSTERED ([VendorRequisition_Code] ASC)
);

