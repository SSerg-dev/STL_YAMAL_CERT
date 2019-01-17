

  CREATE View [syslog].[UserTask]

  as
  ( Select 
		[UserTask_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Row_Status]
      ,[TaskNumber]
      ,[TaskName]
      ,[Description_Eng]
      ,[Description_Rus]

	  from [syslog].[p_UserTask]
	  Where  [Row_Status] = 0

  )
