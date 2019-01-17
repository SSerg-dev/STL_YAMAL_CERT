
create view InspectionTechnique as select [InspectionTechnique_ID], [InspectionTechnique_Code], [Description_Rus] from p_InspectionTechnique where RowStatus < 100