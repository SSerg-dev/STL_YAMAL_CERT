﻿



  CREATE view [syslog].[User]
  as
  ( Select 
	   [User_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[User_Domain_Name]
      ,[User_First_Name]
      ,[User_Last_Name]
      ,[Description]
  FROM [syslog].[p_User]
  where [Row_Status] = 0
  )
