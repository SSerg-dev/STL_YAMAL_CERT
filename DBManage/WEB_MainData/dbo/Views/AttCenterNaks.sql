
create view AttCenterNaks as select [AttCenterNaks_ID], [AttCenterNaks_Code], [Description_Rus], [City] from p_AttCenterNaks where RowStatus < 100