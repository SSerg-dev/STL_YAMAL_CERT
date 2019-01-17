CREATE VIEW dbo.UI_CheckItem
AS
SELECT        dbo.CheckList.CheckList_Code, ci.CheckItem_Name, ci.Comment, dbo.Person.ShortName, dbo.Position.Position_Code, si.Status_ID, si.Description_Rus AS CheckItem_Status, ci.Update_DTS, ci.Position, 
                         dbo.CheckList.CheckList_ID, ci.CheckItem_ID, dbo.Division.Division_Name, ci.Document_ID, dbo.[Document].Document_Name, dbo.CheckList.Register_ID, dbo.[Document].Document_Number, ci.Issued_Date, 
                         si.Status_Code
FROM            dbo.CheckList INNER JOIN
                         dbo.CheckItem AS ci ON dbo.CheckList.CheckList_ID = ci.CheckList_ID INNER JOIN
                         dbo.AppUser ON ci.Modified_User_ID = dbo.AppUser.AppUser_ID LEFT OUTER JOIN
                         dbo.Employee ON dbo.AppUser.AppUser_ID = dbo.Employee.AppUser_ID LEFT OUTER JOIN
                         dbo.Person ON dbo.Employee.Person_ID = dbo.Person.Person_ID LEFT OUTER JOIN
                         dbo.Position ON dbo.Employee.Position_ID = dbo.Position.Position_ID LEFT OUTER JOIN
                         dbo.Position_to_Division ON dbo.Position.Position_ID = dbo.Position_to_Division.Position_ID LEFT OUTER JOIN
                         dbo.CheckItem_to_Status AS cits ON ci.CheckItem_ID = cits.CheckItem_ID LEFT OUTER JOIN
                         dbo.Status AS si ON cits.Status_ID = si.Status_ID LEFT OUTER JOIN
                         dbo.Division ON dbo.Position_to_Division.Division_ID = dbo.Division.Division_ID LEFT OUTER JOIN
                         dbo.[Document] ON ci.Document_ID = dbo.[Document].Document_ID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'layFlags = 280
            TopColumn = 0
         End
         Begin Table = "cits"
            Begin Extent = 
               Top = 6
               Left = 854
               Bottom = 136
               Right = 1069
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "si"
            Begin Extent = 
               Top = 303
               Left = 197
               Bottom = 442
               Right = 406
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Division"
            Begin Extent = 
               Top = 293
               Left = 471
               Bottom = 423
               Right = 641
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Document"
            Begin Extent = 
               Top = 444
               Left = 38
               Bottom = 574
               Right = 232
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
      Begin ColumnWidths = 18
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2355
         Alias = 3375
         Table = 1170
         Output = 2190
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_CheckItem';










GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_CheckItem';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[33] 4[29] 2[22] 3) )"
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
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CheckList"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 247
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ci"
            Begin Extent = 
               Top = 6
               Left = 269
               Bottom = 262
               Right = 613
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AppUser"
            Begin Extent = 
               Top = 6
               Left = 651
               Bottom = 205
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 252
               Left = 38
               Bottom = 382
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Person"
            Begin Extent = 
               Top = 221
               Left = 1036
               Bottom = 365
               Right = 1217
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Position"
            Begin Extent = 
               Top = 216
               Left = 742
               Bottom = 401
               Right = 974
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Position_to_Division"
            Begin Extent = 
               Top = 264
               Left = 250
               Bottom = 394
               Right = 461
            End
            Disp', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_CheckItem';









