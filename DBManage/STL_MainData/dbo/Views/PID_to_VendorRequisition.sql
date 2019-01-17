CREATE view PID_to_VendorRequisition as select [PID_ID], [PID_to_VendorRequisition_ID], [VendorRequisition_ID] from p_PID_to_VendorRequisition where row_status < 100
