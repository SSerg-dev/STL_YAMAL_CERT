CREATE view Register_to_ABDFinalFolder as 
SELECT [Register_To_ABDFinalFolder_ID]
      ,[DTS_Start]
      ,[DTS_End]
      ,[Row_status]
      ,[Register_ID]
      ,[ABDFinalFolder_ID]
  FROM [dbo].[p_Register_to_ABDFinalFolder]
  where row_status < 100 
