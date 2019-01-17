


CREATE VIEW [dbo].[R_Structure]
AS
SELECT        Module_ID AS Structure_ID, Module_Name as Structure_Name
FROM            [dbo].[module]
UNION
SELECT        Line_ID, Line_Number
FROM            [dbo].[Line]
UNION
SELECT        CivilSector_ID, CivilSector_Number
FROM            [dbo].[CivilSector]
UNION
SELECT        TestPack_ID, TestPack_Name
FROM            [dbo].[TestPack]
