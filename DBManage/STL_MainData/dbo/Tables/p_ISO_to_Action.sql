CREATE TABLE [dbo].[p_ISO_to_Action] (
    [ISO_to_Action_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    [Row_status]         INT              NULL,
    [Package_ID]         UNIQUEIDENTIFIER NULL,
    [IsometricNumber_ID] UNIQUEIDENTIFIER NOT NULL,
    [RegisterNumber_ID]  UNIQUEIDENTIFIER NOT NULL,
    [PipingWorkType_ID]  UNIQUEIDENTIFIER NOT NULL,
    [SubContractor_ID]   UNIQUEIDENTIFIER NULL,
    [Created_By]         NVARCHAR (255)   NULL,
    [Modified_By]        NVARCHAR (255)   NULL
);

