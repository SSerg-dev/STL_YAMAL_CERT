CREATE view [dbo].[ISO_to_Action] as 
select [Created_By], [ISO_to_Action_ID], [IsometricNumber_ID], [Modified_By], [Package_ID], [PipingWorkType_ID], [RegisterNumber_ID] 
from p_ISO_to_Action where row_status < 100
