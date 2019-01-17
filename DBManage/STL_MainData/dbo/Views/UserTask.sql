
  CREATE View [dbo].[UserTask]

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

	  from [dbo].[p_UserTask]
	  Where  [Row_Status] = 0

  )
