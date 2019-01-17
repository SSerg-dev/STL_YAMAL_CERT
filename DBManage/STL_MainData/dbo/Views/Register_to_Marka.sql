
  Create view  dbo.Register_to_Marka
   as
    (SELECT [Register_to_Marka_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Register_ID]
      ,[Marka_ID]
  FROM [dbo].[p_Register_to_Marka]
  where [Row_status] = 0
  )
