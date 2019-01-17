CREATE TABLE [abd].[p_GeneralDocumentAttribute] (
    [GeneralDocumentAttribute_ID]     UNIQUEIDENTIFIER CONSTRAINT [DF_p_GeneralDocumentAttribute] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                      DATETIME2 (7)    NOT NULL,
    [Update_DTS]                      DATETIME2 (7)    NOT NULL,
    [Row_Status]                      INT              NOT NULL,
    [GeneralDocumentAttribute_Value]  NVARCHAR (300)   NOT NULL,
    [EntityType_ID]                   UNIQUEIDENTIFIER NOT NULL,
    [GeneralDocument_ID]              UNIQUEIDENTIFIER NOT NULL,
    [GeneralDocumentAttribute_Format] NVARCHAR (300)   NOT NULL,
    [GeneralDocumentAttribute_Order]  INT              NOT NULL,
    CONSTRAINT [PK_p_GeneralDocumentAttribute] PRIMARY KEY CLUSTERED ([GeneralDocumentAttribute_ID] ASC),
    CONSTRAINT [FK_p_GeneralDocumentAttribute_p_EntityType_abd] FOREIGN KEY ([EntityType_ID]) REFERENCES [abd].[p_EntityType] ([EntityType_ID]),
    CONSTRAINT [FK_p_GeneralDocumentAttribute_p_GeneralDocument_abd] FOREIGN KEY ([GeneralDocument_ID]) REFERENCES [abd].[p_GeneralDocument] ([GeneralDocument_ID]),
    CONSTRAINT [FK_p_GeneralDocumentAttribute_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UN_GeneralDocumentAttribute] UNIQUE NONCLUSTERED ([GeneralDocumentAttribute_Value] ASC)
);

