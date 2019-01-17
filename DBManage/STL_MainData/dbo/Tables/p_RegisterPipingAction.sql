CREATE TABLE [dbo].[p_RegisterPipingAction] (
    [RegisterPipingAction_ID] UNIQUEIDENTIFIER NOT NULL,
    [Register_ID]             UNIQUEIDENTIFIER NULL,
    [PipingWorkType_ID]       UNIQUEIDENTIFIER NULL,
    [ISO_ID]                  UNIQUEIDENTIFIER NULL,
    [DTS_Strat]               DATETIME2 (7)    NULL,
    [DTS_End]                 DATETIME2 (7)    NULL,
    [Row_Status]              INT              NULL,
    [Insert_DTS]              DATETIME2 (7)    NULL,
    [Update_DTS]              DATETIME2 (7)    NULL,
    [Created_By]              NVARCHAR (255)   NULL,
    [Modified_By]             NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_RegisterPipingAction] PRIMARY KEY CLUSTERED ([RegisterPipingAction_ID] ASC),
    CONSTRAINT [FK_p_RegisterPipingAction_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_RegisterPipingAction_PipingWorkType_ID_p_PipingWorkType] FOREIGN KEY ([PipingWorkType_ID]) REFERENCES [dbo].[p_PipingWorkType] ([PipingWorkType_ID]),
    CONSTRAINT [FK_p_RegisterPipingAction_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_RegisterPipingAction_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status])
);


GO


CREATE trigger [dbo].[InsUpd_p_RegisterPipingAction] on [dbo].[p_RegisterPipingAction] after insert, update 
as begin
	if exists
	(
		select 1 from inserted i
			join p_register p on p.Register_ID = i.Register_ID 
			group by i.PipingWorkType_ID, i.ISO_ID, p.WorkPackage_ID
			having count(1) > 1
	) 
	begin
		raiserror ('Duplicate combination of ISO and PipingWorkType connected to the same WorkPackage are not allowed. 1', 16, 1)
		rollback  
		return
	end

	if exists
	(
		select 1 from p_RegisterPipingAction a 
			join p_Register b on a.Register_ID = b.Register_ID
			group by a.PipingWorkType_ID, a.ISO_ID, b.WorkPackage_ID
			having count(1) > 1
	)
	begin
		raiserror ('Duplicate combination of ISO and PipingWorkType connected to the same WorkPackage are not allowed. 2', 16, 1)
		rollback  
		return
	end
end 
