CREATE view PID_to_DocumentTypeCode as select [DocumentTypeCode_ID], [PID_ID], [PID_to_DocumentTypeCode_ID] from p_PID_to_DocumentTypeCode where row_status < 100
