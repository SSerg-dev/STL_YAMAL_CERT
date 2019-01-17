
create view LogId_to_FileLOG as 
SELECT [LogId_to_FileLOG_ID]
      ,[LogId_ID]
      ,[FileLOG_ID]
  FROM [dbo].[p_LogId_to_FileLOG]
where [Row_Status] = 0
