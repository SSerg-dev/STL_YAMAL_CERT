CREATE TABLE [abd].[p_GeneralDocument] (
    [GeneralDocument_ID]             UNIQUEIDENTIFIER CONSTRAINT [DF_p_GeneralDocument] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                     DATETIME2 (7)    NOT NULL,
    [Update_DTS]                     DATETIME2 (7)    NOT NULL,
    [Row_Status]                     INT              NOT NULL,
    [GeneralDocument_Name]           NVARCHAR (300)   NOT NULL,
    [GeneralDocument_Title]          NVARCHAR (300)   NOT NULL,
    [EntityType_ID]                  UNIQUEIDENTIFIER NOT NULL,
    [GeneralDocument_CreationDate]   DATETIME2 (7)    NOT NULL,
    [GeneralDocument_ModofiedDate]   DATETIME2 (7)    NOT NULL,
    [GeneralDocument_CreatedBy]      UNIQUEIDENTIFIER NOT NULL,
    [GeneralDocument_ModifiedBy]     UNIQUEIDENTIFIER NOT NULL,
    [GeneralDocument_RevisionNumber] NVARCHAR (100)   NOT NULL,
    [GeneralDocument_RevisionDate]   DATETIME2 (7)    NOT NULL,
    [GeneralDocument_Parent_ID]      UNIQUEIDENTIFIER NOT NULL,
    [Contragent_ID]                  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_GeneralDocument] PRIMARY KEY CLUSTERED ([GeneralDocument_ID] ASC),
    CONSTRAINT [FK_p_GeneralDocument_p_Contragent] FOREIGN KEY ([Contragent_ID]) REFERENCES [dbo].[p_Contragent] ([Contragent_ID]),
    CONSTRAINT [FK_p_GeneralDocument_p_EntityType_abd] FOREIGN KEY ([EntityType_ID]) REFERENCES [abd].[p_EntityType] ([EntityType_ID]),
    CONSTRAINT [FK_p_GeneralDocument_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UN_GeneralDocument] UNIQUE NONCLUSTERED ([GeneralDocument_Name] ASC)
);

