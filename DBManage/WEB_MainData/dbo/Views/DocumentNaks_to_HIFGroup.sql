
create view DocumentNaks_to_HIFGroup as select [DocumentNaks_to_HIFGroup_ID], [DocumentNaks_ID], [HIFGroup_ID] from p_DocumentNaks_to_HIFGroup where RowStatus < 100