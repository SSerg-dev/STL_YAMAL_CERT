using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2
{
	public class QueryBank
	{
		/*This class is used to easy model class bodies from big sql queries.
		 * Use intellisense wisely here. Keep your queries organised */
		public static String ABDFinalFolderListBySet = 
			@"select f.ABDFinalFolder_ID, f.ABDFinalFolder_Name
				from dbo.ABDFinalFolder f
				join dbo.ABDFinalFolder_to_ABDFinalSet fts on f.ABDFinalFolder_ID = fts.ABDFinalFolder_ID
				join dbo.ABDFinalSet s on fts.ABDFinalSet_ID = s.ABDFinalSet_ID
				where s.ABDFinalSet_ID = @searchParameter order by f.ABDFinalFolder_Name desc";

		/*this query is initial query and is used by query factory. To use this query in SSMS add 
		 " ) select* from Results_CTE " to the end */
		public static String ABDFinalFolderListTyped =
                    @"WITH Results_CTE AS(
                    SELECT [ABDFinalFolder_ID]
                        ,[ABDFinalFolder_Name]
                        ,[ABDStatus_ID]
                        ,[Status_ENG]
                        ,[Status_Rus]
                        ,[SubContractor_Id]
                        ,[SubContractor_Name]
                        ,[CTR_RESP]
                        ,[Transmittal_Code]
                        ,[ListCount]
                        ,[TitleObject_Name]
                        ,[Marka_Name]
                        ,[ReportOrder]
                        ,[Final_Compilation_Start_Date]
                        ,[Final_Compilation_Target_Date]
                    ,ROW_NUMBER() OVER
                    (ORDER BY
                        [ABDFinalFolder_Name]
                    ) 
                    AS RowNum
                    FROM [DEV_STL_MainData].[dbo].[FinalABDCompilation] ";

		public static String ABDDocumentListGetFolderSpecification =
                @"SELECT
                    [ABDDocument_ID]
                    ,[ABDDocument_Number]
                    ,[ABDDocument_Name]
                    ,[Number_in_Folder]
                    ,[DDC_Description_Rus]
                    ,[DDC_Description_Eng]
                    ,[DTC_Description_Rus]
                    ,[DTC_Description_Eng]
                    ,[DocumentTypeCode_ID]
                    ,[DocumentTypeCode_Name]
                    ,[Structure]
                    ,[GOST_ID]
                    ,[GOST_Code]
                    ,[PID_ID]
                    ,[PID_Code]
                    ,[Sheet_Folder_Number]
                    ,[Total_Sheets]
                    ,[Issue_Date]
                FROM [DEV_STL_MainData].[dbo].[ABDDocumentFull]
                where [ABDFinalFolder_ID] = @searchParameter";
		
		public static string ABDFinalSetGetList = 
			@"SELECT	s.ABDFinalSet_ID, s.ABDFinalSet_Number 
				FROM dbo.ABDFinalSet s
				left join dbo.TitleObject t on s.TitleObject_ID = t.TitleObject_ID
				left join dbo.Marka m on s.Marka_ID = m.Marka_ID
				order by m.ReportOrder asc, t.ReportOrder asc,  s.ABDFinalSet_Number desc  ";

		public static string ABDFinalSetGetSetHead =
			@"SELECT s.ABDFinalSet_ID,
				s.ABDFinalSet_Number,
				s.TitleObject_ID,
				t.TitleObject_Name,
				t.Description_Rus as TitleDescriptionRus,
				t.ReportColor as TitleObjectColor,
				s.Marka_ID,
				m.Marka_Name,
				m.Description_Rus as MarkaDescriptionRus,
				m.ReportColor as MarkaColor
				FROM dbo.ABDFinalSet s
				left join dbo.TitleObject t on s.TitleObject_ID = t.TitleObject_ID
				left join dbo.Marka m on s.Marka_ID = m.Marka_ID
				where s.ABDFinalSet_ID = @searchParameter";

		public static string ABDFinalSetGetSetByFolder = 
				@"SELECT s.ABDFinalSet_ID, s.ABDFinalSet_Number
				FROM dbo.ABDFinalFolder f
				join dbo.ABDFinalFolder_to_ABDFinalSet fts on f.ABDFinalFolder_ID = fts.ABDFinalFolder_ID
				join dbo.ABDFinalSet s on fts.ABDFinalSet_ID = s.ABDFinalSet_ID
				where f.ABDFinalFolder_ID = @searchParameter";

		public static string getContragentByFolder =
				@"SELECT c.Contragent_ID, c.Description_Rus
				FROM dbo.ABDFinalFolder AS f
				JOIN dbo.ABDFinalFolder_to_Contragent AS ftc ON f.ABDFinalFolder_ID = ftc.ABDFinalFolder_ID
				JOIN dbo.Contragent AS c ON c.Contragent_ID = ftc.Contragent_ID
				where f.ABDFinalFolder_ID = @searchParameter";

		public static string checkPidGost = @"select count(*) as cnt from dbo.GOST_to_PID
				where GOST_ID = @searchParameter1 and PID_ID = @searchParameter2";

	}
}


/*
 * SELECT [RowNumber]
      ,[Structure_ID]
      ,[Structure_Name]
      ,[UnitNumberDocumentCode_ID]
      ,[UnitNumberDocumentCode_Name]
      ,[DisciplineDocumentCode_ID]
      ,[DisciplineDocumentCode_Name]
      ,[DocumentTypeCode_ID]
      ,[DocumentTypeCode_Name]
      ,[Number_in_Folder]
      ,[GOST_ID]
      ,[GOST_Code]
      ,[PID_ID]
      ,[PID_Code]
      ,[ABDDocument_ID]
      ,[ABDDocument_Number]
      ,[ABDDocument_Name]
      ,[Issue_Date]
      ,[Sheet_Folder_Number]
      ,[Total_Sheets]
      ,[Remark]
      ,[ABDFinalFolder_ID]
      ,[ABDFinalFolder_Name]
      ,[ABDFinalFolderItem_ID]
      ,[ABDFinalFolderItemDrawing_ID]
      ,[ABDFinalFolderItem_to_Structure_ID]
  FROM [dbo].[UI_ABDFinalFolderItem]
GO
*/