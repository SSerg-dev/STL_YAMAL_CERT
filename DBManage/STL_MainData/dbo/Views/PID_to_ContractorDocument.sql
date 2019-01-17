
CREATE view [dbo].[PID_to_ContractorDocument] as select a.[ContractorDocument_ID], [PID_ID], a.PID_to_ContractorDocument_ID from p_PID_to_ContractorDocument a where row_status < 100
