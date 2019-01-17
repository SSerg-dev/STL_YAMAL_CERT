CREATE view WorkPackage_to_Contragent as select [Contragent_ID], [WorkPackage_ID], [WorkPackage_to_Contragent_ID] from p_WorkPackage_to_Contragent where row_status < 100
