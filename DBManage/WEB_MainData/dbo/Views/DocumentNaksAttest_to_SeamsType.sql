
create view DocumentNaksAttest_to_SeamsType as select [DocumentNaksAttest_to_SeamsType_ID], [DocumentNaksAttest_ID], [SeamsType_ID] from p_DocumentNaksAttest_to_SeamsType where RowStatus < 100