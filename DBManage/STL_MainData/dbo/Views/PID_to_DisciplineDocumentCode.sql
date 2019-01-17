CREATE view PID_to_DisciplineDocumentCode as select [DisciplineDocumentCode_ID], [PID_ID], [PID_to_DisciplineDocumentCode_ID] from p_PID_to_DisciplineDocumentCode where row_status < 100
