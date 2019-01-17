
CREATE View [syslog].[UserTaskLog_Full]
as
(  Select UTL.[UserTaskLog_ID]
      ,UTL.[Insert_DTS]
      ,UTL.[Update_DTS]
      ,UTL.[Run_Number]
      ,UTL.[User_ID]
      ,UTL.[UserTask_ID]
      ,UTL.[UserTaskMessage_ID]
      ,UTL.[FilePath]
      ,UTL.[FileName]
      ,UTL.[Description_Eng]
      ,UTL.[Description_Rus]
	  ,UT.TaskNumber
	  ,UT.TaskName
	  ,UT.Description_Eng as UT_Description_Eng
	  ,UT.Description_Rus as UT_Description_Rus
	  ,UTM.Message_Number
	  ,UTM.Message_Text
	  ,UTM.Message_Type
	  ,UTM.MessageDescription_ENG
	  ,UTM.MessageDescription_RUS
	  ,USR.User_Domain_Name
	  ,USR.User_First_Name
	  ,USR.User_Last_Name
	  
	  
  FROM [syslog].[UserTaskLog] as UTL
  Inner join [syslog].[UserTask] as UT on UT.UserTask_ID = UTL.UserTask_ID
  inner join [syslog].[UserTaskMessage] UTM on UTM.UserTaskMessage_ID = UTL.UserTaskMessage_ID 
  inner join [syslog].[User] USR on UTL.[User_ID] = USR.[User_ID]
  )
