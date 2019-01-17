CREATE view DocumentProjectNumber as select [Description_Eng], [Description_Rus], [DocumentProjectNumber_ID], [DocumentProjectNumber_Name] from p_DocumentProjectNumber where row_status < 100
