﻿
create view DocumentNaksAttest_to_WeldMaterial as select [DocumentNaksAttest_to_WeldMaterial_ID], [DocumentNaksAttest_ID], [WeldMaterial_ID] from p_DocumentNaksAttest_to_WeldMaterial where RowStatus < 100