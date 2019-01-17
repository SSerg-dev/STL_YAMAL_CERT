CREATE VIEW dbo.WPPipingQuantityErrors
AS
SELECT        ER.Log_ID, ER.Title, ER.Marka, ER.Line, ER.Design_Area, ER.Sheet, ER.ISO, ER.Shop_Weld_RegNum, ER.Shop_Weld_AD_cur_State, ER.Shop_Weld_Issued_SCTR, ER.Shop_Weld_Accepted_CPY, ER.Field_Weld_RegNum, 
                         ER.Field_Weld_cur_State, ER.Field_Weld_Issued_SCTR, ER.Field_Weld_Accepted_CPY, ER.AKZ_Shop_RegNum, ER.AKZ_Shop_cur_State, ER.AKZ_Shop_Issued_SCTR, ER.AKZ_Shop_Accepted_CPY, ER.AKZ_Weld_RegNum, 
                         ER.AKZ_Weld_cur_State, ER.AKZ_Weld_Issued_SCTR, ER.GW_RegNum_RegNum, ER.AKZ_Weld_Accepted_CPY, ER.GW_cur_State, ER.GW_Issued_SCTR, ER.GW_Accepted_CPY, ER.Insulation_RegNum, 
                         ER.Insulation_cur_State, ER.Insulation_Issued_SCTR, ER.Insulation_Accepted_CPY, ER.Test_Density_Strength, ER.Test_Leak, ER.Certificate_Installation, ER.Source_File, ER.Error_Code, ER.Load_Date, ER.Error_Column, 
                         CASE WHEN Len(ER.Reason) > 3 THEN ER.Reason ELSE E.Description_Rus + ' / ' + E.Description_Eng END AS Reason
FROM            dbo.s_WPPipingQuantityErrors AS ER LEFT OUTER JOIN
                         dbo.p_ValidationErrors AS E ON E.Number = ER.Reason

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
         Begin Table = "ER"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 253
               Right = 284
            End
            DisplayFlags = 280
            TopColumn = 27
         End
         Begin Table = "E"
            Begin Extent = 
               Top = 9
               Left = 423
               Bottom = 267
               Right = 666
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'WPPipingQuantityErrors';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'WPPipingQuantityErrors';

