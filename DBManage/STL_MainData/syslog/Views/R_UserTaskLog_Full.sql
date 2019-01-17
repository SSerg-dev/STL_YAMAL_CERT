

CREATE View [syslog].[R_UserTaskLog_Full]
as
(  Select UTL.[UserTaskLog_ID]
      ,UTL.[Insert_DTS]
      ,UTL.[Update_DTS]
      ,UTL.[Run_Number]
      ,UTL.[User_ID]
      ,UTL.[UserTask_ID]
      ,UTL.[UserTaskMessage_ID]
      ,UTL.[FilePath]
      ,LTRIM(RTRIM(UTL.[FileName])) as  [FileName]
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
	  ,U.User_Domain_Name
	  ,U.User_First_Name
	  ,U.User_Last_Name
	  
	  
  FROM [syslog].[UserTaskLog] as UTL
  Inner join [syslog].[UserTask] as UT on UT.UserTask_ID = UTL.UserTask_ID
  inner join [syslog].[UserTaskMessage] UTM on UTM.UserTaskMessage_ID = UTL.UserTaskMessage_ID 
  inner join [syslog].[User] U on U.User_ID = UTL.User_ID
  )
