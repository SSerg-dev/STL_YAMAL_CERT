Create View [syslog].[UserTaskLogXLS_Full]
  As
  (
  Select UTL.[UserTaskLog_ID]
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
	  ,UXLS.Sheet_Name
	  ,UXLS.Column_Number
	  ,UXLS.[Row_Number]
	  ,UXLS.Cell_Value
	  ,UXLS.[ErrorDescriptiuon_Eng] as [XLS_ErrorDescriptiuon_Eng]
	  ,UXLS.[ErrorDescriptiuon_Rus] as [XLS_ErrorDescriptiuon_Rus]
	  
  FROM [syslog].[UserTaskLog] as UTL
  Inner join [syslog].[UserTask] as UT on UT.UserTask_ID = UTL.UserTask_ID
  inner join [syslog].[UserTaskMessage] UTM on UTM.UserTaskMessage_ID = UTL.UserTaskMessage_ID 
  inner join [syslog].[UserXLSErrorLog] UXLS on UXLS.UserTaskLog_ID = UTL.UserTaskLog_ID
  )