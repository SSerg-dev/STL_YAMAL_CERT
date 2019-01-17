
CREATE view [dbo].[ContractorDocument] as select a.ContractorDocument_Number, a.ContractorDocument_ID from p_ContractorDocument a where row_status < 100
