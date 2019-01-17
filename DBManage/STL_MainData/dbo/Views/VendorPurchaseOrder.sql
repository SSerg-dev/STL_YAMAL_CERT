CREATE view VendorPurchaseOrder as select [VendorPurchaseOrder_Code], [VendorPurchaseOrder_ID] from p_VendorPurchaseOrder where row_status < 100
