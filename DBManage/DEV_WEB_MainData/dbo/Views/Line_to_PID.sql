﻿create view Line_to_PID as select [Line_to_PID_ID], [Line_ID], [PID_ID] from p_Line_to_PID where RowStatus = 0