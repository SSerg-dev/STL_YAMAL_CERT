  CREATE view [dbo].[Line]

  as
  ( Select 
   [Line_ID]
      ,[Insert_DTS]
      ,[Update_DTS]
      ,[Created_User_ID]
      ,[Modified_User_ID]
      ,[Line_Code]
      ,[Location_From]
      ,[Location_To]
      ,[Fluid_Name_Eng]
      ,[Fluid_Name_Rus]
      ,[Fluid_Danger_Code_By_Gost]
      ,[Fluid_Fire_Aand_Explosive_Hazard]
      ,[Fluid_Group_By_TP_TC_032_2013]
      ,[Fluid_Group_By_GOST_32569_2013]
      ,[Pipeline_Category_By_GOST_32569_2013]
      ,[Piprline_Category_By_TP_TC_032_2013]
	  from [dbo].[p_Line]
	  where [RowStatus] < 100
	  )
