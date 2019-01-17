CREATE view [JobCard_to_Marka] as
SELECT [JobCard_to_Marka_ID]
      ,[JobCard_ID]
      ,[Marka_ID]
  FROM [dbo].[p_JobCard_to_Marka]
where row_status < 100
