﻿create view DesignAreaType as select [DesignAreaType_ID], [DesignAreaType_Code], [Description_Eng], [Description_Rus] from p_DesignAreaType where RowStatus = 0