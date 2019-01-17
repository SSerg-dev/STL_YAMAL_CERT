CREATE view TAG_to_TechnicalPassport as select [TAG_ID], [TAG_to_TechnicalPassport_ID], [TechnicalPassport_ID] from p_TAG_to_TechnicalPassport where row_status < 100
