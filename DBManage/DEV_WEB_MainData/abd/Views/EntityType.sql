﻿create view abd.EntityType as select [EntityType_ID], [EntityType_Code], [EntityType_Group], [Attribute_DataType], [Document_Type] from p_EntityType where RowStatus < 100
