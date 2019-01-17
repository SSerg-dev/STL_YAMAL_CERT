CREATE VIEW dbo.R_UndergroundObject
AS
SELECT        uo.UndergroundObject_ID, uo.TitleObject_ID, t.TitleObject_Name, t.Description_Eng AS TitleObject_Description_Eng, t.Description_Rus AS TitleObject_Description_Rus, t.ReportColor AS TitleObject_Reportcolor, 
                         t.ReportOrder AS TitleObject_Reportorder, uo.SubTitleObject_ID, st.TitleObject_Name AS SubTitleObject_Name, st.Description_Eng AS SubTitleObject_Description_Eng, st.Description_Rus AS SubTitleObject_Description_Rus, 
                         st.ReportColor AS SubTitleObject_Reportcolor, st.ReportOrder AS SubTitleObject_Reportorder, uo.Marka_ID, m.Marka_Name, uo.ABDFinalSet
FROM            dbo.UndergroundObject AS uo INNER JOIN
                         dbo.TitleObject AS t ON uo.TitleObject_ID = t.TitleObject_ID INNER JOIN
                         dbo.TitleObject AS st ON uo.SubTitleObject_ID = st.TitleObject_ID INNER JOIN
                         dbo.Marka AS m ON uo.Marka_ID = m.Marka_ID LEFT OUTER JOIN
                         dbo.Phase AS p ON t.Phase_Name = p.Phase_Name LEFT OUTER JOIN
                         dbo.Phase AS sp ON st.Phase_Name = sp.Phase_Name

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
         Begin Table = "uo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 6
               Left = 287
               Bottom = 136
               Right = 523
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "st"
            Begin Extent = 
               Top = 6
               Left = 561
               Bottom = 136
               Right = 797
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "m"
            Begin Extent = 
               Top = 6
               Left = 835
               Bottom = 136
               Right = 1092
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 1130
               Bottom = 102
               Right = 1300
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sp"
            Begin Extent = 
               Top = 102
               Left = 1130
               Bottom = 198
               Right = 1300
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
         Width ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_UndergroundObject';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'= 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_UndergroundObject';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_UndergroundObject';

