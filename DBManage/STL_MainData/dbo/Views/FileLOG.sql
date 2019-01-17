CREATE view FileLOG as 
SELECT [FileLOG_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Row_Status]
      ,[FileLOG_Code]
  FROM [dbo].[p_FileLOG]
where row_status < 100 
