CREATE TABLE [dbo].[p_VendorRequisition_to_VendorPurchaseOrder] (
    [VendorRequisition_to_VendorPurchaseOrder_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_VendorRequisition_to_VendorPurchaseOrder_ID] DEFAULT (newsequentialid()) NOT NULL,
    [VendorRequisition_ID]                        UNIQUEIDENTIFIER NOT NULL,
    [VendorPurchaseOrder_ID]                      UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                                  INT              NULL,
    [Insert_DTS]                                  DATETIME2 (7)    NULL,
    [Update_DTS]                                  DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_VendorRequisition_to_VendorPurchaseOrder] PRIMARY KEY CLUSTERED ([VendorRequisition_to_VendorPurchaseOrder_ID] ASC),
    CONSTRAINT [FK_p_VendorRequisition_to_VendorPurchaseOrder_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_VendorRequisition_to_VendorPurchaseOrder_VendorPurchaseOrder_ID_p_VendorPurchaseOrder] FOREIGN KEY ([VendorPurchaseOrder_ID]) REFERENCES [dbo].[p_VendorPurchaseOrder] ([VendorPurchaseOrder_ID]),
    CONSTRAINT [FK_p_VendorRequisition_to_VendorPurchaseOrder_VendorRequisition_ID_p_VendorRequisition] FOREIGN KEY ([VendorRequisition_ID]) REFERENCES [dbo].[p_VendorRequisition] ([VendorRequisition_ID]),
    CONSTRAINT [UQ_p_VendorRequisition_to_VendorPurchaseOrder] UNIQUE NONCLUSTERED ([VendorRequisition_ID] ASC, [VendorPurchaseOrder_ID] ASC)
);

