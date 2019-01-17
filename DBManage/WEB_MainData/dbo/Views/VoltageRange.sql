
create view VoltageRange as select [VoltageRange_ID], [VoltageRange_Code], [Description_Rus] from p_VoltageRange where RowStatus < 100