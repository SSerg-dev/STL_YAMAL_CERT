Create view dbo.[R_Register_to_JobCard]
as 
(Select distinct JobCard_ID, Register_ID from [dbo].[RegisterJobCardAction_m])