
create view InspectionSubject as select [InspectionSubject_ID], [Parent_ID], [Structure_Level], [InspectionSubject_Code], [Description_Rus] from p_InspectionSubject where RowStatus < 100