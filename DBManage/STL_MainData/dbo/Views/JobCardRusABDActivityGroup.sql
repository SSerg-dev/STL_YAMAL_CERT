CREATE view JobCardRusABDActivityGroup as 
SELECT [JobCardRusABDActivityGroup_ID]
      ,[Description_Rus]
      ,[Description_Eng]
      ,[Row_Status]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Report_Order]
  FROM [dbo].[p_JobCardRusABDActivityGroup]
  where row_status < 100
