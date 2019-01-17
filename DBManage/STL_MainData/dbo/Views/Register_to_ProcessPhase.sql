

  Create view  [dbo].[Register_to_ProcessPhase]
   as
    (SELECT [Register_to_ProcessPhase_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Register_ID]
      ,[ProcessPhase_ID]
  FROM [dbo].[p_Register_to_ProcessPhase]
  where [Row_status] = 0
  )
