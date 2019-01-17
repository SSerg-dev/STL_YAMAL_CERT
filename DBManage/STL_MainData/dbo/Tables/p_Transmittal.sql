CREATE TABLE [dbo].[p_Transmittal] (
    [Transmittal_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_Transmittal_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NULL,
    [Update_DTS]       DATETIME2 (7)    NULL,
    [Row_Status]       INT              NULL,
    [Transmittal_Code] NVARCHAR (300)   NOT NULL,
    CONSTRAINT [PK_p_Transmittal] PRIMARY KEY CLUSTERED ([Transmittal_ID] ASC),
    CONSTRAINT [FK_p_Transmittal_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_Transmittal] UNIQUE NONCLUSTERED ([Transmittal_Code] ASC)
);

