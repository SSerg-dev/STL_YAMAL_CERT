

CREATE VIEW [dbo].[R_Register_CheckList]
AS
SELECT        r.Register_Code, sr.Description_Rus AS RegStatus, cl.CheckList_Code, ct.CheckType_Code, sl.Description_Rus AS CheckListStatus, i.Employee_Code AS ChecList_RespCode, p.ShortName AS CheckList_Resp_Shortname, 
                         po.Position_Description AS CheckList_Resp_Position, d.Division_Code AS CheckList_Resp_Division
FROM            dbo.Register AS r INNER JOIN
                         dbo.Register_to_Status AS rts ON rts.Register_ID = r.Register_ID INNER JOIN
                         dbo.Status AS sr ON rts.Status_ID = sr.Status_ID INNER JOIN
                         dbo.CheckList AS cl ON r.Register_ID = cl.Register_ID LEFT OUTER JOIN
                         dbo.Employee AS i ON cl.Resp_Employee_ID = i.Employee_ID LEFT OUTER JOIN
                         dbo.Person AS p ON i.Person_Id = p.Person_ID LEFT OUTER JOIN
                         dbo.Position AS po ON i.Position_Id = po.Position_ID LEFT OUTER JOIN
--                         dbo.Division AS d ON po.Division_ID = d.Division_ID INNER JOIN
-- New relation ====================
						dbo.Position_to_Division PTD ON po.Position_ID = PTD.Position_ID INNER JOIN
						dbo.Division D ON D.Division_ID = PTD.Division_ID INNER JOIN -- LEFT OUTER JOIN   
-- --------------------------------
                         dbo.CheckParty AS cp ON cl.CheckParty_ID = cp.CheckParty_ID INNER JOIN
                         dbo.CheckType AS ct ON ct.CheckType_ID = cp.CheckType_ID INNER JOIN
                         dbo.CheckList_to_Status AS clts ON clts.CheckList_ID = cl.CheckList_ID INNER JOIN
                         dbo.Status AS sl ON clts.Status_ID = sl.Status_ID

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
         Begin Table = "sr"
            Begin Extent = 
               Top = 6
               Left = 507
               Bottom = 136
               Right = 681
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cl"
            Begin Extent = 
               Top = 6
               Left = 719
               Bottom = 136
               Right = 930
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "i"
            Begin Extent = 
               Top = 6
               Left = 968
               Bottom = 136
               Right = 1148
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 138
               Left = 497
               Bottom = 268
               Right = 667
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "po"
            Begin Extent = 
               Top = 138
               Left = 705
               Bottom = 268
               Right = 902
            End
            DisplayFlags = 280
            TopColumn = 0
         End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_Register_CheckList';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'
         Begin Table = "d"
            Begin Extent = 
               Top = 138
               Left = 940
               Bottom = 268
               Right = 1110
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "clts"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sl"
            Begin Extent = 
               Top = 138
               Left = 285
               Bottom = 268
               Right = 459
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cp"
            Begin Extent = 
               Top = 138
               Left = 1148
               Bottom = 268
               Right = 1332
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ct"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 366
               Right = 219
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_Register_CheckList';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_Register_CheckList';

