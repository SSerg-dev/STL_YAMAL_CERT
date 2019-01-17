
CREATE view ABDFinalFolder_to_Transmittal as 
SELECT [ABDFinalFolder_to_Transmittal_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Row_Status]
      ,[ABDFinalFolder_ID]
      ,[Transmittal_ID]
FROM [dbo].[p_ABDFinalFolder_to_Transmittal]
where row_status < 100
