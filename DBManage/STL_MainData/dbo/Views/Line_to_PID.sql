CREATE view Line_to_PID as select [Line_ID], [Line_to_PID_ID], [PID_ID] from p_Line_to_PID where row_status < 100
