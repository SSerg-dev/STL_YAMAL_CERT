
CREATE VIEW [dbo].[T_Register_List]
AS
select 
	 Register_ID				= r.Register_ID
	,Register_Code				= r.Register_Code
	,Register_Date				= r.Register_Date
	,Current_Iteration			= r.Current_Iteration
	,Status_ID					= st.Status_ID
	,Status_Code				= st.Status_Code
	,Status_Description_Rus		= st.Description_Rus
	,Contractor_ID				= cnt.Contragent_ID
	,Contractor_Code			= cnt.Contragent_Code
	,SubContractor_ID			= csct.Contragent_Code
	,SubContractor_Code			= csct.Contragent_ID
	,Customer_ID				= cst.Contragent_ID
	,Customer_Code				= cst.Contragent_Code
	,TitleObject_ID				= t.TitleObject_ID
	,TitleObject_Code			= t.TitleObject_Code
	,Marka_ID					= m.Marka_ID
	,Marka_Code					= m.Marka_Code
	,Complex					= z01.Parameter_Value
	,Project					= z02.Parameter_Value
	,UI_PageNumber				= 1
from	dbo.T_Register				r 
left join dbo.T_Register_to_Status		r2st on r.Register_ID = r2st.Register_ID 
left join dbo.Status					st on r2st.Status_ID = st.Status_ID
LEFT JOIN dbo.Register_to_TitleObject AS rtt ON rtt.Register_ID = r.Register_ID 
LEFT JOIN dbo.TitleObject AS t ON rtt.TitleObject_ID = t.TitleObject_ID 
LEFT JOIN dbo.Register_to_Marka AS rtm ON rtm.Register_ID = r.Register_ID 
LEFT JOIN dbo.Marka AS		m ON rtm.Marka_ID = m.Marka_ID
left join dbo.Contragent	cnt on r.Contractor_ID = cnt.Contragent_ID
left join dbo.Contragent	cst on r.Customer_ID = cst.Contragent_ID
left join dbo.Contragent	csct on r.SubContractor_ID = csct.Contragent_ID
outer apply dbo.Get_ParamValue('Complex_Rus') z01
outer apply dbo.Get_ParamValue('Project_Rus') z02

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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'T_Register_List';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'T_Register_List';

