CREATE VIEW [dbo].[UI_Personal]
AS
SELECT 
	 a.Employee_ID
	,a.Employee_Code
	,b.Person_ID
	,b.Person_Code
	,b.FirstName
	,b.SecondName
	,b.LastName
	,b.ShortName
	,FullName = FirstName + N' ' + SecondName  + N' ' + LastName
	,c.Position_ID
	,c.Position_Code
	,c.Position_Description
	,d.AppUser_ID
	,d.AppUser_Code
	,e.Division_ID
	,e.Division_Code
	,f.Contragent_ID
	,f.Contragent_Code
	,f.Description_Rus
	,b.BirthDate
FROM dbo.Employee AS a LEFT OUTER JOIN
dbo.Person AS b ON a.Person_ID = b.Person_ID LEFT OUTER JOIN
dbo.Position AS c ON a.Position_ID = c.Position_ID LEFT OUTER JOIN
dbo.AppUser AS d ON a.AppUser_ID = d.AppUser_ID LEFT OUTER JOIN
dbo.Position_to_Division AS c2e ON c.Position_ID = c2e.Position_ID LEFT OUTER JOIN
dbo.Division AS e ON c2e.Division_ID = e.Division_ID LEFT OUTER JOIN
dbo.Contragent AS f ON a.Contragent_ID = f.Contragent_ID
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_Personal';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'     End
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_Personal';


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
               Bottom = 136
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 269
               Right = 418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 458
               Bottom = 119
               Right = 655
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 693
               Bottom = 136
               Right = 863
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c2e"
            Begin Extent = 
               Top = 6
               Left = 901
               Bottom = 136
               Right = 1112
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 6
               Left = 1150
               Bottom = 136
               Right = 1320
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "f"
            Begin Extent = 
               Top = 120
               Left = 458
               Bottom = 250
               Right = 640
            End
            DisplayFlags = 280
            TopColumn = 0
         End
 ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'UI_Personal';

