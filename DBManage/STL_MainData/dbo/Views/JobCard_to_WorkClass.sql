CREATE view JobCard_to_WorkClass as
SELECT [JobCard_To_WorkClass_ID]
      ,[JobCard_ID]
      ,[WorkClass_ID]
  FROM [dbo].[p_JobCard_to_WorkClass]
  where row_status < 100
