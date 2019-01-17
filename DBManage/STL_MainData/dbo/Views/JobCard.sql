CREATE view [JobCard] as
select 
	  [JobCard_ID]
      ,[JobCard_Number]
      ,[Activity_Description]
      ,[COW_Type]
      ,[IsChecked]
  FROM [dbo].[p_JobCard]
  where row_status < 100
