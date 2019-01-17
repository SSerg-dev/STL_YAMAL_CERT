
CREATE VIEW [dbo].[R_CheckList]
AS
SELECT        cl.CheckList_Code, cl.CheckList_Date, cp.CheckParty_Code, po.Position_Description, p.ShortName, sl.Description_Rus AS CheckList_Status, ci.Comment, si.Description_Rus AS CheckItem_Status
FROM            dbo.CheckList AS cl LEFT OUTER JOIN
                         dbo.Employee AS i ON cl.Resp_Employee_ID = i.Employee_ID LEFT OUTER JOIN
                         dbo.Person AS p ON i.Person_Id = p.Person_ID LEFT OUTER JOIN
                         dbo.Position AS po ON po.Position_ID = i.Position_Id INNER JOIN
                         dbo.CheckParty AS cp ON cl.CheckParty_ID = cp.CheckParty_ID INNER JOIN
                         dbo.CheckList_to_Status AS clts ON cl.CheckList_ID = clts.CheckList_ID INNER JOIN
                         dbo.Status AS sl ON clts.Status_ID = sl.Status_ID LEFT OUTER JOIN
                         dbo.CheckItem AS ci ON cl.CheckList_ID = ci.CheckList_ID LEFT OUTER JOIN
						 dbo.CheckItem_to_Status AS cits ON ci.CheckItem_ID = cits.CheckItem_ID LEFT OUTER JOIN
                         dbo.Status AS si ON cits.Status_ID = si.Status_ID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'nd
         Begin Table = "ci"
            Begin Extent = 
               Top = 6
               Left = 950
               Bottom = 136
               Right = 1120
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "si"
            Begin Extent = 
               Top = 6
               Left = 1158
               Bottom = 136
               Right = 1332
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_CheckList';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_CheckList';


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
         Begin Table = "cl"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 231
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "i"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 138
               Left = 256
               Bottom = 268
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "po"
            Begin Extent = 
               Top = 138
               Left = 464
               Bottom = 268
               Right = 661
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cp"
            Begin Extent = 
               Top = 6
               Left = 269
               Bottom = 136
               Right = 453
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "clts"
            Begin Extent = 
               Top = 6
               Left = 491
               Bottom = 136
               Right = 700
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sl"
            Begin Extent = 
               Top = 6
               Left = 738
               Bottom = 136
               Right = 912
            End
            DisplayFlags = 280
            TopColumn = 0
         E', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_CheckList';

