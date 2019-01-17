
create view TestMethod as select [TestMethod_ID], [Parent_ID], [Structure_Level], [TestMethod_Code], [Description_Rus] from p_TestMethod where RowStatus < 100