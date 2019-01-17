CREATE view [JobCard_to_Module] as
SELECT [JobCard_to_Module_ID]
      ,[JobCard_ID]
      ,[Module_ID]
  FROM [dbo].[p_JobCard_to_Module]
  where row_status < 100
