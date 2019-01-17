

  CREATE View [dbo].[Contragent]
    As
  (  
  SELECT[Contragent_ID]
      ,[Code]
      ,[Description_Eng]
      ,[Description_Rus]
      ,[Row_status]
      ,[Insert_DTS]
      ,[Update_DTS]
  FROM [dbo].[p_Contragent]
  where [Row_status] = 0
  )
