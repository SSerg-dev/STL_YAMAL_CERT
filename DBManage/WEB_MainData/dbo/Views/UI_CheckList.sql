CREATE VIEW dbo.UI_CheckList
AS
SELECT        cl.CheckList_Code, cl.CheckList_Date, cp.CheckParty_Code, po.Position_Description, p.ShortName, sl.Description_Rus AS CheckList_Status, cl.Register_ID, cl.CheckList_ID, sl.Status_Code, sl.Status_ID, po.Position_ID, 
                         p.Person_ID, cp.CheckType_ID, dbo.CheckType.CheckType_Code
FROM            dbo.CheckList AS cl LEFT OUTER JOIN
                         dbo.Employee AS i ON cl.Resp_Employee_ID = i.Employee_ID LEFT OUTER JOIN
                         dbo.Person AS p ON i.Person_ID = p.Person_ID LEFT OUTER JOIN
                         dbo.Position AS po ON po.Position_ID = i.Position_ID INNER JOIN
                         dbo.CheckParty AS cp ON cl.CheckParty_ID = cp.CheckParty_ID INNER JOIN
                         dbo.CheckList_to_Status AS clts ON cl.CheckList_ID = clts.CheckList_ID INNER JOIN
                         dbo.Status AS sl ON clts.Status_ID = sl.Status_ID INNER JOIN
                         dbo.CheckType ON cp.CheckType_ID = dbo.CheckType.CheckType_ID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_CheckList';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'd
         Begin Table = "CheckType"
            Begin Extent = 
               Top = 205
               Left = 1146
               Bottom = 335
               Right = 1327
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
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1890
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_CheckList';










GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[58] 4[13] 2[12] 3) )"
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
         Begin Table = "cl"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 224
               Right = 231
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "i"
            Begin Extent = 
               Top = 6
               Left = 269
               Bottom = 186
               Right = 449
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 487
               Bottom = 136
               Right = 657
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "po"
            Begin Extent = 
               Top = 6
               Left = 695
               Bottom = 136
               Right = 892
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cp"
            Begin Extent = 
               Top = 6
               Left = 930
               Bottom = 219
               Right = 1114
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "clts"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 307
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sl"
            Begin Extent = 
               Top = 196
               Left = 309
               Bottom = 326
               Right = 483
            End
            DisplayFlags = 280
            TopColumn = 0
         En', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_CheckList';





