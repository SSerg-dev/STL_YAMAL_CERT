
create view ElectricalSafetyAbilitation as select [ElectricalSafetyAbilitation_ID], [ElectricalSafetyAbilitation_Code], [Description_Rus] from p_ElectricalSafetyAbilitation where RowStatus < 100