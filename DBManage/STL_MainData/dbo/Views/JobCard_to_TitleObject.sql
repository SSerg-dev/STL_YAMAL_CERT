CREATE view JobCard_to_TitleObject as
SELECT [JobCard_to_TitleObject_ID]
      ,[JobCard_ID]
      ,[TitleObject_ID]
  FROM [dbo].[p_JobCard_to_TitleObject]
  where row_status < 100 
