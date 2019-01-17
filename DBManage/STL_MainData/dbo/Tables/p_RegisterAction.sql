CREATE TABLE [dbo].[p_RegisterAction] (
    [RegisterAction_ID] UNIQUEIDENTIFIER NOT NULL,
    [Register_ID]       UNIQUEIDENTIFIER NULL,
    [PipingWorkType_ID] UNIQUEIDENTIFIER NULL,
    [ISO_ID]            UNIQUEIDENTIFIER NULL,
    [DTS_Strat]         DATETIME2 (7)    NULL,
    [DTS_End]           DATETIME2 (7)    NULL,
    [Row_Status]        INT              NULL,
    [Insert_DTS]        DATETIME2 (7)    NULL,
    [Update_DTS]        DATETIME2 (7)    NULL,
    [Created_By]        NVARCHAR (255)   NULL,
    [Modified_By]       NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_RegisterAction] PRIMARY KEY CLUSTERED ([RegisterAction_ID] ASC),
    CONSTRAINT [FK_p_RegisterAction_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_RegisterAction_PipingWorkType_ID_p_PipingWorkType] FOREIGN KEY ([PipingWorkType_ID]) REFERENCES [dbo].[p_PipingWorkType] ([PipingWorkType_ID]),
    CONSTRAINT [FK_p_RegisterAction_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_RegisterAction_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status])
);


GO


-- SQL Server Syntax  
-- Trigger on an INSERT, UPDATE, or DELETE statement to a table or view (DML Trigger)  

CREATE TRIGGER [dbo].[InsUpd_p_RegisterAction] 
ON [dbo].[p_RegisterAction]  
AFTER INSERT, UPDATE 
AS 
if (SELECT count(*)
		  FROM dbo.p_RegisterAction ra
          join dbo.p_Register r on r.Register_ID = ra.Register_ID
		  join inserted as i on r.WorkPackage_ID = (select WorkPackage_ID from p_Register r1 join inserted i1 on r1.Register_ID = i1.Register_ID)
							and ra.PipingWorkType_ID = i.PipingWorkType_ID
							and ra.ISO_ID = i.ISO_ID
		  WHERE ra.Row_Status= 0 and r.Row_Status= 0 ) > 1
BEGIN  
RAISERROR ('This combination of ISO and WorkType connected to the same Work Package already exists  in database', 16, 1);  
ROLLBACK TRANSACTION;  
RETURN   
END;  
