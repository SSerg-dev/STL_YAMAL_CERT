CREATE TABLE [dbo].[p_Register_to_Marka] (
    [Register_to_Marka_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_Marka_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]           DATETIME2 (7)    NULL,
    [Update_DTS]           DATETIME2 (7)    NULL,
    [Row_status]           INT              NULL,
    [Register_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Marka_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Created_By]           NVARCHAR (255)   NULL,
    [Modified_By]          NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_Register_to_Marka] PRIMARY KEY CLUSTERED ([Register_to_Marka_ID] ASC),
    CONSTRAINT [FK_p_Register_to_Marka_Marka_ID_p_Marka] FOREIGN KEY ([Marka_ID]) REFERENCES [dbo].[p_Marka] ([Marka_ID]),
    CONSTRAINT [FK_p_Register_to_Marka_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_Marka_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Register_to_Marka] UNIQUE NONCLUSTERED ([Marka_ID] ASC, [Register_ID] ASC)
);

