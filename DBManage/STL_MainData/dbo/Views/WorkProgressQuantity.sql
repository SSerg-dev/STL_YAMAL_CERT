

--if object_id('dbo.WorkProgressQuantity','V') > 0 drop view dbo.WorkProgressQuantity
--go

CREATE view [dbo].[WorkProgressQuantity] as
select [WorkProgressQuantity_ID]
      ,[Parent_ID]
      ,[LogId]
      ,[WorkPackage_ID]
      ,[Num]
      ,[Phase_ID] = null /* field [Phase_ID] are not exists Ivan Vaskov 18.06.08 */
      ,[TitleObject_ID]
      ,[Unit]
      ,[Marka_ID]
      ,[Activity_Desc]
      ,[UOM]
      ,[Design_Target]
      ,[Fact_Volume]
      ,[Fact_Percent]
      ,[Test_Done]
      ,[Acts_Prepared_CNT]
      ,[Acts_Prepared_Percent]
      ,[Reg]
      ,[Under_Review_CNT]
      ,[Under_Review_Percent]
      ,[Commented_CNT]
      ,[Commented_Percent]
      ,[Approved_CNT]
      ,[Approved_Percent]
      ,[Multiple]
      ,[Issues]
      ,[Row_Status]
      ,[Insert_DTS]
      ,[Update_DTS]
FROM [dbo].[p_WorkProgressQuantity] a 
where a.row_status < 100
