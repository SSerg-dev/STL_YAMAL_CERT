﻿
create view DocumentNaksAttest_to_WeldMaterialGroup as select [DocumentNaksAttest_to_WeldMaterialGroup_ID], [DocumentNaksAttest_ID], [WeldMaterialGroup_ID] from p_DocumentNaksAttest_to_WeldMaterialGroup where RowStatus < 100