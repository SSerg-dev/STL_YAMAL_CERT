


/* where FF.ABDFinalFolder_Name = '3300-33B0300-АВК-4-020'*/
CREATE VIEW [dbo].[ABDDocumentFull]
AS

SELECT	
 	
						 Doc.ABDDocument_ID, Doc.ABDDocument_Number, Doc.ABDDocument_Name, FF.ABDFinalFolder_ID, FF.ABDFinalFolder_Name, 
						 DDC.DisciplineDocumentCode_ID, 
                         DDC.DisciplineDocumentCode_Name, DDC.Description_Rus AS DDC_Description_Rus, DDC.Description_Eng AS DDC_Description_Eng, 
                         DTC.DocumentTypeCode_ID, DTC.DocumentTypeCode_Name, DTC.Description_Rus AS DTC_Description_Rus, DTC.Description_Eng AS DTC_Description_Eng, 
                         G.GOST_ID, G.GOST_Code, G.Description_Rus AS G_Description_Rus, M.Module_ID, M.Module_Name, M.Description_Rus AS M_Description_Rus, 
                         M.Description_Eng AS M_Description_Eng, P.PID_ID, P.PID_Code, P.Description_Eng AS PID_Description_Eng, S.Contragent_ID AS SubContractor_ID, 
                         S.Code AS SubContractor_Name, U.UnitNumberDocumentCode_ID, U.UnitNumberDocumentCode_Name, U.Description_Rus AS U_Description_Rus, 
                         U.Description_Eng AS U_Description_Eng, Doc.Issue_Date, Doc.Sheet_Folder_Number, Doc.Total_Sheets, Doc.Number_in_Folder, 
                         ISNULL(ISNULL(ISNULL(M.Module_Name, L.Line_Number), CS.CivilSector_Number), 'N/A') AS Structure, 
						 --ISNULL(ISNULL(ISNULL(M.Module_ID, L.Line_ID),CS.CivilSector_ID), 'N/A') AS Structure_ID, -- == Possible problem
						 ISNULL(ISNULL(ISNULL(M.Module_ID, L.Line_ID),CS.CivilSector_ID), NULL) AS Structure_ID, -- == Possible problem
						 FF.Final_Compilation_Target_Date, FF.Final_Compilation_Start_Date, FF.CTR_RESP
FROM            dbo.ABDDocument AS Doc LEFT OUTER JOIN
                         dbo.ABDDocument_to_ABDFinalFolder AS DRF ON DRF.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.ABDFinalFolder AS FF ON DRF.ABDFinalFolder_ID = FF.ABDFinalFolder_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_DisciplineDocumentCode AS DRD ON DRD.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.DisciplineDocumentCode AS DDC ON DDC.DisciplineDocumentCode_ID = DRD.DisciplineDocumentCode_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_DocumentTypeCode AS DRC ON DRC.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.DocumentTypeCode AS DTC ON DTC.DocumentTypeCode_ID = DRC.DocumentTypeCode_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_GOST AS DRG ON DRG.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.GOST AS G ON G.GOST_ID = DRG.GOST_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_Module AS DRM ON DRM.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.Module AS M ON M.Module_ID = DRM.Module_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_Line AS DRL ON DRL.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.Line AS L ON L.Line_ID = DRL.Line_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_CivilSector AS DRCS ON DRCS.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.CivilSector AS CS ON CS.CivilSector_ID = DRCS.CivilSector_ID LEFT OUTER JOIN
                         dbo.ABDDocument_to_PID AS DRP ON DRP.ABDDocument_ID = Doc.ABDDocument_ID LEFT OUTER JOIN
                         dbo.PID AS P ON P.PID_ID = DRP.PID_ID LEFT OUTER JOIN
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
         Configuration = "(H (1[41] 4[20] 2[35] 3) )"
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
         Begin Table = "Doc"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "DRF"
            Begin Extent = 
               Top = 123
               Left = 545
               Bottom = 252
               Right = 831
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FF"
            Begin Extent = 
               Top = 345
               Left = 743
               Bottom = 474
               Right = 996
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "DRD"
            Begin Extent = 
               Top = 301
               Left = 426
               Bottom = 430
               Right = 766
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDC"
            Begin Extent = 
               Top = 534
               Left = 38
               Bottom = 663
               Right = 299
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRC"
            Begin Extent = 
               Top = 666
               Left = 38
               Bottom = 795
               Right = 353
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DTC"
            Begin Extent = 
               Top = 798
               Left = 38
               Bottom = 927
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ABDDocumentFull';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'0
         End
         Begin Table = "DRG"
            Begin Extent = 
               Top = 930
               Left = 38
               Bottom = 1059
               Right = 273
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "G"
            Begin Extent = 
               Top = 6
               Left = 293
               Bottom = 118
               Right = 466
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRM"
            Begin Extent = 
               Top = 1062
               Left = 38
               Bottom = 1191
               Right = 284
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "M"
            Begin Extent = 
               Top = 1194
               Left = 38
               Bottom = 1323
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRL"
            Begin Extent = 
               Top = 6
               Left = 504
               Bottom = 118
               Right = 731
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "L"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 339
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRCS"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 382
               Right = 299
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CS"
            Begin Extent = 
               Top = 384
               Left = 38
               Bottom = 513
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRP"
            Begin Extent = 
               Top = 1326
               Left = 38
               Bottom = 1455
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "P"
            Begin Extent = 
               Top = 1194
               Left = 268
               Bottom = 1306
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRS"
            Begin Extent = 
               Top = 1458
               Left = 38
               Bottom = 1570
               Right = 303
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "S"
            Begin Extent = 
               Top = 1308
               Left = 268
               Bottom = 1437
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DRU"
            Begin Extent = 
               Top = 1572
               Left = 38
               Bottom = 1701
               Right = 393
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "U"
            Begin Extent = 
               Top = 1704
               Left = 38
               Bottom = 1833
               Right = 314
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
      End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ABDDocumentFull';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 3, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ABDDocumentFull';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane3', @value = N'
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ABDDocumentFull';

