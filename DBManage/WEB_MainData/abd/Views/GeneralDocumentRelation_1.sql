﻿
CREATE view [abd].[DocumentRelation] as select [DocumentRelation_ID], [DocumentFrom_ID], [DocumentTo_ID], [RelationType_ID], [DocumentRelation_Order] from abd.p_DocumentRelation where RowStatus < 100
