
create VIEW [dbo].[UI_Line]
AS
SELECT        l.Line_ID, l.Line_Number, l.Row_Status, l.Location_From, l.Location_To, l.Fluid_Name_Eng, l.Fluid_Name_Rus, l.Fluid_Danger_Code_By_Gost, l.Fluid_Fire_Aand_Explosive_Hazard, 
                         l.Fluid_Group_By_TP_TC_032_2013 AS Fluid_Group_By_TP_TC_032_2013, l.Fluid_Group_By_GOST_32569_2013 AS Fluid_Group_By_GOST, l.Pipeline_Category_By_GOST_32569_2013 AS Pipeline_Category_By_GOST, 
                         l.Piprline_Category_By_TP_TC_032_2013 AS Piprline_Category_By_TP_TC_032_2013, i.ISO_ID
FROM            dbo.p_Line AS l LEFT OUTER JOIN
                         dbo.ISO_to_Line AS itl ON l.Line_ID = itl.LINE_ID LEFT OUTER JOIN
                         dbo.ISO AS i ON itl.ISO_ID = i.ISO_ID
