CREATE view DocumentOriginCode as select [Description_Eng], [Description_Rus], [DocumentOriginCode_ID], [DocumentOriginCode_Name] from p_DocumentOriginCode where row_status < 100
