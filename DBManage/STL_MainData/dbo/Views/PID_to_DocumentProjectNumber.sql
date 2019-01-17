CREATE view PID_to_DocumentProjectNumber as select [DocumentProjectNumber_ID], [PID_ID], [PID_to_DocumentProjectNumber_ID] from p_PID_to_DocumentProjectNumber where row_status < 100
