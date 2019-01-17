CREATE VIEW dbo.R_WorkProgressPipingQuantity
AS
SELECT        wpq.WorkProgressPipingQuantity_ID, wpq.Parent_ID, wpq.LogID, dbo.p_TitleObject.TitleObject_Name, dbo.p_Marka.Marka_Name, 
                         dbo.p_WorkPackage.WorkPackage_Name, '' AS Expr1, dbo.p_Line.Line_Number, wpq.Design_Area, wpq.Sheet, dbo.p_ISO.ISO_Number, wpq.Shop_Weld_RegNum, 
                         wpq.Shop_Weld_AD_cur_State, wpq.Shop_Weld_Issued_SCTR, wpq.Shop_Weld_Accepted_CPY, wpq.Field_Weld_RegNum, wpq.Field_Weld_AD_cur_State, 
                         wpq.Field_Weld_Issued_SCTR, wpq.Field_Weld_Accepted_CPY, wpq.AKZ_Shop_RegNum, wpq.AKZ_Shop_AD_cur_State, wpq.AKZ_Shop_Issued_SCTR, 
                         wpq.AKZ_Shop_Accepted_CPY, wpq.AKZ_Weld_RegNum, wpq.AKZ_Weld_AD_cur_State, wpq.AKZ_Weld_Issued_SCTR, wpq.AKZ_Weld_Accepted_CPY, 
                         wpq.GW_RegNum_RegNum, wpq.GW_AD_cur_State, wpq.GW_Issued_SCTR, wpq.GW_Accepted_CPY, wpq.Insulation_RegNum, wpq.Insulation_AD_cur_State, 
                         wpq.Insulation_Issued_SCTR, wpq.Insulation_Accepted_CPY, wpq.Test_Density_Strength, wpq.Test_Leak, wpq.Certificate_Installation, 
                         dbo.p_TitleObject.TitleObject_ID, dbo.p_Marka.Marka_ID, wpq.WorkPackage_ID, dbo.p_TitleObject.Phase_Name
FROM            dbo.p_WorkProgressPipingQuantity AS wpq INNER JOIN
                         dbo.p_WorkPackage ON wpq.WorkPackage_ID = dbo.p_WorkPackage.WorkPackage_ID INNER JOIN
                         dbo.p_Line ON wpq.Line_ID = dbo.p_Line.Line_ID INNER JOIN
                         dbo.p_ISO ON wpq.ISO_ID = dbo.p_ISO.ISO_ID INNER JOIN
                         dbo.p_ISO_to_Marka ON dbo.p_ISO.ISO_ID = dbo.p_ISO_to_Marka.ISO_ID INNER JOIN
                         dbo.p_Marka ON dbo.p_ISO_to_Marka.Marka_ID = dbo.p_Marka.Marka_ID INNER JOIN
                         dbo.p_ISO_to_TitleObject ON dbo.p_ISO.ISO_ID = dbo.p_ISO_to_TitleObject.ISO_ID INNER JOIN
                         dbo.p_TitleObject ON dbo.p_ISO_to_TitleObject.TitleObject_ID = dbo.p_TitleObject.TitleObject_ID
WHERE        (wpq.Row_Status < 100)

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[45] 4[17] 2[17] 3) )"
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
         Top = -21
         Left = -504
      End
      Begin Tables = 
         Begin Table = "wpq"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 332
               Right = 519
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "p_WorkPackage"
            Begin Extent = 
               Top = 6
               Left = 557
               Bottom = 114
               Right = 735
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_Line"
            Begin Extent = 
               Top = 270
               Left = 559
               Bottom = 378
               Right = 843
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_ISO"
            Begin Extent = 
               Top = 6
               Left = 1284
               Bottom = 114
               Right = 1435
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_ISO_to_Marka"
            Begin Extent = 
               Top = 166
               Left = 1803
               Bottom = 295
               Right = 1980
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_Marka"
            Begin Extent = 
               Top = 298
               Left = 1161
               Bottom = 427
               Right = 1418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_ISO_to_TitleObject"
            Begin Extent = 
               Top = 148
               Left = 842
               Bottom = 277
               Right = 1044
            End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressPipingQuantity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_TitleObject"
            Begin Extent = 
               Top = 164
               Left = 1279
               Bottom = 293
               Right = 1486
            End
            DisplayFlags = 280
            TopColumn = 7
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 42
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
         Column = 5745
         Alias = 900
         Table = 1170
         Output = 3600
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressPipingQuantity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_WorkProgressPipingQuantity';

