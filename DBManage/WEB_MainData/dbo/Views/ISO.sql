  Create view [dbo].[ISO]

  As 
  ( Select 
  [ISO_ID]

      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Created_User_ID]
      ,[Modified_User_ID]
      ,[ISO_Code]
      ,[Line_ID]
      ,[Phase_ID]
      ,[Marka_ID]
      ,[TitleObject_ID]
      ,[DesignAreaType_ID]
      ,[ProcessPhase_ID]
  FROM [dbo].[p_ISO]
  where [RowStatus] < 100
  )