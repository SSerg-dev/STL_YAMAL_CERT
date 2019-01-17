
create view TestTypeRef as select [TestTypeRef_ID], [TestTypeRef_Code], [Description_Rus], [Description_Eng] from p_TestTypeRef where RowStatus < 100