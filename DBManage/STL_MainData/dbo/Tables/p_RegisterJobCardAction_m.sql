CREATE TABLE [dbo].[p_RegisterJobCardAction_m] (
    [RegisterJobCardAction_m_ID]    UNIQUEIDENTIFIER NOT NULL,
    [Register_ID]                   UNIQUEIDENTIFIER NULL,
    [JobCardRusABDActivityGroup_ID] UNIQUEIDENTIFIER NULL,
    [JobCard_ID]                    UNIQUEIDENTIFIER NULL,
    [DTS_Strat]                     DATETIME2 (7)    NULL,
    [DTS_End]                       DATETIME2 (7)    NULL,
    [Row_Status]                    INT              NULL,
    [Insert_DTS]                    DATETIME2 (7)    NULL,
    [Update_DTS]                    DATETIME2 (7)    NULL,
    [Created_By]                    NVARCHAR (255)   NULL,
    [Modified_By]                   NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_RegisterJobCardAction_m] PRIMARY KEY CLUSTERED ([RegisterJobCardAction_m_ID] ASC),
    CONSTRAINT [FK_p_RegisterJobCardAction_m_JobCard_ID_p_JobCard] FOREIGN KEY ([JobCard_ID]) REFERENCES [dbo].[p_JobCard] ([JobCard_ID]),
    CONSTRAINT [FK_p_RegisterJobCardAction_m_JobCardRusABDActivityGroup_ID_p_JobCardRusABDActivityGroup] FOREIGN KEY ([JobCardRusABDActivityGroup_ID]) REFERENCES [dbo].[p_JobCardRusABDActivityGroup] ([JobCardRusABDActivityGroup_ID]),
    CONSTRAINT [FK_p_RegisterJobCardAction_m_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_RegisterJobCardAction_m_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_RegisterJobCardAction_m] UNIQUE NONCLUSTERED ([Register_ID] ASC, [JobCardRusABDActivityGroup_ID] ASC, [JobCard_ID] ASC)
);


GO


CREATE trigger [dbo].[InsUpd_p_RegisterJobCardAction_m] on [dbo].[p_RegisterJobCardAction_m] after insert, update 
as begin
	if exists
	(
		select 1 from inserted i
			join p_register p on p.Register_ID = i.Register_ID 
			group by i.JobCardRusABDActivityGroup_ID, i.JobCard_ID, p.WorkPackage_ID
			having count(1) > 1
	) 
	begin
		raiserror ('Duplicate combination of JobCardRusABDActivityGroup and JobCard connected to the same WorkPackage are not allowed. 1', 16, 1)
		rollback  
		return
	end

	if exists
	(
		select 1 from p_RegisterJobCardAction_m a 
			join p_Register b on a.Register_ID = b.Register_ID
			group by a.JobCardRusABDActivityGroup_ID, a.JobCard_ID, b.WorkPackage_ID
			having count(1) > 1
	)
	begin
		raiserror ('Duplicate combination of JobCardRusABDActivityGroup and JobCard connected to the same WorkPackage are not allowed. 2', 16, 1)
		rollback  
		return
	end
end 
