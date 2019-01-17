


CREATE view [dbo].[UI_RegisterListWithDeleted]
AS
SELECT     r.Register_ID, r.LOG_ID, r.Register_Number, '' AS Phase, t.TitleObject_Name, '' AS [Target (Unit/ISO)], m.Marka_Name, r.Work_Desc, r.CNT_Date, r.SCTR_RESP, 
                      r.CTR_RESP, rts.ABDStatusDate, s.Description_Rus, r.Notes, t.ReportColor AS TitleColor, t.ReportOrder AS TitleOrder, m.ReportColor AS MarkaColor, 
                      m.ReportOrder AS MarkaOrder, s.ReportColor AS StatusColor, s.ReportOrder AS StatusOrder, t.TitleObject_ID, m.Marka_ID, s.ABDStatus_ID, r.WorkPackage_ID, 
                      w.WorkPackage_Name
FROM         dbo.p_Register AS r LEFT OUTER JOIN
                      dbo.Register_to_TitleObject AS rtt ON rtt.Register_ID = r.Register_ID LEFT OUTER JOIN
                      dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID LEFT OUTER JOIN
                      dbo.Register_to_Marka AS rtm ON rtm.Register_ID = r.Register_ID LEFT OUTER JOIN
                      dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID LEFT OUTER JOIN
                      dbo.Register_to_ABDStatus AS rts ON rts.Register_ID = r.Register_ID LEFT OUTER JOIN
                      dbo.Status AS s ON rts.ABDStatus_ID = s.ABDStatus_ID LEFT OUTER JOIN
                      dbo.WorkPackage AS w ON r.WorkPackage_ID = w.WorkPackage_ID
WHERE r.row_status < 100 or r.Row_Status = 200
