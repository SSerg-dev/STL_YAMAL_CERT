CREATE view ISO_to_Spool as select [ISO_ID], [ISO_to_Spool_ID], [Spool_ID] from p_ISO_to_Spool where row_status < 100
