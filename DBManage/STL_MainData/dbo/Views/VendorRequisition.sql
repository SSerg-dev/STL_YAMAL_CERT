CREATE view VendorRequisition as select [VendorRequisition_Code], [VendorRequisition_ID] from p_VendorRequisition where row_status < 100
