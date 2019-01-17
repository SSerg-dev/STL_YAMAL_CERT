
create view QualificationField as select [QualificationField_ID], [Parent_ID], [Structure_Level], [QualificationField_Code], [Description_Rus] from p_QualificationField where RowStatus < 100