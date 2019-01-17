
  CREATE View [syslog].[UserXLSErrorLog] 
  as
  (SELECT [UserXLSErrorLog_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
     
      ,[User_ID]
      ,[UserTaskLog_ID]
      ,[Sheet_Name]
      ,[Column_Number]
      ,[Row_Number]
      ,[Cell_Value]
      ,[ErrorDescriptiuon_Eng]
      ,[ErrorDescriptiuon_Rus]
  FROM [syslog].[p_UserXLSErrorLog]
  where  [Row_Status] < 100)
