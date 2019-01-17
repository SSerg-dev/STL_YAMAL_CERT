CREATE VIEW dbo.R_LOGID_to_Contragent
AS
WITH Logs(ConvertedLog_ID, WorkPackage_Name, lWorkPackage_ID) AS (SELECT DISTINCT CAST(sq.LOG_ID AS nvarchar(255)) AS ConvertedLog_ID, wp.WorkPackage_Name, wp.WorkPackage_ID
                                                                                                                                                                  FROM            dbo.Register AS sq INNER JOIN
                                                                                                                                                                                           dbo.WorkPackage AS wp ON sq.LOG_ID LIKE wp.WorkPackage_Name + '%' AND (wp.WorkPackage_Name LIKE '%bis%' OR
                                                                                                                                                                                           wp.WorkPackage_Name LIKE '%qua%' OR
                                                                                                                                                                                           wp.WorkPackage_Name LIKE '%ter%')
                                                                                                                                                                  UNION ALL
                                                                                                                                                                  SELECT DISTINCT CAST(sq.LOG_ID AS nvarchar(255)) AS ConvertedLog_ID, wp.WorkPackage_Name, wp.WorkPackage_ID
                                                                                                                                                                  FROM            dbo.Register AS sq INNER JOIN
                                                                                                                                                                                           dbo.WorkPackage AS wp ON sq.LOG_ID LIKE wp.WorkPackage_Name + '%' AND sq.LOG_ID NOT LIKE '%bis%' AND sq.LOG_ID NOT LIKE '%qua%' AND 
                                                                                                                                                                                           sq.LOG_ID NOT LIKE '%ter%'), Contr(WorkPackage_ID, Code, Contragent_ID) AS
    (SELECT        w.WorkPackage_ID, c.Code, c.Contragent_ID
      FROM            dbo.WorkPackage AS w INNER JOIN
                                dbo.WorkPackage_to_Contragent AS wtc ON w.WorkPackage_ID = wtc.WorkPackage_ID INNER JOIN
                                dbo.Contragent AS c ON wtc.Contragent_ID = c.Contragent_ID)
    SELECT        Logs_1.ConvertedLog_ID AS Reg_LOG_ID, Contr_1.Code, Contr_1.WorkPackage_ID, Contr_1.Contragent_ID, l.LogId_ID, l.LogId_Code
     FROM            Logs AS Logs_1 INNER JOIN
                              Contr AS Contr_1 ON Logs_1.lWorkPackage_ID = Contr_1.WorkPackage_ID INNER JOIN
                              dbo.p_LogId AS l ON Logs_1.ConvertedLog_ID = l.LogId_Code

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
         Begin Table = "Logs_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "l"
            Begin Extent = 
               Top = 17
               Left = 384
               Bottom = 147
               Right = 554
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Contr_1"
            Begin Extent = 
               Top = 6
               Left = 592
               Bottom = 119
               Right = 769
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
         Width = 1830
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_LOGID_to_Contragent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_LOGID_to_Contragent';

