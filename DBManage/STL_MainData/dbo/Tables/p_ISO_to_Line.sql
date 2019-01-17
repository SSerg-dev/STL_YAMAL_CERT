CREATE TABLE [dbo].[p_ISO_to_Line] (
    [ISO_to_Line_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_ISO_to_Line_ID] DEFAULT (newsequentialid()) NOT NULL,
    [ISO_ID]         UNIQUEIDENTIFIER NOT NULL,
    [LINE_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]     INT              NULL,
    [Insert_DTS]     DATETIME2 (7)    NULL,
    [Update_DTS]     DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_ISO_to_Line] PRIMARY KEY CLUSTERED ([ISO_to_Line_ID] ASC),
    CONSTRAINT [FK_p_ISO_to_Line_ISO_ID_p_ISO] FOREIGN KEY ([ISO_ID]) REFERENCES [dbo].[p_ISO] ([ISO_ID]),
    CONSTRAINT [FK_p_ISO_to_Line_LINE_ID_p_Line] FOREIGN KEY ([LINE_ID]) REFERENCES [dbo].[p_Line] ([Line_ID]),
    CONSTRAINT [FK_p_ISO_to_Line_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ISO_to_Line] UNIQUE NONCLUSTERED ([ISO_ID] ASC, [LINE_ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [p_ISO_to_Line_idx_ISO_LINE]
    ON [dbo].[p_ISO_to_Line]([ISO_ID] ASC, [LINE_ID] ASC);

