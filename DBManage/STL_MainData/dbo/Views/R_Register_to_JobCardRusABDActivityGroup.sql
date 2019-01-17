Create view dbo.R_Register_to_JobCardRusABDActivityGroup
as 
(Select distinct Register_ID, JobCardRusABDActivityGroup_ID from [dbo].[RegisterJobCardAction_m])