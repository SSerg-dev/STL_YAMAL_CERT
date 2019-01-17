
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE view [dbo].[LogId] as 
SELECT [LogId_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Row_Status]
      ,[LogId_Code]
  FROM [dbo].[p_LogId]
  where row_status < 100 
