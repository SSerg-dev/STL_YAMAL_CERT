CREATE view [dbo].[r_LogId_to_FileLOG]
AS
SELECT        dbo.p_LogId_to_FileLOG.LogId_to_FileLOG_ID, dbo.p_LogId_to_FileLOG.LogId_ID, dbo.p_LogId_to_FileLOG.FileLOG_ID, dbo.p_FileLOG.FileLOG_Code, 
                         dbo.p_LogId.LogId_Code
FROM            dbo.p_LogId_to_FileLOG INNER JOIN
                         dbo.p_FileLOG ON dbo.p_LogId_to_FileLOG.FileLOG_ID = dbo.p_FileLOG.FileLOG_ID INNER JOIN
                         dbo.p_LogId ON dbo.p_LogId_to_FileLOG.LogId_ID = dbo.p_LogId.LogId_ID
WHERE        (dbo.p_LogId_to_FileLOG.row_status < 100)
