
CREATE view [dbo].[PipelineCompletionZvezda_Errors]

  As

  (select 
  -- PC.*
  
       PC.[TestPack]
      ,PC.[PROCESS_PHASE]
      ,PC.[Weld_SCTR]
      ,PC.[AKZ_SCTR]
      ,PC.[Ins_SCTR]
      ,PC.[Weld_FF]
      ,PC.[AKZ_FF]
      ,PC.[Ins_FF]
      ,PC.[Source_File]
      ,PC.[Load_Date]
      ,PC.[Error_Code]
      ,PC.[Error_Column]
      ,PC.[Reason]
  
  , LTRIM(RTRIM(VE.Description_Eng)) + ' / ' + LTRIM(RTRIM(VE.Description_Rus)) as Reason_TXT
  ,VE.Description_Eng
  ,VE.Description_Rus 
  
  FROM [dbo].[s_PipelineCompletionZvezda_Errors] PC
  left join [dbo].[p_ValidationErrors] VE ON VE.Number = PC.Reason
  )
