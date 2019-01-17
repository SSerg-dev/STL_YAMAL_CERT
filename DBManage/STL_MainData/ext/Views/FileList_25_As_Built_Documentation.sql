
CREATE VIEW [ext].[FileList_25_As_Built_Documentation]
AS
SELECT     FileList_25_As_Built_Documentation_ID, FileName, Created_By, Modified_By
FROM         ext.p_FileList_25_As_Built_Documentation
WHERE     (Row_Status < 100)
