CREATE TABLE [dbo].[p_Register_to_TitleObject] (
    [Register_to_TitleObject_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Register_to_TitleObject_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                 DATETIME2 (7)    NULL,
    [Update_DTS]                 DATETIME2 (7)    NULL,
    [Row_status]                 INT              NULL,
    [Register_ID]                UNIQUEIDENTIFIER NOT NULL,
    [TitleObject_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Created_By]                 NVARCHAR (255)   NULL,
    [Modified_By]                NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_Register_to_TitleObject] PRIMARY KEY CLUSTERED ([Register_to_TitleObject_ID] ASC),
    CONSTRAINT [FK_p_Register_to_TitleObject_Register_ID_p_Register] FOREIGN KEY ([Register_ID]) REFERENCES [dbo].[p_Register] ([Register_ID]),
    CONSTRAINT [FK_p_Register_to_TitleObject_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_Register_to_TitleObject_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_Register_to_TitleObject] UNIQUE NONCLUSTERED ([Register_ID] ASC, [TitleObject_ID] ASC)
);

