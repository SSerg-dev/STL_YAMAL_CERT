CREATE VIEW dbo.R_WorkProgressQuantity
AS
SELECT        wpq.LogId, wp.WorkPackage_Name, wpq.Num, t.TitleObject_Name, wpq.Unit, m.Marka_Name, wpq.Activity_Desc, wpq.UOM, wpq.Design_Target, wpq.Fact_Volume, wpq.Fact_Percent, wpq.Test_Done, wpq.Acts_Prepared_CNT, 
                         wpq.Acts_Prepared_Percent, wpq.Reg, wpq.Under_Review_CNT, wpq.Under_Review_Percent, wpq.Commented_CNT, wpq.Commented_Percent, wpq.Approved_CNT, wpq.Approved_Percent, wpq.Multiple, wpq.Issues, 
                         wpq.Insert_DTS, t.TitleObject_ID, m.Marka_ID, wp.WorkPackage_ID
FROM            dbo.p_WorkProgressQuantity AS wpq INNER JOIN
                         dbo.p_RowStatus_sys AS rs ON wpq.Row_Status = rs.Row_Status AND rs.Row_Status < 100 INNER JOIN
                         dbo.p_WorkPackage AS wp ON wpq.WorkPackage_ID = wp.WorkPackage_ID INNER JOIN
                         dbo.p_TitleObject AS t ON wpq.TitleObject_ID = t.TitleObject_ID INNER JOIN
                         dbo.p_Marka AS m ON wpq.Marka_ID = m.Marka_ID
WHERE        (wpq.Row_Status < 100)

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
         Begin Table = "wpq"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 262
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rs"
            Begin Extent = 
               Top = 6
               Left = 300
               Bottom = 135
               Right = 487
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "wp"
            Begin Extent = 
               Top = 6
               Left = 525
               Bottom = 135
               Right = 738
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 102
               Left = 776
               Bottom = 231
               Right = 983
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "m"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 295
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
      Begin ColumnWidths = 11
         Column = 2760
         Alias = 900
         Table = 1170
         Outp', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressQuantity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'ut = 720
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressQuantity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressQuantity';

