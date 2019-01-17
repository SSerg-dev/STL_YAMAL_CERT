Create view dbo.R_JobCard_to_JobCardRusABDActivityGroup
as 
(Select distinct JobCard_ID, JobCardRusABDActivityGroup_ID from [dbo].[RegisterJobCardAction_m])