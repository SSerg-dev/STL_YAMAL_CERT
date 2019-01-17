CREATE VIEW dbo.R_Register_to_Document
AS
SELECT        r.Register_Code, s.Description_Rus AS Register_Status, r.Current_Iteration, rtd.Iteration AS DocumentLinkIteration, d.Document_Code, d.Document_Number, sd.Description_Rus AS Document_Status
FROM            dbo.Register AS r INNER JOIN
                         dbo.Register_to_Status AS rts ON r.Register_ID = rts.Register_ID LEFT OUTER JOIN
                         dbo.Register_to_Document AS rtd ON r.Register_ID = rtd.Register_ID LEFT OUTER JOIN
                         dbo.[Document] AS d ON d.Document_ID = rtd.Document_ID LEFT OUTER JOIN
                         dbo.Document_to_Status AS dts ON d.Document_ID = dts.Document_ID LEFT OUTER JOIN
                         dbo.Status AS sd ON dts.Status_ID = sd.Status_ID LEFT OUTER JOIN
                         dbo.Status AS s ON rts.Status_ID = s.Status_ID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_Register_to_Document';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' End
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_Register_to_Document';


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
               Bottom = 136
               Right = 231
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rts"
            Begin Extent = 
               Top = 6
               Left = 269
               Bottom = 136
               Right = 469
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rtd"
            Begin Extent = 
               Top = 6
               Left = 507
               Bottom = 136
               Right = 731
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 769
               Bottom = 136
               Right = 963
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "dts"
            Begin Extent = 
               Top = 6
               Left = 1001
               Bottom = 119
               Right = 1215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sd"
            Begin Extent = 
               Top = 120
               Left = 1001
               Bottom = 250
               Right = 1175
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
        ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_Register_to_Document';

