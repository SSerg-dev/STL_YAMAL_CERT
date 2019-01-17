CREATE TABLE [abd].[p_GeneralDocumentRelation] (
    [GeneralDocumentRelation_ID]      UNIQUEIDENTIFIER CONSTRAINT [DF_p_GeneralDocumentRelation] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                      DATETIME2 (7)    NOT NULL,
    [Update_DTS]                      DATETIME2 (7)    NOT NULL,
    [Row_Status]                      INT              NOT NULL,
    [GeneralDocumentAttributeFrom_ID] UNIQUEIDENTIFIER NOT NULL,
    [GeneralDocumentAttributeTo_ID]   UNIQUEIDENTIFIER NOT NULL,
    [EntityType_ID]                   UNIQUEIDENTIFIER NOT NULL,
    [GeneralDocumentRelation_Order]   INT              NOT NULL,
    CONSTRAINT [PK_p_GeneralDocumentRelation] PRIMARY KEY CLUSTERED ([GeneralDocumentRelation_ID] ASC),
    CONSTRAINT [FK_p_GeneralDocumentRelation_p_EntityType_abd] FOREIGN KEY ([EntityType_ID]) REFERENCES [abd].[p_EntityType] ([EntityType_ID]),
    CONSTRAINT [FK_p_GeneralDocumentRelation_p_GeneralDocumentAttributeFrom_abd] FOREIGN KEY ([GeneralDocumentAttributeFrom_ID]) REFERENCES [abd].[p_GeneralDocumentAttribute] ([GeneralDocumentAttribute_ID]),
    CONSTRAINT [FK_p_GeneralDocumentRelation_p_GeneralDocumentAttributeTo_abd] FOREIGN KEY ([GeneralDocumentAttributeTo_ID]) REFERENCES [abd].[p_GeneralDocumentAttribute] ([GeneralDocumentAttribute_ID]),
    CONSTRAINT [FK_p_GeneralDocumentRelation_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status])
);

