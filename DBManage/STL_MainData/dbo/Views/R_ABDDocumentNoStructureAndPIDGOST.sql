CREATE VIEW dbo.R_ABDDocumentNoStructureAndPIDGOST
AS
SELECT DISTINCT 
                         Doc.ABDDocument_ID, Doc.ABDDocument_Number, Doc.ABDDocument_Name, FF.ABDFinalFolder_ID, FF.ABDFinalFolder_Name, DDC.DisciplineDocumentCode_ID, 
                         DDC.DisciplineDocumentCode_Name, DDC.Description_Rus AS DDC_Description_Rus, DDC.Description_Eng AS DDC_Description_Eng, 
                         DTC.DocumentTypeCode_ID, DTC.DocumentTypeCode_Name, DTC.Description_Rus AS DTC_Description_Rus, DTC.Description_Eng AS DTC_Description_Eng, 
                         S.Contragent_ID AS SubContractor_ID, S.Code AS SubContractor_Name, U.UnitNumberDocumentCode_ID, U.UnitNumberDocumentCode_Name, 
                         U.Description_Rus AS U_Description_Rus, U.Description_Eng AS U_Description_Eng, Doc.Issue_Date, Doc.Sheet_Folder_Number, Doc.Total_Sheets, 
                         Doc.Number_in_Folder
FROM            dbo.ABDDocument AS Doc LEFT OUTER JOIN
                         dbo.ABDDocument_to_ABDFinalFolder AS DRF ON DRF.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.ABDFinalFolder AS FF ON DRF.ABDFinalFolder_ID = FF.ABDFinalFolder_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_DisciplineDocumentCode AS DRD ON DRD.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.DisciplineDocumentCode AS DDC ON DDC.DisciplineDocumentCode_ID = DRD.DisciplineDocumentCode_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_DocumentTypeCode AS DRC ON DRC.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.DocumentTypeCode AS DTC ON DTC.DocumentTypeCode_ID = DRC.DocumentTypeCode_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_GOST AS DRG ON DRG.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_Contragent AS DRS ON DRS.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.Contragent AS S ON S.Contragent_ID = DRS.Contragent_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_UnitNumberDocumentCode AS DRU ON DRU.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.UnitNumberDocumentCode AS U ON U.UnitNumberDocumentCode_ID = DRU.UnitNumberDocumentCode_ID

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
         Begin Table = "Doc"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRF"
            Begin Extent = 
               Top = 6
               Left = 293
               Bottom = 135
               Right = 579
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FF"
            Begin Extent = 
               Top = 6
               Left = 617
               Bottom = 135
               Right = 870
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRD"
            Begin Extent = 
               Top = 6
               Left = 908
               Bottom = 135
               Right = 1248
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDC"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 299
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRC"
            Begin Extent = 
               Top = 138
               Left = 337
               Bottom = 267
               Right = 652
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DTC"
            Begin Extent = 
               Top = 138
               Left = 690
               Bottom = 267
               Right = 926
            End
            DisplayFlags = 280
            TopColumn = 0
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_ABDDocumentNoStructureAndPIDGOST';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'      End
         Begin Table = "DRG"
            Begin Extent = 
               Top = 138
               Left = 964
               Bottom = 267
               Right = 1199
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRS"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 382
               Right = 303
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "S"
            Begin Extent = 
               Top = 6
               Left = 1286
               Bottom = 135
               Right = 1460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRU"
            Begin Extent = 
               Top = 270
               Left = 341
               Bottom = 399
               Right = 696
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "U"
            Begin Extent = 
               Top = 270
               Left = 734
               Bottom = 399
               Right = 1010
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_ABDDocumentNoStructureAndPIDGOST';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'R_ABDDocumentNoStructureAndPIDGOST';

