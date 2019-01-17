  CREATE view [dbo].[UserTaskLog]
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
  FROM [dbo].[p_UserTaskLog]
  where [Row_Status] = 0
  
  )
