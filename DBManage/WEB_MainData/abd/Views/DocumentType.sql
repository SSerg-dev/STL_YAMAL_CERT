﻿
CREATE view [abd].[DocumentType] as select [DocumentType_ID], [DocumentType_Code], [DocumentType_Name], [DocumentType_Group], [Description_Rus], [Description_Eng] from abd.p_DocumentType where RowStatus < 100