
create view DocumentNaks as select [DocumentNaks_ID], [Person_ID], [Number], [IssueDate], [ValidUntil], [Schifr], [WeldType_ID], [ParentDocumentNaks_ID] from p_DocumentNaks where RowStatus < 100