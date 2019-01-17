/*if object_id('dbo.WorkProgressQuantity','V') > 0 drop view dbo.WorkProgressQuantity
go*/
CREATE VIEW dbo.WorkProgressPipingQuantity
AS
SELECT        WorkProgressPipingQuantity_ID, Parent_ID, LogID, WorkPackage_ID, TitleObject_ID, Marka_ID, Line_ID, Design_Area, Sheet, ISO_ID, Shop_Weld_RegNum, Shop_Weld_AD_cur_State, Shop_Weld_Issued_SCTR, 
                         Shop_Weld_Accepted_CPY, Field_Weld_RegNum, Field_Weld_AD_cur_State, Field_Weld_Issued_SCTR, Field_Weld_Accepted_CPY, AKZ_Shop_RegNum, AKZ_Shop_AD_cur_State, AKZ_Shop_Issued_SCTR, 
                         AKZ_Shop_Accepted_CPY, AKZ_Weld_RegNum, AKZ_Weld_AD_cur_State, AKZ_Weld_Issued_SCTR, AKZ_Weld_Accepted_CPY, GW_RegNum_RegNum, GW_AD_cur_State, GW_Issued_SCTR, GW_Accepted_CPY, 
                         Insulation_RegNum, Insulation_AD_cur_State, Insulation_Issued_SCTR, Insulation_Accepted_CPY, Test_Density_Strength, Test_Leak, Certificate_Installation, Row_Status, Insert_DTS, Update_DTS, Source_File
FROM            dbo.p_WorkProgressPipingQuantity AS a
WHERE        (Row_Status < 100)

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
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 227
               Right = 354
            End
            DisplayFlags = 344
            TopColumn = 31
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'WorkProgressPipingQuantity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'WorkProgressPipingQuantity';

