CREATE VIEW dbo.FinalABDCompilation
AS
SELECT        FF.ABDFinalFolder_ID, FF.ABDFinalFolder_Name, FF.CTR_RESP, FF.Final_Compilation_Start_Date, FF.Final_Compilation_Target_Date, FF.ListCount, FS.ABDFinalSet_ID, FS.ABDFinalSet_Number, S.ABDStatus_ID, 
                         S.Description_Eng AS Status_ENG, S.Description_Rus AS Status_Rus, TOBJ.TitleObject_ID, TOBJ.TitleObject_Name, SC.Contragent_ID AS SubContractor_Id, SC.Code AS SubContractor_Name, M.Marka_ID, M.Marka_Name, 
                         T.Transmittal_ID, T.Transmittal_Code, S.ReportColor, S.ReportOrder, S.Description_Rus + ' / ' + S.Description_Eng AS FoldedStatus, NEWID() AS NewGUID
FROM            dbo.ABDFinalFolder AS FF INNER JOIN
                         dbo.ABDFinalFolder_to_ABDFinalSet AS FF_R_FS ON FF.ABDFinalFolder_ID = FF_R_FS.ABDFinalFolder_ID INNER JOIN
                         dbo.ABDFinalSet AS FS ON FS.ABDFinalSet_ID = FF_R_FS.ABDFinalSet_ID INNER JOIN
                         dbo.ABDFinalFolder_to_ABDStatus AS FF_R_S ON FF_R_S.ABDFinalFolder_ID = FF.ABDFinalFolder_ID INNER JOIN
                         dbo.ABDFinalFolder_to_Contragent AS FF_R_SC ON FF_R_SC.ABDFinalFolder_ID = FF.ABDFinalFolder_ID LEFT OUTER JOIN
                         dbo.ABDFinalFolder_to_Transmittal AS FRT ON FF.ABDFinalFolder_ID = FRT.ABDFinalFolder_ID INNER JOIN
                         dbo.TitleObject AS TOBJ ON TOBJ.TitleObject_ID = FS.TitleObject_ID INNER JOIN
                         dbo.Contragent AS SC ON SC.Contragent_ID = FF_R_SC.Contragent_ID INNER JOIN
                         dbo.ABDStatus AS S ON S.ABDStatus_ID = FF_R_S.ABDStatus_ID INNER JOIN
                         dbo.Marka AS M ON M.Marka_ID = FS.Marka_ID LEFT OUTER JOIN
                         dbo.Transmittal AS T ON T.Transmittal_ID = FRT.Transmittal_ID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'olumn = 0
         End
         Begin Table = "SC"
            Begin Extent = 
               Top = 930
               Left = 38
               Bottom = 1042
               Right = 260
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "S"
            Begin Extent = 
               Top = 270
               Left = 278
               Bottom = 399
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "M"
            Begin Extent = 
               Top = 1044
               Left = 38
               Bottom = 1173
               Right = 295
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T"
            Begin Extent = 
               Top = 798
               Left = 283
               Bottom = 927
               Right = 465
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FinalABDCompilation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FinalABDCompilation';


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
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "FF"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 291
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FF_R_FS"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 309
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FS"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 399
               Right = 240
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FF_R_S"
            Begin Extent = 
               Top = 402
               Left = 38
               Bottom = 531
               Right = 303
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FF_R_SC"
            Begin Extent = 
               Top = 534
               Left = 38
               Bottom = 663
               Right = 322
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FRT"
            Begin Extent = 
               Top = 666
               Left = 38
               Bottom = 795
               Right = 305
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TOBJ"
            Begin Extent = 
               Top = 798
               Left = 38
               Bottom = 927
               Right = 245
            End
            DisplayFlags = 280
            TopC', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FinalABDCompilation';

