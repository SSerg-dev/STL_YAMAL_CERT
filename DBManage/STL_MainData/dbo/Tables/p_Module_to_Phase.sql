CREATE TABLE [dbo].[p_Module_to_Phase] (
    [Module_to_Phase_ID] UNIQUEIDENTIFIER NOT NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    [Row_Status]         INT              NULL,
    [Module_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Phase_ID]           UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_Module_to_Phase] PRIMARY KEY CLUSTERED ([Module_to_Phase_ID] ASC),
    CONSTRAINT [FK_p_Module_to_Phase_Module_ID_p_Module] FOREIGN KEY ([Module_ID]) REFERENCES [dbo].[p_Module] ([Module_ID]),
    CONSTRAINT [FK_p_Module_to_Phase_Phase_ID_p_Phase] FOREIGN KEY ([Phase_ID]) REFERENCES [dbo].[p_Phase] ([Phase_ID]),
    CONSTRAINT [FK_p_Module_to_Phase_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Module_to_Phase] UNIQUE NONCLUSTERED ([Module_ID] ASC, [Phase_ID] ASC)
);

