

  CREATE View [syslog].[UserTaskMessage]
    as
  ( Select
       [UserTaskMessage_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Message_Type]
      ,[Message_Number]
      ,[Message_Text]
      ,[MessageDescription_ENG]
      ,[MessageDescription_RUS]
  FROM [syslog].[p_UserTaskMessage]
  where  [Row_Status] = 0 

  )
