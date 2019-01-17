CREATE TABLE [dbo].[p_Module] (
    [Module_ID]          UNIQUEIDENTIFIER NOT NULL,
    [Module_Name]        NVARCHAR (255)   NOT NULL,
    [Sub_Item]           NVARCHAR (255)   NULL,
    [Description_Rus]    NVARCHAR (255)   NULL,
    [Description_Eng]    NVARCHAR (255)   NULL,
    [Engineering_Center] NVARCHAR (255)   NULL,
    [Source]             NVARCHAR (100)   NULL,
    [Row_Status]         INT              NULL,
    [Insert_DTS]         DATETIME2 (7)    NULL,
    [Update_DTS]         DATETIME2 (7)    NULL,
    [Module_Type]        SMALLINT         NULL,
    [TitleObject_ID]     UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_p_Module] PRIMARY KEY CLUSTERED ([Module_ID] ASC),
    CONSTRAINT [FK_p_Module_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_Module_TitleObject_ID_p_TitleObject] FOREIGN KEY ([TitleObject_ID]) REFERENCES [dbo].[p_TitleObject] ([TitleObject_ID]),
    CONSTRAINT [UQ_p_Module] UNIQUE NONCLUSTERED ([Module_Name] ASC)
);

