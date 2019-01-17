
  Create View dbo.Register_to_TitleObject

  As 
  ( SELECT  [Register_to_TitleObject_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Register_ID]
      ,[TitleObject_ID]
  FROM [dbo].[p_Register_to_TitleObject]
  where [Row_status] = 0
  )
