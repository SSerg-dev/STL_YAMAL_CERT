﻿create view ISO_to_ProcessPhase as select [ISO_ID], [ISO_to_ProcessPhase_ID], [ProcessPhase_ID] from p_ISO_to_ProcessPhase where row_status < 100 