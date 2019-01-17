CREATE view Register_to_FileLOG as 
SELECT [Register_To_FileLOG_ID]
      ,[DTS_Start]
      ,[DTS_End]
      ,[Row_status]
      ,[Register_ID]
      ,[FileLOG_ID]
  FROM [dbo].[p_Register_to_FileLOG]
  where row_status < 100 
