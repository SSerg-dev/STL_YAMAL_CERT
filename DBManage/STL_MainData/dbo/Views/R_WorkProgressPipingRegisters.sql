
CREATE view [dbo].[R_WorkProgressPipingRegisters]
AS
SELECT        dbo.p_WorkProgressPipingRegisters.LogId, dbo.p_WorkProgressPipingRegisters.Reg, dbo.p_WorkPackage.WorkPackage_Name, 
                         dbo.p_WorkProgressPipingRegisters.Unit, dbo.p_WorkProgressPipingRegisters.Work_Desc, dbo.p_WorkProgressPipingRegisters.CNT_Date, 
                         dbo.p_WorkProgressPipingRegisters.Repr_SCNT, dbo.p_WorkProgressPipingRegisters.Repr_CNT, dbo.p_WorkProgressPipingRegisters.Status_Date, 
                         s.Description_Rus + N' / ' + s.Description_Eng AS Status_Name, dbo.p_Contragent.Code as SubContractor_Name, s.ReportColor, s.ReportOrder, '' AS Phase_Name
FROM            dbo.p_WorkProgressPipingRegisters INNER JOIN
                         dbo.p_WorkPackage ON dbo.p_WorkProgressPipingRegisters.WorkPackage_ID = dbo.p_WorkPackage.WorkPackage_ID INNER JOIN
                         dbo.p_ABDStatus AS s ON dbo.p_WorkProgressPipingRegisters.ABDStatus_ID = s.ABDStatus_ID INNER JOIN
                         dbo.p_WorkPackage_to_Contragent ON dbo.p_WorkPackage.WorkPackage_ID = dbo.p_WorkPackage_to_Contragent.WorkPackage_ID INNER JOIN
                         dbo.p_Contragent ON dbo.p_WorkPackage_to_Contragent.Contragent_ID = dbo.p_Contragent.Contragent_ID
WHERE        (dbo.p_WorkProgressPipingRegisters.row_status < 100) AND (s.Description_Rus + N' / ' + s.Description_Eng <> N'Аннулирован / Cancelled')

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[15] 4[50] 2[21] 3) )"
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
         Top = -5404
         Left = -1311
      End
      Begin Tables = 
         Begin Table = "p_WorkProgressPipingRegisters"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 260
               Right = 298
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_WorkPackage"
            Begin Extent = 
               Top = 6
               Left = 336
               Bottom = 136
               Right = 550
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 741
               Bottom = 114
               Right = 898
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_WorkPackage_to_SubContractor"
            Begin Extent = 
               Top = 94
               Left = 1017
               Bottom = 223
               Right = 1292
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_SubContractor"
            Begin Extent = 
               Top = 203
               Left = 718
               Bottom = 332
               Right = 940
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
      Begin ColumnWidths = 15
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
         Width = 1500', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressPipingRegisters';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3555
         Alias = 900
         Table = 5865
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressPipingRegisters';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressPipingRegisters';

