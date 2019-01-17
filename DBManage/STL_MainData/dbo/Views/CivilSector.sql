  CREATE View dbo.[CivilSector]
  AS
  ( Select
	  [CivilSector_ID]
      ,[CivilSector_Number]
      ,[Row_status]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[TitleObject_ID]
  FROM [dbo].[p_CivilSector]
  where [Row_status] < 100 

  )
