

CREATE VIEW [dbo].[UI_RegisterList]
AS
SELECT     r.Register_ID, r.LOG_ID, r.Register_Number, '' AS Phase, t.TitleObject_Name, '' AS [Target (Unit/ISO)], m.Marka_Name, r.Work_Desc, r.CNT_Date, r.SCTR_RESP, 
                      r.CTR_RESP, rts.ABDStatusDate, s.Description_Rus, r.Notes, t.ReportColor AS TitleColor, t.ReportOrder AS TitleOrder, m.ReportColor AS MarkaColor, 
                      m.ReportOrder AS MarkaOrder, s.ReportColor AS StatusColor, s.ReportOrder AS StatusOrder, t.TitleObject_ID, m.Marka_ID, s.ABDStatus_ID, r.WorkPackage_ID, 
                      w.WorkPackage_Name
FROM         dbo.Register AS r LEFT OUTER JOIN
                      dbo.Register_to_TitleObject AS rtt ON rtt.Register_ID = r.Register_ID LEFT OUTER JOIN
                      dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID LEFT OUTER JOIN
                      dbo.Register_to_Marka AS rtm ON rtm.Register_ID = r.Register_ID LEFT OUTER JOIN
                      dbo.Marka AS m ON rtm.Marka_ID = m.Marka_ID LEFT OUTER JOIN
                      dbo.Register_to_ABDStatus AS rts ON rts.Register_ID = r.Register_ID LEFT OUTER JOIN
                      dbo.Status AS s ON rts.ABDStatus_ID = s.ABDStatus_ID LEFT OUTER JOIN
                      dbo.WorkPackage AS w ON r.WorkPackage_ID = w.WorkPackage_ID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'       End
         Begin Table = "w"
            Begin Extent = 
               Top = 206
               Left = 82
               Bottom = 314
               Right = 260
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
      Begin ColumnWidths = 26
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
      Begin ColumnWidths = 11
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_RegisterList';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_RegisterList';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "r"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 167
               Right = 238
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "rtt"
            Begin Extent = 
               Top = 113
               Left = 355
               Bottom = 221
               Right = 566
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 210
               Left = 600
               Bottom = 318
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "rtm"
            Begin Extent = 
               Top = 74
               Left = 696
               Bottom = 182
               Right = 884
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "m"
            Begin Extent = 
               Top = 147
               Left = 954
               Bottom = 382
               Right = 1189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rts"
            Begin Extent = 
               Top = 6
               Left = 1241
               Bottom = 114
               Right = 1433
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 201
               Left = 1251
               Bottom = 339
               Right = 1466
            End
            DisplayFlags = 280
            TopColumn = 4
  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_RegisterList';

