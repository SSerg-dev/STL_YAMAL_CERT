
CREATE view [abd].[DocumentAttribute] as select [DocumentAttribute_ID], [DocumentAttribute_Value], [AttributeType_ID], [Document_ID], [DocumentAttribute_Order] from abd.p_DocumentAttribute where RowStatus < 100
