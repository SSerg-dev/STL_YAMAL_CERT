
CREATE  view [dbo].[TitleObject]
AS
SELECT        TitleObject_ID, TitleObject_PARENTID, Structure, TitleObject_Name, Description_Eng, Description_Rus, Phase_Name, ReportColor, ReportOrder, GLB_Weight, 
                         Book1_Pct, Book1_Weight, Book2_Pct, Book2_Weight, Book3_Pct, Book3_Weight, Book4_Weight, TitleObject_for_ABDFinalSet, StageOfConstr
FROM            dbo.p_TitleObject
WHERE        (row_status < 100)
