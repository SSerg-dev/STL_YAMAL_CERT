
create view QualificationLevel as select [QualificationLevel_ID], [QualificationLevel_Code], [Description_Rus] from p_QualificationLevel where RowStatus < 100