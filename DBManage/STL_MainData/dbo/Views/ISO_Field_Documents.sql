








CREATE View [dbo].[ISO_Field_Documents]
AS
(
Select
LL.LINE_NUMBER,
ISO.ISO_Number,
PP.Phase_Name,
SC.Code as SubContractor_Name,
WP.WorkPackage_Name,
TP.TestPack_Name,
TP.Test_Completed_Date,
PWT.Description_Eng as 'PipingWorkType_Eng',
RP.Register_Number,
STS.Description_Eng,
--CAST(RP.MODIFIED_ON as date) as Status_date,
--DATEDIFF(day,RP.MODIFIED_ON, getdate()) as Duration,
STS.Status_Type,
RP.SCTR_Resp,
RP.CTR_Resp
from [dbo].[p_ISO] ISO
left outer join [dbo].[p_ISO_to_Action] ITA on ITA.IsometricNumber_ID = ISO.ISO_ID
left outer join [dbo].[p_Register] RP on ITA.RegisterNumber_ID = RP.Register_ID
left outer join [dbo].[p_Register_to_ABDStatus] RTS on RP.Register_ID = RTS.Register_ID
left outer join [dbo].[p_ABDStatus] STS on RTS.ABDStatus_ID= STS.ABDStatus_ID
left outer join [dbo].[p_ISO_to_Line] ITL on ITL.ISO_ID = ISO.ISO_ID
left outer join [dbo].[p_Line] LL on ITL.LINE_ID = LL.Line_ID
left outer join [dbo].[p_ISO_to_Phase] ITP on ITP.ISO_ID = ISO.ISO_ID
left outer join [dbo].[p_Phase] PP on ITP.Phase_ID = PP.Phase_ID
left join [dbo].[p_WorkPackage] WP on ITA.Package_ID = WP.WorkPackage_ID
left join  [dbo].[p_WorkPackage_to_Contragent] WTS ON WTS.[WorkPackage_ID]= WP.WorkPackage_ID
left join [dbo].[p_Contragent] SC on WTS.[Contragent_ID]=SC.[Contragent_ID]
left join [dbo].[p_PipingWorkType] PWT on ITA.PipingWorkType_ID = PWT.PipingWorkType_ID
left join [dbo].[P_TestPack_to_ISO] TTI on TTI.ISO_ID = ISO.ISO_ID
left join [dbo].[P_TestPack] TP on TTI.TestPack_ID = TP.TestPack_ID
);
