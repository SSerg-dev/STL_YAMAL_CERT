
CREATE view RegisterPipingAction as
SELECT [RegisterPipingAction_ID]
      ,[Register_ID]
      ,[PipingWorkType_ID]
      ,[ISO_ID]
      ,[DTS_Strat]
      ,[DTS_End]
  FROM [dbo].[p_RegisterPipingAction]
  where row_status < 100
