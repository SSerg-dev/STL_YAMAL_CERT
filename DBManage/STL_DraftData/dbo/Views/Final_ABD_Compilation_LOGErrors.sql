

CREATE view [dbo].[Final_ABD_Compilation_LOGErrors]
as
(
SELECT [Stage]
      ,[Title]
      ,[C_Name]
      ,[Marka]
      ,[Marka_Description]
      ,[Set]
      ,[Folder]
      ,[Status]
      ,[TN_Number]
      ,[TN_Date]
      ,[Draw_Number]
      ,[Draw_GOST]
      ,[C_Object]
      ,[Complectation_Start_Date]
      ,[C_YAM]
      ,[C_VEL]
      ,[C_ZPGS]
      ,[C_KXM]
      ,[C_REGA]
      ,[C_NOVA]
      ,[C_SNEMA]
      ,[COW_Marka]
      ,[STL_Rep]
      ,[Initial_Reg]
      ,[Folder_List_Number]
      ,[Remark]
      ,[Source_File]
      ,[Load_Date]
      ,[Error_Code]
      ,[Error_Column]
      ,[Reason]
	  ,CASE WHEN Len(E.Reason) 
                      > 3 THEN E.Reason ELSE d .Description_Rus + ' / ' + d .Description_Eng END AS Reason_TXT
  FROM [dbo].[s_Final_ABD_Compilation_LOGErrors] E
  LEFT OUTER JOIN
                      dbo.p_ValidationErrors AS d ON E.Reason = CAST(d.Number AS nvarchar(10))
					  )
