CREATE view PID_to_DocumentOriginCode as select [DocumentOriginCode_ID], [PID_ID], [PID_to_DocumentOriginCode_ID] from p_PID_to_DocumentOriginCode where row_status < 100
