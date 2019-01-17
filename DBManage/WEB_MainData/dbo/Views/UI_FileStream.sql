CREATE VIEW dbo.[UI_FileStream]
AS
SELECT        a.Document_ID, a.FileTable_ID, b.name, b.file_type, b.last_write_time, a.Document_to_FileTable_ID
FROM            dbo.Document_to_FileTable AS a LEFT OUTER JOIN
                         STL_FileStorage.dbo.p_FileShareTable AS b ON a.FileTable_ID = b.stream_id

GO
