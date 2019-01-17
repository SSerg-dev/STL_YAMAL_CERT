
CREATE view [abd].[DocumentAttributeRelation] as select [DocumentAttributeRelation_ID], [DocumentAttributeFrom_ID], [DocumentAttributeTo_ID], [RelationType_ID], [Document_ID], [DocumentAttributeRelation_Order] from abd.p_DocumentAttributeRelation where RowStatus < 100
