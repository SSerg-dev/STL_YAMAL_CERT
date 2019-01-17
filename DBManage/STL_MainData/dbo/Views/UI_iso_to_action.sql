CREATE view dbo.UI_iso_to_action
AS
SELECT        RA.RegisterAction_ID, RA.Register_ID, R.Register_Number, R.WorkPackage_ID, WP.WorkPackage_Name, RA.PipingWorkType_ID, 
                         WT.Description_Eng AS PipingWorkType_Eng, RA.ISO_ID, I.ISO_Number
FROM            dbo.p_RegisterAction AS RA INNER JOIN
                         dbo.p_RowStatus_sys AS RS ON RS.Row_Status = RA.Row_Status AND RS.row_status < 100 INNER JOIN
                         dbo.p_Register AS R ON RA.Register_ID = R.Register_ID INNER JOIN
                         dbo.p_WorkPackage AS WP ON R.WorkPackage_ID = WP.WorkPackage_ID INNER JOIN
                         dbo.p_PipingWorkType AS WT ON RA.PipingWorkType_ID = WT.PipingWorkType_ID INNER JOIN
                         dbo.p_ISO AS I ON RA.ISO_ID = I.ISO_ID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  Width = 2370
         Width = 2580
         Width = 1500
         Width = 1500
         Width = 3450
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_iso_to_action';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_iso_to_action';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[46] 4[15] 2[20] 3) )"
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
         Begin Table = "RS"
            Begin Extent = 
               Top = 3
               Left = 1296
               Bottom = 132
               Right = 1483
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WT"
            Begin Extent = 
               Top = 161
               Left = 601
               Bottom = 290
               Right = 794
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "R"
            Begin Extent = 
               Top = 104
               Left = 996
               Bottom = 233
               Right = 1177
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "I"
            Begin Extent = 
               Top = 174
               Left = 281
               Bottom = 303
               Right = 451
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WP"
            Begin Extent = 
               Top = 153
               Left = 1275
               Bottom = 282
               Right = 1473
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RA"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 231
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
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
       ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_iso_to_action';

