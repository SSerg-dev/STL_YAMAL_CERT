
  CREATE view [syslog].[UserTaskLog]
  as
  (Select
       [UserTaskLog_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Run_Number]
      ,[User_ID]
      ,[UserTask_ID]
      ,[UserTaskMessage_ID]
      ,[FilePath]
      ,[FileName]
      ,[Description_Eng]
      ,[Description_Rus]
  FROM [syslog].[p_UserTaskLog]
  where [Row_Status] = 0
  
  )
