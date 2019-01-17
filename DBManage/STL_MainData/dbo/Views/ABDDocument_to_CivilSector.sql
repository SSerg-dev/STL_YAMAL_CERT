CREATE view ABDDocument_to_CivilSector as select [ABDDocument_ID], [ABDDocument_to_CivilSector_ID], [CivilSector_ID] from p_ABDDocument_to_CivilSector where row_status < 100
