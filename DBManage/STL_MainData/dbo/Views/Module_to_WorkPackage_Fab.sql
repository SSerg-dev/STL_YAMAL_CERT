CREATE view Module_to_WorkPackage_Fab as select [Module_ID], [Module_to_WorkPackage_Fab_ID], [WorkPackage_Fab_ID] from p_Module_to_WorkPackage_Fab where row_status < 100
