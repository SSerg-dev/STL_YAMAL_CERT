


CREATE view [dbo].[UnitNumberDocumentCode]
as
(
SELECT [UnitNumberDocumentCode_ID]
      ,[UnitNumberDocumentCode_Name]
      ,[Description_Eng]
      ,[Description_Rus]
      ,[Insert_DTS]
      ,[Update_DTS]
  FROM [dbo].[p_UnitNumberDocumentCode]
  where [Row_Status] =0
  )
