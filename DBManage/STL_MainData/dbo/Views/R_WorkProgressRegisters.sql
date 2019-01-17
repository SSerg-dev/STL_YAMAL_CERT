
CREATE view [dbo].[R_WorkProgressRegisters]
AS
SELECT        wpr.LogId, wpr.Reg, wp.WorkPackage_Name, t.TitleObject_Name, wpr.Unit, m.Marka_Name, wpr.Work_Desc, wpr.CNT_Date, wpr.Repr_SCNT, 
                         wpr.Repr_CNT, wpr.Status_Date, s.Description_Rus + ' / ' + s.Description_Eng AS Status_Name, wpr.Insert_DTS, dbo.p_Contragent.Code as SubContractor_Name, 
                         s.ReportColor, s.ReportOrder, m.Marka_ID, t.TitleObject_ID
FROM            dbo.p_WorkProgressRegisters AS wpr INNER JOIN
                         dbo.p_RowStatus_sys AS rs ON wpr.Row_Status = rs.Row_Status AND rs.row_status < 100 INNER JOIN
                         dbo.p_WorkPackage AS wp ON wpr.WorkPackage_ID = wp.WorkPackage_ID INNER JOIN
                         dbo.p_TitleObject AS t ON wpr.TitleObject_ID = t.TitleObject_ID INNER JOIN
                         dbo.p_Marka AS m ON wpr.Marka_ID = m.Marka_ID INNER JOIN
                         dbo.p_ABDStatus AS s ON wpr.ABDStatus_ID = s.ABDStatus_ID INNER JOIN
                         dbo.p_WorkPackage_to_Contragent ON rs.Row_Status = dbo.p_WorkPackage_to_Contragent.Row_Status AND 
                         wp.WorkPackage_ID = dbo.p_WorkPackage_to_Contragent.WorkPackage_ID INNER JOIN
                         dbo.p_Contragent ON rs.Row_Status = dbo.p_Contragent.Row_status AND 
                         dbo.p_WorkPackage_to_Contragent.Contragent_ID = dbo.p_Contragent.Contragent_ID
WHERE        (wpr.row_status < 100) AND (s.Description_Rus + ' / ' + s.Description_Eng <> N'Аннулирован / Cancelled')

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[24] 2[16] 3) )"
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
         Begin Table = "wpr"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 263
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "rs"
            Begin Extent = 
               Top = 6
               Left = 301
               Bottom = 135
               Right = 488
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "wp"
            Begin Extent = 
               Top = 6
               Left = 526
               Bottom = 135
               Right = 739
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 777
               Bottom = 101
               Right = 947
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 121
               Left = 771
               Bottom = 250
               Right = 978
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
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 985
               Bottom = 135
               Right = 1159
            End
            DisplayFlags = 280
            TopColumn = 0
         End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressRegisters';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         Begin Table = "p_WorkPackage_to_SubContractor"
            Begin Extent = 
               Top = 175
               Left = 1235
               Bottom = 304
               Right = 1510
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_SubContractor"
            Begin Extent = 
               Top = 67
               Left = 1324
               Bottom = 196
               Right = 1546
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
         Column = 5430
         Alias = 2520
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressRegisters';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressRegisters';

