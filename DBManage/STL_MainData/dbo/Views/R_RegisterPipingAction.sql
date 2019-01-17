CREATE VIEW dbo.R_RegisterPipingAction
AS
SELECT        dbo.p_PipingWorkType.PipingWorkType_ID, dbo.p_Register.Register_ID, dbo.p_ISO.ISO_ID, dbo.p_ISO.ISO_Number, dbo.p_Register.Register_Number, dbo.p_PipingWorkType.Description_Rus, 
                         dbo.p_PipingWorkType.Description_Eng, dbo.p_Register.LOG_ID, dbo.p_RegisterPipingAction.RegisterPipingAction_ID, dbo.p_ABDStatus.Code, dbo.p_ABDStatus.Description_Eng AS Expr1
FROM            dbo.p_RegisterPipingAction INNER JOIN
                         dbo.p_PipingWorkType ON dbo.p_RegisterPipingAction.PipingWorkType_ID = dbo.p_PipingWorkType.PipingWorkType_ID INNER JOIN
                         dbo.p_Register ON dbo.p_RegisterPipingAction.Register_ID = dbo.p_Register.Register_ID INNER JOIN
                         dbo.p_ISO ON dbo.p_RegisterPipingAction.ISO_ID = dbo.p_ISO.ISO_ID INNER JOIN
                         dbo.p_Register_to_ABDStatus ON dbo.p_Register.Register_ID = dbo.p_Register_to_ABDStatus.Register_ID INNER JOIN
                         dbo.p_ABDStatus ON dbo.p_Register_to_ABDStatus.ABDStatus_ID = dbo.p_ABDStatus.ABDStatus_ID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_RegisterPipingAction';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N's = 11
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_RegisterPipingAction';


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
         Begin Table = "p_RegisterPipingAction"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "p_PipingWorkType"
            Begin Extent = 
               Top = 6
               Left = 292
               Bottom = 135
               Right = 485
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "p_Register"
            Begin Extent = 
               Top = 6
               Left = 523
               Bottom = 135
               Right = 704
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "p_ISO"
            Begin Extent = 
               Top = 263
               Left = 381
               Bottom = 392
               Right = 551
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_Register_to_ABDStatus"
            Begin Extent = 
               Top = 6
               Left = 950
               Bottom = 136
               Right = 1173
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p_ABDStatus"
            Begin Extent = 
               Top = 153
               Left = 1214
               Bottom = 283
               Right = 1388
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
   End
   Begin CriteriaPane = 
      Begin ColumnWidth', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_RegisterPipingAction';

