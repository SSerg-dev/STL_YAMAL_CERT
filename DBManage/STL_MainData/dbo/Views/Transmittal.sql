CREATE view Transmittal as 
SELECT [Transmittal_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Row_Status]
      ,[Transmittal_Code]
  FROM [dbo].[p_Transmittal]
where row_status < 100 
