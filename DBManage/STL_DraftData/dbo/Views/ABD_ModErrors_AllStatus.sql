
CREATE VIEW [dbo].[ABD_ModErrors_AllStatus]
AS
SELECT        ER.Title, ER.Marka, ER.Set_Number, ER.Folder_Number, ER.Structure, ER.Unit, ER.Discipline, ER.Doc_Type, ER.SCTR, ER.Document_Sequiential_No_in_Folder, 
                         ER.GOST_Design_Drawing_No, ER.YLNG_Design_Drawing_No, ER.Document_No, ER.Document_Title, ER.Document_Issue_Date, ER.Sheet_No_in_Folder, 
                         ER.Total_sheets_No, ER.Remarks, ER.Source_File, ER.Load_Date, ER.Error_Code, ER.Error_Column, ER.Reason, 
                         E.Description_Rus + ' / ' + E.Description_Eng AS Reason_TXT, ER.Row_Status
FROM            dbo.s_ABD_ModErrors AS ER LEFT OUTER JOIN
                         dbo.p_ValidationErrors AS E ON E.Number = ER.Reason
