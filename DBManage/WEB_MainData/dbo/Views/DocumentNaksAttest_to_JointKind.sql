
create view DocumentNaksAttest_to_JointKind as select [DocumentNaksAttest_to_JointKind_ID], [DocumentNaksAttest_ID], [JointKind_ID] from p_DocumentNaksAttest_to_JointKind where RowStatus < 100