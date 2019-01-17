CREATE TABLE [dbo].[p_VendorPurchaseOrder] (
    [VendorPurchaseOrder_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_VendorPurchaseOrder_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]               DATETIME2 (7)    NULL,
    [Update_DTS]               DATETIME2 (7)    NULL,
    [Row_Status]               INT              NULL,
    [VendorPurchaseOrder_Code] NVARCHAR (300)   NOT NULL,
    CONSTRAINT [PK_p_VendorPurchaseOrder] PRIMARY KEY CLUSTERED ([VendorPurchaseOrder_ID] ASC),
    CONSTRAINT [FK_p_VendorPurchaseOrder_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_VendorPurchaseOrder] UNIQUE NONCLUSTERED ([VendorPurchaseOrder_Code] ASC)
);

