
  Create View dbo.Position_to_Division
    as
  ( SELECT
	   [Position_to_Division_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Created_User_ID]
      ,[Modified_User_ID]
      ,[Position_ID]
      ,[Division_ID]
  FROM [dbo].[p_Position_to_Division]
  where [RowStatus] < 100
  )
