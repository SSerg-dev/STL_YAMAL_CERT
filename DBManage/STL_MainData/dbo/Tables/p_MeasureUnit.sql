CREATE TABLE [dbo].[p_MeasureUnit] (
    [MeasureUnit_ID]   UNIQUEIDENTIFIER NOT NULL,
    [MeasureUnit_Code] NVARCHAR (50)    NOT NULL,
    [Code_Rus]         NVARCHAR (50)    NULL,
    [Code_Eng]         NVARCHAR (50)    NULL,
    [Symbol_Rus]       NVARCHAR (50)    NULL,
    [Symbol_Eng]       NVARCHAR (50)    NULL,
    [Description_Rus]  NVARCHAR (255)   NULL,
    [Description_Eng]  NVARCHAR (255)   NULL,
    [Type]             NVARCHAR (255)   NULL,
    [Status]           NVARCHAR (255)   NULL,
    [Row_Status]       INT              NULL,
    [Insert_DTS]       DATETIME2 (7)    NULL,
    [Update_DTS]       DATETIME2 (7)    NULL,
    CONSTRAINT [PK_p_MeasureUnit] PRIMARY KEY CLUSTERED ([MeasureUnit_ID] ASC),
    CONSTRAINT [FK_p_MeasureUnit_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_MeasureUnit] UNIQUE NONCLUSTERED ([MeasureUnit_Code] ASC)
);

