CREATE TABLE [dbo].[p_Register_to_ProcessPhase] (
    [Register_to_ProcessPhase_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_ProcessPhase_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                  DATETIME2 (7)    NULL,
    [Update_DTS]                  DATETIME2 (7)    NULL,
    [Row_status]                  INT              NULL,
    [Register_ID]                 UNIQUEIDENTIFIER NOT NULL,
    [ProcessPhase_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Created_By]                  NVARCHAR (255)   NULL,
    [Modified_By]                 NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_Register_to_ProcessPhase] PRIMARY KEY CLUSTERED ([Register_to_ProcessPhase_ID] ASC),
    CONSTRAINT [FK_p_Register_to_ProcessPhase_ProcessPhase_ID_p_ProcessPhase] FOREIGN KEY ([ProcessPhase_ID]) REFERENCES [dbo].[p_ProcessPhase] ([ProcessPhase_ID]),
    CONSTRAINT [FK_p_Register_to_ProcessPhase_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_ProcessPhase_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Register_to_ProcessPhase] UNIQUE NONCLUSTERED ([ProcessPhase_ID] ASC, [Register_ID] ASC)
);

