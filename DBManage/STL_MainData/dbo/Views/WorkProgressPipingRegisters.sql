

--if object_id('dbo.WorkProgressQuantity','V') > 0 drop view dbo.WorkProgressQuantity
--go

CREATE view [dbo].[WorkProgressPipingRegisters] as
SELECT [WorkProgressPipingRegisters_ID]
      ,[Parent_ID]
      ,[LogId]
      ,[WorkPackage_ID]
      ,[Reg]
      ,[Phase_ID] = null /* field [Phase_ID] are not exists Ivan Vaskov 18.06.08 */
      ,[TitleObject_ID]
      ,[Unit]
      ,[Marka_ID]
      ,[Work_Desc]
      ,[CNT_Date]
      ,[Repr_SCNT]
      ,[Repr_CNT]
      ,[Status_Date]
      ,[ABDStatus_ID]
      ,[Row_Status]
      ,[Insert_DTS]
      ,[Update_DTS]
FROM [dbo].[p_WorkProgressPipingRegisters] a 
where a.row_status < 100
