CREATE view ISO_to_RusLabStatus as select [ISO_ID], [ISO_to_RusLabStatus_ID], [RusLabStatus_ID] from p_ISO_to_RusLabStatus where row_status < 100
