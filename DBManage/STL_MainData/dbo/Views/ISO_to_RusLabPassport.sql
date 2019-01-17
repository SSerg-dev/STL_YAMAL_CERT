CREATE view ISO_to_RusLabPassport as select [ISO_ID], [p_ISO_to_RusLabPassport_ID], [RusLabPassport_ID] from p_ISO_to_RusLabPassport where row_status < 100
