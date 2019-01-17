CREATE TABLE [dbo].[p_SubContractor2] (
    [SubContractor_ID]       UNIQUEIDENTIFIER NOT NULL,
    [SubContractor_Name]     NVARCHAR (50)    NOT NULL,
    [SubContractor_FullName] NVARCHAR (250)   NULL,
    [Row_status]             INT              NULL,
    [Insert_DTS]             DATETIME2 (7)    NULL,
    [Update_DTS]             DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_SubContractor2] PRIMARY KEY CLUSTERED ([SubContractor_ID] ASC),
    CONSTRAINT [FK_p_SubContractor2_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_SubContractor2] UNIQUE NONCLUSTERED ([SubContractor_Name] ASC)
);


GO
CREATE NONCLUSTERED INDEX [p_Subcontractor_idx_multiple]
    ON [dbo].[p_SubContractor2]([SubContractor_ID] ASC, [SubContractor_Name] ASC);

