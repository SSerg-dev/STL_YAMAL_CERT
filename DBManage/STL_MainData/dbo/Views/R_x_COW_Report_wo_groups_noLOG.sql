CREATE VIEW dbo.R_x_COW_Report_wo_groups_noLOG
AS 
select 1 a
/*
SELECT     TOP (100) PERCENT TitleObject_Name, Marka_Name, SUM(RegPrepared) AS RegPrepared, SUM(RegAproved) AS RegAproved, SUM(RegPercentage) 
                      AS RegPercentage, SUM(JCPrepared) AS JCPrepared, SUM(JCAproved) AS JCAproved, SUM(JCpercentage) AS JCpercentage
FROM         (SELECT DISTINCT 
                                              t.TitleObject_Name, m.Marka_Name, p.RegPrepared, a.RegAproved, p.RegPrepared / a.RegAproved * 100 AS RegPercentage, 0 AS JCPrepared, 
                                              0 AS JCAproved, 0 AS JCpercentage
                       FROM          dbo.Register AS r INNER JOIN
                                              dbo.Register_to_TitleObject AS rtt ON r.Register_ID = rtt.Register_ID INNER JOIN
                                              dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID INNER JOIN
                                              dbo.Register_to_Marka AS rtm ON r.Register_ID = rtm.Register_ID INNER JOIN
                                              dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID INNER JOIN
                                              dbo.Register_to_Status AS rts ON r.Register_ID = rts.Register_ID INNER JOIN
                                              dbo.Status AS s ON rts.ABDStatus_ID = s.ABDSTATUS_ID AND s.CODE <> 'N/A' INNER JOIN
                                                  (SELECT     t.TitleObject_ID, m.Marka_ID, COUNT(r.Register_Number) AS RegPrepared
                                                    FROM          dbo.Register AS r INNER JOIN
                                                                           dbo.Register_to_TitleObject AS rtt ON r.Register_ID = rtt.Register_ID INNER JOIN
                                                                           dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID INNER JOIN
                                                                           dbo.Register_to_Marka AS rtm ON r.Register_ID = rtm.Register_ID INNER JOIN
                                                                           dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID INNER JOIN
                                                                           dbo.Register_to_Status AS rts ON r.Register_ID = rts.Register_ID INNER JOIN
                                                                           dbo.Status AS s ON rts.ABDStatus_ID = s.ABDSTATUS_ID AND s.CODE <> 'N/A'
                                                    WHERE      (r.FileLOG LIKE '%COW%')
                                                    GROUP BY t.TitleObject_ID, m.Marka_ID) AS p ON t.TitleObject_ID = p.TitleObject_ID AND m.Marka_ID = p.Marka_ID INNER JOIN
                                                  (SELECT     t.TitleObject_ID, m.Marka_ID, COUNT(r.Register_Number) AS RegAproved
                                                    FROM          dbo.Register AS r INNER JOIN
                                                                           dbo.Register_to_TitleObject AS rtt ON r.Register_ID = rtt.Register_ID INNER JOIN
                                                                           dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID INNER JOIN
                                                                           dbo.Register_to_Marka AS rtm ON r.Register_ID = rtm.Register_ID INNER JOIN
                                                                           dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID INNER JOIN
                                                                           dbo.Register_to_Status AS rts ON r.Register_ID = rts.Register_ID INNER JOIN
                                                                           dbo.Status AS s ON rts.ABDStatus_ID = s.ABDSTATUS_ID AND s.CODE <> 'N/A' AND s.CODE IN ('YLNGs', 'HOfc')
                                                    WHERE      (r.FileLOG LIKE '%COW%')
                                                    GROUP BY t.TitleObject_ID, m.Marka_ID) AS a ON t.TitleObject_ID = a.TitleObject_ID AND m.Marka_ID = a.Marka_ID
                       WHERE      (r.FileLOG LIKE '%COW%')
                       UNION ALL
                       SELECT DISTINCT 
                                             t.TitleObject_Name, m.Marka_Name, 0 AS RegPrepared, 0 AS RegAproved, 0 AS RegPercentage, p_1.JCPrepared, a_1.JCAproved, 
                                             p_1.JCPrepared / a_1.JCAproved * 100 AS JCpercentage
                       FROM         dbo.Register AS r INNER JOIN
                                             dbo.Register_to_TitleObject AS rtt ON r.Register_ID = rtt.Register_ID INNER JOIN
                                             dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID INNER JOIN
                                             dbo.Register_to_Marka AS rtm ON r.Register_ID = rtm.Register_ID INNER JOIN
                                             dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID INNER JOIN
                                             dbo.Register_to_Status AS rts ON r.Register_ID = rts.Register_ID INNER JOIN
                                             dbo.Status AS s ON rts.ABDStatus_ID = s.ABDSTATUS_ID AND s.CODE <> 'N/A' INNER JOIN
                                             dbo.JobCard_to_Marka AS jtm ON jtm.Marka_ID = m.Marka_ID INNER JOIN
                                             dbo.JobCard_to_TitleObject AS jtt ON jtt.TitleObject_ID = t.TitleObject_ID INNER JOIN
                                             dbo.JobCard AS j ON jtm.JobCard_ID = j.JobCard_ID AND jtt.JobCard_ID = j.JobCard_ID INNER JOIN
                                             dbo.Register_to_JobCard AS rtj ON rtj.Register_ID = r.Register_ID AND rtj.JobCard_ID = j.JobCard_ID INNER JOIN
                                                 (SELECT     t.TitleObject_ID, m.Marka_ID, COUNT(j.JobCard_Number) AS JCPrepared
                                                   FROM          dbo.Register AS r INNER JOIN
                                                                          dbo.Register_to_TitleObject AS rtt ON r.Register_ID = rtt.Register_ID INNER JOIN
                                                                          dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID INNER JOIN
                                                                          dbo.Register_to_Marka AS rtm ON r.Register_ID = rtm.Register_ID INNER JOIN
                                                                          dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID INNER JOIN
                                                                          dbo.Register_to_Status AS rts ON r.Register_ID = rts.Register_ID INNER JOIN
                                                                          dbo.Status AS s ON rts.ABDStatus_ID = s.ABDSTATUS_ID AND s.CODE <> 'N/A' INNER JOIN
                                                                          dbo.JobCard_to_Marka AS jtm ON jtm.Marka_ID = m.Marka_ID INNER JOIN
                                                                          dbo.JobCard_to_TitleObject AS jtt ON jtt.TitleObject_ID = t.TitleObject_ID INNER JOIN
                                                                          dbo.JobCard AS j ON jtm.JobCard_ID = j.JobCard_ID AND jtt.JobCard_ID = j.JobCard_ID INNER JOIN
                                                                          dbo.Register_to_JobCard AS rtj ON rtj.Register_ID = r.Register_ID AND rtj.JobCard_ID = j.JobCard_ID
                                                   WHERE      (r.FileLOG LIKE '%COW%')
                                                   GROUP BY t.TitleObject_ID, m.Marka_ID) AS p_1 ON t.TitleObject_ID = p_1.TitleObject_ID AND m.Marka_ID = p_1.Marka_ID INNER JOIN
                                                 (SELECT     t.TitleObject_ID, m.Marka_ID, COUNT(j.JobCard_Number) AS JCAproved
                                                   FROM          dbo.Register AS r INNER JOIN
                                                                          dbo.Register_to_TitleObject AS rtt ON r.Register_ID = rtt.Register_ID INNER JOIN
                                                                          dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID INNER JOIN
                                                                          dbo.Register_to_Marka AS rtm ON r.Register_ID = rtm.Register_ID INNER JOIN
                                                                          dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID INNER JOIN
                                                                          dbo.Register_to_Status AS rts ON r.Register_ID = rts.Register_ID INNER JOIN
                                                                          dbo.Status AS s ON rts.ABDStatus_ID = s.ABDSTATUS_ID AND s.CODE <> 'N/A' AND s.CODE IN ('YLNGs', 'HOfc') INNER JOIN
                                                                          dbo.JobCard_to_Marka AS jtm ON jtm.Marka_ID = m.Marka_ID INNER JOIN
                                                                          dbo.JobCard_to_TitleObject AS jtt ON jtt.TitleObject_ID = t.TitleObject_ID INNER JOIN
                                                                          dbo.JobCard AS j ON jtm.JobCard_ID = j.JobCard_ID AND jtt.JobCard_ID = j.JobCard_ID INNER JOIN
                                                                          dbo.Register_to_JobCard AS rtj ON rtj.Register_ID = r.Register_ID AND rtj.JobCard_ID = j.JobCard_ID
                                                   WHERE      (r.FileLOG LIKE '%COW%')
                                                   GROUP BY t.TitleObject_ID, m.Marka_ID) AS a_1 ON t.TitleObject_ID = a_1.TitleObject_ID AND m.Marka_ID = a_1.Marka_ID
                       WHERE     (r.FileLOG LIKE '%COW%')) AS res
GROUP BY TitleObject_Name, Marka_Name
*/

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[20] 4[3] 2[38] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "res"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 219
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_x_COW_Report_wo_groups_noLOG';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_x_COW_Report_wo_groups_noLOG';

