  Create View dbo.T_CheckList
  as
  (
	SELECT
		CL.[CheckList_ID]
		,S.Status_ID
		,S.Status_Code
		,S.Description_Rus
-- CheckList_ID, Status_ID, Status_Code, Description_Rus 
	From [dbo].[p_CheckList] CL
	INNER JOIN CheckList_to_Status CHS ON CHS.CheckList_ID = CL.CheckList_ID
	INNER JOIN [Status] S ON  S.Status_ID = CHS.Status_ID
	where CL.[RowStatus] between 300 and 399
  
  )