Create View [dbo].[StructureFull]
as 
(
Select DRM.ABDDocument_ID, M.Module_Name As Structure, 'Module' As Structure_Type, 'M' As Structure_Abbr  from dbo.ABDDocument_to_Module AS DRM INNER JOIN 
                         dbo.Module AS M ON M.Module_ID = DRM.Module_ID
Union All

Select DRL.ABDDocument_ID, L.Line_Number AS Structure, 'Line' As Structure_Type, 'L' As Structure_Abbr          From dbo.ABDDocument_to_Line AS DRL 
					INNER JOIN dbo.Line AS L ON L.Line_ID = DRL.Line_ID
Union All

Select DRCS.ABDDocument_ID, CS.CivilSector_Number AS Structure, 'CivilSector' As Structure_Type, 'C' As Structure_Abbr   From dbo.ABDDocument_to_CivilSector AS DRCS 
		INNER JOIN dbo.CivilSector AS CS ON CS.CivilSector_ID = DRCS.CivilSector_ID
		)